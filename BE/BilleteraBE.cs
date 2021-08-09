using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.ValueObject;

namespace BE
{
    public class BilleteraBE : EntityBE
    {
        public Int64 idwallet;
        public ClienteBE cliente;
        public MonedaBE moneda;
        public string direccion;
        public DateTime fecCreacion;        
        public Money saldo;
        public Money saldo_pending;
        public CuentaBE cuenta;
    }
}
