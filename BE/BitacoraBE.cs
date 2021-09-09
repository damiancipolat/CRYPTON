using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BitacoraBE : EntityBE
    {
        public int id;
        public UsuarioBE usuario;
        public DateTime fecLog;
        public string actividad;
        public string payload;
    }
}