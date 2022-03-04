using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DAL;
using BE;
using SEC.Exceptions;
using IO;
using SEC;

namespace BL.Security
{
    public class IntegrityBL
    {
        //Verifica integridad solo de usuarios.
        private bool validateDvhUsers()
        {
            List<UsuarioBE> userList = new UsuarioDAL().findAll();

            //Validate no result.
            if (userList.Count == 0)
            {
                throw new IntegrityException(
                    "INTEGRITY_USERS_NOT_FOUND",
                    "Horizontal warning - Users not found in DB"
                );
            }

            //Compare current hash vs column hash.
            foreach (UsuarioBE user in userList)
            {
                string newHash = new HashUsuario().hash(user);
                Debug.WriteLine("comparing hash id:" + user.idusuario.ToString() + " " + newHash + " --- " + user.hash);

                //Compare table hash with computed hash.                
                if (newHash != user.hash)
                {
                    throw new IntegrityException(
                        "INTEGRITY_USERS_CORRUPT",
                        "Horizontal warning - Comparing hash id:" + user.idusuario.ToString() + " " + newHash + "," + user.hash
                    );
                }
            }

            return true;
        }

        //Verifica integridad con tabla de dvv.
        private bool validateDvvUsers()
        {
            UsuarioDAL user = new UsuarioDAL();
            DvvDAL dv = new DvvDAL();

            //Computo todos los hash de la tabla usuarios.
            string fullHash = user.getEntityHash();

            //Traigo la tabla del dvv para usuarios.
            DvhBE dvBE = dv.find("usuario");

            //If not found register.
            if (dvBE == null)
            {
                throw new IntegrityException(
                    "INTEGRITY_USERS_ENTITY_FAIL",
                    "Vertical warning - users not found in entity integrity table"
                );
            }

            Debug.WriteLine("Compare entity calculated-hash:"+fullHash+" vs entity table-hash:"+dvBE.hash);

            //Comparo hashes.
            if (fullHash != dvBE.hash)
            {
                throw new IntegrityException(
                    "INTEGRITY_USERS_ENTITY_FAIL",
                    "Vertical warning - users entity table violated"
                );
            }              

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
