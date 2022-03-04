using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class ClienteAgenda : AbstractDAL<ClienteAgendaBE>
    {
        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private ClienteAgendaBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            ClienteAgendaBE target = new ClienteAgendaBE();

            //Bindeo campos con la lista de resultados.
            this.binder.match(fieldData, target);

            return target;

        }

        //Este metodo obtiene en base al ID el usuario.
        public ClienteAgendaBE findById(int id)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("cliente_agenda", "idcontacto", id);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Este metodo retorna una lista de clientes.
        public List<ClienteAgendaBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("cliente_agenda");

            //Lista resultado.
            List<ClienteAgendaBE> lista = new List<ClienteAgendaBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Agrega un nuevo usuario.
        public int insert(ClienteAgendaBE contacto)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"idcliente",contacto.cliente.idcliente},
                { "moneda",contacto.moneda.cod},
                { "valor",contacto.valor}
            };

            return this.getInsert().insertSchema(schema, "cliente_agenda", true);
        }

        //Borra el usuario.
        public int delete(int id)
        {
            return this.getDelete().deleteById("idcontacto", id, "cliente_agenda");
        }

        //Actualizar el usuario.
        public int update(ClienteAgendaBE contacto)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{                
                {"idcliente",contacto.cliente.idcliente},
                { "moneda",contacto.moneda.cod},
                { "valor",contacto.valor}
            };

            return this.getUpdate().updateSchemaById(schema, "cliente_agenda", "idcontacto", contacto.idcontacto);
        }
    }
}