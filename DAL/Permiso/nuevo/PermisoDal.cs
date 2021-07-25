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

namespace DAL.Permiso.nuevo
{
    public class PermisoDAL
    {
        private Componente2 GetComponent(int id, IList<Componente2> lista)
        {
            Componente2 component = lista != null ? lista.Where(i => i.Id.Equals(id)).FirstOrDefault() : null;

            if (component == null && lista != null)
            {
                foreach (var c in lista)
                {
                    var l = GetComponent(id, c.Hijos);
                    if (l != null && l.Id == id)
                        return l;
                    else
                    {
                        if (l != null)
                            return GetComponent(id, l.Hijos);
                    }
                }
            }

            return component;
        }

        public IList<Componente2> GetAll(string familia)
        {
            string where = "is NULL";
            if (!String.IsNullOrEmpty(familia))
                where = familia;

            //Armo el query recursivo.
            string sql = $@"with recursivo as (
                        select sp2.id_permiso_padre, sp2.id_permiso_hijo  from permiso_permiso_new SP2
                        where sp2.id_permiso_padre {where}
                        UNION ALL 
                        select sp.id_permiso_padre, sp.id_permiso_hijo from permiso_permiso_new sp 
                        inner join recursivo r on r.id_permiso_hijo= sp.id_permiso_padre
                        )
                        select r.id_permiso_padre,r.id_permiso_hijo,p.id,p.nombre, p.permiso
                        from recursivo r 
                        inner join permiso_new p on r.id_permiso_hijo = p.id ";

            //Hago la consulta.
            QuerySelect builder = new QuerySelect();
            SqlDataReader reader = builder.query(sql);

            var lista = new List<Componente2>();
            while (reader.Read())
            {
                int id_padre = 0;
                if (reader["id_permiso_padre"] != DBNull.Value)
                    id_padre = reader.GetInt32(reader.GetOrdinal("id_permiso_padre"));

                int id = reader.GetInt32(reader.GetOrdinal("id"));
                string nombre = reader.GetString(reader.GetOrdinal("nombre"));
                string permiso = (reader["permiso"] != DBNull.Value)?reader.GetString(reader.GetOrdinal("permiso")):string.Empty;

                Componente2 c;
                if (string.IsNullOrEmpty(permiso))
                    c = new Familia2();
                else
                    c = new Patente2();

                c.Id = id;
                c.Nombre = nombre;

                var padre = GetComponent(id_padre, lista);

                if (padre == null)
                    lista.Add(c);
                else
                    padre.AgregarHijo(c);
            }

            reader.Close();
            return lista;
        }

        public void FillFamilyComponents(Familia2 familia)
        {
            familia.VaciarHijos();
            foreach (var item in GetAll("=" + familia.Id))
                familia.AgregarHijo(item);
        }
        
        public void GuardarFamilia(Familia2 c)
        {
            //Borro el permiso root.
            QueryDelete builderDelete = new QueryDelete();
            builderDelete.deleteById("id_permiso_padre", c.Id, "permiso_permiso_new");

            //Agrego recursivamente.
            foreach (var item in c.Hijos)
            {   
                var schema = new Dictionary<string, Object>{
                    {"id_permiso_padre",c.Id},
                    {"id_permiso_hijo", item.Id }
                };

                QueryInsert builderInsert = new QueryInsert();
                builderInsert.insertSchema(schema, "permiso_permiso_new", false);
            }
        }
    }
}