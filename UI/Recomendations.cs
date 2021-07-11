﻿using System;
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
using DAL;

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
            this.frm_recom_list.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_REQ"), Idioma.GetInstance().translate("SEARCH_COL_REQ"));
            this.frm_recom_list.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_PRICE"), Idioma.GetInstance().translate("SEARCH_COL_PRICE"));
            this.frm_recom_list.Columns.Add(Idioma.GetInstance().translate("SEARCH_COL_OFFER"), Idioma.GetInstance().translate("SEARCH_COL_OFFER"));
        }

        private void Btn_refresh_Click(object sender, EventArgs e)
        {

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
                        order.pide.cod,
                        order.precio.ToString(),
                        order.ofrece.cod,
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
           List<OrdenVentaBE> data = new MarketBL().recomendar(Session.GetInstance().getActiveClient());
           this.fillData(data);
        }
    }
}
