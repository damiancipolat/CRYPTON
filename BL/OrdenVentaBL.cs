using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public class OrdenVentaBL
    {
        public OrdenVentaBE create(OrdenVentaBE venta)
        {
            int newId = new OrdenVentaDAL().save(venta);
            venta.idorden = newId;

            return venta;
        }

        public int update(OrdenVentaBE venta)
        {
            return new OrdenVentaDAL().update(venta);
        }

        public int delete(OrdenVentaBE venta)
        {
            return new OrdenVentaDAL().delete(venta.idorden);
        }

        public OrdenVentaBE load(long id)
        {
            return new OrdenVentaDAL().findById(id);
        }
    }
}
