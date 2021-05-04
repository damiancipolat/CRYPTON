using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

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

        //Language
        private string languageName;
        private Dictionary<string, string> language;

        //Start the session bind values.
        public void sessionStart(UsuarioBE userParam)
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
        public void sessionEnd()
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
    }
}


/*
         Dictionary<string, object> result = new Dictionary<string, object>();

foreach (KeyValuePair<string, object> data in rows)
    result.Add(data.Key, data.Value);
 */
