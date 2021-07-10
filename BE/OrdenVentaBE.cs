using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum OrdenEstado
    {
        DISPONIBLE=1,
        VENDIDA=2,
        EXPIRADA=3
    }

    public class OrdenVentaBE : EntityBE
    {
        public Int64 idorden;
        public ClienteBE vendedor;
        public double cantidad;
        public double precio;
        public MonedaBE ofrece;
        public MonedaBE pide;
        public DateTime fecCreacion;
        public DateTime fecFin;
        public OrdenEstado ordenEstado;
    }
}
