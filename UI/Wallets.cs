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

namespace UI
{
    public partial class frm_wallets : Form
    {
        public frm_wallets()
        {
            InitializeComponent();
        }

        //Actualizo los textos en base al idioma elegido.
        private void translateTexts()
        {
            //Labels.
            this.ars_label.Text = Idioma.GetInstance().translate("ARS_LABEL");
            this.dog_label.Text = Idioma.GetInstance().translate("DOG_LABEL");
            this.ltc_label.Text = Idioma.GetInstance().translate("LTC_LABEL");
            this.btc_label.Text = Idioma.GetInstance().translate("BTC_LABEL");

            //Bindeo menu inicio.
            this.your_wallets_label.Text = Idioma.GetInstance().translate("YOUR_WALLETS_LABEL");
            this.Text = Idioma.GetInstance().translate("YOUR_WALLETS_LABEL");
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Frm_wallets_Load(object sender, EventArgs e)
        {
            this.translateTexts();
        }
    }
}
