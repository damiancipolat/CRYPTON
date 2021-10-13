using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public class CommisionBL
    {
        public List<ComisionBE> search(string type, string from, string to)
        {
            return new ComisionDAL().findByDate(type, from, to);
        }
    }
}