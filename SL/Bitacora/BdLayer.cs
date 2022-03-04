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
    public class BdLayer
    {
        public int log(string actividad, string payload)
        {
            //Creo la entidad bitacora.
            BitacoraBE logBE = new BitacoraBE();
            logBE.payload = payload;
            logBE.usuario = Session.GetInstance().getUser();
            logBE.fecLog = DateTime.Now;
            logBE.actividad = actividad != null ? actividad : "LOG";

            //Registro en la bd.
            return new BitacoraDAL().insert(logBE);
        }
    }
}
