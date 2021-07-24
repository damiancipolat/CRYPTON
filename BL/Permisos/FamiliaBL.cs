using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Permiso.nuevo;
using BE.Permisos;

namespace BL.Permisos
{
    public class FamiliaBL
    {
        public int save(string value)
        {
            return new FamiliaDAL().save(value);
        }

        public List<Familia2> getAll()
        {
            return new FamiliaDAL().getAll();
        }
    }
}
