﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using BL.Exceptions;
using BE;
using DAL;
using IO;
using IO.Responses;
using SL;

namespace BL
{
    public class BilleteraBL
    {
        public BilleteraBL()
        {
        }

        //CREACION --------------------------------------------------------------

        //Obtengo las claves en base a la configuración.
        private ApiKeysBE getEnvironment()
        {
            //Traigo el ambiente desde la configuración.
            string envConfig = ConfigurationManager.AppSettings["Environment"];

            //Consulto desde la bd.
            return new ApiKeysDAL().findByCode(envConfig);

        }

        //Extraigo la clave en base a la moneda.
        private string getKeys(ApiKeysBE keys, string money)
        {
            switch (money)
            {
                case "BTC":
                    return keys.btc;
                case "LTC":
                    return keys.ltc;
                case "DOG":
                    return keys.dog;
                default:
                    return "";
            }
        }

        //Crea la billetera para criptomonedas usa block.io
        public BilleteraBE crearCrypto(CuentaBE cuenta, ClienteBE cliente, MonedaBE moneda)
        {
            //Obtengo las claves de la red que corresponde la moneda.
            string networkKey = this.getKeys(this.getEnvironment(), moneda.cod);
            
            if (networkKey == null)
                throw new BusinessException("Keys not found");

            //Creo la wallet en block.io
            NewWallet created = new BlockIo(networkKey).createWallet();
            Bitacora.GetInstance().log("Se ha creado :"+moneda.cod+"/"+created.data.address,true);

            //Creo la billetera.
            BilleteraBE wallet = new BilleteraBE();
            wallet.cliente = cliente;
            wallet.direccion = created.data.address;            
            wallet.fecCreacion = DateTime.Now;
            wallet.moneda = moneda;
            wallet.cuenta = cuenta;
            wallet.saldo = 0;

            return wallet;
        }

        //Cuenta en ARS, no usa proveedor.
        public BilleteraBE crearARS(CuentaBE cuenta, ClienteBE cliente, MonedaBE moneda)
        {
            //Creo la billetera.
            BilleteraBE wallet = new BilleteraBE();
            wallet.cliente = cliente;
            wallet.direccion = cuenta.idcuenta.ToString()+"-"+ DateTime.Now.ToString("yyyyMMddHHmmssfff")+"-"+cliente.idcliente.ToString();
            wallet.fecCreacion = DateTime.Now;
            wallet.moneda = moneda;
            wallet.cuenta = cuenta;
            wallet.saldo = 0;

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
            BilleteraBE newWallet = (money.cod == "ARS")
                ? this.crearARS(cuenta, cliente, money)
                : this.crearCrypto(cuenta,cliente, money);

            //Proceso guardado en la bd.
            return new BilleteraDAL().insert(newWallet);
        }

        //CONSULTA-----------------------------------------------------------------
        private string getBalance(string address, MonedaBE moneda)
        {
            //Obtengo las claves de la red que corresponde la moneda.
            string networkKey = this.getKeys(this.getEnvironment(), moneda.cod);

            if (networkKey == null)
                throw new BusinessException("Keys not found");

            //Consulto el balance en block.io.
            Balance balance = new BlockIo(networkKey).getBalance(address);
            Bitacora.GetInstance().log("Se ha consultado el balance:" + moneda.cod + "/" + address+", "+balance.data.available_balance, true);

            return balance.data.available_balance;
        }

        public BilleteraBE getById(int id, bool updatedBalance=false)
        {
            //Recupero de la bd los datos, si no existe retorno null.
            BilleteraBE wallet = new BilleteraDAL().findById(id);

            if (wallet == null)
                return null;

            //Si piden saldo actualizado lo traigo del blockio
            if (updatedBalance && wallet.moneda.cod != "ARS")
                wallet.saldo = float.Parse(this.getBalance(wallet.direccion, wallet.moneda));
            
            return wallet;
        }

        //-------------------------------------------------------------------------

        public void depositar(BilleteraBE target, float ammount) { }
        public void extraer(BilleteraBE target, float ammount) { }
        public void transferir(BilleteraBE origen, BilleteraBE destino, float ammount) { }
        public float traerSaldo(BilleteraBE wallet) { return 0; }
        public void traerOperaciones(BilleteraBE wallet) { }
        public float cotizarTransfer(BilleteraBE sourcce,float ammount) { return 0; }
    }
}