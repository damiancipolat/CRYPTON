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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using UI;
using SL;
using BL;
using BE;

namespace UI.Comisiones
{
    public partial class frm_ganancias : Form
    {
        private List<ComisionBE> innerResult;

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
            this.report_download.Text = Idioma.GetInstance().translate("REPORT_DBT_DOWNLOAD");
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
            this.innerResult = result;

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

        private void downloaPDF(string filePath)
        {
            if (this.innerResult.Count == 0) 
            {
                MessageBox.Show("No hay registros para poder generar el reporte!");
                return;
            }

            // Inicializamos el documento PDF
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

            // Importante Abrir el documento
            doc.Open();

            // Creamos un titulo personalizado con tamaño de fuente 18 y color Azul
            Paragraph title = new Paragraph();
            title.Add(Idioma.GetInstance().translate("REPORT_DBT_TITLE") +" - "+ this.date_from_txt.Text+"/"+this.date_to_txt.Text+" "+this.report_type_combo.Text);
            doc.Add(title);

            // Agregamos un parrafo vacio como separacion.
            doc.Add(new Paragraph(""));
            doc.Add(new Paragraph(""));

            // Empezamos a crear la tabla, definimos una tabla de 6 columnas
            PdfPTable table = new PdfPTable(6);

            //Armo las columnas
            table.AddCell(Idioma.GetInstance().translate("idcobro"));
            table.AddCell(Idioma.GetInstance().translate("cliente"));
            table.AddCell(Idioma.GetInstance().translate("registro"));
            table.AddCell(Idioma.GetInstance().translate("moneda"));
            table.AddCell(Idioma.GetInstance().translate("valor"));
            table.AddCell(Idioma.GetInstance().translate("estado"));

            //Genero las filas.
            foreach (ComisionBE data in this.innerResult)
            {
                table.AddCell(data.idcobro.ToString());
                table.AddCell(data.cliente.alias);
                table.AddCell(data.fecRegister.ToString("yyyy-mm-dd HH:MM:ss.fff"));
                table.AddCell(data.moneda.cod);
                table.AddCell(data.valor.getValue().ToString());
                table.AddCell((data.processed.ToString() == "1" ? "Cobrado" : "Pendiente"));
            }

            // Agregamos la tabla al documento
            doc.Add(table);

            // Ceramos el documento
            doc.Close();
        }

        private void report_download_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Pdf|*.pdf";
            saveFileDialog1.Title = Idioma.GetInstance().translate("REPORT_DBT_REPORT_SAVE");
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.downloaPDF(saveFileDialog1.FileName);
                MessageBox.Show(Idioma.GetInstance().translate("REPORT_DBT_REPORT_GENERATED"));
            }
        }
    }
}
