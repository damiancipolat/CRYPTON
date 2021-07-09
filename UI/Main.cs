using BE;
using BE.Permisos;
using BL;
using DAL;
using SL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using UI.Notifications;

namespace UI
{
    public partial class frm_main : Form, INotification
    {
        //Bus de notificaciones.
        private Notificator uiEvents = new Notificator();
        private string defaultLang=null;

        public frm_main()
        {
            InitializeComponent();

            //Realizo actualizacion.
            this.render();

            //Bindeo el form principal para recibir notificaciones desde otras ventans.
            this.uiEvents.Attach(this);
        }

        //------------------------------------------------------------------------------

        //Metodos de render.
        private void adjustControls()
        {
            //Posiciona el splash screen en el centro.
            this.main_splash.Left = (this.Width / 2) - (this.main_splash.Width / 2);
            this.main_splash.Top = (this.Height / 2) - (this.main_splash.Height / 2);

            //Posiciona el splash de actividades en el centro.
           // this.main_splash_activity_panel.Left = (this.Width / 2) - (this.main_splash_activity_panel.Width / 2);
           // this.main_splash_activity_panel.Top = (this.Height / 2) - (this.main_splash_activity_panel.Height / 2);
            
            //Oculto/muestro menus en base a la sesion y permisos.
            this.bindMenu();            
        }

        //Se carga el idioma por defecto.
        private void loadDefaultLanguage()
        {
            //Cargo el idioma por defecto de la configuracion si no esta seteado.
            this.defaultLang = (this.defaultLang == null)
                ? ConfigurationManager.AppSettings["Language"]
                : Idioma.GetInstance().getDefault().code;
            
            //Cargo el idioma por defecto.
            Idioma.GetInstance().setDefault(Idioma.GetInstance().getIdioma(this.defaultLang));
        }

        //Actualizo los textos en base al idioma elegido.
        private void translateTexts()
        {
            //Labels.
            this.main_splash_title.Text = Idioma.GetInstance().translate("MAIN_SPLASH_TITLE");
            this.main_btn_login.Text = Idioma.GetInstance().translate("MAIN_BTN_LOGIN");
            this.main_btn_register.Text = Idioma.GetInstance().translate("MAIN_MENU_SIGNUP");
           // this.main_splash_activity.Text = Idioma.GetInstance().translate("MAIN_SPLASH_ACTIVITY");
            this.main_change_language.Text = Idioma.GetInstance().translate("MAIN_CHANGE_LANGUAGE");

            //Bindeo menu inicio.            
            this.main_menu_start.Text = Idioma.GetInstance().translate("MAIN_MENU_START");
            this.main_change_language.Text = Idioma.GetInstance().translate("MAIN_CHANGE_LANGUAGE");
            this.main_menu_login.Text = Idioma.GetInstance().translate("MAIN_MENU_LOGIN");
            this.main_menu_signup.Text = Idioma.GetInstance().translate("MAIN_MENU_SIGNUP");
            this.main_menu_signout.Text = Idioma.GetInstance().translate("MAIN_MENU_SIGNOUT");
            this.main_menu_exit.Text = Idioma.GetInstance().translate("MAIN_MENU_EXIT");

            //Bindeo menu cliente.
            this.main_menu_operate.Text = Idioma.GetInstance().translate("MAIN_MENU_OPERATE");
            this.main_menu_buy.Text = Idioma.GetInstance().translate("MAIN_MENU_BUY");
            this.main_menu_sell.Text = Idioma.GetInstance().translate("MAIN_MENU_SELL");
            this.main_menu_search.Text = Idioma.GetInstance().translate("MAIN_MENU_SEARCH");
            this.main_menu_deposit.Text = Idioma.GetInstance().translate("MAIN_MENU_DEPOSIT");
            this.main_menu_extract.Text = Idioma.GetInstance().translate("MAIN_MENU_EXTRACT");

            //bindeo menuit
            this.main_menu_it.Text = Idioma.GetInstance().translate("MAIN_MENU_IT");
            this.main_menu_it_add_user.Text = Idioma.GetInstance().translate("MAIN_MENU_IT_ADD_USER");
            this.main_menu_it_user_manager.Text = Idioma.GetInstance().translate("MAIN_MENU_IT_USER_MANAGER");
            this.main_menu_it_lang_manager.Text = Idioma.GetInstance().translate("MAIN_MENU_IT_LANG_MANAGER");
            
        }

        //Se ejecuta al inicio del formulario, setea idioma base.
        public void render()
        {
            //Cargo el idioma por decto.
            this.loadDefaultLanguage();

            //Traduzco los textos en base al idioma.
            this.translateTexts();

            //Ajusto los controles.
            this.adjustControls();
        }

        public void Update()
        {
            this.render();
        }

        //------------------------------------------------------------------------------

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
            PermisoBL permBL = new PermisoBL();

            //Set items if the code exist in the list.
            this.main_menu_operate.Visible = true;
            this.main_menu_search.Visible = permBL.hasPermission(permissions, "USR005");
            this.main_menu_sell.Visible = permBL.hasPermission(permissions, "USR004");
            this.main_menu_buy.Visible = permBL.hasPermission(permissions, "USR003");
            this.main_menu_deposit.Visible = permBL.hasPermission(permissions, "USR002");
            this.main_menu_extract.Visible = permBL.hasPermission(permissions, "USR001");
        }

        //Manejo el menu de empleado.
        private void handleEmployeeMenu()
        {
            List<Componente> permissions = Session.GetInstance().getPermissions();
            PermisoBL permBL = new PermisoBL();

            //It menu
            this.main_menu_it.Visible = permBL.hasPermission(permissions, "ADM003");
            this.main_menu_it_add_user.Visible = permBL.hasPermission(permissions, "IT0001");
            this.main_menu_it_user_manager.Visible = permBL.hasPermission(permissions, "IT0002");
            this.main_menu_it_lang_manager.Visible = permBL.hasPermission(permissions, "IT0003");
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
                {
                    this.handleClientMenu();
                }                    

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

                //IT MENU
                this.main_menu_it.Visible = false;
            }
        }

        //-----------------------------------------------------------------------------

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
            this.adjustControls();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            this.adjustControls();
        }

        private void Main_splash_Resize(object sender, EventArgs e)
        {
            this.adjustControls();
        }

        private void Btn_login_Leave(object sender, EventArgs e)
        {

        }

        private void Btn_login_Enter(object sender, EventArgs e)
        {

        }

        private void Main_Shown(object sender, EventArgs e)
        {

        }

        private void CambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Language(this.uiEvents).Show();
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

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Main_menu_operate_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click_2(object sender, EventArgs e)
        {
            new frm_wallets(2).Show();
        }

        private void Button2_Click_3(object sender, EventArgs e)
        {
        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void Main_splash_activity_panel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Button1_Click_3(object sender, EventArgs e)
        {
            new frm_publish_sell().Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click_4(object sender, EventArgs e)
        {

        }

        private void Button2_Click_4(object sender, EventArgs e)
        {

        }

        private void AltaDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RegisterUser().Show();
        }

        private void GestorPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UsersControl().Show();
        }

        private void Button1_Click_5(object sender, EventArgs e)
        {
   
        }

        private void Button1_Click_6(object sender, EventArgs e)
        {
            UsuarioBE user = new UsuarioBL().findById(2);
            new PermisosFrm(user).Show();
        }

        private void Button1_Click_7(object sender, EventArgs e)
        {
            new IdiomaPanel().Show();
        }

        private void GestorIdiomasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IdiomaPanel().Show();
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            new RegisterUser().Show();
        }
    }
}
 
 