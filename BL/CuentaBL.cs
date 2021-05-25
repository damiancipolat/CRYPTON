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

        public void crearBilleteras(CuentaBE cuenta) { }
        public void crearCuenta(CuentaBE cuenta) { }
        public void darBaja(CuentaBE cuenta) { }
        public void bloquear(CuentaBE cuenta) { }
        public List<BilleteraBE> traerBilleteras(CuentaBE cuenta) { return new List<BilleteraBE>(); }

    }
}
