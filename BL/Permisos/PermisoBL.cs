using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE;
using BE.Permisos;
using DAL.Permiso;

namespace BL.Permisos
{
    public class PermisoBL
    {
        public bool Existe(Componente c, int id)
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
        public void FillFamilyComponents(Familia familia)
        {
            new PermisoDAL().FillFamilyComponents(familia);
        }

        public void GuardarFamilia(List<Tuple<string, int, int>> operations)
        {
            //Proceso las operaciones.
            foreach (Tuple<string, int, int> operation in operations)
            {
                PermisoDAL bizDal = new PermisoDAL();
                string mode = operation.Item1;

                //Si son agregados.
                if (mode == "add")
                    bizDal.save(operation.Item2, operation.Item3);

                //Si es borrar
                if (mode == "del")
                    bizDal.remove(operation.Item2, operation.Item3);
            }
        }

        public IList<Componente> GetAll(string familia)
        {
            return new PermisoDAL().GetAll(familia);
        }

        //Revisa si el permiso esta dentro de la lista.
        public bool hasPermission(IList<Componente> permisos, string name)
        {
            Debug.WriteLine("Check permssion:"+name);
            return new PermisoDAL().hasPermissionByName(permisos, name);
        }
    }
}