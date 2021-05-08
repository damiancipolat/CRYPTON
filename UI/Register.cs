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
using UI.utils;
using BL;

namespace UI
{
    public partial class frm_signup : Form
    {
        //Reference to main windos.
        private frm_main parent;

        //Lista de relacion campos vs bindeos.
        private Dictionary<string, string> labelBindings = new Dictionary<string, string>{
                {"signup_title","SINGUP_TITLE"},
                { "signup_name","SIGNUP_NAME"},
                { "signup_surname","SIGNUP_SURNAME"},
                { "signup_alias","SIGNUP_ALIAS"},
                { "signup_email","SIGNUP_EMAIL"},
                { "signup_pwd","SIGNUP_PWD"},
                { "signup_ok","SIGNUP_OK"},
                { "signup_cancel","SIGNUP_CANCEL"}
            };

        public frm_signup(frm_main parent)
        {
            InitializeComponent();
            this.parent = parent;

            //Realizo actualizacion.
            new labelBinder().bindKeys(this.Controls, this.labelBindings);
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
            //Bindeo campos 
            UsuarioBE newUser = new UsuarioBE();
            newUser.nombre = this.signup_txt_name.Text;
            newUser.apellido = this.signup_txt_surname.Text;
            newUser.alias = this.signup_txt_alias.Text;
            newUser.email = this.signup_txt_email.Text;
            newUser.pwd = this.signup_txt_pwd.Text;
            newUser.tipoUsuario = UsuarioTipo.CLIENTE;

            //Grabo el usuario.
            new UsuarioBL().save(newUser);
            MessageBox.Show("Usuario creado con exito!");
            
            //Hago autologin.            
            UsuarioBE user = new Auth().login(newUser.email, this.signup_txt_pwd.Text);
            this.parent.render();
            this.Close();
        }

        private void Frm_signup_Load(object sender, EventArgs e)
        {

        }
    }
}
