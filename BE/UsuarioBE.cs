using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum UsuarioTipo
    {
        CLIENTE=1,
        EMPLEADO=2
    }

    public class UsuarioBE : EntityBE
    {
        public Int64 idusuario;
        public string nombre;
        public string apellido;
        public string alias;
        public string email;
        public UsuarioTipo tipoUsuario;
        public string pwd;
        public string hash;
    }
}
