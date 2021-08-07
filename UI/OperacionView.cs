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
using SL;
using BL;
using BE;
using BE.ValueObject;

namespace UI
{
    public partial class OperacionView : Form
    {
        private OrdenVentaBE2 orden;
        private double platFormTax;

        public OperacionView(long id)
        {
            InitializeComponent();

            //Cargo la orden internamente.
            this.orden = new OrdenVentaBL2().load(id);
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
            {/*
                try
                {
                    new OrdenCompraBL().comprar(this.orden, Session.GetInstance().getActiveClient());
                    MessageBox.Show(Idioma.GetInstance().translate("BUY_SUCCESS"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Idioma.GetInstance().translate("BUY_ERROR"));
                }*/
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
            this.op_final_cost.Text= Idioma.GetInstance().translate("OP_TOTAL");
        }

        private void OperacionView_Load(object sender, EventArgs e)
        {
            //Valor final.
            decimal final;

            //Traduzco los textos.
            this.translateTexts();

            //Seteo campos.
            this.op_offer_label.Text = Idioma.GetInstance().translate("OP_OFFER") + " "+new Money(this.orden.cantidad.getValue()).ToString() + " "+this.orden.ofrece.cod;
            this.op_req_label.Text = Idioma.GetInstance().translate("OP_REQ")+" "+new Money(this.orden.precio.getValue()).ToString() + " " + this.orden.pide.cod;

            //Agregoe el valor de la orden.
            final = this.orden.precio.getValue();

            //Cargo los costos de operacion.
            List<(string, string, string)> list = new OrdenCompraBL().getTaxesToBuy(this.orden, Session.GetInstance().getActiveClient());

            foreach ((string, string, string) tmp in list)
            {
                //Registro el impuesto.
                this.tax_box.Text = this.tax_box.Text + tmp.Item1 + " " + tmp.Item2 + " " + Idioma.GetInstance().translate(tmp.Item3) + Environment.NewLine;

                //Contabilizo el valor.
                final = final + new Money(tmp.Item1).getValue();
            }

            //Seteo el valor final.            
            this.op_final_total.Text = (this.orden.pide.cod == "ARS" 
                ? new Money(final).ToShortString()
                : new Money(final).ToFormatString())+" " + this.orden.pide.cod;
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
