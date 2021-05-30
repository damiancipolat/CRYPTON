using System;
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
    public class BilleteraBL
    {
        public BilleteraBL()
        {
            //..
        }

        public void depositar(BilleteraBE target, float ammount) { }
        public void extraer(BilleteraBE target, float ammount) { }
        public void transferir(BilleteraBE origen, BilleteraBE destino, float ammount) { }
        public float traerSaldo(BilleteraBE wallet) { return 0; }
        public void traerOperaciones(BilleteraBE wallet) { }
        public float cotizarTransfer(BilleteraBE sourcce,float ammount) { return 0; }
    }
}
