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
using BL.Permisos;

namespace BL.Permisos
{
    public class UserPermisoBL
    {
        public List<Componente> getPermission(UsuarioBE u)
        {
            return new UserPermisoDAL().getPermmision(u);
        }

        public Patente findByName(string name)
        {
            return new UserPermisoDAL().findByName(name);
        }

        public void FillUserComponents(UsuarioBE u)
        {            
            new UserPermisoDAL().FillUserComponents(u);
        }

        public void GuardarPermisos(List<Tuple<string,int,int>> operations)
        {
            foreach (Tuple<string, int, int> op in operations)
            {
                if (op.Item1 == "add")
                    this.save(op.Item2,op.Item3);

                if (op.Item1 == "del")
                    this.delete(op.Item2,op.Item3);
            }
        }

        public void save(long userId, int permisoId)
        {
            new UserPermisoDAL().save(userId,permisoId);
        }
        public void delete(int userId, int permisoId)
        {
            new UserPermisoDAL().delete(userId, permisoId);
        }
    }
}
