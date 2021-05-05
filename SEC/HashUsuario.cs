using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace SEC
{
    public class HashUsuario
    {
        protected Cripto coders = new Cripto();

        public string hash(UsuarioBE target)
        {
            UsuarioBE user = target;

            string chunk = user.idusuario.ToString() +
                user.nombre +
                user.apellido +
                user.email +
                user.alias;

            return this.coders.GetHash(chunk);
            
        }
    }
}
