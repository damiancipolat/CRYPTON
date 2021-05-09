using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE.Permisos;
using DAL.DAO;
using DAL.Permiso;

namespace DAL.Permiso
{
    public class PermisoUserDAL : DAL.PermisoDAL
    {
        //Obtiene recursivamente la lista de componentes filtrando por usuario.
        public List<Componente> FindAll(string familia, int userid)
        {
            //Obtengo el sql para buscar todos recursivamente.
            string sql = this.sqlGen.getAllByUser(familia, userid);
            Debug.WriteLine("QUERY:" + sql);

            return this.Find(sql);
        }

        //Reviso si el usuario tiene seteado el permiso.
        public bool hasPermission(int id, int userid)
        {
            IList<Componente> lista = this.FindAll(string.Empty, userid);
            Componente c = this.GetComponent(id, lista);

            return c != null;
        }
    }
}
