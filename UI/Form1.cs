using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics;
using System.Dynamic;
using System.Reflection;
using System.Collections;
using BE;
using BE.Permisos;
using DAL.DAO;
using DAL;
using DAL.Permiso;
using DAL.Admin;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            /*
            //Hacer restore
            UsuarioDAL dam = new UsuarioDAL();
            UsuarioBE damBE = dam.findById(1);

            BackupBE bckBE = new BackupBE();
            bckBE.usuario = damBE;
            bckBE.fecRec = DateTime.Now;
            bckBE.type = "RESTORE";
            bckBE.path = "c:/crypton_backup_bd_20210503054138.bak";

            BackupDAL bckDAL = new BackupDAL();
            int code = bckDAL.restoreBackup(bckBE);
            Debug.WriteLine("--------->"+code);
            */

            /*
            //Hacer backup
            UsuarioDAL dam = new UsuarioDAL();
            UsuarioBE damBE = dam.findById(1);

            BackupBE bckBE = new BackupBE();
            bckBE.usuario = damBE;
            bckBE.fecRec = DateTime.Now;
            bckBE.type = "BACKUP";

            String timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            bckBE.path = "c:/crypton_backup_bd_" + timeStamp + ".bak";

            BackupDAL bckDAL = new BackupDAL();
            bckDAL.makeBackup(bckBE);
            */

            /*
            BackupDAL bck = new BackupDAL();
            String timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            bck.makeBackup("c:/backup_bd_"+timeStamp+".bak");
            Debug.WriteLine(timeStamp);            

            PermisoUserDAL permiso = new PermisoUserDAL();
            bool exist = permiso.hasPermission(2,2);
            Debug.WriteLine("tiene:"+exist.ToString());

            IList<Componente> result = permiso.FindAll("");
            Debug.WriteLine(">>>" + result[0].Hijos.Count.ToString());

            Debug.WriteLine(">>>"+result[0].Count.ToString());
            UsuarioDAL pepe = new UsuarioDAL();
            UsuarioBE result = pepe.login("damian.cipolat@gmail.com", "1234");
            Debug.WriteLine(">"+result.idusuario.ToString()+"sss"+result.nombre);
            */
        }
    }
}