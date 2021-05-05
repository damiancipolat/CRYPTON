using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DAL;
using BE;

namespace SEC
{
    public class Integrity
    {
        //Singleton logic.
        private static Integrity _instance;

        public static Integrity GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Integrity();
            }

            return _instance;
        }

        //Verifica integridad solo de usuarios.
        private bool validateDvhUsers()
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

        //Verifica integridad con tabla de dvv.
        private bool validateDvvUsers()
        {
            UsuarioDAL user = new UsuarioDAL();
            DvhDAL dv = new DvhDAL();

            //Computo todos los hash de la tabla usuarios.
            string fullHash = user.getEntityHash();

            //Traigo la tabla del dvv para usuarios.
            DvhBE dvBE = dv.find("usuario");
            
            //If not found register.
            if (dvBE == null)
                throw new Exception("Usuario verification table not found");

            //Comparo hashes.
            if (fullHash != dvBE.hash)
                throw new Exception("Usuario vertical validation FAIL");

            return true;
        }

        //Verifica la identidad de todas las tablas.
        public bool validateComplete()
        {
            this.validateDvvUsers();
            this.validateDvhUsers();
            return true;
        }

    }
}
