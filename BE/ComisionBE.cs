using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.ValueObject;

namespace BE
{
    public class ComisionBE : EntityBE
    {
        public Int64 idcobro;
        public Operaciones tipo_operacion;
        public Int64 referencia;
        public MonedaBE moneda;
        public Money valor;
        public DateTime fecCobro;
        public int processed;
        public BilleteraBE wallet;
        public ClienteBE cliente;
    }
}