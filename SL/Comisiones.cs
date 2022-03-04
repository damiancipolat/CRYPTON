using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using DAL.DAO;
using DAL.Idiomas;
using System.Configuration;
using SL;

namespace SL
{
    public class Comisiones
    {
        //Singleton logic.
        private static Comisiones _instance;

        public static Comisiones GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Comisiones();
            }

            return _instance;
        }

        //Recibo una operacion y calculo el valor.
        public float cotizar(object operacion)
        {
            return 0;
        }
    }
}
