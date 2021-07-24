using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using BE;
using BE.Permisos;
using DAL;
using DAL.DAO;

namespace DAL.Permiso.nuevo
{
    public class PatenteDAL
    {
        public int save(string value)
        {
            var schema = new Dictionary<string, Object>{
                {"nombre",value},
                {"permiso", value}
            };

            QueryInsert builder = new QueryInsert();
            return builder.insertSchema(schema, "permiso_new", true);
        }

        public int delete(int id)
        {
            QueryDelete builder = new QueryDelete();
            return builder.deleteById("id", id, "permiso_new");
        }

        public List<Patente2> getAll()
        {
            //Instancio el sql builder y ejecuto el query.
            string sql = "select * from permiso_new p where p.permiso is not null;";
            QuerySelect builder = new QuerySelect();
            SqlDataReader reader = builder.query(sql);

            var lista = new List<Patente2>();

            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("id"));
                string nombre = reader.GetString(reader.GetOrdinal("nombre"));

                Patente2 c = new Patente2();
                c.Id = id;
                c.Nombre = nombre;
                lista.Add(c);
            }

            reader.Close();
            return lista;
        }
    }
}
