using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using SL;
using BL;
using BE;

namespace UI
{
    public partial class frm_recomendations : Form
    {
        public frm_recomendations()
        {
            InitializeComponent();
        }

        //Actualizo los textos en base al idioma elegido.
        private void translateTexts()
        {
            //Labels.
            this.Text = Idioma.GetInstance().translate("RECOM_TITLE");
            this.recom_title.Text = Idioma.GetInstance().translate("RECOM_TITLE");
            this.recom_descrip.Text = Idioma.GetInstance().translate("RECOM_DESCRIP");
            this.btn_view.Text = Idioma.GetInstance().translate("USR_LANG_UI_REFRESH_LANGUAGE");
            this.sell_close.Text = Idioma.GetInstance().translate("RECOM_CLOSE");
            this.btn_view.Text = Idioma.GetInstance().translate("RECOM_VIEW");
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Frm_recom_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Frm_recomendations_Load(object sender, EventArgs e)
        {
            //Traduzco textos.
            this.translateTexts();

            //Creo las columnas.
            this.frm_recom_list.ReadOnly = true;

            //Load columns.
            this.frm_recom_list.Columns.Clear();
            this.frm_recom_list.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_ID"), Idioma.GetInstance().translate("SEARCH_COL_ID"));
            this.frm_recom_list.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_SELLER"), Idioma.GetInstance().translate("SEARCH_COL_SELLER"));
            this.frm_recom_list.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_QTY"), Idioma.GetInstance().translate("SEARCH_COL_QTY"));
            this.frm_recom_list.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_OFFER"), Idioma.GetInstance().translate("SEARCH_COL_OFFER"));
            this.frm_recom_list.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_PRICE"), Idioma.GetInstance().translate("SEARCH_COL_PRICE"));
            this.frm_recom_list.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_REQ"), Idioma.GetInstance().translate("SEARCH_COL_REQ"));

            //Load data.
            ClienteBE client = Session.GetInstance().getActiveClient();
            List<OrdenVentaBE> data = new MarketBL().recomendar(client);

            Bitacora.GetInstance().log("RECOMENDATIONS", "Carga de recomendaciones:" + client.email+" encontrados:"+data.Count.ToString());

            //Fill the grid.
            this.fillData(data);
        }

        private void Btn_refresh_Click(object sender, EventArgs e)
        {
            if (this.frm_recom_list.SelectedCells.Count > 0)
            {
                int selectedrowindex = this.frm_recom_list.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.frm_recom_list.Rows[selectedrowindex];
                string idValue = Convert.ToString(selectedRow.Cells[0].Value);

                if (idValue!="")
                    new OperacionView(long.Parse(idValue)).Show();
            }
        }

        private void Sell_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fillData(List<OrdenVentaBE> orders)
        {
            this.frm_recom_list.Rows.Clear();

            if (orders.Count > 0)
            {
                //Loop to fill data.
                foreach (OrdenVentaBE order in orders)
                {
                    //Texto de orden de estado.
                    string status = "";

                    switch (order.ordenEstado)
                    {
                        case OrdenEstado.DISPONIBLE:
                            status = "Disponible";
                            break;
                        case OrdenEstado.EXPIRADA:
                            status = "Expirada";
                            break;
                        case OrdenEstado.FINALIZADA:
                            status = "Finalizada";
                            break;
                        case OrdenEstado.VENDIDA:
                            status = "Vendida";
                            break;
                    }

                    //Agrego en la fila.
                    this.frm_recom_list.Rows.Add(
                        new string[] {
                        order.idorden.ToString(),
                        order.vendedor.alias,
                        order.cantidad.ToString(),
                        order.ofrece.cod,
                        order.precio.ToString(),
                        order.pide.cod,
                        status
                    });
                }
            }
            else
            {
                this.frm_recom_list.Rows.Add(
                    new string[] {
                        "Sin resultados"
                });
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
 
        }

        private void frm_recomendations_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManual.GetInstance().openForClient("recomendaciones");
        }
    }
}
