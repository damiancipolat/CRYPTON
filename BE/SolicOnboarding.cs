using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum OnboardingEstados
    {
        VALIDO=1,
        RECHAZADO=2,
        ILEGIBLE=3
    }

    public class SolicOnboarding
    {
        public int idSolic;
        public DateTime fecSolic;
        public Usuario Usuario;
        public string imgFrente;
        public string imgDorso;
        public string imgSelfie;
        public OnboardingEstados solicEstado;
        public DateTime fecProceso;
        public Usuario operador;
    }
}
