using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        private OrdenVentaBE orden;
        private Money finalValue;

        public OperacionView(long id)
        {
            InitializeComponent();

            //Cargo la orden internamente.
            this.orden = new OrdenVentaBL().load(id);
        }

        private void test(string msg,int step) 
        {
            this.orden_loader_process.Value = step;
            this.orden_loader.Visible = true;
            this.orden_loader_txt.Text = "Procesando operacion...";
            this.orden_loader_detail.Text = msg;
            this.Update();
            Console.WriteLine("---->" + msg);
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
                try
                {
                    //Animacion de tapar controles.
                    this.orden_loader.Visible = false;
                    this.orden_loader_process.Visible = true;
                    this.Show();
                    this.Update();
                    Thread.Sleep(1000);

                    MyDelegate del = this.test;

                    //Proceso la compra.
                    new OrdenCompraBL().comprar(
                        this.orden, 
                        Session.GetInstance().getActiveClient(),
                        this.finalValue,
                        test
                    );
                    
                    Console.WriteLine("FINNNN");

                    MessageBox.Show(Idioma.GetInstance().translate("BUY_SUCCESS"));
                    this.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void translateTexts()
        {
            this.Text = Idioma.GetInstance().translate("OP_TITLE") + " #" + this.orden.idorden.ToString();
            this.orden_loader_txt.Text = Idioma.GetInstance().translate("RECOM_WAIT");
            this.op_id.Text = Idioma.GetInstance().translate("OP_TITLE") + " #" + this.orden.idorden.ToString();
            this.op_seller.Text = Idioma.GetInstance().translate("OP_SELLER") + " " + this.orden.vendedor.alias;
            this.op_detail_label.Text= Idioma.GetInstance().translate("OP_DETAIL_LABEL");
            this.op_tax_label.Text = Idioma.GetInstance().translate("OP_TAX_LABEL");
            this.op_label_tax_info.Text= Idioma.GetInstance().translate("OP_TAX_LABEL_INFO");
            this.btn_close.Text = Idioma.GetInstance().translate("OP_BTN_CLOSE");
            this.btn_buy.Text = Idioma.GetInstance().translate("OP_BTN_BUY");
            this.op_final_cost.Text= Idioma.GetInstance().translate("OP_TOTAL");
            this.orden_loader_detail.Text = Idioma.GetInstance().translate("ORDEN_LOADER_DETAIL");
        }

        private void OperacionView_Load(object sender, EventArgs e)
        {
            //Traduzco los textos.
            this.translateTexts();

            //Hago un render.
            this.orden_loader.Visible = true;
            this.Show();
            this.Update();
            Thread.Sleep(1000);

            //Valor final.
            decimal final;

            //Seteo campos.
            this.op_offer_label.Text = Idioma.GetInstance().translate("OP_OFFER") + " "+new Money(this.orden.cantidad.getValue()).ToString() + " "+this.orden.ofrece.cod;
            this.op_req_label.Text = Idioma.GetInstance().translate("OP_REQ")+" "+new Money(this.orden.precio.getValue()).ToString() + " " + this.orden.pide.cod;

            //Agregoe el valor de la orden.
            final = this.orden.precio.getValue();

            //Cargo los costos de operacion.
            ClienteBE client = Session.GetInstance().getActiveClient();
            List<(string, string, string)> list = new OrdenCompraBL().getTaxesToBuy(this.orden, client);

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

            Bitacora.GetInstance().log("VIEW", "Visualizando operacion:"+this.orden.idorden.ToString()+" "+client.email);

            //Guardo el costo total.
            this.finalValue = new Money(final);
            
            //oculto
            this.orden_loader.Visible = false;
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void orden_loader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
