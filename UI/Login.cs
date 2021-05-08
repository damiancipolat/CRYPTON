using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SL;
using BE;
using UI.utils;

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
            new labelBinder().bindKeys(this.Controls, this.labelBindings);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Deny acces with booth white flags.
            if ((this.txt_email.Text == "") && (this.txt_pwd.Text == ""))
            {
                MessageBox.Show("Debe completar, el usuario y contraseña");
                return;
            }

            //Validate login.
            Auth auth = new Auth();
            UsuarioBE user = auth.login(this.txt_email.Text, this.txt_pwd.Text);
            
            //Muestro mensaje de bienvenida.
            MessageBox.Show("Bienvenido: "+user.nombre+"!!");        
            this.parent.render();
            this.Close();
        }

        private void Frm_login_Load(object sender, EventArgs e)
        {

        }

        private void Login_btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
