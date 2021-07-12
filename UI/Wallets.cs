using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using SL;
using BL;
using BE;

namespace UI
{
    public partial class frm_wallets : Form
    {
        private long accountId;

        public frm_wallets(long accountId)
        {
            this.accountId = accountId;
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
            this.your_wallets_descrip_label.Text = Idioma.GetInstance().translate("YOUR_WALLETS_DESCRIPT");
            this.Text = Idioma.GetInstance().translate("YOUR_WALLETS_LABEL");
            this.btn_refresh.Text= Idioma.GetInstance().translate("BTN_UPDATE_PERMISSION");
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        //Cargo los saldos de las billeteras.
        private void loadWallets()
        {
            try
            {
                //Cargo las billeteras.
                CuentaBE cuenta = new CuentaBL().traer(this.accountId);
                Dictionary<string, BilleteraBE> wallets = new CuentaBL().traerBilleteras(cuenta);

                //Cargo los saldos.
                this.ars_saldo.Text = wallets["ARS"].saldo.ToString() + " ARS";
                this.btc_saldo.Text = wallets["BTC"].saldo.ToString() + " BTC";
                this.ltc_saldo.Text = wallets["LTC"].saldo.ToString() + " LTC";
                this.dog_saldo.Text = wallets["DOG"].saldo.ToString() + " DOG";

                //Cargo las direcciones.
                this.ars_address.Text = wallets["ARS"].direccion;
                this.btc_address.Text = wallets["BTC"].direccion;
                this.ltc_address.Text = wallets["LTC"].direccion;
                this.dog_address.Text = wallets["DOG"].direccion;

                Debug.WriteLine("ARS>>>" + wallets["ARS"].direccion);
                Debug.WriteLine("BTC>>>" + wallets["BTC"].direccion);
                Debug.WriteLine("LTC>>>" + wallets["LTC"].direccion);
                Debug.WriteLine("DOG>>>" + wallets["DOG"].direccion);

            }
            catch (Exception ex)
            {

            }

        }

        private void Frm_wallets_Load(object sender, EventArgs e)
        {
            //Traduszco los textos y cargo los datos.
            this.translateTexts();
            this.loadWallets();
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.loadWallets();
        }
    }
}
