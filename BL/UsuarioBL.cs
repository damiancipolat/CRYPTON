using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE;
using BE.Permisos;
using DAL;
using DAL.Permiso;
using SL;
using SEC;

namespace BL
{
    public class UsuarioBL
    {
        public UsuarioBL()
        {
            //..
        }

        //Guardo la relacion usuario permiso.
        private int attachPermission(int idusuario)
        {
            //Traigo la lista de permisos del rol cliente.
            IList<Componente> permissionList = new DAL.Permiso.PermisoTodoDAL().FindAll("3");

            //Registro cada permiso que le corresponde al cliente.
            foreach (Componente perm in permissionList)
            {
                UsuarioPermiso userBE = new UsuarioPermiso();
                userBE.idpermiso = perm.Id;
                userBE.idusuario = idusuario;

                new UsuarioPermisoDAL().insert(userBE);
            }

            return 0;
        }

        //Registra un nuevo usuario.
        public int save(UsuarioBE user)
        {
            //Codifico el password como hash.
            user.pwd = Cripto.GetInstance().GetHash(user.pwd);

            //Encripto simetricamente el email.
            user.email = Cripto.GetInstance().Encrypt(user.email);
            user.hash = new HashUsuario().hash(user);            

            //Registro el usuario.
            int resultInsert = new UsuarioDAL().insert(user);

            //Actualizo el DVV de usuarios.
            new DvvDAL().updateHash("usuario", new UsuarioDAL().getEntityHash());

            return resultInsert;
        }
    }
}
