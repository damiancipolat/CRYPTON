using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class NotificacionBE : EntityBE
    {
        public Int64 idnotification;
        public ClienteBE cliente;
        public string payload;
        public DateTime fecRegistro;
        public int marked;
    }
}