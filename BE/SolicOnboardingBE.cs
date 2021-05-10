using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{    
    public enum OnboardingEstado
    {
        VALIDO = 1,
        RECHAZADO = 2,
        ILEGIBLE = 3
    }

    public class SolicOnboardingBE
    {
        public Int64 idsolic;
        public DateTime fecSolic;
        public UsuarioBE usuario;
        public string img_frente;
        public string img_dorso;
        public string img_selfie;
        public OnboardingEstado solicEstado;
        public DateTime fecProceso;
        public UsuarioBE operador;
    }    
}
