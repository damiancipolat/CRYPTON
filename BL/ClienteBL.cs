using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Permisos;
using DAL;
using DAL.Permiso;
using SL;
using SEC;

namespace BL
{
    public class ClienteBL
    {
        public ClienteBL()
        {
            //..
        }

        private int createUser(ClienteBE cliente)
        {
            //Registro por separado.
            UsuarioBE newUser = new UsuarioBE();
            newUser.alias = cliente.alias;
            newUser.nombre = cliente.nombre;
            newUser.apellido = cliente.apellido;
            newUser.email = cliente.email;
            newUser.pwd = cliente.pwd;

            return new UsuarioBL().save(newUser);
        }

        public int save(ClienteBE cliente)
        {
            //Registro el usuario obtengo el id.
            int insertedId = this.createUser(cliente);

            //Seteo relacion cliente
            UsuarioBE tmpUser = new UsuarioBE();
            tmpUser.idusuario = insertedId;

            //Seteo campo de cliente autoseteados.
            cliente.valido = "N";
            cliente.usuario = tmpUser;

            //Registro el cliente por separado.
            return new ClienteDAL().insert(cliente);
        }
    }
}
