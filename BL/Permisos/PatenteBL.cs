using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Permiso;
using BE.Permisos;

namespace BL.Permisos
{
    public class PatenteBL
    {
        public int save(string value)
        {
            return new PatenteDAL().save(value);
        }

        public int delete(int id)
        {
            return new PatenteDAL().delete(id);
        }

        public List<Patente> getAll()
        {
            return new PatenteDAL().getAll();
        }
    }
}
