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
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"email","pepe@pepe.com"},
                { "tipo_usuario",2}
            };

            QueryUpdate upd = new QueryUpdate();
            upd.updateSchemaById(schema, "usuario", "idusuario", 2);
            */

            QueryUpdate upd = new QueryUpdate();
            upd.updateSchemaWhereAnd(
                new Dictionary<string, Object>{
                    {"email","prueba@mock.com"},
                    { "tipo_usuario",3}
                }, new Dictionary<string, Object>{
                    {"email","pepe@pepe.com"},
                    {"pwd","1234"}
            }, "usuario");

            /*
            UsuarioDAL dam = new UsuarioDAL();
            string hashes = dam.getEntityHash();
            Debug.WriteLine("---->"+hashes);
            */
            /*
            UsuarioDAL dam = new UsuarioDAL();
            UsuarioBE damBE = dam.findById(2);
            Debug.WriteLine(damBE.hash);
            */
            /*
            //Crear bitacora.
            UsuarioDAL dam = new UsuarioDAL();
            UsuarioBE damBE = dam.findById(1);

            BitacoraBE bitacoraBE = new BitacoraBE();
            bitacoraBE.usuario = damBE;
            bitacoraBE.type = 1;
            bitacoraBE.fecLog = DateTime.Now;
            bitacoraBE.payload = "Paso algo opa";

            BitacoraDAL bitacoraDAL = new BitacoraDAL();
            bitacoraDAL.insert(bitacoraBE);
            */

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            UsuarioDAL dam = new UsuarioDAL();
            dam.getEntityHash();
        }
    }
}