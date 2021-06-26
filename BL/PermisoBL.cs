﻿using System;
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

        //Traigo la lista de componentes.
        public List<Componente> getRaw()
        {
            return new PermisoTodoDAL().GetRaw();
        }

        //Bindeo a un usuario todos los permisos del tipo cliente.
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

        //Bindeo especificamente un permiso a un usuario.
        public int bindSpecificToUser(string rol, string permiso, long id)
        {
            return new PermisoUserDAL().bindToUser(rol, permiso, id);
        }

        //Borro un permiso a un usuario.
        public int removeToUser(string rol, string permiso, long id)
        {
            return new PermisoUserDAL().removeToUser(rol,permiso,id);
        }

        //Revisa si el permiso esta dentro de la lista.
        public bool hasPermission(IList<Componente> permisos, string id)
        {
            return new PermisoDAL().hasPermission(permisos, id);
        }
    }
}