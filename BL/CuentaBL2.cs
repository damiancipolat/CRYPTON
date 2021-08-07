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
    public class CuentaBL2
    {
        public CuentaBL2()
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
            BilleteraBL2 walletBL = new BilleteraBL2();
            
            //ARS
            int arsId = walletBL.crear(cuenta, cliente, "ARS");
            Bitacora.GetInstance().log("Se ha creado la cuenta en ars pesos id:" + arsId.ToString(), true);

            //BTC
            int btcId = walletBL.crear(cuenta, cliente, "BTC");
            Bitacora.GetInstance().log("Se ha creado la cuenta en bitcoin:" + btcId.ToString(), true);

            //LTC
            int ltcId = walletBL.crear(cuenta, cliente, "LTC");
            Bitacora.GetInstance().log("Se ha creado la cuenta en litecoin id:" + ltcId.ToString(), true);

            //DOG
            int dogId = walletBL.crear(cuenta, cliente, "DOG");
            Bitacora.GetInstance().log("Se ha creado la cuenta en doge id:" + dogId.ToString(), true);
            
        }

        //Traigo la cuenta activa de un cliente.
        public CuentaBE traerActiva(ClienteBE cliente)
        {
            return new CuentaDAL().getActive(cliente);
        }

        //Registra la lista de permisos que le corresponden a un cliente.
        public void registerClientPermission(ClienteBE cliente)
        {
            Debug.WriteLine("Bind client permission of if: "+cliente.idusuario);

            //Cargo el arbol de permisos para un usuario que arranca de cero.
            /*PermisoBL perm = new PermisoBL();
            long clientId = cliente.usuario.idusuario;

            //Registro.
            perm.bindSpecificToUser(null,"R001", clientId);
            perm.bindSpecificToUser("R001","R002", clientId);
            perm.bindSpecificToUser("R002", "CLI001", clientId);
            perm.bindSpecificToUser("R002", "CLI002", clientId);
            perm.bindSpecificToUser("R002", "CLI003", clientId);
            perm.bindSpecificToUser("R002", "CLI004", clientId);
            perm.bindSpecificToUser("R002", "CLI005", clientId);
            perm.bindSpecificToUser("R002", "CLI006", clientId);*/
        }

        //CONSULTA --------------------------------------------------------------

        //Traigo la billetera en base al id-
        public CuentaBE traer(long id)
        {
            return new CuentaDAL().findById(id);
        }

        //Consulto las billeteras asociadas a una cuenta retorno en forma de diccionario.
        public Dictionary<string, BilleteraBE2> traerBilleteras(CuentaBE cuenta, bool balanceUpdate)
        {
            //Recupero las billeteras de esta cuenta.
            List<BilleteraBE2> wallets = new BilleteraDAL2().findByCuenta(cuenta.idcuenta);

            //Valido si hay cuentas.
            if (wallets.Count == 0)
                throw new Exception("Wallets not found for this account");

            //Armo el diccionario de retorno.
            Dictionary<string, BilleteraBE2> walletAccount = new Dictionary<string, BilleteraBE2>();

            BilleteraBL2 walletBiz = new BilleteraBL2();

            //Cargo el diccionario.
            walletAccount.Add("ARS", walletBiz.getById(wallets.SingleOrDefault(i => i.moneda.cod == "ARS").idwallet, false));
            walletAccount.Add("BTC", walletBiz.getById(wallets.SingleOrDefault(i => i.moneda.cod == "BTC").idwallet, balanceUpdate));
            walletAccount.Add("LTC", walletBiz.getById(wallets.SingleOrDefault(i => i.moneda.cod == "LTC").idwallet, balanceUpdate));
            walletAccount.Add("DOG", walletBiz.getById(wallets.SingleOrDefault(i => i.moneda.cod == "DOG").idwallet, balanceUpdate));
                        

            return walletAccount;
        }

        //Consulto las billeteras asociadas a una cuenta retorno en forma de lista.
        public List<BilleteraBE2> traerBilleterasList(CuentaBE cuenta)
        {
            return new BilleteraDAL2().findByCuenta(cuenta.idcuenta);
        }

        //Traigo las billeteras que tiene un cliente en base a su cuenta activa.
        public Dictionary<string, BilleteraBE2> traerBilleterasCliente(ClienteBE cliente,bool balanceUpdate=false)
        {
            CuentaBE activeAccount = this.traerActiva(cliente);

            if (activeAccount == null)
                throw new Exception("No active account for this client.");

            return this.traerBilleteras(activeAccount, balanceUpdate);
        }

        //-------------------------------------

        public void darBaja(CuentaBE cuenta) { }
        public void bloquear(CuentaBE cuenta) { }
    }
}
