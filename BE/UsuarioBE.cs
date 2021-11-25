using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Permisos;

namespace BE
{
    public enum UsuarioTipo
    {
        CLIENTE=1,
        EMPLEADO=2
    }

    public enum UsuarioEstado
    {
        NULO=0,
        ACTIVO = 1,
        INACTIVO = 2,
        BLOQUEADO = 3
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
        public List<Componente> _permisos;
        public UsuarioEstado estado;

        public List<Componente> Permisos
        {
            get
            {
                return _permisos;
            }
        }

        public UsuarioBE()
        {
            _permisos = new List<Componente>();
        }

    }
}
