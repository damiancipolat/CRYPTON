using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BL;
using BE.ValueObject;
using SL;

namespace UI.Comisiones
{
    public partial class frm_cobrar : Form
    {
        public frm_cobrar()
        {
            InitializeComponent();
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }


        private void loadData(List<ComisionBE> list) 
        {
            this.list_comision_data.Rows.Clear();

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

        private void frm_cobrar_Load(object sender, EventArgs e)
        {
            //Traigo la lista de comisiones para ser cobradas.
            List<ComisionBE> pendings = new CommisionBL().getPendingsToPay();

            //Total
            Money total = this.summarizeList(pendings);
            this.cobrar_total_label.Text = "Total a cobrar:"+total.getValue().ToString();

            //Cargo filas.
            this.loadColumns();
            this.loadData(pendings);
        }
    }
}
