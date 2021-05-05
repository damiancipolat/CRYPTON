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
using DAL.Idiomas;
using DAL.Permiso;
using DAL.Admin;
using SL;
using SEC;

namespace UI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PermisoUserDAL permUser = new PermisoUserDAL();
            List<Componente> perms = permUser.FindAll("", 1);
            IList<Componente> childs = perms[0].Hijos;
            
            foreach (Componente pe in childs)
            {
                Debug.WriteLine("---->"+pe.Id.ToString()+","+pe.Nombre);
            }

            //PermisoUserDAL permiso = new PermisoUserDAL();
            //permiso.FindAll();
            //bool exist = permiso.hasPermission(2, 2);
            //Debug.WriteLine("tiene:" + exist.ToString());

            //IList<Componente> result = permiso.FindAll("");
            //Debug.WriteLine(">>>" + result[0].Hijos.Count.ToString());




            //Dictionary<string, string> words = new IdiomaDAL().loadWords("ES");
            //foreach(string a in words.Keys.ToList())            
            //Debug.WriteLine(">>>>"+a);

            /*
            List<IdiomaBE> idiomas = new IdiomaDAL().findAll();
            foreach (IdiomaBE i in idiomas)
                Debug.WriteLine(i.code+"  "+i.descripcion);
            */

            //new Auth().login("damian.cipolat@gmail.com","1234");
            //Integrity check = new Integrity();
            //check.validateComplete();

            /*
            UsuarioDAL user = new UsuarioDAL();
            UsuarioBE damBE = user.findById(1);
            string hash = new HashUsuario().hash(damBE);
            Debug.WriteLine("HASH"+hash);
            */

            //user.findAll();

            /*
            DvhBE dvhBE = new DvhDAL().findByKey("usuario");
            Debug.WriteLine("---->"+dvhBE.tabla);
            */
            /*
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"email","pepe@pepe.com"},
                { "tipo_usuario",2}
            };
            che
            QueryUpdate upd = new QueryUpdate();
            upd.updateSchemaById(schema, "usuario", "idusuario", 2);
            */
            /*
            QueryUpdate upd = new QueryUpdate();
            upd.updateSchemaWhereAnd(
                new Dictionary<string, Object>{
                    {"email","prueba@mock.com"},
                    { "tipo_usuario",3}
                }, new Dictionary<string, Object>{
                    {"email","pepe@pepe.com"},
                    {"pwd","1234"}
            }, "usuario");*/

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

        private void Button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                UsuarioBE user = Auth.GetInstance().login(txt_email.Text, txt_pwd.Text);
                MessageBox.Show("Acceso permitido", "LOGIN");
            }
            catch (Exception error) {                
                MessageBox.Show("Acceso NO permitido", "LOGIN");
            }

        }
    }
}