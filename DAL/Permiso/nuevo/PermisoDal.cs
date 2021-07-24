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
       /* public IList<Familia> GetAllFamilias()
        {
            //Instancio el sql builder y ejecuto el query.
            string sql = "select * from permiso p where p.permiso is  null;";
            QuerySelect builder = new QuerySelect();
            SqlDataReader reader = builder.query(sql);

            var lista = new List<Familia>();

            while (reader.Read())
            {
                var id = reader.GetInt32(reader.GetOrdinal("id"));
                var nombre = reader.GetString(reader.GetOrdinal("nombre"));
                Familia c = new Familia();

                //c.Cod
               // c.Id = id;
                c.Nombre = nombre;
                lista.Add(c);
            }

            reader.Close();
            cnn.Close();


            return lista;
        }*/

    }
}
    /*
        public class PermisosRepository
        {

            public Array GetAllPermission()
            {
                return Enum.GetValues(typeof(TipoPermiso));
            }

            private string GetConnectionString()
            {
                var cs = new SqlConnectionStringBuilder("Server=localhost\\SQLEXPRESS02;Database=Practica;Trusted_Connection=True;");
                return cs.ConnectionString;
            }

            public Componente GuardarComponente(Componente p, bool esfamilia)
            {
                try
                {
                    var cnn = new SqlConnection(GetConnectionString());
                    cnn.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = cnn;

                    var sql = $@"insert into permiso (nombre,permiso) values (@nombre,@permiso);  SELECT ID AS LastID FROM permiso WHERE ID = @@Identity;       ";

                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("nombre", p.Nombre));


                    if (esfamilia)
                        cmd.Parameters.Add(new SqlParameter("permiso", DBNull.Value));

                    else
                        cmd.Parameters.Add(new SqlParameter("permiso", p.Permiso.ToString()));

                    var id = cmd.ExecuteScalar();
                    p.Id = (int)id;
                    return p;
                }
                catch (Exception e)
                {


                    throw e;
                }


            }

            public void GuardarFamilia(Familia c)
            {

                try
                {
                    var cnn = new SqlConnection(GetConnectionString());
                    cnn.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = cnn;


                    var sql = $@"delete from permiso_permiso where id_permiso_padre=@id;       ";

                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("id", c.Id));
                    cmd.ExecuteNonQuery();

                    foreach (var item in c.Hijos)
                    {
                        cmd = new SqlCommand();
                        cmd.Connection = cnn;


                        sql = $@"insert into permiso_permiso (id_permiso_padre,id_permiso_hijo) values (@id_permiso_padre,@id_permiso_hijo) ";

                        cmd.CommandText = sql;
                        cmd.Parameters.Add(new SqlParameter("id_permiso_padre", c.Id));
                        cmd.Parameters.Add(new SqlParameter("id_permiso_hijo", item.Id));

                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }

            public IList<Patente> GetAllPatentes()
            {

                var cnn = new SqlConnection(GetConnectionString());
                cnn.Open();
                var cmd = new SqlCommand();
                cmd.Connection = cnn;

                var sql = $@"select * from permiso p where p.permiso is not null;";

                cmd.CommandText = sql;

                var reader = cmd.ExecuteReader();

                var lista = new List<Patente>();

                while (reader.Read())
                {


                    var id = reader.GetInt32(reader.GetOrdinal("id"));
                    var nombre = reader.GetString(reader.GetOrdinal("nombre"));
                    var permiso = reader.GetString(reader.GetOrdinal("permiso"));


                    Patente c = new Patente();

                    c.Id = id;
                    c.Nombre = nombre;
                    c.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permiso);
                    lista.Add(c);

                }
                reader.Close();
                cnn.Close();


                return lista;
            }
            
            public IList<Componente> GetAll(string familia)
            {
                var where = "is NULL";

                if (!String.IsNullOrEmpty(familia))
                {
                    where = familia;
                }

                var cs = new SqlConnectionStringBuilder("Server=localhost\\SQLEXPRESS02;Database=Practica;Trusted_Connection=True;");
                var cnn = new SqlConnection(cs.ConnectionString);
                cnn.Open();
                var cmd = new SqlCommand();
                cmd.Connection = cnn;

                var sql = $@"with recursivo as (
                        select sp2.id_permiso_padre, sp2.id_permiso_hijo  from permiso_permiso SP2
                        where sp2.id_permiso_padre {where} --acá se va variando la familia que busco
                        UNION ALL 
                        select sp.id_permiso_padre, sp.id_permiso_hijo from permiso_permiso sp 
                        inner join recursivo r on r.id_permiso_hijo= sp.id_permiso_padre
                        )
                        select r.id_permiso_padre,r.id_permiso_hijo,p.id,p.nombre, p.permiso
                        from recursivo r 
                        inner join permiso p on r.id_permiso_hijo = p.id 
						
                        ";

                cmd.CommandText = sql;

                var reader = cmd.ExecuteReader();

                var lista = new List<Componente>();

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

                    if (string.IsNullOrEmpty(permiso))//usamos este campo para identificar. Solo las patentes van a tener un permiso del sistema relacionado
                        c = new Familia();

                    else
                        c = new Patente();

                    c.Id = id;
                    c.Nombre = nombre;
                    if (!string.IsNullOrEmpty(permiso))
                        c.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permiso);

                    var padre = GetComponent(id_padre, lista);

                    if (padre == null)
                    {
                        lista.Add(c);
                    }
                    else
                    {
                        padre.AgregarHijo(c);
                    }



                }
                reader.Close();
                cnn.Close();


                return lista;
            }
                                          
            private Componente GetComponent(int id, IList<Componente> lista)
            {

                Componente component = lista != null ? lista.Where(i => i.Id.Equals(id)).FirstOrDefault() : null;

                if (component == null && lista != null)
                {
                    foreach (var c in lista)
                    {

                        var l = GetComponent(id, c.Hijos);
                        if (l != null && l.Id == id) return l;
                        else
                        if (l != null)
                            return GetComponent(id, l.Hijos);

                    }
                }



                return component;



            }

            public void FillUserComponents(Usuario u)
            {

                var cnn = new SqlConnection(GetConnectionString());
                cnn.Open();

                var cmd2 = new SqlCommand();
                cmd2.Connection = cnn;
                cmd2.CommandText = $@"select p.* from usuarios_permisos up inner join permiso p on up.id_permiso=p.id where id_usuario=@id;";
                cmd2.Parameters.AddWithValue("id", u.Id);

                var reader = cmd2.ExecuteReader();
                u.Permisos.Clear();
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
                        c1.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permisop);
                        u.Permisos.Add(c1);
                    }
                    else
                    {
                        c1 = new Familia();
                        c1.Id = idp;
                        c1.Nombre = nombrep;

                        var f = GetAll("=" + idp);

                        foreach (var familia in f)
                        {
                            c1.AgregarHijo(familia);
                        }
                        u.Permisos.Add(c1);
                    }



                }
                reader.Close();

            }

        public void FillFamilyComponents(Familia familia)
            {
                familia.VaciarHijos();
                foreach (var item in GetAll("=" + familia.Id))
                {
                    familia.AgregarHijo(item);
                }
            }
        }*
    }*/
