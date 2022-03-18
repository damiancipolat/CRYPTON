using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using BE;
using SL;

namespace SL
{
    public class Bitacora
    {
        //Singleton logic.
        private static Bitacora _instance;
        private ILogger logger;

        public static Bitacora GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Bitacora();
            }

            return _instance;
        }

        private void setLogger(ILogger logger) 
        {
            this.logger = logger;            
        }

        public void log(string actividad, string payload, bool debug = false)
        {
            //Armo instancias.
            BdLayer bdLogLayer = new BdLayer();
            FileLayer fileLogLayer = new FileLayer();
            FileJsonLayer fileJsonLayer = new FileJsonLayer();

            //Traigo el modo de logeo en json..
            string jsonLogMode = ConfigurationManager.AppSettings["LogMode"];

            //Intento grabar el log en la bd, si falla se graba en un archivo.
            try
            {
                this.setLogger(bdLogLayer);
                this.logger.log(actividad, payload);
            }
            catch (Exception ex)
            {
                this.setLogger(fileLogLayer);
                this.logger.log(actividad, payload);

                //Registro en formato json.
                if (jsonLogMode == "ONERROR") 
                {
                    this.setLogger(fileJsonLayer);
                    this.logger.log(actividad, payload + " - " + ex.Message);
                }                    
            }
            finally
            {
                Debug.WriteLine(payload);

                //Registro en formato json.
                if (jsonLogMode == "ALWAYS") 
                {
                    this.setLogger(fileJsonLayer);
                    this.logger.log(actividad, payload);
                }                    
            }
        }
    }
}