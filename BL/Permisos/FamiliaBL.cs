using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Permiso;
using BE.Permisos;

namespace BL.Permisos
{
    public class FamiliaBL
    {
        public int save(string value)
        {
            return new FamiliaDAL().save(value);
        }

        public int delete(int id)
        {
            return new FamiliaDAL().delete(id);
        }

        public List<Familia> getAll()
        {
            return new FamiliaDAL().getAll();
        }
    }
}
