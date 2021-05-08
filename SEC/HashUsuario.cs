using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE;

namespace SEC
{
    public class HashUsuario
    {
        public string hash(UsuarioBE target)
        {
            UsuarioBE user = target;
            string chunk = user.nombre+user.apellido+user.email+user.alias;
            return  new Cripto().GetHash(chunk);
            
        }
    }
}
