using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE;
using DAL;
using SEC;

namespace BL
{
    public class UsuarioBL
    {
        public UsuarioBL()
        {
            //..
        }

        public int save(UsuarioBE user)
        {
            //Codifico el password como hash.
            user.pwd = Cripto.GetInstance().GetHash(user.pwd);
            user.hash = new HashUsuario().hash(user);            

            //Registro el usuario.
            return new UsuarioDAL().insert(user);
        }
    }
}
