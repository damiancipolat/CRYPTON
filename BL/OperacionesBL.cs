using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE;
using DAL;
using BL;
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

        //Registro acreditación de saldos a cuentas.
        public int acreditar(SolicOperacionBE solicitud)
        {
            //Actualizo el saldo de la billetera.
            new BilleteraBL().acreditarARS(solicitud.billetera, solicitud.valor.getValue());
        
            //Grabo la operacion.
            return new SolicOperacionDAL().save(solicitud);
        }

        public void rechazar(SolicOperacionBE solicitud) { }
        public void extraer(SolicOperacionBE solicitud) { }

        public int update(SolicOperacionBE solicitud) { return 0; }
    }
}