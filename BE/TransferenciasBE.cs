using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class TransferenciasBE : EntityBE
    {
        public Int64 idtransf;
        public DateTime fecProc;
        public ClienteBE cliente;
        public BilleteraBE2 origen;
        public BilleteraBE2 destino;
        public decimal valor;
        public MonedaBE moneda;
        public long idorden;
    }
}
