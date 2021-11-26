using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SL;
using SL.Exceptions;
using VL.Exceptions;
using VL;
using BE;
using SEC.Exceptions;

namespace UI
{
    public partial class frm_login : Form
    {
        //Reference to main windos.
        private frm_main parent;

        //Lista de relacion campos vs bindeos.
        private Dictionary<string, string> labelBindings = new Dictionary<string, string>{
                {"login_title_1","LOGIN_TITLE_1"},
                { "login_title_email","LOGIN_TITLE_EMAIL"},
                { "login_title_password","LOGIN_TITLE_PASSWORD"},
                { "login_btn_cancel","LOGIN_BTN_CANCEL"},
                { "login_btn_ingresar","LOGIN_BTN_INGRESAR"}
            };

        public frm_login(frm_main parent)
        {
            this.parent = parent;
            InitializeComponent();

            //Realizo actualizacion.
           // new labelBinder().bindKeys(this.Controls, this.labelBindings);
        }

        //Traducir textos.
        private void translateTexts()
        {
            this.login_title_1.Text= Idioma.GetInstance().translate("LOGIN_TITLE_1");
            this.login_title_email.Text= Idioma.GetInstance().translate("LOGIN_TITLE_EMAIL");
            this.login_title_password.Text = Idioma.GetInstance().translate("LOGIN_TITLE_PASSWORD");
            this.login_btn_ingresar.Text = Idioma.GetInstance().translate("LOGIN_BTN_INGRESAR");
            this.login_btn_cancel.Text = Idioma.GetInstance().translate("LOGIN_BTN_CANCEL");
            this.Text = Idioma.GetInstance().translate("LOGIN");
        }

        //Proceso login con manejo de excepciones.
        private void Button1_Click(object sender, EventArgs e)
        {
            try{
                //Valido el input.
                UserValidator.GetInstance().validateLogin(this.txt_email.Text, this.txt_pwd.Text);

                //Hago el login.
                new Auth().login(this.txt_email.Text, this.txt_pwd.Text);

                //Cierro.
                this.parent.render();
                this.Close();
            }
            catch (InputException ex){
                MessageBox.Show(
                    Idioma.GetInstance().translate(ex.Message),
                    Idioma.GetInstance().translate("LOGIN_INPUT_ERROR_TITLE"),
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
            }
            catch (ServiceException ex)
            {
                MessageBox.Show(
                    Idioma.GetInstance().translate(ex.Message),
                    Idioma.GetInstance().translate("LOGIN_INPUT_ERROR_TITLE"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    Idioma.GetInstance().translate(ex.Message),
                    Idioma.GetInstance().translate("SECURITY_ERROR"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Frm_login_Load(object sender, EventArgs e)
        {
            this.translateTexts();
        }

        private void Login_btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_login_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManual.GetInstance().openForClient("login");
        }
    }
}
