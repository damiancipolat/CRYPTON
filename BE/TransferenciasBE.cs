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
        public BilleteraBE origen;
        public BilleteraBE destino;
        public double valor;
        public MonedaBE moneda;
        public int idorden;
    }
}
