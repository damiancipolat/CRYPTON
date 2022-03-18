using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL
{
    interface ILogger
    {
        void log(string actividad, string payload);
    }
}
