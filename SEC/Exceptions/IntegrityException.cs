using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEC.Exceptions
{ 

    public class IntegrityException : Exception
    {
        public IntegrityException(string message): base(message)
        {
        }
    }
}