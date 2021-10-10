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

        //Busqueda libre en base a texto.
        public List<UsuarioBE> searchByText(string text)
        {
            return new UsuarioDAL().searchByText(text);
        }

        //Traigo todos los usuarios.
        public List<UsuarioBE> getAll()
        {
            return new UsuarioDAL().findAll();
        }

        //Buscar por id.
        public UsuarioBE findById(int id)
        {
            return new UsuarioDAL().findById(id);
        }

        //Registra un nuevo usuario.
        public int save(UsuarioBE user)
        {
            //Codifico el password como hash.
            user.pwd = Cripto.GetInstance().GetHash(user.pwd);

            //Encripto simetricamente el email.
            user.email = Cripto.GetInstance().Encrypt(user.email);

            //Hago un DVH para este registro de la entidad.
            user.hash = new HashUsuario().hash(user);
            
            //Registro el usuario.
            int insertedId = new UsuarioDAL().save(user);
            Debug.WriteLine("Grabado user"+insertedId.ToString());

            //Actualizo el DVV de usuarios.
            new DvvDAL().updateHash("usuario", new UsuarioDAL().getEntityHash());

            return insertedId;
        }
    }
}
