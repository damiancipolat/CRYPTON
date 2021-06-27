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
using DAL;

namespace DAL
{
    public class UsuarioDAL:AbstractDAL<UsuarioBE>
    {
        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private UsuarioBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count== 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            UsuarioBE userTarget = new UsuarioBE();

            //Bindeo campos con la lista de resultados.
            this.binder.match(fieldData, userTarget);

            //Actualizo el tipo de usuario que es un enum.            
            Dictionary<string, object> mapa = this.getParser().rowToDictionary(fieldData);
            userTarget.tipoUsuario = (UsuarioTipo)mapa["tipo_usuario"];
            
            //Blanqueo el campo de password.
            userTarget.pwd = "";

            return userTarget;

        }

        //Buscar usuarios en base a texto.
        public List<UsuarioBE> searchByText(string text)
        {
            //Ejecuto la consulta.
            string sql = "select us.* from usuario as us "+
                "where us.apellido like '%"+text+"%'"+
                "or us.nombre like '%"+text+"%'"+
                "or us.email like '%"+text+"%';";

            List<object> result = this.getSelect().queryList(sql);

            //Lista resultado.
            List<UsuarioBE> lista = new List<UsuarioBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Este metodo obtiene en base al ID el usuario.
        public UsuarioBE findById(int id)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("usuario", "idusuario", id);

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

        //Este metodo retorna una lista de usuarios.
        public List<UsuarioBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("usuario");

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
            List<Object> result = this.getSelect().selectAnd(new Dictionary<string, Object>{
                {"email",email},
                { "pwd",pwd}
            }, "usuario");

            if (result.Count == 0)
                return null;

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);
        }

        //Borra el usuario.
        public int delete(int id)
        {            
            return this.getDelete().deleteById("idusuario", id, "usuario");
        }

        //Actualizar el usuario.
        public int update(UsuarioBE user)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"nombre",user.nombre},
                { "apellido",user.apellido},
                { "alias",user.alias},
                { "email",user.email},
                { "tipo_usuario",(int)user.tipoUsuario},
                { "pwd",user.pwd},
                { "hash",user.hash}
            };

            return this.getUpdate().updateSchemaById(schema,"usuario","idusuario",user.idusuario);
        }

        //Agrega un nuevo usuario.
        public int save(UsuarioBE user)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"nombre",user.nombre},
                { "apellido",user.apellido},
                { "alias",user.alias},
                { "email",user.email},
                { "tipo_usuario",(int)user.tipoUsuario},
                { "pwd",user.pwd},
                { "hash",user.hash}
            };

            return this.getInsert().insertSchema(schema, "usuario",true);
        }

        //Obtener el hash completo de la entidad.
        public string getEntityHash()
        {
            List<object> result = this.getSelect().selectAll("usuario");
            string summarizedHash = "";

            foreach (List<object> register in result)
                summarizedHash = summarizedHash + new SqlParser().rowToDictionary(register)["hash"];

            return summarizedHash;
        }
    }
}