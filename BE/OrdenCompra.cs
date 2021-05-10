using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class OrdenCompraBE
    {
        public Int64 idcompra;
        public OrdenVentaBE ordenVenta;
        public DateTime fecOperacion;
        public ClienteBE comprador;
        public MonedaBE moneda;
        public int cantidad;
        public float precio;
    }
}
