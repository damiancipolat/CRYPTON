using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BL
{
    public class BitacoraBL
    {
        public List<string> getActivities()
        {
            return new BitacoraDAL().getActivities();
        }

        public List<BitacoraBE> search(string activity, string from, string to, string text)
        {
            return new BitacoraDAL().search(activity,from,to,text);
        }
    }
}
