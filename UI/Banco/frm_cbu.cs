using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using SL;
using BE;
using BL;

namespace UI.Banco
{
    public partial class frm_cbu : Form
    {
        public frm_cbu()
        {
            InitializeComponent();
        }

        private void loadBankdData() 
        {
            List<BancoBE> bankData = new BancoBL().findAll();
            
            if (bankData.Count > 0)
            {
                BancoBE data = bankData[0];
                this.txt_cbu.Text= Idioma.GetInstance().translate("TXT_CBU")+" "+data.cbu;
                this.txt_bank.Text = Idioma.GetInstance().translate("TXT_BANK") + " " + data.nombre;
                this.txt_alias.Text = Idioma.GetInstance().translate("TXT_ALIAS") + " " + data.alias;
            }
            else 
            {
                MessageBox.Show("Bank data not found ");
            }
        }

        private void translateText() 
        {
            this.Text = Idioma.GetInstance().translate("CBU_TITLE");
            this.cbu_title.Text = Idioma.GetInstance().translate("CBU_TITLE");
            this.cbu_title_descip.Text = Idioma.GetInstance().translate("CBU_TITLE_DESCRIP");
            this.warning_title.Text = Idioma.GetInstance().translate("WARNING_TITLE");
            this.warning_title_descrip.Text = Idioma.GetInstance().translate("WARNING_TITLE_DESCRIP");
            this.btn_copy.Text = Idioma.GetInstance().translate("BTN_COPY");
            this.btn_close.Text = Idioma.GetInstance().translate("BTN_CLOSE");
            this.btn_profile.Text = Idioma.GetInstance().translate("MAIN_MENU_PROFILE");
        }

        private void frm_cbu_Load(object sender, EventArgs e)
        {
            this.loadBankdData();
            this.translateText();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {

            this.Close();
            ClienteBE cli = Session.GetInstance().getActiveClient();
            new frm_profile(cli).Show();
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            string line = this.txt_bank.Text + "@" + this.txt_cbu.Text + "@" + this.txt_alias.Text;
            line = line.Replace("@", Environment.NewLine);

            Clipboard.SetText(line);
        }
    }
}
