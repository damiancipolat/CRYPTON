using System;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.DAO;

namespace DAL
{
    public class UsuarioDAL
    {
        //Bindea el schema de usuario con el data reader.
        private UsuarioBE bindWithData(List<Object> result, QuerySelect builder)
        {
            if (!(result.Count > 0))
                return null;

            //Cargo el resultado en un mapa para traer los campos que no se pueden bindear directo.
            List<object> row = ((IEnumerable)result[0]).Cast<object>().ToList();
            Dictionary<string, object> mapa = builder.getAsDictionary(row);

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
            QuerySelect builder = new QuerySelect();
            List<object> result = builder.selectById("usuario", "idusuario", id);

            //Bindeo con el esquema.
            return this.bindWithData(result, builder);

        }

        //Buscar usuario y contraseña.
        public UsuarioBE login(string email, string pwd)
        {
            //Armo el query.
            QuerySelect builder = new QuerySelect();

            //Ejecuto y parseo a una list para poder hacer binding.
            SqlDataReader data = builder.query("select * from usuario where email='" + email+"' and pwd='" + pwd + "';");
            List<Object> result = builder.bindWithList(data);

            //Bindeo con el esquema.
            return this.bindWithData(result, builder);
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
                { "pwd",user.pwd}
            };

            QueryInsert builder = new QueryInsert();
            return builder.insertSchema(schema, "usuario");
        }
    }
}
