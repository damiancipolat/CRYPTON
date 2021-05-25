using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum CuentaEstado
    {
        ACTIVA = 1,
        INACTIVA = 2,
        BLOQUEADA = 3
    }

    public class CuentaBE
    {
        public Int64 idcuenta;
        public ClienteBE cliente;
        public DateTime fecAlta;
        public CuentaEstado estado;
    }
}
