using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Permiso
{
    public class PermisoSQL
    {
        //Retorna el sql para traer la lista de permisos sin filtro.
        public string getAll(string familia)
        {
            //Seteo el where.
            string where = (!String.IsNullOrEmpty(familia)) ? "="+familia : "is NULL";

            //Genero el sql.
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

            return sql;
        }

        //Trae la lista completa de permisos filtrando por idusuario.
        public string getAllByUser(string familia,int userid)
        {
            //Seteo el where.
            string where = (!String.IsNullOrEmpty(familia)) ? "="+familia : "is NULL";

            //Genero el sql.
            string sql = $@"with recursivo as(
               select sp2.idrol, sp2.idpermiso from rol_permiso SP2
               where sp2.idrol {where}
               UNION ALL
               select sp.idrol, sp.idpermiso from rol_permiso sp
               inner join recursivo r on r.idpermiso = sp.idrol
            ) 
            select r.idrol,r.idpermiso,p.idpermiso as id,p.nombre, p.es_patente
            from recursivo r
            inner join permiso p on r.idpermiso = p.idpermiso
            inner join usuario_permiso up on up.idpermiso = p.idpermiso
            where up.idusuario = {userid};";

            return sql;
        }

    }
}
