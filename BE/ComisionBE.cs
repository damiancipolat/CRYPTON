using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ComisionBE : EntityBE
    {
        public Int64 idcobro;
        public ComisionValorBE operacion;
        public Int64 referencia;
        public MonedaBE moneda;
        public float valor;
        public DateTime fecCobro;
    }
}