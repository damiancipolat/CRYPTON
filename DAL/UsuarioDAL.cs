using System;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE;
using DAL.DAO;

namespace DAL
{
    public class UsuarioDAL
    {

        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private UsuarioBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count== 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            UsuarioBE userTarget = new UsuarioBE();

            //Bindeo campos con la lista de resultados.
            new EntityBinder().match(fieldData, userTarget);

            //Actualizo el tipo de usuario que es un enum.            
            Dictionary<string, object> mapa = new SqlParser().rowToDictionary(fieldData);
            userTarget.tipoUsuario = (UsuarioTipo)mapa["tipo_usuario"];

            //Blanqueo el campo de password.
            userTarget.pwd = "";

            return userTarget;

        }

        //Este metodo obtiene en base al ID el usuario.
        public UsuarioBE findById(int id)
        {
            //Busco en la bd por id.
            List<object> result = new QuerySelect().selectById("usuario", "idusuario", id);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Este metodo retorna una lista de usuarios.
        public List<UsuarioBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = new QuerySelect().selectAll("usuario");

            //Lista resultado.
            List<UsuarioBE> lista = new List<UsuarioBE>();
            
            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Buscar usuario y contraseña.
        public UsuarioBE login(string email, string pwd)
        {
            //Armo el query con un where con schema.
            List<Object> result = new QuerySelect().selectAnd(new Dictionary<string, Object>{
                {"email",email},
                { "pwd",pwd}
            }, "usuario");

            if (result.Count == 0)
                return null;

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);
        }

        //Agrega un nuevo usuario.
        public int insert(UsuarioBE user)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"nombre",user.nombre},
                { "apellido",user.apellido},
                { "alias",user.alias},
                { "email",user.email},
                { "tipo_usuario",(int)user.tipoUsuario},
                { "pwd",user.pwd},
                { "user",user.hash}
            };

            QueryInsert builder = new QueryInsert();
            return builder.insertSchema(schema, "usuario");
        }

        //Obtener el hash completo de la entidad.
        public string getEntityHash()
        {
            List<object> result = new QuerySelect().selectAll("usuario");
            string summarizedHash = "";

            foreach (List<object> register in result)
                summarizedHash = summarizedHash + new SqlParser().rowToDictionary(register)["hash"];

            return summarizedHash;
        }
    }
}