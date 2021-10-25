using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Admin;
using DAL.Admin;

namespace BL.Admin
{
    public class BackupBL
    {
        public BackupBL() { }

        public int makeBackup(BackupBE backup)
        {
            //Agrego el nombre autogenedaro.
            string fileStr = "crypton_backup_"+DateTime.Now.ToString("MM.dd.yyyy.HH.mm.ss")+".bak";
            backup.path = backup.path + "\\" + fileStr;

            //Seteo el file size a cero.
            backup.size = 0;

            return new BackupDAL().makeBackup(backup);

        }

        public BackupBE findById(int id)
        {
            return new BackupDAL().findById(id);
        }

        public int restoreBackup(BackupBE backup)
        {
            return new BackupDAL().restoreBackup(backup);
        }

        public List<BackupBE> findAll()
        {
            return new BackupDAL().findAll();
        }
    }
}
