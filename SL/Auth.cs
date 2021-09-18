using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using DAL;
using DAL.Idiomas;
using DAL.Permiso;
using BE;
using BE.Permisos;
using SEC;
using SL.Exceptions;
using SL;

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

        //Traigo la lista de permisos para el usuario que se logea.
        private List<Componente> getPermission(UsuarioBE user)
        {
            return new UserPermisoDAL().getPermmision(user);
        }

        //Activo la sesion, cargo idioma y permisos.
        private void startSession(UsuarioBE user)
        {
            //Inicio la sesion.
            Session newSession = Session.GetInstance();
            newSession.start(user);

            //Cargo los permisos del usuario.
            newSession.setPermission(this.getPermission(user));
        }

        //Validacion de credenciales.
        private UsuarioBE checkCredentials(string email, string pwd)
        {
            //Encripto el password para que coincida con la bd.
            string criptedPwd = Cripto.GetInstance().GetHash(pwd);

            //Encripto el email dado que es un dato protegido.
            email = Cripto.GetInstance().Encrypt(email);

            //Busco el usuario para el login.
            UsuarioBE user = new UsuarioDAL().login(email, criptedPwd);

            //Detecto error de login.
            if (user == null)
                throw new ServiceException("LOGIN_SERVICE_ERROR");

            //Desencripto el email.
            user.email = Cripto.GetInstance().Decrypt(email);

            return user;
        }

        //Valida usuario y contraseña para ingresar.
        public UsuarioBE login(string email, string pwd)
        {
            Bitacora.GetInstance().log("LOGIN","Request login of user:" + email);
            Debug.WriteLine("Request login of user:" + email);

            //Antes de hacer el login, hago una prueba de integridad.
            //Integrity.GetInstance().validateComplete();

            //Valido las credenciales y obtengo el usuario logeado.
            UsuarioBE user = this.checkCredentials(email,pwd);

            //Inicio la sesion.
            this.startSession(user);

            Bitacora.GetInstance().log("LOGIN","Login of user:"+email+" success!");

            return user;
        }
    }
}