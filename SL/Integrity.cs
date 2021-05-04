using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using System.Diagnostics;

namespace SL
{
    public class Integrity
    {
        public bool validateUsers()
        {
            List<UsuarioBE> userList = new UsuarioDAL().findAll();

            //Validate no result.
            if ((userList.Count == 0))
                throw new Exception("List of user with no data");

            //Compare current hash vs column hash.
            foreach (UsuarioBE user in userList)
            {
                string newHash = new HashUsuario().hash(user);

                //Compare table hash with computed hash.
                if (newHash != user.hash)
                    throw new Exception("Integrity fail idusuaro:"+user.idusuario);
            }

            return true;
        }
    }
}
