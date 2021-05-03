using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using DAL.DAO;

namespace DAL.Admin
{
    public class Backup
    {
        public void makeBackup(string path)
        {
            string sql = "BACKUP DATABASE Crypton TO DISK = '" + path + "' WITH FORMAT, MEDIANAME = 'SQLServerBackups', NAME = 'Full Backup of SQLTestDB'";

            QueryInsert cmd = new QueryInsert();
            int outCode = cmd.query(sql);
            Debug.WriteLine("salida"+outCode.ToString());
        }
    }
}