using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Permisos;
using DAL.Permiso.nuevo;

namespace BL.Permisos
{
    public class PermisoBL
    {
        public bool Existe(Componente2 c, int id)
        {
            bool existe = false;

            if (c.Id.Equals(id))
                existe = true;
            else

                foreach (var item in c.Hijos)
                {
                    existe = Existe(item, id);

                    if (existe)
                        return true;
                }

            return existe;
        }

        public void FillFamilyComponents(Familia2 familia)
        {
            new PermisoDAL().FillFamilyComponents(familia);
        }

        public void GuardarFamilia(Familia2 c)
        {
            new PermisoDAL().GuardarFamilia(c);
        }

        public IList<Componente2> GetAll(string familia)
        {
            return new PermisoDAL().GetAll(familia);
        }
    }
}
