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

namespace DAL.Permiso
{
    public class UserPermisoDAL
    {
        public List<Componente> getPermmision(UsuarioBE user)
        {
            List<Componente> permList = new List<Componente>();

            //Hago la consulta.
            string sql = "select p.* from usuarios_permisos up inner join permiso p on up.id_permiso=p.id where id_usuario=" + user.idusuario;
            
            //Abro conexion.
            QuerySelect builder = new QuerySelect();
            SqlDataReader reader = builder.query(sql);

            //Parsear datos.
            while (reader.Read())
            {
                var idp = reader.GetInt32(reader.GetOrdinal("id"));
                var nombrep = reader.GetString(reader.GetOrdinal("nombre"));

                var permisop = String.Empty;
                if (reader["permiso"] != DBNull.Value)
                    permisop = reader.GetString(reader.GetOrdinal("permiso"));

                Componente c1;
                if (!String.IsNullOrEmpty(permisop))
                {
                    c1 = new Patente();
                    c1.Id = idp;
                    c1.Nombre = nombrep;
                    permList.Add(c1);
                }
                else
                {
                    c1 = new Familia();
                    c1.Id = idp;
                    c1.Nombre = nombrep;

                    var f = new PermisoDAL().GetAll("=" + idp);

                    foreach (var familia in f)
                    {
                        c1.AgregarHijo(familia);
                    }
                    permList.Add(c1);
                }
            }

            //Cierro conexion.
            reader.Close();

            return permList;
        }

        public void FillUserComponents(UsuarioBE u)
        {
            //Traigo la lista de permisos.
            List<Componente> permList = this.getPermmision(u);

            //Agrego los permisos.
            u.Permisos.AddRange(permList);
        }
      
        public void save(long userId, int permisoId)
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

        public Patente findByName(string name)
        {
            //Instancio el sql builder y ejecuto el query.
            string sql = "select * from permiso p where nombre='"+name+"';";
            QuerySelect builder = new QuerySelect();
            SqlDataReader reader = builder.query(sql);

            if (reader.HasRows)
            {
                //Leo un registro.
                reader.Read();

                //Cargo la patente.
                Patente c = new Patente();
                c.Id = reader.GetInt32(reader.GetOrdinal("id"));
                c.Nombre = reader.GetString(reader.GetOrdinal("nombre"));

                return c;
            }

            //Cierro la conexion.
            builder.closeConnection();

            return null;
        }

    }
}