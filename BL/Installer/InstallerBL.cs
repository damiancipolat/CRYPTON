using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Installer;

namespace BL.Installer
{
    public class InstallerBL
    {
        //Chequea si la conexion al servidor y la bd pueden lograrse.
        private bool isBdActive()
        {
            return new InstallerDAL().isBdActive();
        }

        //Revisa si existen las tablas.
        private bool checkTables()
        {
            return new InstallerDAL().checkTables();
        }

        //Ejecuta las validaciones.
        public bool validate() 
        {
            bool status = this.isBdActive() && checkTables();

            if (!status)
                throw new Exception("Fallo la instalación, cierre crypton y vuelva a intentar o comuniquese con soporte@crypton.com.");

            return true;
        }

        
    }
}
