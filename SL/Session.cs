using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Permisos;

namespace SL
{
    public class Session
    {
        //Singleton logic.
        private static Session _instance;

        public static Session GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Session();
            }

            return _instance;
        }

        //Session variables.
        private bool active = false;
        private UsuarioBE user;
        private DateTime startDate;
        private DateTime endDate;

        //Permission list.
        private List<Componente> permissions;

        //Language
        private string languageName;
        private Dictionary<string, string> language;

        //Get the user.
        public UsuarioBE getUser()
        {
            return this.user;
        }

        //Start the session bind values.
        public void start(UsuarioBE userParam)
        {
            //Deny active an active session.
            if (active)
                throw new Exception("The session is already active");

            //Active session flags.
            active = true;
            user = userParam;

            //Set dates.
            startDate = DateTime.Now;
        }

        //Finish the session.
        public void close()
        {
            //Active session flags.
            active = false;

            //Set dates.
            startDate = DateTime.Now;
        }

        //Set the language.
        public void setLanguage(string langName, Dictionary<string, string> langList)
        {
            languageName = langName;
            language = langList;
        }

        //Set permission list.
        public void setPermission(List<Componente> permissions)
        {
            this.permissions = permissions;
        }

        //Indica si la sesion esta activa o no.
        public bool isActive()
        {
            return this.active == true;
        }
    }
}