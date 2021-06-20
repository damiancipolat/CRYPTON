﻿using System;
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
                    this.signup_txt_pwd.Text
                );

                //Bindeo campos 
                ClienteBE newClient = new ClienteBE();
                newClient.nombre = this.signup_txt_name.Text;
                newClient.apellido = this.signup_txt_surname.Text;
                newClient.alias = this.signup_txt_alias.Text;
                newClient.email = this.signup_txt_email.Text;
                newClient.pwd = this.signup_txt_pwd.Text;
                newClient.tipoUsuario = UsuarioTipo.CLIENTE;

                //Grabo el cliente.
                new ClienteBL().save(newClient);
                
                //Mensaje de exito.
                /*MessageBox.Show(
                    Idioma.GetInstance().translateKey("REGISTER_INPUT_SUCCESS"),
                    Idioma.GetInstance().translateKey("REGISTER_INPUT_ERROR_TITLE"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );*/

                //Hago autologin.
                UsuarioBE user = new Auth().login(this.signup_txt_email.Text, this.signup_txt_pwd.Text);
                this.parent.render();
                this.Close();
            }
            catch (InputException ex)
            {
                /*MessageBox.Show(
                    Idioma.GetInstance().translateKey(ex.Message),
                    Idioma.GetInstance().translateKey("REGISTER_INPUT_ERROR_TITLE"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );*/
            }
        }

        private void Frm_signup_Load(object sender, EventArgs e)
        {
            MessageBox.Show("AAAAA");
        }
    }
}
