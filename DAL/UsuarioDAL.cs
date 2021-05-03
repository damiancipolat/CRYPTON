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
        //Bindea el schema de usuario con el data reader.
        private UsuarioBE bindSchema(List<Object> result)
        {
            if (!(result.Count > 0))
                return null;

            //Cargo el resultado en un mapa para traer los campos que no se pueden bindear directo.
            SqlParser parser = new SqlParser();
            Dictionary<string, object> mapa = parser.rowToDictionary(((IEnumerable)result[0]).Cast<object>().ToList());

            //Armo el usuario resultado.
            UsuarioBE userTarget = new UsuarioBE();

            //Bindeo campos
            EntityBinder.bindOne(result, userTarget);

            //Bindeo el tipo de usuario a enum.
            userTarget.tipoUsuario = (UsuarioTipo)mapa["tipo_usuario"];

            return userTarget;
        }

        //Este metodo obtiene en base al ID el usuario.
        public UsuarioBE findById(int id)
        {
            //Busco en la bd por id.
            List<object> result = new QuerySelect().selectById("usuario", "idusuario", id);

            //Bindeo con el esquema.
            return this.bindSchema(result);

        }

        //Buscar usuario y contraseña.
        public UsuarioBE login(string email, string pwd)
        {
            //Armo el query con un where con schema.
            List<Object> result = new QuerySelect().selectAnd(new Dictionary<string, Object>{
                {"email",email},
                { "pwd",pwd}
            }, "usuario");

            //Bindeo con el esquema.
            return this.bindSchema(result);
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