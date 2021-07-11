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
            this.binder.match(fieldData, userTarget);

            //Actualizo el tipo de usuario que es un enum.            
            Dictionary<string, object> mapa = this.getParser().rowToDictionary(fieldData);

            //Bindeo campos.
            UsuarioBE user = new UsuarioDAL().findById((long)mapa["idusuario"]);

            if (user != null)
            {
                userTarget.alias = user.alias;
                userTarget.nombre = user.nombre;
                userTarget.apellido = user.apellido;
                userTarget.email = user.email;
                userTarget.tipoUsuario = UsuarioTipo.CLIENTE;
            }

            return userTarget;
        }

        private string getString(object o)
        {
            if (o == DBNull.Value) return null;
            return (string)o;
        }

        //Este metodo obtiene en base al ID el usuario.
        public ClienteBE findById(long id)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("cliente", "idcliente", id);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Este metodo obtiene el cliente en base al usuariobe.
        public ClienteBE findByUser(UsuarioBE user)
        {
            List<object> result = this.getSelect().selectById("cliente", "idusuario", user.idusuario);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);
        }


        //Este metodo busca por email
        public List<UsuarioBE> findByEmail(string email)
        {
            //Busco en la bd por email.
            List<Object> result = this.getSelect().selectAnd(new Dictionary<string, Object>{
                {"email",email}
            }, "usuario");

            //Lista resultado.
            List<UsuarioBE> lista = new List<UsuarioBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Busca por dni.
        public List<ClienteBE> findByDNI(string dni)
        {
            //Busco en la bd por dni.
            List<Object> result = this.getSelect().selectAnd(new Dictionary<string, Object>{
                {"numero",dni}
            }, "cliente");

            //Lista resultado.
            List<ClienteBE> lista = new List<ClienteBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
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
                {"fec_nac",client.fec_nac.ToString("yyyy-MM-dd HH:mm:ss.fff")},
                {"num_tramite",client.num_tramite},
                {"domicilio",client.domicilio},
                {"telefono",client.telefono},
                {"valido",client.valido}
            };

            return this.getUpdate().updateSchemaById(schema, "cliente", "idusuario", client.idcliente);
        }
    }
}
