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

namespace DAL
{
    public class PermisoDAL
    {
        protected PermisoSQL sqlGen = new PermisoSQL();

        //Bindea los registros y le da forma de arbol.
        protected List<Componente> bindAll(SqlDataReader reader)
        {
            List<Componente> lista = new List<Componente>();

            while (reader.Read())
            {
                int id_padre = 0;

                if (reader["idrol"] != DBNull.Value)
                    id_padre = reader.GetInt32(reader.GetOrdinal("idrol"));

                //Bindeo campos a tipos.
                int id = reader.GetInt32(reader.GetOrdinal("id"));
                string nombre = reader.GetString(reader.GetOrdinal("nombre"));
                bool patente = reader.GetBoolean(reader.GetOrdinal("es_patente"));

                //Seteo la rama / hoja.
                Componente c = (!patente) ? (Componente)new Familia() : (Componente)new Patente();
 
                //Bindeo campos
                c.Id = id;
                c.Nombre = nombre;

                //Busco el padre.
                Componente padre = this.GetComponent(id_padre, lista);

                if (padre == null)
                    lista.Add(c);
                else
                    padre.AgregarHijo(c);

            }

            return lista;
        }

        //Busca el componente recursivamente.
        protected Componente GetComponent(int id, IList<Componente> lista)
        {
            Componente component = lista != null ? lista.Where(i => i.Id.Equals(id)).FirstOrDefault() : null;

            if (component == null && lista != null)
            {
                foreach (var c in lista)
                {

                    var l = this.GetComponent(id, c.Hijos);
                    if (l != null && l.Id == id) return l;
                    else
                    if (l != null)
                        return GetComponent(id, l.Hijos);

                }
            }

            return component;

        }
     
        //Ejecuta la busqueda tanto por cliente o libre.
        protected IList<Componente> Find(string sql)
        {
            //Instancio el sql builder.
            QuerySelect builder = new QuerySelect();
            SqlDataReader reader = builder.query(sql);

            //Parseo el data reader a lista.
            List<Componente> lista = this.bindAll(reader);

            //Cierro punteros.
            reader.Close();
            builder.closeConnection();

            return lista;
        }
    }
}
