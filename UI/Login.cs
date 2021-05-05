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

namespace UI
{
    public partial class frm_login : Form
    {
        private frm_main parent;

        public frm_login(frm_main parent)
        {
            this.parent = parent;
            InitializeComponent();
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

            if (user == null)
            {
                MessageBox.Show("Acceso incorrecto, verifique sus datos,");
                return;
            }
            
            //Muestro mensaje de bienvenida.
            MessageBox.Show("Bienvenido: "+user.nombre+"!!");        
            this.parent.render();
            this.Close();

        }

        private void Frm_login_Load(object sender, EventArgs e)
        {

        }
    }
}
