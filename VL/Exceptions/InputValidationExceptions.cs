using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Exceptions
{
    public class InputException : Exception
    {
        //Esta excepcion se usa en errores de input.
        public InputException(string message): base(message)
        {
        }
    }
}
