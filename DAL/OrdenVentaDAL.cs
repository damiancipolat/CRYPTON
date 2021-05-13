using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class OrdenVentaDAL : AbstractDAL<OrdenVentaBE>
    {

        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private OrdenVentaBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            OrdenVentaBE ordenVenta = new OrdenVentaBE();

            //Bindeo campos con la lista de resultados.
            this.binder.match(fieldData, ordenVenta);

            return ordenVenta;

        }

        //Este metodo obtiene en base al ID el usuario.
        public OrdenVentaBE findById(int id)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("orden_venta", "idorden", id);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Este metodo retorna una lista de clientes.
        public List<OrdenVentaBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("orden_venta");

            //Lista resultado.
            List<OrdenVentaBE> lista = new List<OrdenVentaBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Agrega un nuevo usuario.
        public int save(OrdenVentaBE venta)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                { "vendedor",venta.vendedor.idcliente},
                { "cantidad",venta.cantidad},
                { "moneda",venta.moneda.cod},
                { "precio",venta.precio},
                { "fecCreacion",venta.fecCreacion},
                { "fecFin",venta.fecFin}
            };

            return this.getInsert().insertSchema(schema, "orden_venta", true);
        }

        //Borra el usuario.
        public int delete(int id)
        {
            return this.getDelete().deleteById("idorden", id, "orden_venta");
        }

        //Actualizar el usuario.
        public int update(OrdenVentaBE venta)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                { "vendedor",venta.vendedor.idcliente},
                { "cantidad",venta.cantidad},
                { "moneda",venta.moneda.cod},
                { "precio",venta.precio},
                { "fecCreacion",venta.fecCreacion},
                { "fecFin",venta.fecFin}
            };

            return this.getUpdate().updateSchemaById(schema, "orden_venta", "idorden", venta.idorden);
        }
    }
}
