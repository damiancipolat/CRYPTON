using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE;

namespace DAL
{
    public class OrdenCompraDAL : AbstractDAL<OrdenCompraBE>
    {
        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private OrdenCompraBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            OrdenCompraBE ordenCompra = new OrdenCompraBE();

            //Bindeo campos con la lista de resultados.
            this.binder.match(fieldData, ordenCompra);

            return ordenCompra;

        }

        //Este metodo obtiene en base al ID el usuario.
        public OrdenCompraBE findById(int id)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("orden_compra", "idcompra", id);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Este metodo retorna una lista de compras.
        public List<OrdenCompraBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("orden_compra");

            //Lista resultado.
            List<OrdenCompraBE> lista = new List<OrdenCompraBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Este metodo retorna una lista de compras de un cliente.
        public List<OrdenCompraBE> findByClient(ClienteBE cliente)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                { "comprador",cliente.idcliente}
            };

            List<object> result = this.getSelect().selectAnd(schema, "orden_compra");

            //Lista resultado.
            List<OrdenCompraBE> lista = new List<OrdenCompraBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Traigo la lista de monedas.
        public List<(string, string)> getFavouriteMoneys(ClienteBE cliente)
        {
            //Hago la consulta.
            string sql = "select distinct ov.ofrece,ov.pide from orden_compra as oc inner join orden_venta as ov on ov.idorden = oc.idorden where oc.comprador="+cliente.idcliente.ToString()+";";
            SqlDataReader reader = this.getSelect().query(sql);

            List<(string,string)> money = new List<(string,string)>();

            //Loppeo cargando.
            while (reader.Read())
            {
                //Parseo.
                string ofrece = reader.GetValue(0).ToString();
                string pide = reader.GetValue(1).ToString();

                money.Add((ofrece,pide));
            }

            return money;
        }

        //Agrega un nuevo usuario.
        public int save(OrdenCompraBE compra)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                { "idorden",compra.ordenVenta.idorden},
                { "fecOperacion",compra.fecOperacion},
                { "comprador",compra.comprador.idusuario},
                { "moneda",compra.moneda.cod},
                { "cantidad",compra.cantidad},
                { "precio",compra.precio}
            };

            return this.getInsert().insertSchema(schema, "orden_compra", true);
        }

        //Borra el usuario.
        public int delete(int id)
        {
            return this.getDelete().deleteById("idorden", id, "orden_compra");
        }

        //Actualizar el usuario.
        public int update(OrdenCompraBE compra)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                { "idorden",compra.ordenVenta.idorden},
                { "fecOperacion",compra.fecOperacion},
                { "comprador",compra.comprador.idusuario},
                { "moneda",compra.moneda.cod},
                { "cantidad",compra.cantidad},
                { "precio",compra.precio}
            };

            return this.getUpdate().updateSchemaById(schema, "orden_compra", "idorden", compra.idcompra);
        }

    }
}
