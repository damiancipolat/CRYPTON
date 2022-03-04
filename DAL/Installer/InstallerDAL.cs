using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using DAL.DAO;

namespace DAL.Installer
{
    public class InstallerDAL
    {
        //Chequea si la conexion al servidor y la bd pueden lograrse.
        public bool isBdActive()
        {
            try
            {
                return new QueryBuilder().checkConnection();
            }catch(Exception err)
            {
                Debug.WriteLine("---++++" + err.Message);
                return false;
            }
            
        }

        //Revisa si existen las tablas.
        public bool checkTables()
        {
            try 
            {
                SqlDataReader result = new QuerySelect().query("select * from cuenta_estado;");
                return result.HasRows;
            }
            catch (Exception err)
            {
                Debug.WriteLine("---++++" + err.Message);
                return false;
            }
        }
    }
}
