using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DAL;
using DAL.Idiomas;
using DAL.Permiso;
using BE;
using BE.Permisos;
using SL;
using SEC;
using SL.Exceptions;

namespace SL
{
    public class Auth
    {
        //Singleton logic.
        private static Auth _instance;

        public static Auth GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Auth();
            }

            return _instance;
        }

        //Business methods.
        private void startSession(UsuarioBE user)
        {
            //Inicio la sesion.
            Session newSession = Session.GetInstance();
            newSession.start(user);

            //Cargo idioma por defecto.
            Dictionary<string, string> words = new IdiomaDAL().loadWords("ES");
            newSession.setLanguage("ES", words);

            //Cargo los permisos del usuario.
            PermisoUserDAL permUser = new PermisoUserDAL();
            newSession.setPermission(permUser.FindAll("", 1));
        }

        public UsuarioBE login(string email, string pwd)
        {
            Bitacora.GetInstance().log("Request login of user:" + email);

            //Antes de hacer el login, hago una prueba de integridad.
            Integrity.GetInstance().validateComplete();

           //Encripto el password para que coincida con la bd.
            string criptedPwd = Cripto.GetInstance().GetHash(pwd);

            //Encripto el email dado que es un dato protegido.
            email = Cripto.GetInstance().Encrypt(email);
            
            //Busco el usuario para el login.
            UsuarioBE user= new UsuarioDAL().login(email, criptedPwd);

            //Detecto error de login.
            if (user == null)
                throw new ServiceException("LOGIN_SERVICE_ERROR");

            //Desencripto el email.
            user.email = Cripto.GetInstance().Decrypt(email);

            //Inicio la sesion.
            this.startSession(user);

            Bitacora.GetInstance().log("Login of user:"+email+" success!");

            return user;
        }
    }
}
