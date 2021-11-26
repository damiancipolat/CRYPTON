using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using BE;
using BE.ValueObject;
using SL;
using BL;
using IO;
using IO.Responses;

namespace UI.Banco
{
    public partial class frm_crypto_extract : Form
    {
        private List<BilleteraBE> wallets = new List<BilleteraBE>();

        public frm_crypto_extract()
        {
            InitializeComponent();
        }

        private void translaTexts() 
        {
        
        }

        private void wallet_btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void translateText() 
        {
            this.Text= Idioma.GetInstance().translate("EXTRACT_CRYPTO_WALLET_TITLE");
            this.extract_crypto_wallet_title.Text = Idioma.GetInstance().translate("EXTRACT_CRYPTO_WALLET_TITLE");
            this.extract_crypto_wallet_descrip.Text = Idioma.GetInstance().translate("EXTRACT_CRYPTO_WALLET_DESCRIP");
            this.extract_crypto_origin.Text = Idioma.GetInstance().translate("EXTRACT_CRYPTO_WALLET_ORIGIN");
            this.extract_crypto_value.Text = Idioma.GetInstance().translate("EXTRACT_CRYPTO_WALLET_VALUE");
            this.extract_crypto_destiny.Text = Idioma.GetInstance().translate("EXTRACT_CRYPTO_WALLET_DESTINY");
            this.wallet_btn_close.Text= Idioma.GetInstance().translate("PROFILE_CLOSE");
            this.wallet_btn_close.Text = Idioma.GetInstance().translate("PROFILE_CLOSE");
            this.wallet_btn_ok.Text= Idioma.GetInstance().translate("BTN_RETIRO_OK");
        }

        private void frm_crypto_extract_Load(object sender, EventArgs e)
        {
            this.translateText();

            //Cargo las billeteras.
            Dictionary<string,BilleteraBE> myWallets = new CuentaBL().traerBilleterasCliente(Session.GetInstance().getActiveClient(),true);

            this.wallets.Add(myWallets["BTC"]);
            this.wallets.Add(myWallets["LTC"]);
            this.wallets.Add(myWallets["DOG"]);

            //Cargo items.
            foreach(BilleteraBE tmp in this.wallets) 
                this.cmb_wallets_list.Items.Add(tmp.moneda.cod+" "+tmp.saldo.getValue().ToString());

            //Seteo por defecto.
            this.cmb_wallets_list.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Traigo la billetera elegida.
                BilleteraBE selected = this.wallets[this.cmb_wallets_list.SelectedIndex];

                //Calculo los impuestos.
                string fee = new TransferenciaBL().estimate(selected.moneda, this.txt_destiny.Text, this.txt_value.Text);

                //Hago la consulta.
                string label = Idioma.GetInstance().translate("CRYPTO_EXTRACT_TXT").Replace("%s", selected.moneda.cod + " " + fee);
                string title = Idioma.GetInstance().translate("CRYPTO_EXTRACT_TITLE");

                DialogResult dr = MessageBox.Show(label, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    //Hago la transferencia.
                    new TransferenciaBL().transfer(selected.moneda, this.txt_value.Text, selected.direccion, this.txt_destiny.Text);

                    //Mensaje de ok.
                    MessageBox.Show(Idioma.GetInstance().translate("CRYPTO_EXTRACT_SUCCESS"));
                    this.Close();
                }
            }
            catch (Exception error) 
            {
                MessageBox.Show(error.Message);
            }            
        }

        private void frm_crypto_extract_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManual.GetInstance().openForClient("solic_extraccion_crypto");
        }
    }
}