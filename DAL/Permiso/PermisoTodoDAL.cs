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
    public class PermisoTodoDAL: DAL.PermisoDAL
    {
        //Obtiene recursivamente la lista de componentes.
        public IList<Componente> FindAll(string familia)
        {
            //Obtengo el sql para buscar todos recursivamente.
            string sql = this.sqlGen.getAll(familia);
            Debug.WriteLine("QUERY:" + sql);

            return this.Find(sql);
        }
    }
}
