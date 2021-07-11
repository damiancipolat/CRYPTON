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
using BL;
using BE;

namespace UI
{
    public partial class OperacionView : Form
    {
        private OrdenVentaBE orden;
        private double platFormTax;

        public OperacionView(long id)
        {
            InitializeComponent();

            //Cargo la orden internamente.
            this.orden = new OrdenVentaBL().load(id);
        }

        private void Btn_accept_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                Idioma.GetInstance().translate("MY_SELL_FINISH_TITLE"),
                Idioma.GetInstance().translate("MY_SELL_FINISH_CONFIRM"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes && this.orden!=null)
            {

            }
        }

        private void translateTexts()
        {
            this.Text = Idioma.GetInstance().translate("OP_TITLE") + " #" + this.orden.idorden.ToString();
            this.op_id.Text = Idioma.GetInstance().translate("OP_TITLE") + " #" + this.orden.idorden.ToString();
            this.op_seller.Text = Idioma.GetInstance().translate("OP_SELLER") + " " + this.orden.vendedor.alias;
            this.op_detail_label.Text= Idioma.GetInstance().translate("OP_DETAIL_LABEL");
            this.op_tax_label.Text = Idioma.GetInstance().translate("OP_TAX_LABEL");
            this.op_label_tax_info.Text= Idioma.GetInstance().translate("OP_TAX_LABEL_INFO");
            this.btn_close.Text = Idioma.GetInstance().translate("OP_BTN_CLOSE");
            this.btn_buy.Text = Idioma.GetInstance().translate("OP_BTN_BUY");
        }

        private void OperacionView_Load(object sender, EventArgs e)
        {
            //Traduzco los textos.
            this.translateTexts();

            //Seteo campos.
            this.op_offer_label.Text = Idioma.GetInstance().translate("OP_OFFER") + " "+this.orden.cantidad.ToString()+" "+this.orden.ofrece.cod;
            this.op_req_label.Text = Idioma.GetInstance().translate("OP_REQ")+" "+this.orden.precio.ToString() + " " + this.orden.pide.cod;

            //Traigo el costo de la plataforma.
            this.platFormTax = ((new ComisionValorBL().getBuyCost() * this.orden.precio) / 100);
            this.tax_box.Text = "- Adicional comision plataforma: " +"+"+this.platFormTax.ToString()+this.orden.pide.cod;

            //Si la moneda es cripto incluyo costo de transferencia de la red de cripto.
            if (this.orden.pide.cod == "ARS")
            {
                this.tax_box.Text = this.tax_box.Text + Environment.NewLine + "- Adicional red cripto: 0,000154LTC";
            }
            else
            {
                this.tax_box.Text = this.tax_box.Text + Environment.NewLine + "- No incluye adicional por costo de transferencia red cripto.";
            }
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
