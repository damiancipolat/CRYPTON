using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class OrdenCompraBE : EntityBE
    {
        public Int64 idcompra;
        public OrdenVentaBE ordenVenta;
        public DateTime fecOperacion;
        public ClienteBE comprador;
        public MonedaBE moneda;
        public float cantidad;
        public float precio;
    }
}
