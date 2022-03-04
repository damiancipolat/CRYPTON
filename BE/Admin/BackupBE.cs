using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Admin
{
    public class BackupBE
    {
        public Int64 idbackup;
        public UsuarioBE usuario;
        public string path;
        public DateTime fecRec;
        public string type;
        public Int64 size;
    }
}