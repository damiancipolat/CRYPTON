using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;

namespace SL
{
    public class HelpManual
    {
        //Singleton logic.
        private static HelpManual _instance;

        public static HelpManual GetInstance()
        {
            if (_instance == null)
            {
                _instance = new HelpManual();
            }

            return _instance;
        }

        public void openForClient(string code)
        {
            string url = ConfigurationManager.AppSettings["HelpWebsite"];

            //Run browser.
            System.Diagnostics.Process.Start(url + "/clientes.html#" + code);
        }

        public void openForEmpleado(string code)
        {
            string url = ConfigurationManager.AppSettings["HelpWebsite"];

            //Run browser.
            System.Diagnostics.Process.Start(url + "/empleados.html#" + code);
        }

        //Abro un browser
        public void openHelp(string code)
        {
            string url = ConfigurationManager.AppSettings["HelpWebsite"];

            //Run browser.
            System.Diagnostics.Process.Start(url+"/#"+code);
        }
    }
}