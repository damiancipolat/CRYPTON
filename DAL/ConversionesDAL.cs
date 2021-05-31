using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.DAO;

namespace DAL
{
    public class ConversionesDAL : AbstractDAL<ConversionesBE>
    {
        //TODO
        public ConversionesBE getBycode(string moneda) { return new ConversionesBE(); }
    }
}
