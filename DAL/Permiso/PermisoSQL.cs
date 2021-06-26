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
            string where = (!String.IsNullOrEmpty(familia)) ? "='"+familia+"'" : "is NULL";

            //Genero el sql.
            string sql = $@"with recursivo as(
               select sp2.codrol, sp2.codpermiso from rol_permiso SP2
               where sp2.codrol {where}
               UNION ALL
               select sp.codrol, sp.codpermiso from rol_permiso sp
               inner join recursivo r on r.codpermiso = sp.codrol
            ) 
            select r.codrol,r.codpermiso,p.codpermiso as id,p.nombre, p.es_patente, 0 as idusuario
            from recursivo r
            inner join permiso p on r.codpermiso = p.codpermiso
            option (maxrecursion 0);";

            return sql;
        }

        //Trae la lista completa de permisos filtrando por idusuario.
        public string getAllByUser(string familia,long userid)
        {
            //Seteo el where.
            string where = (!String.IsNullOrEmpty(familia)) ? "='" + familia + "'" : "is NULL";

            //Genero el sql.
            string sql = $@"with recursivo as(
               select sp2.codrol, sp2.codpermiso, sp2.idusuario from rol_permiso SP2
               where sp2.codrol {where}
               UNION ALL
               select sp.codrol, sp.codpermiso, sp.idusuario from rol_permiso sp
               inner join recursivo r on r.codpermiso = sp.codrol
            ) 
            select r.codrol,r.codpermiso,p.codpermiso as id,p.nombre, p.es_patente, r.idusuario
            from recursivo r
            inner join permiso p on r.codpermiso = p.codpermiso
            where r.idusuario = {userid} option (maxrecursion 0);";

            return sql;
        }

        //Traigo la lista raw de permisos.
        public string getAllRaw()
        {
            return "select codpermiso, nombre, es_patente from permiso;";
        }
    }
}