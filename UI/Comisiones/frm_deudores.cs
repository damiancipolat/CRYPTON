﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using BE;
using SL;
using BL;

namespace UI.Comisiones
{
    public partial class frm_deudores : Form
    {
        public frm_deudores()
        {
            InitializeComponent();
        }
        private void translateText() 
        {
            this.Text= Idioma.GetInstance().translate("COMMISION_DEBTS_TITLE");
            this.commision_debts_title.Text = Idioma.GetInstance().translate("COMMISION_DEBTS_TITLE");
            this.commision_debts_title_descrip.Text = Idioma.GetInstance().translate("COMMISION_DEBTS_TITLE_DESCRIP");
            this.commision_debts_notify_btn.Text = Idioma.GetInstance().translate("COMMISION_DEBTS_NOTIFY_BTN");
        }

        private void loadColumns() 
        {
            //Load columns.
            this.list_comision_data.ReadOnly = true;
            this.list_comision_data.Columns.Clear();
            this.list_comision_data.Columns.Add(Idioma.GetInstance().translate("tipo_operacion"), Idioma.GetInstance().translate("tipo_operacion"));
            this.list_comision_data.Columns.Add(Idioma.GetInstance().translate("idcliente"), Idioma.GetInstance().translate("idcliente"));
            this.list_comision_data.Columns.Add(Idioma.GetInstance().translate("moneda"), Idioma.GetInstance().translate("moneda"));
            this.list_comision_data.Columns.Add(Idioma.GetInstance().translate("valor"), Idioma.GetInstance().translate("valor"));
        }

        public void fillData(List<(int, int, string, float)> items) 
        {
            this.list_comision_data.Rows.Clear();

            //Loop to fill data.
            foreach ((int, int, string, float) data in items)
            {
                //Debug.WriteLine("@" + tmp.Item1.ToString() + "," + tmp.Item2.ToString() + "," + tmp.Item3.ToString() + "," + tmp.Item4.ToString());

                this.list_comision_data.Rows.Add(
                    new string[] {
                        data.Item1.ToString(),
                        data.Item2.ToString(),
                        data.Item3.ToString(),
                        data.Item4.ToString()
                });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.list_comision_data.SelectedCells.Count > 0)
            {
                int selectedrowindex = this.list_comision_data.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.list_comision_data.Rows[selectedrowindex];
                string idValue = Convert.ToString(selectedRow.Cells[1].Value);
                float value = Convert.ToSingle(selectedRow.Cells[3].Value);

                if (idValue != "" && idValue != null) 
                {
                    new CommisionBL().reclaimPayment(Convert.ToInt32(idValue), value);
                    MessageBox.Show("Se ah enviado un aviso al cliente!");
                }
            }
        }

        private void frm_deudores_Load(object sender, EventArgs e)
        {
            this.translateText();
            this.loadColumns();
            this.fillData(new CommisionBL().getDebtors());            
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


/*
 
 */