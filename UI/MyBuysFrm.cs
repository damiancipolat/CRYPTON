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

namespace UI
{
    public partial class MyBuysFrm : Form
    {
        private List<OrdenCompraBE> orders;

        public MyBuysFrm()
        {
            InitializeComponent();
        }


        //Actualizo los textos en base al idioma elegido.
        private void translateTexts()
        {
            //Labels.
            this.Text = Idioma.GetInstance().translate("MY_BUYS");
            this.my_buy_orders_title.Text = Idioma.GetInstance().translate("MY_BUYS");
            this.btn_close.Text = Idioma.GetInstance().translate("SEARCH_BTN_CLOSE");
            this.btn_refresh.Text = Idioma.GetInstance().translate("USR_LANG_UI_REFRESH_LANGUAGE");
        }

        private void fillData()
        {

            //Traigo las compras del cliente.
            this.orders = new OrdenCompraBL().findByClient(Session.GetInstance().getActiveClient());

            this.usr_orders_data.Rows.Clear();

            if (orders.Count > 0)
            {
                //Loop to fill data.
                foreach (OrdenCompraBE order in this.orders)
                {
                    //Agrego en la fila.
                    this.usr_orders_data.Rows.Add(
                         new string[] {
                         order.idcompra.ToString(),
                         order.fecOperacion.ToString(),
                         order.ordenVenta.cantidad.ToString(),
                         order.ordenVenta.ofrece.cod,
                         order.cantidad.ToString(),
                         order.moneda.cod.ToString()
                     });                  
                }
            }
        }

        private void MyBuysFrm_Load(object sender, EventArgs e)
        {            
            //Traduzo textos.
            this.translateTexts();

            //Limpio la grilla
            this.usr_orders_data.ReadOnly = true;

            //Load columns.
            this.usr_orders_data.Columns.Clear();
            this.usr_orders_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_ID"), Idioma.GetInstance().translate("SEARCH_COL_ID"));
            this.usr_orders_data.Columns.Add(Idioma.GetInstance().translate("BUY_DATE"), Idioma.GetInstance().translate("BUY_DATE"));
            this.usr_orders_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_QTY"), Idioma.GetInstance().translate("SEARCH_COL_QTY"));
            this.usr_orders_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_REQ"), Idioma.GetInstance().translate("SEARCH_COL_REQ"));
            this.usr_orders_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_PRICE"), Idioma.GetInstance().translate("SEARCH_COL_PRICE"));
            this.usr_orders_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_OFFER"), Idioma.GetInstance().translate("SEARCH_COL_OFFER"));

            //Cargo valores en la grilla.
            this.fillData();
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_refresh_Click(object sender, EventArgs e)
        {
            this.fillData();
        }
    }
}
