using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEC.Exceptions
{ 

    public class IntegrityException : Exception
    {
        public string metadata;

        public IntegrityException(string message, string metadata=null): base(message)
        {
            this.metadata = metadata;
        }
    }
}