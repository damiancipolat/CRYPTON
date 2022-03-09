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
using BE;
using SL;
using BL;
using SEC;

namespace UI
{
    public partial class frm_user_status : Form
    {
        private UsuarioBE user;

        public frm_user_status(UsuarioBE user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void translateText() 
        {
            this.user_status_title.Text = Idioma.GetInstance().translate("USER_STATUS_TITLE");
            this.user_status_alias.Text = Idioma.GetInstance().translate("USER_STATUS_ALIAS")+" "+this.user.alias;
            this.user_status_label.Text = Idioma.GetInstance().translate("USER_STATUS_LABEL");
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {
            //Seteo el estado.
            string status = this.usr_status_cmb.Text;

            if (status == "ACTIVO")
                this.user.estado = UsuarioEstado.ACTIVO;

            if (status == "INACTIVO")
                this.user.estado = UsuarioEstado.INACTIVO;

            if (status == "BLOQUEADO")
            {
                //Seteo el estado.
                this.user.estado = UsuarioEstado.BLOQUEADO;

                //Cargo y muestro.
                InputForm frm = new InputForm(Idioma.GetInstance().translate("Confirmar bloqueo"), Idioma.GetInstance().translate("Ingrese el motivo de bloqueo"));
                frm.ShowDialog();

                //Obtengo el valor. 
                string value = frm.getValue();

                if (value != null)
                {
                    //Armo el dto.
                    UsuarioBloqBE bloq = new UsuarioBloqBE();
                    bloq.motivo = value;
                    bloq.fecBloq = DateTime.Now;
                    bloq.usuario = this.user;

                    //Guardo el bloqueo,.
                    new UsuarioBloqBL().save(bloq);
                }
            }

            //Actualizo.
            new UsuarioBL().update(this.user);

            //Mensaje de exito.
            MessageBox.Show(Idioma.GetInstance().translate("GENERIC_SUCCESS"));

            //Cerrar.
            this.Close();

        }

        private void selectOption() 
        {
            string status = this.usr_status_cmb.Text;

            if (status == "ACTIVO")
                this.usr_status_cmb.SelectedIndex = 0;

            if (status == "INACTIVO")
                this.usr_status_cmb.SelectedIndex =  1;

            if (status == "BLOQUEADO")
                this.usr_status_cmb.SelectedIndex = 2;
        }

        private void frm_user_status_Load(object sender, EventArgs e)
        {
            this.translateText();

            //Fijo valores.
            this.usr_status_cmb.Items.Clear();
            this.usr_status_cmb.Items.Add("ACTIVO");
            this.usr_status_cmb.Items.Add("INACTIVO");
            this.usr_status_cmb.Items.Add("BLOQUEADO");
            this.usr_status_cmb.SelectedIndex = 0;

            //Seteo el combo.
            this.selectOption();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_user_status_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManual.GetInstance().openForEmpleado("bloquear_cliente");
        }
    }
}
