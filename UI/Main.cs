using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Configuration;
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
    public partial class frm_main : Form
    {
        public frm_main()
        {
            InitializeComponent();
        }

        //Metodos de rener.
        public void render()
        {
            //Posiciona el splash screen en el centro.
            this.main_splash.Left = (this.Width / 2) - (this.main_splash.Width / 2);
            this.main_splash.Top = (this.Height / 2) - (this.main_splash.Height / 2);

            //Vuelve transparente un label.
            this.main_txt_hello.Parent = this.pictureBox1;
            this.main_txt_hello.BackColor = Color.Transparent;
            this.main_txt_hello.Top = this.Size.Height - 110;
            Debug.WriteLine(">>>" + Session.GetInstance().isActive().ToString());

            //Cuando la sesion esta activa.
            if (Session.GetInstance().isActive())
            {
                
                this.main_splash.Hide();
            }
            else
            {
                this.main_splash.Show();
            }
            
        }

        //Se ejecuta al inicio del formulario, setea idioma base.
        public void bootstrap()
        {
            this.render();

            //Load default language.
            string defaultLang = ConfigurationManager.AppSettings["Language"];

            if (!(defaultLang != ""))
                throw new Exception("Unable to load default language");

            //Load words.
            Dictionary<string,string> lang = new IdiomaDAL().loadWords(defaultLang);
            
            if (lang.Values.Count==0)
                throw new Exception("Unable to load words from default language");

            //Load in session the list of words.
            Session.GetInstance().setLanguage(defaultLang, lang);
        }

        private bool isWindowOpen(string name)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm!=null&&frm.Name == name)
                    return true;
            }

            return false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Abro el login si no esta abierto.
             if (!isWindowOpen("frm_login"))
                new frm_login(this).Show();

            /*PermisoUserDAL permUser = new PermisoUserDAL();
            List<Componente> perms = permUser.FindAll("", 1);
            IList<Componente> childs = perms[0].Hijos;
            
            foreach (Componente pe in childs)
            {
                Debug.WriteLine("---->"+pe.Id.ToString()+","+pe.Nombre);
            }*/

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
            this.bootstrap();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            UsuarioDAL dam = new UsuarioDAL();
            dam.getEntityHash();
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            this.render();

            //Show login pannels.
            if (!Session.GetInstance().isActive())
            {
                this.btn_login.Visible = true;
                this.txt_welcome.Visible = false;
            }
            else
            {
                this.btn_login.Visible = false;
                this.txt_welcome.Visible = true;
                this.txt_welcome.Text = "Bievenido "+Session.GetInstance().getUser().nombre;
            }

        }

        private void Main_Resize(object sender, EventArgs e)
        {
            this.render();
        }

        private void Txt_welcome_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click_1(object sender, EventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_splash_Resize(object sender, EventArgs e)
        {
            this.render();
        }

        private void Btn_login_Leave(object sender, EventArgs e)
        {
            this.render();
        }

        private void Btn_login_Enter(object sender, EventArgs e)
        {
            this.render();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            this.render();
        }

        private void Frm_main_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void ToolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            
        }

        private void StatusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void CambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Language().Show();
        }
    }
}