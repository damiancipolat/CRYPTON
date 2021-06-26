using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using BE.Permisos;
using DAL.DAO;
using DAL.Permiso;
using BE;
using BE.Permisos;

namespace DAL.Permiso
{
    public class PermisoTodoDAL : DAL.PermisoDAL
    {
        //Obtiene recursivamente la lista de componentes.
        public List<Componente> FindAll(string familia)
        {
            //Obtengo el sql para buscar todos recursivamente.
            string sql = this.sqlGen.getAll(familia);
            Debug.WriteLine("QUERY:" + sql);

            return this.Find(sql);
        }

        //Traigo la lista de permisos.
        public List<Componente> GetRaw()
        {
            string sql = this.sqlGen.getAllRaw();

            //Instancio el sql builder.
            QuerySelect builder = new QuerySelect();
            SqlDataReader reader = builder.query(sql);

            List<Componente> lista = new List<Componente>();

            while (reader.Read())
            {
                Componente comp = (Componente)new Patente();
                comp.Cod = reader.GetString(reader.GetOrdinal("codpermiso"));
                comp.Nombre = reader.GetString(reader.GetOrdinal("nombre"));
                //comp.esPatente = Convert.ToBoolean(reader.GetInt32(reader.GetOrdinal("es_patente")));
                lista.Add(comp);
            }

            return lista;
        }
    }
}
