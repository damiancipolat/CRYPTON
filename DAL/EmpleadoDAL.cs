using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace DAL
{
    public class EmpleadoDAL:AbstractDAL<EmpleadoBE>
    {
        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private EmpleadoBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            EmpleadoBE userTarget = new EmpleadoBE();

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
        public EmpleadoBE findById(long id)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("empleado", "idempleado", id);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Traigo por idusuario
        public EmpleadoBE findByUser(UsuarioBE user)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("empleado", "idusuario", user.idusuario);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);
        }

        //Este metodo retorna una lista de clientes.
        public List<EmpleadoBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("empleado");

            //Lista resultado.
            List<EmpleadoBE> lista = new List<EmpleadoBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Agrega un nuevo usuario.
        public int insert(EmpleadoBE employee)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"idusuario",employee.usuario.idusuario},
                {"legajo",employee.legajo }
            };
            
            return this.getInsert().insertSchema(schema, "empleado", true);
        }

        //Borra el usuario.
        public int delete(int id)
        {
            return this.getDelete().deleteById("idempleado", id, "empleado");
        }

        //Actualizar el usuario.
        public int update(EmpleadoBE employee)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"idusuario",employee.idusuario},
                {"legajo",employee.legajo }
            };

            return this.getUpdate().updateSchemaById(schema, "empleado", "idempleado", employee.idempleado);
        }
    }
}