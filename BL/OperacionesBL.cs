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
        

        //Registro acreditación de saldos a billetera.
        public int acreditar(SolicOperacionBE solicitud)
        {
            //Actualizo el saldo de la billetera.
            new BilleteraBL().acreditarARS(solicitud.billetera, solicitud.valor.getValue());
        
            //Grabo la operacion.
            return new SolicOperacionDAL().save(solicitud);
        }

        //Registro y computo la extraccion de dinero en la billetera.
        public int extraer(SolicOperacionBE solicitud) 
        {
            //Actualizo el saldo de la billetera.
            new BilleteraBL().descontarARS(solicitud.billetera,solicitud.valor.getValue());

            //Grabo la operacion.
            return new SolicOperacionDAL().save(solicitud);
        }

        //-----------------------------

        public List<SolicOperacionBE> verSolicitudes() { return new List<SolicOperacionBE>(); }

        public void rechazar(SolicOperacionBE solicitud) { }
        
        public int update(SolicOperacionBE solicitud) { return 0; }
    }
}