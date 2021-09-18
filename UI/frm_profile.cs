using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BL;
using SL;

namespace UI
{
    public partial class frm_profile : Form
    {
        private ClienteBE client;

        public frm_profile(ClienteBE client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void Usr_change_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void translateText()
        {
            this.txt_profile_type_doc.Text = Idioma.GetInstance().translate("PROFILE_TYPE_DOC");
            this.txt_profile_doc_number.Text = Idioma.GetInstance().translate("PROFILE_DOC_NUMBER");
            this.txt_profile_birth_date.Text = Idioma.GetInstance().translate("PROFILE_BIRTH_DATE");
            this.txt_profile_tramite.Text = Idioma.GetInstance().translate("PROFILE_TRAMITE");
            this.txt_profile_address.Text = Idioma.GetInstance().translate("PROFILE_ADDRESS");
            this.txt_profile_phone.Text = Idioma.GetInstance().translate("PROFILE_PHONE");
            this.btn_close.Text = Idioma.GetInstance().translate("PROFILE_CLOSE");
            this.btn_ok.Text = Idioma.GetInstance().translate("PROFILE_OK");
        }

        private void Frm_profile_Load(object sender, EventArgs e)
        {
            //Traduzco.
            this.translateText();

            //Bindeo campos.
            this.txt_phone.Text = this.client.telefono;
            this.txt_address.Text = this.client.domicilio;
            this.txt_tramite.Text = this.client.num_tramite;
            this.txt_num_doc.Text = this.client.numero;
            this.txt_type_doc.Text = this.client.tipoDoc;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
