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
            Bitacora.GetInstance().log("Se ha creado :" + moneda.cod + "/" + created.data.address, true);

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
            wallet.direccion = cuenta.idcuenta.ToString() + "-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "-" + cliente.idcliente.ToString();
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
                : this.crearCrypto(cuenta, cliente, money);

            //Proceso guardado en la bd.
            return new BilleteraDAL2().insert(newWallet);
        }

        //MODIFICACION-------------------------------------------------------------
        public int update(BilleteraBE2 wallet)
        {
            return new BilleteraDAL2().update(wallet);
        }

        //Agrega dinero a una billetera.
        private int acreditarARS(BilleteraBE2 wallet, decimal ammount)
        {
            //Valido si es la misma moneda.
            if (wallet.moneda.cod != "ARS")
                throw new Exception("Operation allow onyl to ars acconut");

            //Valido si hay suficiente saldo.
            if (wallet.saldo.getValue() < ammount)
                throw new Exception("Operation allow onyl to ars account");

            //Actualizo el saldo.
            decimal value = wallet.saldo.getValue()+ammount;
            wallet.saldo = new Money(value);

            return this.update(wallet);
        }

        //Descuenta de una billetera un valor, solo para ars.
        private int descontarARS(BilleteraBE2 wallet, decimal ammount)
        {
            //Valido si es la misma moneda.
            if (wallet.moneda.cod != "ARS")
                throw new Exception("Operation allow onyl to ars acconut");

            //Valido si hay suficiente saldo.
            if (wallet.saldo.getValue() < ammount)
                throw new Exception("Operation allow onyl to ars account");

            //Actualizo el saldo.
            decimal value = wallet.saldo.getValue() - ammount;
            wallet.saldo = new Money(value);

            return this.update(wallet);
        }

        //Registro la transferencia.
        private int recordTransference(long opId, ClienteBE cliente, BilleteraBE2 origen, BilleteraBE2 destino, MonedaBE moneda, decimal ammount)
        {
            //Armo la nueva transferencia.
            TransferenciasBE transfer = new TransferenciasBE();

            transfer.fecProc = DateTime.Now;
            transfer.moneda = origen.moneda;
            transfer.cliente = cliente;
            transfer.origen = origen;
            transfer.destino = destino;
            transfer.valor = ammount;
            transfer.idorden = opId;

            //Guardo.
            return new TransferenciaDAL().save(transfer);
        }

        //Esta operacion solo funciona si la moneda es ARS.
        public int transferir(long tranId, BilleteraBE2 origen, BilleteraBE2 destino, Money ammount)
        {
            //Valido tipo de monedas.
            if (origen.moneda.cod != destino.moneda.cod)
                throw new Exception("Unable to make transference, the money type need to be the same");

            //Obtengo la moneda.
            MonedaBE moneda = origen.moneda;

            //Hago el movimiento en base al tipo de cuenta.
            if (moneda.cod == "ARS")
            {
                this.descontarARS(origen, ammount.getValue());
                this.acreditarARS(destino, ammount.getValue());
            }
            else
            {
                new BlockIo().makeTransference(moneda.cod, origen.direccion, destino.direccion, ammount.ToFormatString());
            }               

            //Grabo la transferencia.
            return this.recordTransference(tranId, origen.cliente, origen, destino, moneda, ammount.getValue());
        }

        //Esta operacion solo funciona si la moneda es ARS.
        public int extraer(BilleteraBE2 target, double ammount)
        {
            if (target.moneda.cod != "ARS")
                throw new Exception("Operation allowed only to wallets in ARS");

            //Traigo la wallet.
            BilleteraBE2 wallet = this.getById(target.idwallet, false);

            //Incremento el saldo.
            wallet.saldo = new Money(wallet.saldo.getValue() - Convert.ToDecimal(ammount));

            //Guardo.
            return this.update(wallet);
        }
        //CONSULTA-----------------------------------------------------------------

        //Obtengo el balance de la cuenta y moneda..
        private string getBalance(string address, MonedaBE moneda)
        {
            //Consulto el balance en block.io.
            Balance balance = new BlockIo().getBalance(moneda.cod, address);
            Bitacora.GetInstance().log("Se ha consultado el balance:" + moneda.cod + "/" + address + ", " + balance.data.available_balance, true);

            return balance.data.available_balance;
        }

        //Obtengo info de la billetera, pudiendo tener el saldo actualizado o no.
        public BilleteraBE2 getById(long id, bool updatedBalance = false)
        {
            //Recupero de la bd los datos, si no existe retorno null.
            BilleteraBE2 wallet = new BilleteraDAL2().findById(id);

            if (wallet == null)
                return null;

            //Si piden saldo actualizado lo traigo del blockio
            if (updatedBalance && wallet.moneda.cod != "ARS")
            {
                //Casteo el formato.
                string balance = this.getBalance(wallet.direccion, wallet.moneda);
                wallet.saldo = new Money(balance);
            }

            return wallet;
        }
    }
}
