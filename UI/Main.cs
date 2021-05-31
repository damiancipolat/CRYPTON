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
using BL;
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
using PL;

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

            //Oculto/muestro menus en base a la sesion y permisos.
            this.bindMenu();            
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

            //Bindeo menu inicio.
            this.main_change_language.Text = Idioma.GetInstance().translateWord("MAIN_CHANGE_LANGUAGE");
            this.main_menu_login.Text = Idioma.GetInstance().translateKey("MAIN_MENU_LOGIN");
            this.main_menu_signup.Text = Idioma.GetInstance().translateKey("MAIN_MENU_SIGNUP");
            this.main_menu_signout.Text = Idioma.GetInstance().translateKey("MAIN_MENU_SIGNOUT");
            this.main_menu_exit.Text = Idioma.GetInstance().translateKey("MAIN_MENU_EXIT");

            //Bindeo menu cliente.
            this.main_menu_operate.Text = Idioma.GetInstance().translateKey("MAIN_MENU_OPERATE");
            this.main_menu_buy.Text = Idioma.GetInstance().translateKey("MAIN_MENU_BUY");
            this.main_menu_sell.Text = Idioma.GetInstance().translateKey("MAIN_MENU_SELL");
            this.main_menu_search.Text = Idioma.GetInstance().translateKey("MAIN_MENU_SEARCH");
            this.main_menu_deposit.Text = Idioma.GetInstance().translateKey("MAIN_MENU_DEPOSIT");
            this.main_menu_extract.Text = Idioma.GetInstance().translateKey("MAIN_MENU_EXTRACT");
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

        //Manejo el menu de cliente.
        private void handleClientMenu()
        {
            List<Componente> permissions = Session.GetInstance().getPermissions();

            foreach (Componente cp in permissions)
            {
                Debug.WriteLine("@@-->"+cp.Id.ToString()+","+cp.Nombre);
            }

            PermisoBL permBL = new PermisoBL();

            //Set items if the code exist in the list.
            this.main_menu_operate.Visible = true;
            this.main_menu_search.Visible = permBL.hasPermission(permissions, 11);
            this.main_menu_sell.Visible = permBL.hasPermission(permissions, 10);
            this.main_menu_buy.Visible = permBL.hasPermission(permissions, 9);
            this.main_menu_deposit.Visible = permBL.hasPermission(permissions, 8);
            this.main_menu_extract.Visible = permBL.hasPermission(permissions, 7);
        }

        //Manejo el menu de empleado.
        private void handleEmployeeMenu()
        {

        }

        //Oculto menu en base a los permisos.
        private void bindMenu()
        {
            //Recupero datos de la sesion.
            bool isActive = Session.GetInstance().isActive();

            //If the user is defined.
            if (Session.GetInstance().getUser() != null)
            {
                UsuarioTipo userType = Session.GetInstance().getUser().tipoUsuario;

                //Manejo menu de clientes.
                if (userType == UsuarioTipo.CLIENTE && isActive)
                    this.handleClientMenu();

                //Manejo menu de empleados.
                if (userType == UsuarioTipo.EMPLEADO && isActive)
                    this.handleEmployeeMenu();
            }          

            //Si esta desactivada la sesion.
            if (isActive)
            {
                this.main_splash.Hide();
                this.main_menu_login.Visible = false;
                this.main_menu_signup.Visible = false;
                this.main_menu_signout.Visible = true;
            }
            else
            {
                //Start menu
                this.main_splash.Show();
                this.main_menu_login.Visible = true;
                this.main_menu_signup.Visible = true;
                this.main_menu_signout.Visible = false;

                //Client menu
                this.main_menu_operate.Visible = false;
                this.main_menu_search.Visible = false;
                this.main_menu_sell.Visible = false;
                this.main_menu_buy.Visible = false;
                this.main_menu_deposit.Visible = false;
                this.main_menu_extract.Visible = false;
            }
        }

        //-----------------------

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

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {

        }

        private void InicioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button2_Click_2(object sender, EventArgs e)
        {
            new frm_publish_sell().Show();
        }
    }
}