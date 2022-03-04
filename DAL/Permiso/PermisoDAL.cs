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

namespace DAL.Permiso
{
    public class PermisoDAL
    {
        //Busco dentro del arbol por nombre.
        private Componente GetComponentByName(string name, IList<Componente> lista)
        {
            Componente component = lista != null ? lista.Where(i => i.Nombre.Equals(name)).FirstOrDefault() : null;

            if (component == null && lista != null)
            {
                foreach (var c in lista)
                {
                    var l = GetComponentByName(name, c.Hijos);
                    if (l != null && l.Nombre == name)
                        return l;
                    else
                    {
                        if (l != null)
                            return GetComponentByName(name, l.Hijos);
                    }
                }
            }

            return component;
        }

        //Busco dentro del arbol por id.
        private Componente GetComponent(int id, IList<Componente> lista)
        {
            Componente component = lista != null ? lista.Where(i => i.Id.Equals(id)).FirstOrDefault() : null;
            
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

        public IList<Componente> GetAll(string familia)
        {
            string where = "is NULL";

            if (!String.IsNullOrEmpty(familia))
                where = familia;

            string sql = $@"with recursivo as (
                        select sp2.id_permiso_padre, sp2.id_permiso_hijo  from permiso_permiso SP2
                        where sp2.id_permiso_padre {where} --acá se va variando la familia que busco
                        UNION ALL 
                        select sp.id_permiso_padre, sp.id_permiso_hijo from permiso_permiso sp 
                        inner join recursivo r on r.id_permiso_hijo= sp.id_permiso_padre
                        )
                        select r.id_permiso_padre,r.id_permiso_hijo,p.id,p.nombre, p.permiso
                        from recursivo r 
                        inner join permiso p on r.id_permiso_hijo = p.id
                        order by p.permiso";

            //Hago la consulta.
            QuerySelect builder = new QuerySelect();
            SqlDataReader reader = builder.query(sql);

            List<Componente> lista = new List<Componente>();

            while (reader.Read())
            {
                int id_padre = 0;
                if (reader["id_permiso_padre"] != DBNull.Value)
                {
                    id_padre = reader.GetInt32(reader.GetOrdinal("id_permiso_padre"));
                }

                var id = reader.GetInt32(reader.GetOrdinal("id"));
                var nombre = reader.GetString(reader.GetOrdinal("nombre"));

                var permiso = string.Empty;
                if (reader["permiso"] != DBNull.Value)
                    permiso = reader.GetString(reader.GetOrdinal("permiso"));

                Componente c;

                if (string.IsNullOrEmpty(permiso))
                    c = new Familia();
                else
                    c = new Patente();

                c.Id = id;
                c.Nombre = nombre;

                var padre = GetComponent(id_padre, lista);

                if (padre == null)
                    lista.Add(c);
                else
                    padre.AgregarHijo(c);
            }

            //Cierro el cursor.
            reader.Close();

            //Cierro la conexion.
            builder.closeConnection();

            return lista;
        }

        public void FillFamilyComponents(Familia familia)
        {
            familia.VaciarHijos();
            foreach (var item in GetAll("=" + familia.Id))
                familia.AgregarHijo(item);
        }

        public int remove(int padre, int hijo)
        {
            var schema = new Dictionary<string, Object>{
                    {"id_permiso_padre",padre},
                    {"id_permiso_hijo",hijo}
            };

            QueryDelete builderDelete = new QueryDelete();
            return builderDelete.deleteSchema(schema, "permiso_permiso");
        }

        public int save(int padre, int hijo)
        {
            var schema = new Dictionary<string, Object>{
                    {"id_permiso_padre",padre},
                    {"id_permiso_hijo", hijo }
                };

            QueryInsert builderInsert = new QueryInsert();
            return builderInsert.insertSchema(schema, "permiso_permiso", false);
        }

        //Revisa si el codigo de permiso existe en la list recursivamente.
        public bool hasPermission(IList<Componente> lista, int id)
        {
            return this.GetComponent(id, lista)!=null;
        }

        //Revisa si el codigo de permiso existe en la list recursivamente busca por nombre.
        public bool hasPermissionByName(IList<Componente> lista, string name)
        {
            return this.GetComponentByName(name, lista) != null;
        }
    }
}