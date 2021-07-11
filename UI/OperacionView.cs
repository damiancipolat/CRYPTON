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

        public OperacionView(long id)
        {
            InitializeComponent();

            //Cargo la orden internamente.
            this.orden = new OrdenVentaBL().load(id);
        }

        private void Btn_accept_Click(object sender, EventArgs e)
        {

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
            this.translateTexts();
            this.op_offer_label.Text = Idioma.GetInstance().translate("OP_OFFER") + " "+this.orden.cantidad.ToString()+" "+this.orden.ofrece.cod;
            this.op_req_label.Text = Idioma.GetInstance().translate("OP_REQ")+" "+this.orden.precio.ToString() + " " + this.orden.pide.cod;
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
