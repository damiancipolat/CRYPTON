using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DAL;
using DAL.Idiomas;
using BE;
using SL;

namespace SL
{
    public class Auth
    {
        private void startSession(UsuarioBE user)
        {
            //Inicio la sesion.
            Session newSession = Session.GetInstance();
            newSession.sessionStart(user);

            //Cargo idioma por defecto.
            Dictionary<string, string> words = new IdiomaDAL().loadWords("ES");
            newSession.setLanguage("ES", words);
        }

        public UsuarioBE login(string email, string pwd)
        {
            //Antes de hacer el login, hago una prueba de integridad.
            //new Integrity().validateComplete();

           //Encripto el password para que coincida con la bd.
            string criptedPwd = new Cripto().GetHash(pwd);
            
           //Busco el usuario para el login.
           UsuarioBE user= new UsuarioDAL().login(email, criptedPwd);

           //Si el login falla retornara null.  
           if (user == null)
                throw new Exception("Invalid login");

            //Start the session, and load language.
            this.startSession(user);

            return user;
        }
    }
}
