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
    public class ClienteDAL : AbstractDAL<ClienteBE>
    {
        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private ClienteBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            ClienteBE userTarget = new ClienteBE();

            //Bindeo campos con la lista de resultados.
            new EntityBinder().match(fieldData, userTarget);

            return userTarget;

        }

        private string getString(object o)
        {
            if (o == DBNull.Value) return null;
            return (string)o;
        }

        //Este metodo obtiene en base al ID el usuario.
        public UsuarioBE findById(int id)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("cliente", "idcliente", id);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Este metodo retorna una lista de clientes.
        public List<ClienteBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("cliente");

            //Lista resultado.
            List<ClienteBE> lista = new List<ClienteBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Agrega un nuevo usuario.
        public int insert(ClienteBE client)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"idusuario",client.usuario.idusuario},
                {"tipoDoc",client.tipoDoc},
                {"numero",client.numero},
                {"fec_nac",client.fec_nac},
                {"num_tramite",client.num_tramite},
                {"domicilio",client.domicilio},
                {"telefono",client.telefono},
                {"valido",client.valido}
            };

            QueryInsert builder = new QueryInsert();
            return builder.insertSchema(schema, "cliente", true);
        }

        //Borra el usuario.
        public int delete(int id)
        {
            return this.getDelete().deleteById("idcliente", id, "cliente");
        }

        //Actualizar el usuario.
        public int update(ClienteBE client)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"tipoDoc",client.tipoDoc},
                {"numero",client.numero},
                {"fec_nac",client.fec_nac},
                {"num_tramite",client.num_tramite},
                {"domicilio",client.domicilio},
                {"telefono",client.telefono},
                {"valido",client.valido}
            };

            return this.getUpdate().updateSchemaById(schema, "cliente", "idusuario", client.idcliente);
        }
    }
}
