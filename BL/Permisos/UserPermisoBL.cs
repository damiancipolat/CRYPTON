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
using DAL.Permiso.nuevo;


namespace BL.Permisos
{
    public class UserPermisoBL
    {
        public void FillUserComponents(UsuarioBE u)
        {
            new UserPermisoDAL().FillUserComponents(u);
        }

        public void SavePermission(UsuarioBE u)
        {
            new UserPermisoDAL().SavePermission(u);
        }
    }
}
