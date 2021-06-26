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
                string id_padre = "";

                if (reader["codrol"] != DBNull.Value)
                    id_padre = reader.GetString(reader.GetOrdinal("codrol"));

                //Bindeo campos a tipos.
                string cod = reader.GetString(reader.GetOrdinal("id"));
                string nombre = reader.GetString(reader.GetOrdinal("nombre"));
                bool patente = reader.GetBoolean(reader.GetOrdinal("es_patente"));

                //Seteo la rama / hoja.
                Componente c = (!patente) ? (Componente)new Familia() : (Componente)new Patente();
 
                //Bindeo campos
                c.Cod = cod;
                c.Nombre = nombre;

                //Busco el padre.
                Componente padre = this.GetComponent(id_padre, lista);

                if (padre == null)
                    lista.Add(c);
                else
                {
                    Debug.WriteLine("****hijos:"+c.Cod);
                    padre.AgregarHijo(c);
                }                    

            }

            return lista;
        }

        //Busca el componente recursivamente.
        protected Componente GetComponent(string id, IList<Componente> lista)
        {
            Componente component = lista != null ? lista.Where(i => i.Cod.Equals(id)).FirstOrDefault() : null;

            if (component == null && lista != null)
            {
                foreach (var c in lista)
                {
                    var l = this.GetComponent(id, c.Hijos);
                    if (l != null && l.Cod == id) return l;
                    else
                    if (l != null)
                        return GetComponent(id, l.Hijos);

                }
            }

            return component;

        }

        //Ejecuta la busqueda tanto por cliente o libre.
        protected List<Componente> Find(string sql)
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

        //Revisa si el codigo de permiso existe en la list recursivamente.
        public bool hasPermission(IList<Componente> lista, string id)
        {
            Componente c = this.GetComponent(id, lista);
            
            return c != null;
        }
    }
}
