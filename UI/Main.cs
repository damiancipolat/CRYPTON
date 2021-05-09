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
using UI.utils;

namespace UI
{
    public partial class frm_main : Form
    {
        //Lista de relacion campos vs bindeos.
        private Dictionary<string, string> labelBindings = new Dictionary<string, string>{
                {"main_splash_title","MAIN_SPLASH_TITLE"},
                { "main_btn_login","MAIN_BTN_LOGIN"},
                { "main_change_language","MAIN_CHANGE_LANGUAGE"}
        };

        public frm_main()
        {
            InitializeComponent();

            //Realizo actualizacion.
            this.bootstrap();
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

            //Cuando la sesion esta activa.
            if (Session.GetInstance().isActive())
            {                
                this.main_splash.Hide();
                this.main_menu_login.Visible = false;
                this.main_menu_signup.Visible = false; 
                this.main_menu_signout.Visible = true;
            }
            else
            {
                this.main_splash.Show();
                this.main_menu_login.Visible = true;
                this.main_menu_signup.Visible = true;
                this.main_menu_signout.Visible = false;
            }
            
        }

        //Se ejecuta al inicio del formulario, setea idioma base.
        public void bootstrap()
        {
            //Traigo el lenguaje por defecto de la configuracion.
            string defaultLang = Idioma.GetInstance().getDefault();

            //Si no esta definido genero error.
            if (!(defaultLang != ""))
                throw new Exception("Unable to load default language");

            //Load in session the list of words.
            Session.GetInstance().setLanguage(defaultLang, Idioma.GetInstance().getWords(defaultLang));
            
            //Cargo el lenguaje por defecto en la sesion.
            new labelBinder().bindKeys(this.Controls, this.labelBindings);

            //Bindeo campos que no se pueden automaticamente.
            this.main_change_language.Text = Idioma.GetInstance().translateWord("MAIN_CHANGE_LANGUAGE");
            this.main_menu_login.Text = Idioma.GetInstance().translateKey("MAIN_MENU_LOGIN");
            this.main_menu_signup.Text = Idioma.GetInstance().translateKey("MAIN_MENU_SIGNUP");
            this.main_menu_signout.Text = Idioma.GetInstance().translateKey("MAIN_MENU_SIGNOUT");
            this.main_menu_exit.Text = Idioma.GetInstance().translateKey("MAIN_MENU_EXIT");
        }

        //Metodo de ventanas.
        private void openLogin()
        {
            //Abro el login si no esta abierto.
            if (!isWindowOpen("frm_login"))
                new frm_login(this).Show();
        }

        private void openRegister()
        {
            //Abro el signup si no esta abierto.
            if (!isWindowOpen("frm_signup"))
                new frm_signup(this).Show();
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
            this.openLogin();

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

        private void Button2_Click(object sender, EventArgs e)
        {
            UsuarioDAL dam = new UsuarioDAL();
            dam.getEntityHash();
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            this.render();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            this.render();
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

        private void CambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Language().Show();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            this.openRegister();
        }

        private void CerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openRegister();
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_menu_signout_Click(object sender, EventArgs e)
        {
            Session.GetInstance().close();
            this.render();
        }

        private void Main_menu_login_Click(object sender, EventArgs e)
        {
            this.openLogin();
        }
    }
}