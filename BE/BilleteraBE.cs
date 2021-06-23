using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BilleteraBE : EntityBE
    {
        public Int64 idwallet;
        public ClienteBE cliente;
        public MonedaBE moneda;
        public string direccion;
        public DateTime fecCreacion;
        public Double saldo;
        public CuentaBE cuenta;
    }
}
