using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DAL;
using BE;

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

        public int log(string actividad,string payload,bool debug=false)
        {
            //Creo la entidad bitacora.
            BitacoraBE logBE = new BitacoraBE();
            logBE.payload = payload;
            logBE.usuario = Session.GetInstance().getUser();
            logBE.fecLog =DateTime.Now;
            logBE.actividad = actividad!=null?actividad:"LOG";

            if (debug)
                Debug.WriteLine(payload);

            //Registro en la bd.
            return new BitacoraDAL().insert(logBE);
        }
    }
}