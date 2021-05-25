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
    public class OperacionesBL
    {
        public OperacionesBL()
        {
            //..
        }

        public List<SolicOperacionBE> verSolicitudes() { return new List<SolicOperacionBE>(); }
        public void acreditar(SolicOperacionBE solicitud) { }
        public void rechazar(SolicOperacionBE solicitud) { }
        public void extraer(SolicOperacionBE solicitud) { }
    }
}