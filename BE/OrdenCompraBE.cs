using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.ValueObject;

namespace BE
{
    public class OrdenCompraBE : EntityBE
    {
        public Int64 idcompra;
        public OrdenVentaBE2 ordenVenta;
        public DateTime fecOperacion;
        public ClienteBE comprador;        
        public Money cantidad;
        public MonedaBE moneda;
    }
}
