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
using BE;
using BL;

namespace UI
{
    public partial class MySellOrders : Form
    {        
        public MySellOrders()
        {
            InitializeComponent();
        }

        //Actualizo los textos en base al idioma elegido.
        private void translateTexts()
        {
            //Labels.
            this.Text = Idioma.GetInstance().translate("MY_SELL_ORDERS_TITLE");
            this.my_sell_orders_title.Text = Idioma.GetInstance().translate("MY_SELL_ORDERS_TITLE");
            this.btn_finish.Text = Idioma.GetInstance().translate("MY_SELL_ORDERS_PAUSE");
            this.btn_close.Text = Idioma.GetInstance().translate("SEARCH_BTN_CLOSE");
            this.btn_refresh.Text = Idioma.GetInstance().translate("USR_LANG_UI_REFRESH_LANGUAGE");
        }

        private void fillData(List<OrdenVentaBE> orders)
        {
            this.usr_orders_data.Rows.Clear();

            if (orders.Count > 0)
            {
                //Loop to fill data.
                foreach (OrdenVentaBE order in orders)
                {
                    //Texto de orden de estado.
                    string status="";

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
                    this.usr_orders_data.Rows.Add(
                        new string[] {
                        order.idorden.ToString(),
                        order.vendedor.alias,
                        order.cantidad.ToString(),
                        order.pide.cod,
                        order.precio.ToString(),
                        order.ofrece.cod,
                        status
                    });
                }
            }
            else
            {
                this.usr_orders_data.Rows.Add(
                    new string[] {
                        "Sin resultados"
                });
            }
        }

        private void updateList()
        {
            //Traigo el cliente activo.
            ClienteBE cli = Session.GetInstance().getActiveClient();

            //Carg la lista de ordenes.
            List<OrdenVentaBE> orders = new OrdenVentaBL().orderBySeller(cli);

            //Cargo la grilla
            this.fillData(orders);
        }

        private void MySellOrders_Load(object sender, EventArgs e)
        {
            //Cargo la traduccion
            this.translateTexts();

            //Limpio la grilla
            this.usr_orders_data.ReadOnly = true;

            //Load columns.
            this.usr_orders_data.Columns.Clear();
            this.usr_orders_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_ID"), Idioma.GetInstance().translate("SEARCH_COL_ID"));
            this.usr_orders_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_SELLER"), Idioma.GetInstance().translate("SEARCH_COL_SELLER"));
            this.usr_orders_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_QTY"), Idioma.GetInstance().translate("SEARCH_COL_QTY"));
            this.usr_orders_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_REQ"), Idioma.GetInstance().translate("SEARCH_COL_REQ"));
            this.usr_orders_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_PRICE"), Idioma.GetInstance().translate("SEARCH_COL_PRICE"));
            this.usr_orders_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_OFFER"), Idioma.GetInstance().translate("SEARCH_COL_OFFER"));
            this.usr_orders_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_STATUS"), Idioma.GetInstance().translate("SEARCH_COL_STATUS"));

            this.updateList();
        }

        private void Btn_finish_Click(object sender, EventArgs e)
        {
            if (this.usr_orders_data.SelectedCells.Count > 0)
            {
                DialogResult dr = MessageBox.Show(
                    Idioma.GetInstance().translate("MY_SELL_FINISH_TITLE"),
                    Idioma.GetInstance().translate("MY_SELL_FINISH_CONFIRM"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes && this.usr_orders_data.SelectedCells.Count > 0)
                {
                    //Traigo el id de orden.
                    int selectedrowindex = this.usr_orders_data.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = this.usr_orders_data.Rows[selectedrowindex];
                    string idValue = Convert.ToString(selectedRow.Cells[0].Value);

                    //Finalizo la orden.
                    new OrdenVentaBL().finish(long.Parse(idValue));

                    //Msj de exito.
                    MessageBox.Show(Idioma.GetInstance().translate("MY_SELL_FINISH_SUCCESS"));

                    this.updateList();
                }
            }
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_refresh_Click(object sender, EventArgs e)
        {
            this.updateList();
        }
    }
}
