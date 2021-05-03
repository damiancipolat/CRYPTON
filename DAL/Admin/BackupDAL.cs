using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using DAL.DAO;
using BE;

namespace DAL.Admin
{
    public class BackupDAL
    {

        //Agrega un nuevo registro de backup
        public int insert(BackupBE backup)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"idusuario",backup.usuario.idusuario},
                { "path",backup.path},
                { "fecRec",backup.fecRec}
            };

            QueryInsert builder = new QueryInsert();
            return builder.insertSchema(schema, "admin_backup");
        }

        //Proceso el backup.
        public int makeBackup(BackupBE backup)
        {
            //Ejecuto el backup.
            string sql = "BACKUP DATABASE Crypton TO DISK = '" + backup.path + "' WITH FORMAT, MEDIANAME = 'SQLServerBackups', NAME = 'Full Backup of SQLTestDB'";
            QueryInsert cmd = new QueryInsert();

            Debug.WriteLine("QUERY:"+sql);

            //Registro el backup.
            this.insert(backup);

            //Retorno la ejecucion del comando.
            return cmd.query(sql);
            
        }
    }
}