using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Permisos;

namespace BE
{
    public class UsuarioBloqBE : EntityBE
    {
        public Int64 idBloq;
        public UsuarioBE usuario;
        public DateTime fecBloq;
        public string motivo;
    }
}