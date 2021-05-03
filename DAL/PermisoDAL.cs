using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using BE.Permisos;
using DAL.DAO;

namespace DAL
{
    public class PermisoDAL
    {
        //Bindea los registros y le da forma de arbol.
        private List<Componente> bindAll(SqlDataReader reader)
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

        //Obtiene recursivamente la lista de componentes.
        public IList<Componente> FindAll(string familia)
        {
            //Seteo el where.
            string where = (!String.IsNullOrEmpty(familia)) ? familia : "is NULL";

            //Sql recursivo.
            string sql = $@"with recursivo as(
               select sp2.idrol, sp2.idpermiso from rol_permiso SP2
               where sp2.idrol {where}
               UNION ALL
               select sp.idrol, sp.idpermiso from rol_permiso sp
               inner join recursivo r on r.idpermiso = sp.idrol
            ) 
            select r.idrol,r.idpermiso,p.idpermiso as id,p.nombre, p.es_patente
            from recursivo r
            inner join permiso p on r.idpermiso = p.idpermiso";

            Debug.WriteLine("QUERY:"+sql);

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
        public bool hasPermission(int id)
        {
            IList<Componente> lista = this.FindAll(string.Empty);
            Componente c = this.GetComponent(id, lista);

            return c != null;
        }

        //Busca el componente recursivamente.
        private Componente GetComponent(int id, IList<Componente> lista)
        {
            Componente component = lista != null ? lista.Where(i => i.Id.Equals(id)).FirstOrDefault() : null;

            if (component == null && lista != null)
            {
                foreach (var c in lista)
                {

                    var l = this.GetComponent(id, c.Hijos);
                    if (l != null && l.Id == id)return l;
                    else
                    if (l != null)
                        return GetComponent(id, l.Hijos);

                }
            }

            return component;

        }

    }
}
