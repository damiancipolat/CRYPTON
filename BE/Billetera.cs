using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Billetera
    {
        public int idWallet;
        public Cliente cliente;
        public Moneda moneda;
        public string address;
        public DateTime fecCreacion;
        public float saldo;
    }
}
