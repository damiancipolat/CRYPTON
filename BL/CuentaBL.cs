﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE;
using DAL;
using SL;
using SEC;

namespace BL
{
    public class CuentaBL
    {
        public CuentaBL()
        {
            //..
        }

        //-------------------------------------

        //Proceso la creacion de la cuenta.
        public int crear(ClienteBE cliente)
        {
            //Creo la cuenta.
            CuentaBE cuenta = new CuentaBE();            
            cuenta.cliente = cliente;
            cuenta.fecAlta = DateTime.Now;
            cuenta.estado = CuentaEstado.ACTIVA;

            //Grabo la cuenta.
            int newId = new CuentaDAL().insert(cuenta);
            cuenta.idcuenta = newId;
            
            //Proceso la creación de las billeteras
            this.crearBilleteras(cuenta,cliente);

            return newId;
        }

        //Proceso la creación de las 4 billeteras.
        private void crearBilleteras(CuentaBE cuenta, ClienteBE cliente)
        {
            BilleteraBL walletBL = new BilleteraBL();

            //ARS
            int arsId= walletBL.crear(cuenta, cliente, "ARS");
            Bitacora.GetInstance().log("Se ha creado la cuenta en ars pesos id:" + arsId.ToString(),true);

            //BTC
            int btcId = walletBL.crear(cuenta, cliente, "BTC");
            Bitacora.GetInstance().log("Se ha creado la cuenta en bitcoin:" + btcId.ToString(),true);

            //LTC
            int ltcId= walletBL.crear(cuenta, cliente, "LTC");
            Bitacora.GetInstance().log("Se ha creado la cuenta en litecoin id:" + ltcId.ToString(),true);

            //DOG
            int dogId= walletBL.crear(cuenta, cliente, "DOG");
            Bitacora.GetInstance().log("Se ha creado la cuenta en doge id:" + dogId.ToString(),true);
        }

        //Traigo la billetera en base al id-
        public CuentaBE traer(long id)
        {
            return new CuentaDAL().findById(id);
        }

        //Consulto las billeteras asociadas a una cuenta retorno en forma de diccionario.
        public Dictionary<string, BilleteraBE> traerBilleteras(CuentaBE cuenta)
        {
            //Recupero las billeteras de esta cuenta.
            List<BilleteraBE> wallets = new BilleteraDAL().findByCuenta(cuenta.idcuenta);

            //Valido si hay cuentas.
            if (wallets.Count == 0)
                throw new Exception("Wallets not found for this account");

            //Armo el diccionario de retorno.
            Dictionary<string, BilleteraBE> walletAccount = new Dictionary<string, BilleteraBE>();

            //Cargo el diccionario.
            walletAccount.Add("ARS", wallets.SingleOrDefault(i => i.moneda.cod == "ARS"));
            walletAccount.Add("BTC", wallets.SingleOrDefault(i => i.moneda.cod == "BTC"));
            walletAccount.Add("LTC", wallets.SingleOrDefault(i => i.moneda.cod == "LTC"));
            walletAccount.Add("DOG", wallets.SingleOrDefault(i => i.moneda.cod == "DOG"));

            return walletAccount;
        }

        //Consulto las billeteras asociadas a una cuenta retorno en forma de lista.
        public List<BilleteraBE> traerBilleterasList(CuentaBE cuenta)
        {
            return new BilleteraDAL().findByCuenta(cuenta.idcuenta);
        }

        //-------------------------------------

        public void darBaja(CuentaBE cuenta) { }
        public void bloquear(CuentaBE cuenta) { }
    }
}
