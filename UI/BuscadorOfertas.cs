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
using BL;
using SL;
using BE;

namespace UI
{
    public partial class BuscadorOfertas : Form
    {
        public BuscadorOfertas()
        {
            InitializeComponent();
        }

        //Actualizo los textos en base al idioma elegido.
        private void translateTexts()
        {
            //Labels.
            this.Text = Idioma.GetInstance().translate("SEARCH_TITLE");
            this.search_title.Text = Idioma.GetInstance().translate("SEARCH_TITLE");
            this.search_descrip.Text = Idioma.GetInstance().translate("SEARCH_DESCRIP");
            this.btn_view.Text = Idioma.GetInstance().translate("SEARCH_BTN_VIEW");
            this.btn_search.Text = Idioma.GetInstance().translate("SEARCH_BTN_SEARCH");
            this.btn_close.Text = Idioma.GetInstance().translate("SEARCH_BTN_CLOSE");
            this.btn_by.Text = Idioma.GetInstance().translate("SEARCH_BTN_BY");
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Publish_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Usr_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (this.usr_search_data.SelectedCells.Count > 0)
            {
                int selectedrowindex = this.usr_search_data.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.usr_search_data.Rows[selectedrowindex];
                string idValue = Convert.ToString(selectedRow.Cells[0].Value);

                if (idValue!=""&&idValue!=null)
                    new OperacionView(long.Parse(idValue)).Show();
            }

        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            //Traigo las monedas.
            MonedaBE origen = new MonedaBL().getByCode(this.moneda_pide.Items[this.moneda_pide.SelectedIndex].ToString());
            MonedaBE destino = new MonedaBL().getByCode(this.moneda_ofrece.Items[this.moneda_ofrece.SelectedIndex].ToString());

            //Traigo el resultado.
            List<OrdenVentaBE> results = new OrdenVentaBL().buscar(destino, origen, Session.GetInstance().getActiveClient());

            //Lleno la grilla.
            this.fillData(results);
        }

        private void fillData(List<OrdenVentaBE> orders)
        {
            this.usr_search_data.Rows.Clear();

            if (orders.Count > 0)
            {
                //Loop to fill data.
                foreach (OrdenVentaBE order in orders)
                {
                    this.usr_search_data.Rows.Add(
                        new string[] {
                        order.idorden.ToString(),
                        order.vendedor.alias,
                        order.cantidad.ToString("0.000000000"),
                        order.ofrece.cod,
                        order.precio.ToString("0.000000000"),
                        order.pide.cod                        
                    });
                }
            }
            else
            {
                this.usr_search_data.Rows.Add(
                    new string[] {
                        "Sin resultados"
                });
            }
        }

        private void BuscadorOfertas_Load(object sender, EventArgs e)
        {
            //Traduzco textos.
            this.translateTexts();

            //Cargo monedas.
            List<MonedaBE> monedas = new MonedaBL().getAll();

            //Cargo los combos.
            foreach (MonedaBE money in monedas)
            {
                this.moneda_ofrece.Items.Add(money.cod);
                this.moneda_pide.Items.Add(money.cod);
            }

            //Seteo defaults.
            this.moneda_ofrece.SelectedIndex = 0;
            this.moneda_pide.SelectedIndex = 0;

            //Seteo solo lectura.
            this.usr_search_data.ReadOnly = true;

            //Load columns.
            this.usr_search_data.Columns.Clear();
            this.usr_search_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_ID"), Idioma.GetInstance().translate("SEARCH_COL_ID"));
            this.usr_search_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_SELLER"), Idioma.GetInstance().translate("SEARCH_COL_SELLER"));
            this.usr_search_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_OFFER"), Idioma.GetInstance().translate("SEARCH_COL_OFFER"));
            this.usr_search_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_QTY"), Idioma.GetInstance().translate("SEARCH_COL_QTY"));
            this.usr_search_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_REQ"), Idioma.GetInstance().translate("SEARCH_COL_REQ"));
            this.usr_search_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_PRICE"), Idioma.GetInstance().translate("SEARCH_COL_PRICE"));                        
        }
    }
}
