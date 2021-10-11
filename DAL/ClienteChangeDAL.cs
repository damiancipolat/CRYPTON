using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE;
using DAL.DAO;

namespace DAL
{
    public class ClienteChangeDAL : AbstractDAL<ClienteChangeBE>
    {
        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private ClienteChangeBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            ClienteChangeBE userTarget = new ClienteChangeBE();

            //Bindeo campos con la lista de resultados.
            this.binder.match(fieldData, userTarget);

            return userTarget;
        }

        //Este metodo obtiene en base al ID el usuario.
        public List<ClienteChangeBE> findByCliente(long id)
        {
            //Busco en la bd por email.
            List<Object> result = this.getSelect().selectAnd(new Dictionary<string, Object>{
                {"idcliente",id}
            }, "cliente_cambios");

            //Lista resultado.
            List<ClienteChangeBE> lista = new List<ClienteChangeBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Este metodo obtiene en base al ID el usuario.
        public ClienteChangeBE findById(long id)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("cliente_cambios", "idchange", id);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Este metodo retorna una lista de clientes.
        public List<ClienteChangeBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("cliente_cambios");

            //Lista resultado.
            List<ClienteChangeBE> lista = new List<ClienteChangeBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Agrega un nuevo usuario.
        public int insert(ClienteBE client)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{                
                {"change_date",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                {"idcliente",client.idcliente},
                {"tipoDoc",client.tipoDoc},
                {"numero",client.numero},
                {"fec_nac",client.fec_nac.ToString("yyyy-MM-dd HH:mm:ss")},
                {"num_tramite",client.num_tramite},
                {"domicilio",client.domicilio},
                {"telefono",client.telefono},
                {"cbu",client.cbu}
            };

            QueryInsert builder = new QueryInsert();
            return builder.insertSchema(schema, "cliente_cambios", true);
        }
    }
}
