using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI;
using SL;
using BL;
using BE;

namespace UI.Comisiones
{
    public partial class frm_ganancias : Form
    {
        public frm_ganancias()
        {
            InitializeComponent();
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            new frm_cobrar().Show();
        }

        private void translateText() 
        {
            this.Text= Idioma.GetInstance().translate("REPORT_DBT_TITLE");
            this.report_dbt_title.Text = Idioma.GetInstance().translate("REPORT_DBT_TITLE");
            this.report_dbt_descrip.Text = Idioma.GetInstance().translate("REPORT_DBT_DESCRIP");
            this.report_dbt_desde.Text = Idioma.GetInstance().translate("REPORT_DBT_DESDE");
            this.report_dbt_hasta.Text = Idioma.GetInstance().translate("REPORT_DBT_HASTA");
            this.report_dbt_type.Text = Idioma.GetInstance().translate("REPORT_DBT_TYPE");
            this.report_dbt_search.Text = Idioma.GetInstance().translate("REPORT_DBT_SEARCH");
            this.report_dbt_pay.Text = Idioma.GetInstance().translate("REPORT_DBT_PAY");
            this.report_dbt_close.Text = Idioma.GetInstance().translate("BTN_CLOSE");            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadColumns() 
        {
            //Load columns.
            this.bitacora_data.ReadOnly = true;
            this.bitacora_data.Columns.Clear();
            this.bitacora_data.Columns.Add(Idioma.GetInstance().translate("idcobro"), Idioma.GetInstance().translate("idcobro"));
            this.bitacora_data.Columns.Add(Idioma.GetInstance().translate("cliente"), Idioma.GetInstance().translate("cliente"));
            this.bitacora_data.Columns.Add(Idioma.GetInstance().translate("registro"), Idioma.GetInstance().translate("registro"));
            this.bitacora_data.Columns.Add(Idioma.GetInstance().translate("moneda"), Idioma.GetInstance().translate("moneda"));
            this.bitacora_data.Columns.Add(Idioma.GetInstance().translate("valor"), Idioma.GetInstance().translate("valor"));
            this.bitacora_data.Columns.Add(Idioma.GetInstance().translate("estado"), Idioma.GetInstance().translate("estado"));
        }

        private void fillData(List<ComisionBE> list) 
        {
            decimal total = 0;
            this.bitacora_data.Rows.Clear();

            //Loop to fill data.
            foreach (ComisionBE data in list)
            {
                this.bitacora_data.Rows.Add(
                    new string[] {
                        data.idcobro.ToString(),
                        data.cliente.alias,
                        data.fecRegister.ToString("yyyy-mm-dd HH:MM:ss.fff"),
                        data.moneda.cod,
                        data.valor.getValue().ToString(),
                        (data.processed.ToString()=="1"?"Cobrado":"Pendiente")
                });

                //Acumulo pesos.
                total = total + data.valor.getValue();
            }

            this.report_total_value.Text = Idioma.GetInstance().translate("REPORT_DBT_TOTAL") + " $" + total.ToString();
        }

        private void frm_ganancias_Load(object sender, EventArgs e)
        {
            this.translateText();
            this.loadColumns();

            //Limpio combos.
            this.report_total_value.Text = "";
            this.report_type_combo.Items.Clear();
            this.report_type_combo.Items.Add("Todos");
            this.report_type_combo.Items.Add("Cobrado");
            this.report_type_combo.Items.Add("Pendiente");
            this.report_type_combo.SelectedIndex = 0;
        }

        private void report_dbt_search_Click(object sender, EventArgs e)
        {
            List<ComisionBE> result = new CommisionBL().findByDate(this.report_type_combo.SelectedIndex.ToString(), this.date_from_txt.Text, this.date_to_txt.Text);

            if (result.Count > 0)
                this.fillData(result);
            else{
                this.bitacora_data.Rows.Clear();
                this.report_total_value.Text = "";
                MessageBox.Show("No hay resultados.");
            }                
        }

        private void activ_combo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frm_ganancias_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManual.GetInstance().openForEmpleado("calc_cobros");
        }
    }
}
