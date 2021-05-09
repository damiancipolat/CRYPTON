using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Permisos;
using DAL.DAO;

namespace DAL.Permiso
{
    public class UsuarioPermisoDAL
    {
        public int insert(UsuarioPermiso userPermisoBE)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"idusuario",userPermisoBE.idusuario},
                { "idpermiso",userPermisoBE.idpermiso}
            };

            QueryInsert builder = new QueryInsert();
            return builder.insertSchema(schema, "usuario_permiso",false);
        }
    }
}
