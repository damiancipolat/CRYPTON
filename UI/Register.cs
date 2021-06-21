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
using SL;
using BE;
using SEC;
using BL;
using BL.Exceptions;
using VL;
using VL.Exceptions;
using UI.Notifications;

namespace UI
{
    public partial class frm_signup : Form
    {
        //Reference to main windows.
        private frm_main parent;

        //Actualizo los textos en base al idioma elegido.
        private void translateTexts()
        {
            //Labels.
            this.signup_title.Text = Idioma.GetInstance().translate("SINGUP_TITLE");
            this.signup_name.Text = Idioma.GetInstance().translate("SIGNUP_NAME");
            this.signup_surname.Text = Idioma.GetInstance().translate("SIGNUP_SURNAME");
            this.signup_alias.Text = Idioma.GetInstance().translate("SIGNUP_ALIAS");
            this.signup_email.Text = Idioma.GetInstance().translate("SIGNUP_EMAIL");
            this.signup_pwd.Text = Idioma.GetInstance().translate("SIGNUP_PWD");
            this.signup_ok.Text = Idioma.GetInstance().translate("SIGNUP_OK");
            this.signup_cancel.Text = Idioma.GetInstance().translate("SIGNUP_CANCEL");
            this.document_number.Text = Idioma.GetInstance().translate("DOCUMENT_NUMBER");
            this.birth_date.Text = Idioma.GetInstance().translate("BIRTH_DATE");
            this.order_number.Text = Idioma.GetInstance().translate("ORDER_NUMER");
            this.address.Text = Idioma.GetInstance().translate("ADDRESS");
            this.phone_number.Text = Idioma.GetInstance().translate("PHONE_NUMBER");
            this.signup_description.Text= Idioma.GetInstance().translate("SINGUP_DESCRIPTION");
            this.your_documents.Text = Idioma.GetInstance().translate("YOUR_DOCUMENTS");
            this.your_user_label.Text = Idioma.GetInstance().translate("YOUR_USER_LABEL");
        }

        public frm_signup(frm_main parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Signup_ok_Click(object sender, EventArgs e)
        {
            try
            {
                //Valido el input.
                UserValidator.GetInstance().validateRegister(
                    this.signup_txt_name.Text,
                    this.signup_txt_surname.Text,
                    this.signup_txt_alias.Text,
                    this.signup_txt_email.Text,
                    this.signup_txt_pwd.Text,
                    this.document_number_txt.Text,
                    this.birth_date_txt.Text,
                    this.order_number_txt.Text,
                    this.address_txt.Text,
                    this.phone_number_txt.Text
                );

                //Bindeo campos 
                ClienteBE newClient = new ClienteBE();
                newClient.nombre = this.signup_txt_name.Text;
                newClient.apellido = this.signup_txt_surname.Text;
                newClient.alias = this.signup_txt_alias.Text;
                newClient.email = this.signup_txt_email.Text;
                newClient.pwd = this.signup_txt_pwd.Text;
                newClient.tipoUsuario = UsuarioTipo.CLIENTE;
                newClient.tipoDoc = "DNI";
                newClient.numero = this.document_number_txt.Text;
               // newClient.fec_nac =this.birth_date_txt.Text;
                newClient.num_tramite = this.order_number_txt.Text;
                newClient.domicilio = this.address_txt.Text;
                newClient.telefono = this.phone_number_txt.Text;

                //Grabo el cliente.
                int newId = new ClienteBL().save(newClient);
                newClient.idcliente = newId;

                //Creo la cuenta del cliente y sus respectivas billeteras
                new CuentaBL().crear(newClient);
                
                //Mensaje de exito.
                MessageBox.Show(
                    Idioma.GetInstance().translate("REGISTER_INPUT_SUCCESS"),
                    Idioma.GetInstance().translate("REGISTER_INPUT_ERROR_TITLE"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                //Hago autologin.
                UsuarioBE user = new Auth().login(this.signup_txt_email.Text, this.signup_txt_pwd.Text);

                this.parent.render();
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
                Debug.WriteLine("----->" + ex.Message);
                MessageBox.Show(
                    Idioma.GetInstance().translate(ex.Message),
                    Idioma.GetInstance().translate("REGISTER_INPUT_ERROR_TITLE"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
            }
        }

        private void Frm_signup_Load(object sender, EventArgs e)
        {
            this.translateTexts();
        }
    }
}
