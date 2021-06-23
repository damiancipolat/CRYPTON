using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum Operaciones
    {
        COMPRA=1,
        VENTA=2,
        EXTRACT=3
    }
    public class ComisionValorBE : EntityBE
    {
        public long idope;
        public string descrip;
        public float valor;
    }
}