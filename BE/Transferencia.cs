using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Transferencia
    {
        public int idTransferencia;
        public DateTime fecProc;
        public UsuarioBE usuario;
        public Billetera origen;
        public Billetera destino;
        public float valor;
        public Moneda moneda;
    }
}
