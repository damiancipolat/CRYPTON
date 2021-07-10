using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

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

            //Actualizo el tipo de usuario que es un enum.            
            Dictionary<string, object> mapa = this.getParser().rowToDictionary(fieldData);

            //Bindeo campos.
            ordenVenta.ofrece = new MonedaDAL().findByCode((string)mapa["ofrece"]);
            ordenVenta.pide = new MonedaDAL().findByCode((string)mapa["pide"]);
            ordenVenta.vendedor = new ClienteDAL().findById((long)mapa["vendedor"]);

            return ordenVenta;
        }

        //Este metodo obtiene en base al ID el usuario.
        public OrdenVentaBE findById(long id)
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

        //Este metodo retorna una lista de actividades.
        public List<OrdenVentaBE> getLastActivities()
        {
            //Creo un esquema dinamico para serejecutado.
            var schema = new Dictionary<string, Object>{
                { "ordenEstado",OrdenEstado.DISPONIBLE}
            };

            List<object> result = this.getSelect().selectAndLast(schema, "orden_venta","idorden",10);

            //Lista resultado.
            List<OrdenVentaBE> lista = new List<OrdenVentaBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //todo
        //Este metodo retorna una lista de actividades para cada moneda.
        public List<OrdenVentaBE> getLastActivitiesByMoney(MonedaBE moneda)
        {
            //Lista resultado.
            List<OrdenVentaBE> lista = new List<OrdenVentaBE>();

            return lista;
        }

        //Agrega un nuevo usuario.
        public int save(OrdenVentaBE venta)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                { "vendedor",venta.vendedor.idcliente},
                { "cantidad",venta.cantidad},
                { "ofrece",venta.ofrece.cod},
                { "pide",venta.pide.cod},
                { "precio",venta.precio},
                { "fecCreacion",(venta.fecCreacion!=null)?venta.fecCreacion.ToString("yyyy-MM-dd HH:mm:ss"):null},
                { "fecFin",(venta.fecFin!=null)?venta.fecFin.ToString("yyyy-MM-dd HH:mm:ss"):null},
                { "ordenEstado",(int)venta.ordenEstado}
            };
            
            return this.getInsert().insertSchema(schema, "orden_venta", true);
        }

        //Borra el usuario.
        public int delete(long id)
        {
            return this.getDelete().logicalDeleteById("idorden", id, "orden_venta");
        }

        //Actualizar el usuario.
        public int update(OrdenVentaBE venta)
        {
            //Creo un esquema dinamico para ser guardado.
            /* var schema = new Dictionary<string, Object>{
                 { "vendedor",venta.vendedor.idcliente},
                 { "cantidad",venta.cantidad},
                 { "moneda",venta.moneda.cod},
                 { "precio",venta.precio},
                 { "fecCreacion",venta.fecCreacion},
                 { "fecFin",venta.fecFin}
             };

             return this.getUpdate().updateSchemaById(schema, "orden_venta", "idorden", venta.idorden);*/
            return 0;
        }

        //todo:
        public List<OrdenVentaBE> search(MonedaBE ofrece, MonedaBE pide)
        {
            //Busco en la bd por dni.
            List<Object> result = this.getSelect().selectAnd(new Dictionary<string, Object>{
                {"ofrece",ofrece.cod},
                {"pide",pide.cod},
                {"ordenEstado",(int)OrdenEstado.DISPONIBLE},
            }, "orden_venta");

            //Lista resultado.
            List<OrdenVentaBE> lista = new List<OrdenVentaBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }
    }
}
