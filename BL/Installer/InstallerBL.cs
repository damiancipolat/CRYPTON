using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
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
            if (!this.isBdActive())
                throw new Exception("No se ha podido establecer la conexion con la BD, contacte a soporte@crypton.com.");

            if (!checkTables())
                throw new Exception("No se encontraron las tablas del sistema,  comuniquese con soporte@crypton.com.");

            return true;
        }

        //Check if the install is required.
        public bool isRequired() 
        {
            return File.Exists("install");
        }

        //Mark as install complete.
        public void markAsRequired()
        {
            if (File.Exists("install"))
                File.Delete("install");
        }

    }
}
