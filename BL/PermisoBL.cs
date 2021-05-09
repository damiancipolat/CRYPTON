using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Permiso;
using BL;
using BE;
using BE.Permisos;

namespace BL
{
    public class PermisoBL
    {
        //Traigo la lista de permisos que corresponden al rol.
        private IList<Componente> getPermissionByRol(UsuarioTipo userType)
        {
            string family = (userType == UsuarioTipo.CLIENTE) ? "2" : "3";

            //Traigo la lista de permisos del rol cliente.
            return new DAL.Permiso.PermisoTodoDAL().FindAll(family);
        }

        //Guardo la relacion usuario permiso.
        public void bindToUser(UsuarioBE user)
        {
            IList<Componente> permissionList = this.getPermissionByRol(user.tipoUsuario);

            //Registro cada permiso que le corresponde al cliente.
            foreach (Componente perm in permissionList)
            {
                UsuarioPermiso userBE = new UsuarioPermiso();
                userBE.idpermiso = perm.Id;
                userBE.idusuario = user.idusuario;

                new UsuarioPermisoDAL().insert(userBE);
            }

        }

        //Revisa si el permiso esta dentro de la lista.
        public bool hasPermission(IList<Componente> permisos, int id)
        {
            return new PermisoDAL().hasPermission(permisos, id);
        }
    }
}