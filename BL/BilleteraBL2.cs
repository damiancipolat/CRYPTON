using System;
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
    public class BilleteraBL
    {
        public BilleteraBL()
        {
        }

        //CREACION --------------------------------------------------------------

        //Crea la billetera para criptomonedas usa block.io
        private BilleteraBE crearCrypto(CuentaBE cuenta, ClienteBE cliente, MonedaBE moneda)
        {
            //Creo la wallet en block.io
            NewWallet created = new BlockIo().createWallet(moneda.cod);
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
        private BilleteraBE crearARS(CuentaBE cuenta, ClienteBE cliente, MonedaBE moneda)
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
            wallet.saldo = new Money(wallet.saldo.getValue() + Convert.ToDecimal(ammount));

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
            wallet.saldo = new Money(wallet.saldo.getValue() - Convert.ToDecimal(ammount));

            //Guardo.
            return this.update(wallet);
        }
        
        //CONSULTA-----------------------------------------------------------------

        //Obtengo el balance de la cuenta y moneda..
        private string getBalance(string address, MonedaBE moneda)
        {
            //Consulto el balance en block.io.
            Balance balance = new BlockIo().getBalance(moneda.cod,address);
            Bitacora.GetInstance().log("Se ha consultado el balance:" + moneda.cod + "/" + address+", "+balance.data.available_balance, true);

            return balance.data.available_balance;
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
                //Casteo el formato.
                string balance = this.getBalance(wallet.direccion, wallet.moneda);
                wallet.saldo = new Money(balance);
            }

            return wallet;
        }

        //-------------------------------------------------------------------------

        public void transferir(BilleteraBE origen, BilleteraBE destino, float ammount) { }
        public float traerSaldo(BilleteraBE wallet) { return 0; }
        public void traerOperaciones(BilleteraBE wallet) { }
        public float cotizarTransfer(BilleteraBE sourcce,float ammount) { return 0; }
    }
}
