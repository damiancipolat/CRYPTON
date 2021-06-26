using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE.Permisos;
using BE;
using DAL.DAO;
using DAL.Permiso;

namespace DAL.Permiso
{
    public class PermisoUserDAL : DAL.PermisoDAL
    {
        //Obtiene recursivamente la lista de componentes filtrando por usuario.
        public List<Componente> FindAll(string familia, long userid)
        {
            //Obtengo el sql para buscar todos recursivamente.
            string sql = this.sqlGen.getAllByUser(familia, userid);
            Debug.WriteLine("QUERY:" + sql);

            return this.Find(sql);
        }

        //Traigo la lista de permisos para un usuario, setea el rol.
        public List<Componente> FindAllClient(UsuarioBE user)
        {
            string family = (user.tipoUsuario == UsuarioTipo.CLIENTE) ? "R002" : "R003";

            //Traigo la lista de permisos del rol cliente.
            return this.FindAll(family,user.idusuario);
        }

        //Bindeo un permiso a un usuario.
        public int bindToUser(string rol, string permiso, long userId)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"codrol",rol},
                {"codpermiso",permiso},
                {"idusuario",userId},
            };

            QueryInsert builder = new QueryInsert();
            return builder.insertSchema(schema, "rol_permiso", false);

        }

        //Creo nuevo permiso compuesto.
        public int createCompuesto(string codpermiso, string nombre)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"codpermiso",codpermiso},
                {"nombre",nombre},
                {"es_patente",0},
            };

            QueryInsert builder = new QueryInsert();
            return builder.insertSchema(schema, "permiso", false);

        }

        //Remuevo un permiso a un usuario.
        public int removeToUser(string rol, string permiso, long userId)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"codrol",rol},
                {"codpermiso",permiso},
                {"idusuario",userId }
            };

            QueryDelete builder = new QueryDelete();
            return builder.deleteSchema(schema, "rol_permiso");
        }
    }
}
