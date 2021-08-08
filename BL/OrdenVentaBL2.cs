using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public class OrdenVentaBL2
    {
        public OrdenVentaBE2 create(OrdenVentaBE2 venta)
        {
            int newId = new OrdenVentaDAL2().save(venta);
            venta.idorden = newId;

            return venta;
        }

        public int update(OrdenVentaBE2 venta)
        {
            return new OrdenVentaDAL2().update(venta);
        }

        public int finish(long idorden)
        {
            OrdenVentaBE2 order = new OrdenVentaDAL2().findById(idorden);

            if (order == null)
                throw new Exception("Order not found!");

            //Doy de baja la orden.    
            order.ordenEstado = OrdenEstado.FINALIZADA;
            return new OrdenVentaDAL2().update(order);
        }

        public int close(OrdenVentaBE2 order)
        {
            if (order == null)
                throw new Exception("Order not found!");

            //Doy de baja la orden.    
            order.ordenEstado = OrdenEstado.VENDIDA;
            return new OrdenVentaDAL2().update(order);
        }

        public OrdenVentaBE2 load(long id)
        {
            return new OrdenVentaDAL2().findById(id);
        }

        public int delete(OrdenVentaBE2 venta)
        {
            return new OrdenVentaDAL2().delete(venta.idorden);
        }

        public float cotizar(OrdenVentaBE2 orden,BilleteraBE destino) { return 0; }

        public List<OrdenVentaBE2> buscar(MonedaBE ofrece, MonedaBE pide,ClienteBE cliente)
        {
            //Traigo los datos.
            List<OrdenVentaBE2> results = new OrdenVentaDAL2().searchByMoneys(ofrece,pide);

            //Cargo lista de resultados.
            List<OrdenVentaBE2> final = new List<OrdenVentaBE2>();

            //Itero para excluir ventas publicadas por mi mismo.
            foreach (OrdenVentaBE2 tmpOrder in results)
                if (tmpOrder.vendedor.idcliente != cliente.idcliente)
                    final.Add(tmpOrder);

            return final;
        }

        public List<OrdenVentaBE2> orderBySeller(ClienteBE cliente)
        {
            return new OrdenVentaDAL2().searchBySeller(cliente);
        }

        public bool validar(OrdenVentaBE2 orden, ClienteBE cliente)
        {
            return true;
        }
    }
}
