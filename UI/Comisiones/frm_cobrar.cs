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
using System.Threading;
using BE;
using BL;
using BE.ValueObject;
using SL;

namespace UI.Comisiones
{
    public partial class frm_cobrar : Form
    {
        private List<(Int64, Int64,string, DateTime, string, Money)> innerList= new List<(Int64, Int64,string, DateTime, string, Money)>();

        public frm_cobrar()
        {
            InitializeComponent();
        }

        private void statusReport(List<(ComisionBE, bool)> results) 
        {
            decimal cobrados = 0;
            decimal pendientes = 0;

            foreach ((ComisionBE, bool) elem in results) 
            {
                if (elem.Item2 == true)
                    cobrados = cobrados + elem.Item1.valor.getValue();

                if (elem.Item2 == false)
                    pendientes = pendientes + elem.Item1.valor.getValue();
            }

            MessageBox.Show("Resultado de proceso - Exitosos: $" + cobrados.ToString() + " - Fallidos: $" + pendientes.ToString());
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea procesar el lote?.", "Debitar pagos", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                //Seteo progress.
                this.Text = "Procesando espere por favor...";
                this.cobrar_progress.Visible = true;
                this.cobrar_progress.Maximum = this.innerList.Count;
                this.cobrar_progress.Step = 1;
                this.cobrar_progress.Value = 0;                

                //Lista administrativa.
                List<(ComisionBE, bool)> results = new List<(ComisionBE, bool)>();

                //Recorro debitando las comisiones.
                foreach ((Int64, Int64, string, DateTime, string, Money) comm in this.innerList)
                {
                    //Incremento el valor.
                    this.cobrar_progress.Value++;
                    this.Update();

                    //Traigo la commision.
                    ComisionBE comision = new CommisionBL().findById(Convert.ToInt32(comm.Item1));

                    //Proceso el debito y lo registro.
                    bool opResult = new CommisionBL().processPayment(comision);
                    results.Add((comision, opResult));

                    //Registro.
                    Debug.WriteLine("<@>" + comision.valor.getValue().ToString() + " - result =" + opResult.ToString());
                }

                //Lanzo un modal como reporte
                this.statusReport(results);

                //Cierro ui.
                this.Text = Idioma.GetInstance().translate("COBRAR_FRM_TITLE");

                this.Close();
            }
        }

        private void loadData(List<(Int64, Int64,string, DateTime, string, Money)> list) 
        {
            //Loop to fill data.
            foreach ((Int64, Int64,string, DateTime, string, Money) data in list)
            {
                this.list_comision_data.Rows.Add(
                    new string[] {
                        data.Item1.ToString(),                          //idcobro
                        data.Item3.ToString(),                          //cliente
                        data.Item4.ToString("yyyy-mm-dd HH:MM:ss.fff"), //registro
                        data.Item5,                                     //moneda
                        data.Item6.getValue().ToString()                //valor
                });
            }
        }

        private void loadColumns()
        {
            //Load columns.
            this.list_comision_data.ReadOnly = true;
            this.list_comision_data.Columns.Clear();
            this.list_comision_data.Rows.Clear();
            this.list_comision_data.Columns.Add(Idioma.GetInstance().translate("idcobro"), Idioma.GetInstance().translate("idcobro"));
            this.list_comision_data.Columns.Add(Idioma.GetInstance().translate("cliente"), Idioma.GetInstance().translate("cliente"));
            this.list_comision_data.Columns.Add(Idioma.GetInstance().translate("registro"), Idioma.GetInstance().translate("registro"));
            this.list_comision_data.Columns.Add(Idioma.GetInstance().translate("moneda"), Idioma.GetInstance().translate("moneda"));
            this.list_comision_data.Columns.Add(Idioma.GetInstance().translate("valor"), Idioma.GetInstance().translate("valor"));
        }

        private Money summarizeList(List<(Int64, Int64, string, DateTime, string, Money)> list) 
        {
            decimal total = 0;

            foreach ((Int64, Int64, string, DateTime, string, Money) comision in list)
                total = total + comision.Item6.getValue();

            return new Money(total);
        }

        private void translateText() 
        {
            this.Text = Idioma.GetInstance().translate("COBRAR_FRM_TITLE");
            this.cobrar_frm_title.Text = Idioma.GetInstance().translate("COBRAR_FRM_TITLE");
            this.cobrar_frm_title_descrip.Text = Idioma.GetInstance().translate("COBRAR_FRM_TITLE_DESCRIP");
            this.cobrar_btn_process.Text = Idioma.GetInstance().translate("COBRAR_BTN_PROCESS");
            this.cobrar_total_label.Text = Idioma.GetInstance().translate("COBRAR_TOTAL_LABEL");
            this.btn_close.Text = Idioma.GetInstance().translate("BTN_CLOSE");
        }

        private void frm_cobrar_Load(object sender, EventArgs e)
        {
            //Traduzco.
            this.translateText();

            //Oculto.
            this.cobrar_progress.Visible = false;
            this.cobrar_progress.Value = 0;

            //Traigo la lista de comisiones para ser cobradas.
            List<(Int64, Int64,string, DateTime, string, Money)> pendings = new CommisionBL().getPendingsToPay();

            //Total
            Money total = this.summarizeList(pendings);
            this.cobrar_total_label.Text = Idioma.GetInstance().translate("COBRAR_TOTAL_LABEL") +" $"+ total.getValue().ToString();

            //Internal buffer.
            this.innerList.Clear();
            this.innerList = pendings;

            //Cargo filas.
            this.loadColumns();
            this.loadData(pendings);
        }

        private void frm_cobrar_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManual.GetInstance().openForEmpleado("cobrar_comisiones");
        }
    }
}
