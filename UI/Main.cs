using BE;
using BE.Permisos;
using BL;
using SL;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using UI.Notifications;
using UI.Permisos;
using UI.Admin;
using UI.Installer;
using UI.Banco;
using BL.Permisos;
using BL.ChangeControl;
using BL.Security;
using BL.Installer;
using BE.ValueObject;
using IO;
using IO.Responses;
using IO.RequestFormat;
using SEC;
using SEC.Exceptions;
using UI.Comisiones;
using DAL;
using System.Security.Principal;


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

        //Correr como admin.
        public bool IsUserAdministrator()
        {
            bool isAdmin;
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                isAdmin = false;
            }
            catch (Exception ex)
            {
                isAdmin = false;
            }
            return isAdmin;
        }

        //------------------------------------------------------------------------------

        //Metodos de render.
        private void adjustControls()
        {
            if (this.installRequired())
                return;

            //Posiciona el splash screen en el centro.
            this.main_splash.Left = (this.Width / 2) - (this.main_splash.Width / 2);
            this.main_splash.Top = (this.Height / 2) - (this.main_splash.Height / 2);

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
            this.main_menu_search.Text = Idioma.GetInstance().translate("MAIN_MENU_SEARCH");
            this.main_menu_recomendations.Text = Idioma.GetInstance().translate("MAIN_MENU_RECOMENDATIONS");
            this.main_menu_my_sells.Text = Idioma.GetInstance().translate("MAIN_MENU_MY_SELLS");
            this.main_menu_notifications.Text= Idioma.GetInstance().translate("MAIN_MENU_NOTIFICATIONS");
            this.main_menu_balance.Text = Idioma.GetInstance().translate("MAIN_MENU_MY_WALLETS");
            this.main_menu_publish.Text= Idioma.GetInstance().translate("MAIN_MENU_SELL");
            this.main_menu_my_buys.Text= Idioma.GetInstance().translate("MY_BUYS");
            this.main_menu_profile.Text = Idioma.GetInstance().translate("MAIN_MENU_PROFILE");
            this.main_menu_cbu.Text= Idioma.GetInstance().translate("MAIN_MENU_CBU");
            this.main_menu_extract.Text = Idioma.GetInstance().translate("MAIN_MENU_EXTRACT");
            this.main_menu_extract_crypto.Text= Idioma.GetInstance().translate("MAIN_MENU_EXTRACT_CRYPTO");            

            //bindeo menu it
            this.main_menu_it.Text = Idioma.GetInstance().translate("MAIN_MENU_IT");
            this.main_menu_it_add_user.Text = Idioma.GetInstance().translate("MAIN_MENU_IT_ADD_USER");
            this.main_menu_it_user_manager.Text = Idioma.GetInstance().translate("MAIN_MENU_IT_USER_MANAGER");
            this.main_menu_it_lang_manager.Text = Idioma.GetInstance().translate("MAIN_MENU_IT_LANG_MANAGER");
            this.main_menu_it_user_perm_manager.Text = Idioma.GetInstance().translate("MAIN_MENU_IT_USER_PERM_MANAGER");
            this.main_menu_it_perm_manager.Text = Idioma.GetInstance().translate("MAIN_MENU_PERMISSION");
            this.main_menu_it_log.Text = Idioma.GetInstance().translate("MAIN_MENU_LOG_SEARCH");
            this.main_menu_it_backup.Text = Idioma.GetInstance().translate("MAIN_MENU_IT_BACKUP");
            this.main_menu_op_cash_in.Text = Idioma.GetInstance().translate("MAIN_MENU_CASH_IN");
            this.main_menu_lista_retiro.Text = Idioma.GetInstance().translate("MAIN_MENU_EXTRACT_ARS");
            this.main_menu_debts.Text = Idioma.GetInstance().translate("COMMISION_DEBTS_TITLE");
            this.main_menu_earnings_report.Text= Idioma.GetInstance().translate("REPORT_DBT_TITLE");
        }

        //Se ejecuta al inicio del formulario, setea idioma base.
        public void render()
        {
            try
            {
                //Analizo si hace falta hacer la instalación antes.
                if (this.installRequired())
                    return;
            
                //Cargo el idioma por decto.
                this.loadDefaultLanguage();

                //Traduzco los textos en base al idioma.
                this.translateTexts();

                //Ajusto los controles.
                this.adjustControls();
            }
            catch (Exception err) 
            {
                Bitacora.GetInstance().log("BOOTSTRAP",err.Message,true);
            }
            
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

        //Oculto/Muestro el menu de cliente.
        private void handleClientMenu()
        {
            List<Componente> permissions = Session.GetInstance().getPermissions();
            PermisoBL permBL = new PermisoBL();

            //Set items if the code exist in the list.
            this.main_menu_operate.Visible = true;
            this.main_menu_client.Visible = true;
            this.main_menu_search.Visible = permBL.hasPermission(permissions,PermisoCodes.SEARCH_OFFERS.ToString());
            this.main_menu_recomendations.Visible = permBL.hasPermission(permissions, PermisoCodes.RECOMENDATIONS.ToString());
            this.main_menu_my_sells.Visible = permBL.hasPermission(permissions, PermisoCodes.MY_PUBLICATIONS.ToString());
            this.main_menu_balance.Visible = permBL.hasPermission(permissions, PermisoCodes.MY_BALANCE.ToString());
            this.main_menu_notifications.Visible = permBL.hasPermission(permissions, PermisoCodes.NOTIFICATIONS.ToString());
            this.main_menu_publish.Visible = permBL.hasPermission(permissions, PermisoCodes.PUBLISH_OFFER.ToString());
            this.main_menu_my_buys.Visible = permBL.hasPermission(permissions, PermisoCodes.MY_BUYS.ToString());
            this.main_menu_my_buys.Visible = permBL.hasPermission(permissions, PermisoCodes.MY_BUYS.ToString());
            this.main_menu_profile.Visible = permBL.hasPermission(permissions, PermisoCodes.MY_PROFILE.ToString());
            this.main_menu_cbu.Visible = permBL.hasPermission(permissions, PermisoCodes.CBU.ToString());
            this.main_menu_extract.Visible = permBL.hasPermission(permissions, PermisoCodes.EXTRACT.ToString());
            this.main_menu_extract_crypto.Visible = permBL.hasPermission(permissions, PermisoCodes.EXTRACT_CRYPTO.ToString());
        }

        //Manejo el menu de empleado.
        private void handleEmployeeMenu()
        {
            List<Componente> permissions = Session.GetInstance().getPermissions();
            PermisoBL permBL = new PermisoBL();

            //It menu
            this.main_menu_it.Visible = true;//permBL.hasPermission(permissions, PermisoCodes.IT.ToString());
            this.main_menu_it_lang_manager.Visible = permBL.hasPermission(permissions, PermisoCodes.MANAGE_LANGUAGES.ToString());
            this.main_menu_it_user_perm_manager.Visible = permBL.hasPermission(permissions, PermisoCodes.MANAGE_USER_PERMISSION.ToString());
            this.main_menu_it_add_user.Visible = permBL.hasPermission(permissions, PermisoCodes.CREATE_USER.ToString());
            this.main_menu_it_user_manager.Visible = permBL.hasPermission(permissions, PermisoCodes.MANAGE_USERS.ToString());            
            this.main_menu_it_perm_manager.Visible = permBL.hasPermission(permissions, PermisoCodes.MANAGE_PERMISSION.ToString());
            this.main_menu_it_log.Visible = permBL.hasPermission(permissions, PermisoCodes.SEARCH_LOG.ToString());
            this.main_menu_it_backup.Visible = permBL.hasPermission(permissions, PermisoCodes.BACKUP.ToString());
            this.main_menu_op_cash_in.Visible = permBL.hasPermission(permissions, PermisoCodes.CASH_IN.ToString());
            this.main_menu_lista_retiro.Visible = permBL.hasPermission(permissions, PermisoCodes.EXTRACT_LIST.ToString());
            this.main_menu_debts.Visible = permBL.hasPermission(permissions, PermisoCodes.DEBTS_REPORT.ToString());
            this.main_menu_earnings_report.Visible = permBL.hasPermission(permissions, PermisoCodes.EARNINGS_REPORT.ToString());
        }

        //Oculto menu en base a los permisos.
        private void bindMenu()
        {
            //Recupero datos de la sesion.
            bool isActive = Session.GetInstance().isActive();

            //If the user is defined.
            if (Session.GetInstance().getUser() != null)
            {
                //Translate text.
                UsuarioTipo userType = Session.GetInstance().getUser().tipoUsuario;

                if (userType == UsuarioTipo.CLIENTE)
                    this.handleClientMenu();

                if (userType == UsuarioTipo.EMPLEADO)
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
                this.main_menu_client.Visible = false;

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
         private void Button2_Click_2(object sender, EventArgs e)
        {
            new frm_publish_sell().Show();
        }
        
        private void Button1_Click_2(object sender, EventArgs e)
        {
            new frm_wallets(2).Show();
        }

        private void Button1_Click_3(object sender, EventArgs e)
        {
            new frm_publish_sell().Show();
        }

        private void AltaDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RegisterUser().Show();
        }

        private void GestorPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UsersControl().Show();
        }

        private void Button1_Click_6(object sender, EventArgs e)
        {

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

        private void Button4_Click_1(object sender, EventArgs e)
        {
            new UsersControl().Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            new frm_publish_sell().Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            new BuscadorOfertas().Show();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            new MySellOrders().Show();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            new frm_recomendations().Show();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            new OperacionView(2).Show();
        }
        private void Button10_Click(object sender, EventArgs e)
        {
            //new RegisterUser().Show();
            new UsersControl().Show();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            ClienteBE cli = new ClienteBL().findById(4);
            new NotificationsFrm(cli).Show();
        }

        private void Main_menu_recomendations_Click(object sender, EventArgs e)
        {
            new frm_recomendations().Show();
        }

        private void Main_menu_my_sells_Click(object sender, EventArgs e)
        {
            new MySellOrders().Show();
        }

        private void Main_menu_search_Click(object sender, EventArgs e)
        {
            new BuscadorOfertas().Show();
        }

        private void Main_menu_publish_Click(object sender, EventArgs e)
        {
            new frm_publish_sell().Show();
        }

        private void Main_menu_balance_Click(object sender, EventArgs e)
        {
            CuentaBE cta = new CuentaBL().traerActiva(Session.GetInstance().getActiveClient());
            new frm_wallets(cta.idcuenta).Show();
        }

        private void Main_menu_notifications_Click(object sender, EventArgs e)
        {
            new NotificationsFrm(Session.GetInstance().getActiveClient()).Show();
        }
        
        private void Button4_Click_2(object sender, EventArgs e)
        {
            new ComponentCrudFrm("family").Show();
        }

        private void Button5_Click_2(object sender, EventArgs e)
        {
            new ComponentCrudFrm("patent").Show();
        }

        private void Button6_Click_1(object sender, EventArgs e)
        {
            new TreeEditorFrm().Show();
        }

        private void Button7_Click_1(object sender, EventArgs e)
        {
            new UserTreeFrm().Show();
        }

        private void Button1_Click_9(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
        }

        private void Main_menu_operate_Click(object sender, EventArgs e)
        {

        }

        private void Main_menu_my_buys_Click(object sender, EventArgs e)
        {
            new MyBuysFrm().Show();
        }

        private void GestorDePermisosUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UserTreeFrm().Show();
        }

        private void Main_menu_it_perm_manager_Click(object sender, EventArgs e)
        {
            new TreeEditorFrm().Show();
        }

        private void Button1_Click_4(object sender, EventArgs e)
        {

        }

        private void Main_menu_it_log_Click(object sender, EventArgs e)
        {
            new frm_bitacora().Show();
        }

        private void Button1_Click_5(object sender, EventArgs e)
        {
            ClienteBE cli = new ClienteBL().findById(4);
            new ClientChangeBL().recordChange(cli);
        }

        private void Main_menu_it_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click_2(object sender, EventArgs e)
        {
            new UsersControl().Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            new TreeEditorFrm().Show();
        }

        private void MainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClienteBE cli = Session.GetInstance().getActiveClient();
            new frm_profile(cli).Show();
        }

        private void Main_menu_it_backup_Click(object sender, EventArgs e)
        {
            new frm_backup().Show();
        }

        private void Button1_Click_8(object sender, EventArgs e)
        {
            new FileLayer().log("aaa", "aaa");
        }

        public void HideAll() 
        {
            this.main_splash.Visible = false;
            this.statusStrip1.Visible = false;
            this.menuStrip1.Visible = false;
        }

        public void ShowAll()
        {
            this.main_splash.Visible = true;
            this.statusStrip1.Visible = true;
            this.menuStrip1.Visible = true;
        }

        private Boolean installRequired() 
        {
            return new InstallerBL().isRequired();
        }

        private void Frm_main_Load(object sender, EventArgs e)
        {
            try
            {

                //Arranco como admin.
                this.IsUserAdministrator();

                //Set title of main form.
                string version = ConfigurationManager.AppSettings["Version"];
                Console.WriteLine("VERSION:" + version);
                this.Text = "Crypton - V " + version;

                //Detecto si hace falta interrumpir y hacer la instalacion 1ro.
                if (this.installRequired())
                {
                    new frm_installer().Show();

                    //Oculto todo.
                    this.HideAll();
                }
                else
                {
                    //Antes de hacer el login, hago una prueba de integridad.
                    new IntegrityBL().validateComplete();
                }
            }
            catch (IntegrityException ex)
            {
                Bitacora.GetInstance().log("VIOLATION ERROR - DETAIL", ex.metadata);
                new NotificacionBL().notifyAdmin("VIOLATION ERROR - DETAIL", ex.metadata);

                MessageBox.Show(
                    Idioma.GetInstance().translate(ex.Message),
                    Idioma.GetInstance().translate("INTEGRITY_ERROR"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Bitacora.GetInstance().log("INTEGRITY ERROR",ex.Message);

                MessageBox.Show(
                    ex.Message,
                    Idioma.GetInstance().translate("ERROR"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Button1_Click_10(object sender, EventArgs e)
        {

        }

        private void Button1_Click_11(object sender, EventArgs e)
        {
        }

        private void Button1_Click_12(object sender, EventArgs e)
        {
            new frm_lista_retiro().Show();
        }

        private void Button1_Click_13(object sender, EventArgs e)
        {
            new frm_cbu().Show();
        }

        private void main_menu_cbu_Click(object sender, EventArgs e)
        {
            new frm_cbu().Show();
        }

        private void button1_Click_14(object sender, EventArgs e)
        {
        }

        private void main_menu_op_cash_in_Click(object sender, EventArgs e)
        {
            new frm_buscar_cbu().Show();
        }

        private void main_menu_extract_Click(object sender, EventArgs e)
        {
            new frm_solic_retiro().Show();
        }

        private void main_menu_lista_retiro_Click(object sender, EventArgs e)
        {
            new frm_lista_retiro().Show();
        }

        private void main_menu_extract_crypto_Click(object sender, EventArgs e)
        {
            new frm_crypto_extract().Show();
        }

        private void button1_Click_15(object sender, EventArgs e)
        {
            this.home_label_bar.Visible = true;
            this.home_label_bar.Text="Cargando...";            
            new frm_cobrar().Show();
            this.home_label_bar.Visible = false;
        }

        private void mainmenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_deudores().Show();
        }

        private void mainmenuearningsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_ganancias().Show();
        }

        private void button1_Click_16(object sender, EventArgs e)
        {

        }

        private void button1_Click_17(object sender, EventArgs e)
        {
        }

        private void button1_Click_18(object sender, EventArgs e)
        {
            new frm_deudores().Show();
        }

        private void button1_Click_19(object sender, EventArgs e)
        {
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpManual.GetInstance().openHelp();
        }

        private void button1_Click_20(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_21(object sender, EventArgs e)
        {
        }
    }
}