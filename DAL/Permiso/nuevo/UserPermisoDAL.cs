using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using BE.Permisos;
using BE;
using DAL.DAO;
using DAL.Permiso;

namespace DAL.Permiso.nuevo
{
    public class UserPermisoDAL
    {
        public void FillUserComponents(UsuarioBE u)
        {
            //Hago la consulta.
            string sql = "select p.* from usuarios_permisos up inner join permiso_new p on up.id_permiso=p.id where id_usuario=" + u.idusuario;
            QuerySelect builder = new QuerySelect();
            SqlDataReader reader = builder.query(sql);

            while (reader.Read())
            {
                var idp = reader.GetInt32(reader.GetOrdinal("id"));
                var nombrep = reader.GetString(reader.GetOrdinal("nombre"));

                var permisop = String.Empty;
                if (reader["permiso"] != DBNull.Value)
                    permisop = reader.GetString(reader.GetOrdinal("permiso"));

                Componente2 c1;
                if (!String.IsNullOrEmpty(permisop))
                {
                    c1 = new Patente2();
                    c1.Id = idp;
                    c1.Nombre = nombrep;
                    u.Permisos.Add(c1);
                }
                else
                {
                    c1 = new Familia2();
                    c1.Id = idp;
                    c1.Nombre = nombrep;

                    var f = new PermisoDAL().GetAll("=" + idp);

                    foreach (var familia in f)
                    {
                        c1.AgregarHijo(familia);
                    }
                    u.Permisos.Add(c1);
                }
            }
            reader.Close();
        }
      
        public void save(int userId, int permisoId)
        {
            QueryInsert builder = new QueryInsert();

            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"id_usuario",userId},
                {"id_permiso",permisoId}
            };

            builder.insertSchema(schema, "usuarios_permisos", false);
        }

        public void delete(int userId, int permisoId)
        {
            QueryDelete builder = new QueryDelete();

            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"id_usuario",userId},
                {"id_permiso",permisoId}
            };

            builder.deleteSchema(schema, "usuarios_permisos");
        }
    }
}