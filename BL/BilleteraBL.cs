﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using System.Globalization;
using BL.Exceptions;
using BE;
using BE.ValueObject;
using DAL;
using IO;
using IO.Responses;
using SL;

namespace BL
{
    public class BilleteraBL2
    {
        public BilleteraBL2()
        {
        }

        //CREACION --------------------------------------------------------------

        //Crea la billetera para criptomonedas usa block.io
        private BilleteraBE2 crearCrypto(CuentaBE cuenta, ClienteBE cliente, MonedaBE moneda)
        {           
            //Creo la wallet en block.io
            NewWallet created = new BlockIo().createWallet(moneda.cod);
            Bitacora.GetInstance().log("Se ha creado :"+moneda.cod+"/"+created.data.address,true);

            //Creo la billetera.
            BilleteraBE2 wallet = new BilleteraBE2();
            wallet.cliente = cliente;
            wallet.direccion = created.data.address;            
            wallet.fecCreacion = DateTime.Now;
            wallet.moneda = moneda;
            wallet.cuenta = cuenta;
            wallet.saldo = new Money("0");
            wallet.saldo_pending = new Money("0");

            return wallet;
        }

        //Cuenta en ARS, no usa proveedor.
        private BilleteraBE2 crearARS(CuentaBE cuenta, ClienteBE cliente, MonedaBE moneda)
        {
            //Creo la billetera.
            BilleteraBE2 wallet = new BilleteraBE2();
            wallet.cliente = cliente;
            wallet.direccion = cuenta.idcuenta.ToString()+"-"+ DateTime.Now.ToString("yyyyMMddHHmmssfff")+"-"+cliente.idcliente.ToString();
            wallet.fecCreacion = DateTime.Now;
            wallet.moneda = moneda;
            wallet.cuenta = cuenta;
            wallet.saldo = new Money("0");
            wallet.saldo_pending = new Money("0");

            return wallet;
        }

        //Crea una billetera dependiendo de la moneda.
        public int crear(CuentaBE cuenta, ClienteBE cliente, string moneda)
        {
            //Busco la moneda.
            MonedaBE money = new MonedaDAL().findByCode(moneda);

            if (money == null)
                throw new BusinessException("Money not found");

            //Creo la nueva billetera.
            BilleteraBE2 newWallet = (money.cod == "ARS")
                ? this.crearARS(cuenta, cliente, money)
                : this.crearCrypto(cuenta,cliente, money);

            //Proceso guardado en la bd.
            return new BilleteraDAL2().insert(newWallet);
        }

        //MODIFICACION-------------------------------------------------------------
        public int update(BilleteraBE2 wallet)
        {
            return new BilleteraDAL2().update(wallet);
        }

        //Esta operacion solo funciona si la moneda es ARS.
        public int depositar(BilleteraBE2 target, double ammount)
        {
            if (target.moneda.cod != "ARS")
                throw new Exception("Operation allowed only to wallets in ARS");

            //Traigo la wallet.
            BilleteraBE2 wallet = this.getById(target.idwallet, false);

            //Incremento el saldo.
            wallet.saldo = new Money((double)wallet.saldo.getValue() + ammount);

            //Guardo.
            return this.update(wallet);
        }

        //Esta operacion solo funciona si la moneda es ARS.
        public int extraer(BilleteraBE2 target, double ammount)
        {
            if (target.moneda.cod != "ARS")
                throw new Exception("Operation allowed only to wallets in ARS");

            //Traigo la wallet.
            BilleteraBE2 wallet = this.getById(target.idwallet, false);

            //Incremento el saldo.
            wallet.saldo = new Money((double)wallet.saldo.getValue() - ammount);

            //Guardo.
            return this.update(wallet);
        }
        
        //CONSULTA-----------------------------------------------------------------

        //Obtengo el balance de la cuenta y moneda..
        private Balance getBalance(string address, MonedaBE moneda)
        {
            //Consulto el balance en block.io.
            Balance balance = new BlockIo().getBalance(moneda.cod,address);
            Bitacora.GetInstance().log("Se ha consultado el balance:" + moneda.cod + "/" + address+", "+balance.data.available_balance, true);

            return balance;
        }

        //Obtengo info de la billetera, pudiendo tener el saldo actualizado o no.
        public BilleteraBE2 getById(long id, bool updatedBalance=false)
        {
            //Recupero de la bd los datos, si no existe retorno null.
            BilleteraBE2 wallet = new BilleteraDAL2().findById(id);

            if (wallet == null)
                return null;

            //Si piden saldo actualizado lo traigo del blockio
            if (updatedBalance && wallet.moneda.cod != "ARS")
            {
                //Traigo el balance de la wallet.
                Balance walletBalance = this.getBalance(wallet.direccion, wallet.moneda);

                //Bindeo valores.
                wallet.saldo = new Money(walletBalance.data.available_balance);
                wallet.saldo_pending = new Money(walletBalance.data.pending_received_balance);
            }                

            //Busco si esta wallet tiene cobro de comisiones pendientes y se la descuento.
            //double pendingTaxes = (new ComisionBL().pendingAmmount(wallet));
            //Debug.WriteLine("Pending taxes for wallet "+id+" - "+pendingTaxes.ToString());

            return wallet;
        }

        //Indica si la cuenta tiene X capacidad para cubrir un fondo.
        public Boolean canCover(BilleteraBE2 wallet, float saldoCubrir)
        {
            return (double)wallet.saldo.getValue() > saldoCubrir;
        }

        //-------------------------------------------------------------------------

        public void transferir(BilleteraBE2 origen, BilleteraBE2 destino, float ammount) { }
        public float traerSaldo(BilleteraBE2 wallet) { return 0; }
        public void traerOperaciones(BilleteraBE2 wallet) { }
        public float cotizarTransfer(BilleteraBE2 sourcce,float ammount) { return 0; }
    }
}
