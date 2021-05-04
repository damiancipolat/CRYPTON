using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace SL
{
    public class HashUsuario: Hasher
    {
        public override string hash(Object target)
        {
            UsuarioBE user = (UsuarioBE)target;

            string chunk = user.idusuario.ToString() +
                user.nombre +
                user.apellido +
                user.email +
                user.alias;

            return this.coders.GetHash(chunk);
            
        }
    }
}
