using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE;
using SL;

namespace SL
{
    public class Bitacora
    {
        //Singleton logic.
        private static Bitacora _instance;

        public static Bitacora GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Bitacora();
            }

            return _instance;
        }

        public void log(string actividad, string payload, bool debug = false)
        {
            //Armo instancias.
            BdLayer bdLogLayer = new BdLayer();
            FileLayer fileLogLayer = new FileLayer();               

            //Intento grabar el log en la bd, si falla se graba en un archivo.
            try
            {
                bdLogLayer.log(actividad, payload);
               // throw new Exception("epa");
            }
            catch (Exception ex)
            {
                fileLogLayer.log(actividad, payload);
            }
            finally
            {
                Debug.WriteLine(payload);
            }
        }
    }
}