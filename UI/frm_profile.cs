using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics;
using BE;
using BL;
using BL.Exceptions;
using SL;
using VL;
using VL.Exceptions;

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
            this.txt_profile_cbu.Text= Idioma.GetInstance().translate("PROFILE_CBU");
            this.btn_close.Text = Idioma.GetInstance().translate("PROFILE_CLOSE");
            this.btn_ok.Text = Idioma.GetInstance().translate("PROFILE_OK");
            this.Text= Idioma.GetInstance().translate("PROFILE_FORM");
        }

        private void Frm_profile_Load(object sender, EventArgs e)
        {
            //Log
            Bitacora.GetInstance().log("PROFILE", "Load profile:" + this.client.email);

            //Traduzco.
            this.translateText();

            //Bindeo campos.
            this.txt_phone.Text = this.client.telefono;
            this.txt_address.Text = this.client.domicilio;
            this.txt_birth_date.Text= this.client.fec_nac.ToString("dd/MM/yyyy");
            this.txt_tramite.Text = this.client.num_tramite;
            this.txt_num_doc.Text = this.client.numero;
            this.txt_type_doc.Text = this.client.tipoDoc;
            this.txt_cbu.Text = this.client.cbu;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                new ClientValidator().validateUpdate(
                    this.txt_type_doc.Text,
                    this.txt_num_doc.Text,
                    this.txt_profile_address.Text,
                    this.txt_tramite.Text,
                    this.txt_address.Text,
                    this.txt_phone.Text);

                //Bindeo campos.
                this.client.telefono = this.txt_phone.Text;
                this.client.domicilio = this.txt_address.Text;
                this.client.num_tramite = this.txt_tramite.Text;
                this.client.numero = this.txt_num_doc.Text;
                this.client.tipoDoc = this.txt_type_doc.Text;
                this.client.cbu = this.txt_cbu.Text;
                this.client.fec_nac = DateTime.ParseExact(this.txt_birth_date.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                //Log.
                Bitacora.GetInstance().log("PROFILE", "Update profile:"+this.client.email);

                //Guardo y cierro.
                new ClienteBL().update(this.client);
                this.Close();
            }
            catch (BusinessException ex)
            {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
