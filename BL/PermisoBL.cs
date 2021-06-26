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
            string family = (userType == UsuarioTipo.CLIENTE) ? "R002" : "R003";

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
                userBE.codpermiso = perm.Cod;
                userBE.idusuario = user.idusuario;

                new UsuarioPermisoDAL().insert(userBE);
            }

        }

        //Borro un permiso a un usuario.
        public int removeToUser(string codPermiso, UsuarioBE user)
        {
            UsuarioPermiso perm = new UsuarioPermiso();
            perm.codpermiso = codPermiso;
            perm.idusuario = user.idusuario;

            return new UsuarioPermisoDAL().remove(perm);
        }

        //Revisa si el permiso esta dentro de la lista.
        public bool hasPermission(IList<Componente> permisos, string id)
        {
            return new PermisoDAL().hasPermission(permisos, id);
        }
    }
}