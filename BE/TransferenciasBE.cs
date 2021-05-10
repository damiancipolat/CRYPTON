using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class TransferenciasBE
    {
        public Int64 idtransf;
        public DateTime fecProc;
        public ClienteBE cliente;
        public BilleteraBE origen;
        public BilleteraBE destino;
        public float valor;
        public MonedaBE moneda;
        public int idorden;
    }
}
