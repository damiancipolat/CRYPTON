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
using BL.Permisos;
using BE.Permisos;

namespace BL
{
    public class CuentaBL
    {
        public CuentaBL()
        {
            //..
        }

        //CREACION --------------------------------------------------------------

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
            this.crearBilleteras(cuenta, cliente);

            //Proceso el alta de los permisos.
            this.registerClientPermission(cliente);

            return newId;
        }

        //Proceso la creación de las 4 billeteras.
        private void crearBilleteras(CuentaBE cuenta, ClienteBE cliente)
        {
            BilleteraBL walletBL = new BilleteraBL();
            
            //ARS
            int arsId = walletBL.crear(cuenta, cliente, "ARS");
            Bitacora.GetInstance().log("SIGNUP","Se ha creado la cuenta en ars pesos id:" + arsId.ToString(), true);

            //BTC
            int btcId = walletBL.crear(cuenta, cliente, "BTC");
            Bitacora.GetInstance().log("SIGNUP", "Se ha creado la cuenta en bitcoin:" + btcId.ToString(), true);

            //LTC
            int ltcId = walletBL.crear(cuenta, cliente, "LTC");
            Bitacora.GetInstance().log("SIGNUP", "Se ha creado la cuenta en litecoin id:" + ltcId.ToString(), true);

            //DOG
            int dogId = walletBL.crear(cuenta, cliente, "DOG");
            Bitacora.GetInstance().log("SIGNUP", "Se ha creado la cuenta en doge id:" + dogId.ToString(), true);
            
        }

        //Traigo la cuenta activa de un cliente.
        public CuentaBE traerActiva(ClienteBE cliente)
        {
            return new CuentaDAL().getActive(cliente);
        }

        //Registra la lista de permisos que le corresponden a un cliente.
        public void registerClientPermission(ClienteBE cliente)
        {
            Debug.WriteLine("Bind client permission of if: "+cliente.usuario.idusuario);
            UserPermisoBL biz = new UserPermisoBL();

            //Busco por patente.
            Patente pat = biz.findByName("CLIENTS");
            
            //Registro la familia al nuevo cliente.
            if (pat != null)
                biz.save(cliente.usuario.idusuario, pat.Id);
        }

        //CONSULTA --------------------------------------------------------------

        //Traigo la billetera en base al id-
        public CuentaBE traer(long id)
        {
            return new CuentaDAL().findById(id);
        }

        //Consulto las billeteras asociadas a una cuenta retorno en forma de diccionario.
        public Dictionary<string, BilleteraBE> traerBilleteras(CuentaBE cuenta, bool balanceUpdate,bool rawUpdate=true)
        {
            //Recupero las billeteras de esta cuenta.
            List<BilleteraBE> wallets = new BilleteraDAL().findByCuenta(cuenta.idcuenta);

            //Valido si hay cuentas.
            if (wallets.Count == 0)
                throw new Exception("Wallets not found for this account");

            //Armo el diccionario de retorno.
            Dictionary<string, BilleteraBE> walletAccount = new Dictionary<string, BilleteraBE>();

            //Instancia al biz de wallets.
            BilleteraBL walletBiz = new BilleteraBL();

            //Cargo el diccionario.
            walletAccount.Add("ARS", walletBiz.getById(wallets.SingleOrDefault(i => i.moneda.cod == "ARS").idwallet, false, rawUpdate));
            walletAccount.Add("BTC", walletBiz.getById(wallets.SingleOrDefault(i => i.moneda.cod == "BTC").idwallet, balanceUpdate, rawUpdate));
            walletAccount.Add("LTC", walletBiz.getById(wallets.SingleOrDefault(i => i.moneda.cod == "LTC").idwallet, balanceUpdate, rawUpdate));
            walletAccount.Add("DOG", walletBiz.getById(wallets.SingleOrDefault(i => i.moneda.cod == "DOG").idwallet, balanceUpdate, rawUpdate));

            return walletAccount;
        }

        //Consulto las billeteras asociadas a una cuenta retorno en forma de lista.
        public List<BilleteraBE> traerBilleterasList(CuentaBE cuenta)
        {
            return new BilleteraDAL().findByCuenta(cuenta.idcuenta);
        }

        //Traigo las billeteras que tiene un cliente en base a su cuenta activa.
        public Dictionary<string, BilleteraBE> traerBilleterasCliente(ClienteBE cliente,bool balanceUpdate=false, bool rawUpdate=true)
        {
            CuentaBE activeAccount = this.traerActiva(cliente);

            if (activeAccount == null)
                throw new Exception("No active account for this client.");

            return this.traerBilleteras(activeAccount, balanceUpdate,rawUpdate);
        }

        //Trae la billetera en ars del cliente.
        public BilleteraBE traerBilleteraArsCliente(ClienteBE cliente) 
        {
            CuentaBE activeAccount = this.traerActiva(cliente);

            //Recupero las billeteras de esta cuenta.
            List<BilleteraBE> wallets = new BilleteraDAL().findByCuentaAndMoneda(activeAccount.idcuenta,"ARS");

            //Traigo la cuenta.
            if (wallets.Count > 0)
                return wallets[0];
            else
                return null;
        }
    }
}
