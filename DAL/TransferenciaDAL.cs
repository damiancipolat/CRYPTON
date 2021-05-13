using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class TransferenciaDAL : AbstractDAL<TransferenciasBE>
    {

        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private TransferenciasBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            TransferenciasBE solicOperation = new TransferenciasBE();

            //Bindeo campos con la lista de resultados.
            this.binder.match(fieldData, solicOperation);

            return solicOperation;

        }

        //Este metodo obtiene en base al ID el usuario.
        public TransferenciasBE findById(int id)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("transferencias", "idtransf", id);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Este metodo retorna una lista de clientes.
        public List<TransferenciasBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("transferencias");

            //Lista resultado.
            List<TransferenciasBE> lista = new List<TransferenciasBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Agrega un nuevo usuario.
        public int save(TransferenciasBE transf)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{                
                {"fecProc",transf.fecProc},
                {"cliente",transf.cliente.idcliente},
                { "origen",transf.origen.idwallet},
                { "destino",transf.destino.idwallet},
                { "valor",transf.valor},
                { "moneda",transf.moneda.cod},
                { "idorden",transf.idorden}
            };

            return this.getInsert().insertSchema(schema, "transferencias", true);
        }

        //Borra el usuario.
        public int delete(int id)
        {
            return this.getDelete().deleteById("idtransf", id, "transferencias");
        }

        //Actualizar el usuario.
        public int update(TransferenciasBE transf)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"fecProc",transf.fecProc},
                {"cliente",transf.cliente.idcliente},
                { "origen",transf.origen.idwallet},
                { "destino",transf.destino.idwallet},
                { "valor",transf.valor},
                { "moneda",transf.moneda.cod},
                { "idorden",transf.idorden}
            };

            return this.getUpdate().updateSchemaById(schema, "transferencias", "idtransf", transf.idtransf);
        }
    }
}
