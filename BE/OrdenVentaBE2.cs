using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.ValueObject;
using BE;

namespace BE
{
    public class OrdenVentaBE2 : EntityBE
    {
        public Int64 idorden;
        public ClienteBE vendedor;
        public Money cantidad;
        public Money precio;
        public MonedaBE ofrece;
        public MonedaBE pide;
        public DateTime fecCreacion;
        public DateTime fecFin;
        public OrdenEstado ordenEstado;
    }
}
