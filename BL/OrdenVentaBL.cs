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

        public int finish(long idorden)
        {
            OrdenVentaBE order = new OrdenVentaDAL().findById(idorden);

            if (order == null)
                throw new Exception("Order not found!");

            //Doy de baja la orden.    
            order.ordenEstado = OrdenEstado.FINALIZADA;
            return new OrdenVentaDAL().update(order);
        }

        public int close(OrdenVentaBE order)
        {
            if (order == null)
                throw new Exception("Order not found!");

            //Doy de baja la orden.    
            order.ordenEstado = OrdenEstado.VENDIDA;
            return new OrdenVentaDAL().update(order);
        }

        public OrdenVentaBE load(long id)
        {
            return new OrdenVentaDAL().findById(id);
        }

        public int delete(OrdenVentaBE venta)
        {
            return new OrdenVentaDAL().delete(venta.idorden);
        }

        public float cotizar(OrdenVentaBE orden,BilleteraBE destino) { return 0; }

        public List<OrdenVentaBE> buscar(MonedaBE ofrece, MonedaBE pide,ClienteBE cliente)
        {
            //Traigo los datos.
            List<OrdenVentaBE> results = new OrdenVentaDAL().searchByMoneys(ofrece,pide);

            //Cargo lista de resultados.
            List<OrdenVentaBE> final = new List<OrdenVentaBE>();

            //Itero para excluir ventas publicadas por mi mismo.
            foreach (OrdenVentaBE tmpOrder in results)
                if (tmpOrder.vendedor.idcliente != cliente.idcliente)
                    final.Add(tmpOrder);

            return final;
        }

        public List<OrdenVentaBE> orderBySeller(ClienteBE cliente)
        {
            return new OrdenVentaDAL().searchBySeller(cliente);
        }

        public bool validar(OrdenVentaBE orden, ClienteBE cliente)
        {
            return true;
        }
    }
}
