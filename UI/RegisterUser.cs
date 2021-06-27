using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using BL;
using BL.Exceptions;
using BE;
using SL;
using UI;
using VL;
using VL.Exceptions;

namespace UI
{
    public partial class RegisterUser : Form
    {
        public RegisterUser()
        {
            InitializeComponent();
        }

        private void translateTexts()
        {
            this.Text = Idioma.GetInstance().translate("SINGUP_TITLE");
            this.signup_cancel.Text = Idioma.GetInstance().translate("BUTTON_CANCEL");
            this.signup_ok.Text = Idioma.GetInstance().translate("BUTTON_OK");
            this.your_user_label.Text = Idioma.GetInstance().translate("YOUR_USER_LABEL");
            this.signup_name.Text = Idioma.GetInstance().translate("SIGNUP_NAME");
            this.signup_surname.Text = Idioma.GetInstance().translate("SIGNUP_SURNAME");
            this.signup_alias.Text = Idioma.GetInstance().translate("SIGNUP_ALIAS");
            this.signup_email.Text = Idioma.GetInstance().translate("SIGNUP_EMAIL");
            this.signup_pwd.Text = Idioma.GetInstance().translate("SIGNUP_PWD");
            this.signup_ok.Text = Idioma.GetInstance().translate("SIGNUP_OK");
            this.signup_cancel.Text = Idioma.GetInstance().translate("SIGNUP_CANCEL");
            this.usr_signup.Text = Idioma.GetInstance().translate("SINGUP_TITLE");
            this.usr_descrip.Text = Idioma.GetInstance().translate("SINGUP_DESCRIP");
            this.signup_legacy.Text= Idioma.GetInstance().translate("SIGNUP_LEGACY");
        }


        private void Signup_ok_Click(object sender, EventArgs e)
        {
            try
            {
                //Valido el input.
                UserValidator.GetInstance().validateEmployee(
                    this.signup_txt_name.Text,
                    this.signup_txt_surname.Text,
                    this.signup_txt_alias.Text,
                    this.signup_txt_email.Text,
                    this.signup_txt_pwd.Text,
                    this.signup_legacy_txt.Text
                );

                //Bindeo campos 
                EmpleadoBE newEmp = new EmpleadoBE();
                newEmp.nombre = this.signup_txt_name.Text;
                newEmp.apellido = this.signup_txt_surname.Text;
                newEmp.alias = this.signup_txt_alias.Text;
                newEmp.email = this.signup_txt_email.Text;
                newEmp.pwd = this.signup_txt_pwd.Text;
                newEmp.tipoUsuario = UsuarioTipo.EMPLEADO;
                newEmp.legajo = this.signup_legacy_txt.Text;

                //Guardo el usuario.
                new EmpleadoBL().save(newEmp);

                MessageBox.Show("Usuario creado con exito!");
                this.Close();
                
            }
            catch (BusinessException ex)
            {
                Debug.WriteLine("----->" + ex.Message);
                MessageBox.Show(
                    Idioma.GetInstance().translate(ex.Message),
                    Idioma.GetInstance().translate("REGISTER_INPUT_ERROR_TITLE"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
            }
            catch (InputException ex)
            {
                MessageBox.Show(
                    Idioma.GetInstance().translate(ex.Message),
                    Idioma.GetInstance().translate("REGISTER_INPUT_ERROR_TITLE"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
            }
        }

        private void RegisterUser_Load(object sender, EventArgs e)
        {
            this.translateTexts();
        }

        private void Signup_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
