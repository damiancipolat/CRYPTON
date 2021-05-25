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
    public class FraudeBL
    {
        public FraudeBL()
        {
            //..
        }

        public List<SolicOnboardingBE> verSolicitudes() { return new List<SolicOnboardingBE>(); }
        public bool aprobar(SolicOnboardingBE solicitud) { return true; }
        public bool rechazar(SolicOnboardingBE solicitud) { return true; }
    }
}
