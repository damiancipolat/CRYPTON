using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Cliente
    {
        public int idCliente;
        public UsuarioBE usuario;
        public string nombre;
        public string apellido;
        public DateTime fecNac;
        public string numTramite;
        public string domicilio;
        public string email;
        public string telefono;
        public SolicOnboarding onboardingOrigen;
    }
}
