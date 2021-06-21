using System;
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
        
        public void crearCuenta(CuentaBE cuenta) { }
        public void darBaja(CuentaBE cuenta) { }
        public void bloquear(CuentaBE cuenta) { }
        public List<BilleteraBE> traerBilleteras(CuentaBE cuenta) { return new List<BilleteraBE>(); }
        //todo
        public List<BilleteraBE> traerBilleteras(ClienteBE cliente) { return new List<BilleteraBE>(); }
    }
}
