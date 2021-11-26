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
using BE;
using BL;
using BE.ValueObject;
using SL;

namespace UI.Comisiones
{
    public partial class frm_cobrar : Form
    {
        private List<ComisionBE> innerList= new List<ComisionBE>();

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

            MessageBox.Show("Resultado de proceso - Exitosos: $" + cobrados.ToString() + " - " + pendientes.ToString());
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
                this.cobrar_waiting.Visible = true;
                List<(ComisionBE, bool)> results = new List<(ComisionBE, bool)>();

                //Recorro debitando las comisiones.
                foreach (ComisionBE comm in this.innerList)
                {
                    //Proceso el debito y lo registro.
                    bool opResult = new CommisionBL().processPayment(comm);
                    results.Add((comm, opResult));

                    //Registro.
                    Debug.WriteLine("<@>" + comm.valor.getValue().ToString() + " - result =" + opResult.ToString());
                }

                this.cobrar_waiting.Visible = false;

                //Lanzo un modal como reporte
                this.statusReport(results);

                ///Cierro ui.
                this.Close();
            }
        }

        private void loadData(List<ComisionBE> list) 
        {
            //Loop to fill data.
            foreach (ComisionBE data in list)
            {
                this.list_comision_data.Rows.Add(
                    new string[] {
                        data.idcobro.ToString(),
                        data.cliente.alias,
                        data.fecRegister.ToString("yyyy-mm-dd HH:MM:ss.fff"),
                        data.moneda.cod,
                        data.valor.getValue().ToString()
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

        private Money summarizeList(List<ComisionBE> list) 
        {
            decimal total = 0;

            foreach (ComisionBE comision in list)
                total = total + comision.valor.getValue();

            return new Money(total);
        }

        private void translateText() 
        {
            this.Text = Idioma.GetInstance().translate("COBRAR_FRM_TITLE");
            this.cobrar_frm_title.Text = Idioma.GetInstance().translate("COBRAR_FRM_TITLE");
            this.cobrar_frm_title_descrip.Text = Idioma.GetInstance().translate("COBRAR_FRM_TITLE_DESCRIP");
            this.cobrar_btn_process.Text = Idioma.GetInstance().translate("COBRAR_BTN_PROCESS");
            this.cobrar_total_label.Text = Idioma.GetInstance().translate("COBRAR_TOTAL_LABEL");
            this.cobrar_waiting.Text = Idioma.GetInstance().translate("COBRAR_WAITING");
            this.btn_close.Text = Idioma.GetInstance().translate("BTN_CLOSE");
        }

        private void frm_cobrar_Load(object sender, EventArgs e)
        {
            //Traduzco.
            this.translateText();

            //Traigo la lista de comisiones para ser cobradas.
            List<ComisionBE> pendings = new CommisionBL().getPendingsToPay();

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
