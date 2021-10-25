using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using DAL.DAO;
using BE.Admin;

namespace DAL.Admin
{
    public class BackupDAL : AbstractDAL<BackupBE>
    {
        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private BackupBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            BackupBE backupTarget = new BackupBE();

            //Bindeo campos con la lista de resultados.
            this.binder.match(fieldData, backupTarget);

            return backupTarget;
        }

        //Este metodo obtiene en base al ID el usuario.
        public BackupBE findById(long id)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("admin_backup", "idbackup", id);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Este metodo retorna una lista de clientes.
        public List<BackupBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("admin_backup");

            //Lista resultado.
            List<BackupBE> lista = new List<BackupBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Agrega un nuevo registro de backup
        private int insert(BackupBE backup)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"idusuario",backup.usuario.idusuario},
                {"path",backup.path},
                {"fecRec",backup.fecRec.ToString("yyyy-MM-dd HH:mm:ss.fff")},
                {"type",backup.type},
                {"size",backup.size}
            };

            QueryInsert builder = new QueryInsert();
            return builder.insertSchema(schema, "admin_backup",true);
        }

        //Actualizar el backup.
        public int update(BackupBE backup)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"idusuario",backup.usuario.idusuario},
                { "path",backup.path},
                { "fecRec",backup.fecRec.ToString("yyyy-MM-dd HH:mm:ss.fff")},
                { "type",backup.type},
                { "size",backup.size}
            };

            return this.getUpdate().updateSchemaById(schema, "admin_backup", "idbackup", backup.idbackup);
        }

        //Actualizo el tamaño del archivo.
        private long updateSize(BackupBE backup)
        {
            //Traigo el tamaño del archivo.
            long fileSize = new System.IO.FileInfo(backup.path).Length;
            Debug.WriteLine("File size of:" + backup.path + " in " + fileSize + " bytes.");

            //Piso el valor.
            backup.size = fileSize;

            //Actualizo el registro.
            return this.update(backup);
        }

        //Proceso el backup.
        public int makeBackup(BackupBE backup)
        {
            //Registro el backup.
            int newId = this.insert(backup);
            Debug.WriteLine("Backup id:" + newId.ToString());

            //Actualizo el id.
            backup.idbackup = newId;

            //Ejecuto el backup.
            string sql = "BACKUP DATABASE Crypton TO DISK = '" + backup.path + "' WITH FORMAT, MEDIANAME = 'SQLServerBackups', NAME = 'Full Backup of SQLTestDB'";
            QueryInsert cmd = new QueryInsert();

            Debug.WriteLine("QUERY:"+sql);

            //Retorno la ejecucion del comando.
            cmd.query(sql);

            //Actualizo el tamaño del archivo.
            this.updateSize(backup);

            return newId;
            
        }

        //Proceso el restore.
        public int restoreBackup(BackupBE backup)
        {
            //Ejecuto el backup.
            string sql = "use master;RESTORE DATABASE Crypton FROM DISK = '"+backup.path+"' WITH FILE = 1, NOUNLOAD, STATS = 5; ";
            QueryInsert cmd = new QueryInsert();
            Debug.WriteLine("QUERY:" + sql);

            //Retorno la ejecucion del comando.
            return cmd.query(sql);

        }
    }
}