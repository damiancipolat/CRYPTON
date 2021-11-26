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
            this.Text= Idioma.GetInstance().translate("WALLET_TITLE");
            this.wallet_btn_close.Text = Idioma.GetInstance().translate("WALLET_BTN_CLOSE");
            this.wallet_btn_refresh.Text = Idioma.GetInstance().translate("WALLET_BTN_REFRESH");
            this.wallet_title.Text = Idioma.GetInstance().translate("WALLET_TITLE");
            this.wallet_descrip.Text = Idioma.GetInstance().translate("WALLET_DESCRIP");;
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
                Dictionary<string, BilleteraBE> wallets = new CuentaBL().traerBilleteras(cuenta, true);

                //Borro las filas.
                this.frm_wallet_list.Rows.Clear();

                BilleteraBE wallet = wallets["BTC"];
                Debug.WriteLine(wallet.moneda.cod + " " + wallet.direccion + " " + wallet.saldo.ToString() + "  " + wallet.saldo_pending.ToString());

                //Agrego ARS
                Debug.WriteLine("Load ARS");
                this.frm_wallet_list.Rows.Add(new string[] {
                    wallets["ARS"].moneda.cod,
                    wallets["ARS"].direccion,
                    wallets["ARS"].saldo.ToString(),
                    wallets["ARS"].saldo_pending.ToString()
                });

                //Agrego BTC
                Debug.WriteLine("Load BTC");
                this.frm_wallet_list.Rows.Add(new string[] {
                    wallets["BTC"].moneda.cod,
                    wallets["BTC"].direccion,
                    wallets["BTC"].saldo.ToString(),
                    wallets["BTC"].saldo_pending.ToString()
                    });

                //Agrego LTC
                Debug.WriteLine("Load LTC");
                this.frm_wallet_list.Rows.Add(new string[] {
                    wallets["LTC"].moneda.cod,
                    wallets["LTC"].direccion,
                    wallets["LTC"].saldo.ToString(),
                    wallets["LTC"].saldo_pending.ToString()
                });

                //Agrego DOG
                Debug.WriteLine("Load DOG");
                this.frm_wallet_list.Rows.Add(new string[] {
                    wallets["DOG"].moneda.cod,
                    wallets["DOG"].direccion,
                    wallets["DOG"].saldo.ToString(),
                    wallets["DOG"].saldo_pending.ToString()
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un problema al cargar los datos");
                Debug.WriteLine(ex.Message);
            }
        }

        private void Frm_wallets_Load(object sender, EventArgs e)
        {
            //Traduszco los textos y cargo los datos.
            this.translateTexts();

            //Cargo la billetera.
            Bitacora.GetInstance().log("WALLET", "Cargando wallet:" + Session.GetInstance().getActiveClient().email);

            //Load columns.
            this.frm_wallet_list.ReadOnly = true;
            this.frm_wallet_list.Columns.Clear();
            this.frm_wallet_list.Columns.Add(Idioma.GetInstance().translate("WALLET_MONEY"), Idioma.GetInstance().translate("WALLET_MONEY"));
            this.frm_wallet_list.Columns.Add(Idioma.GetInstance().translate("WALLET_ADDRESS"), Idioma.GetInstance().translate("WALLET_ADDRESS"));
            this.frm_wallet_list.Columns.Add(Idioma.GetInstance().translate("WALLET_READY_VALUE"), Idioma.GetInstance().translate("WALLET_READY_VALUE"));
            this.frm_wallet_list.Columns.Add(Idioma.GetInstance().translate("WALLET_PENDING_VALUE"), Idioma.GetInstance().translate("WALLET_PENDING_VALUE"));

            //Load wallet data.
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

        private void Wallet_btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_wallets_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManual.GetInstance().openForClient("wallets");
        }
    }
}
