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
using SL;
using BL;

namespace UI.Banco
{
    public partial class frm_lista_retiro : Form
    {
        public frm_lista_retiro()
        {
            InitializeComponent();
        }

        private void translateText()
        {
            this.Text = Idioma.GetInstance().translate("RETIRO_TITLE");
            this.retiro_title.Text = Idioma.GetInstance().translate("RETIRO_TITLE");
            this.retiro_title_descrip.Text = Idioma.GetInstance().translate("RETIRO_TITLE_DESCRIP");
            this.btn_retiro_ok.Text = Idioma.GetInstance().translate("BTN_RETIRO_OK");
            this.btn_retiro_reject.Text = Idioma.GetInstance().translate("BTN_RETIRO_REJECT");
            this.btn_close.Text = Idioma.GetInstance().translate("SEARCH_CBU_BTN_CLOSE");
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadColumns()
        {
            //Load columns.
            this.retiro_list_data.ReadOnly = true;
            this.retiro_list_data.Columns.Clear();
            this.retiro_list_data.Columns.Add(Idioma.GetInstance().translate("idoperacion"), Idioma.GetInstance().translate("idoperacion"));
            this.retiro_list_data.Columns.Add(Idioma.GetInstance().translate("alias"), Idioma.GetInstance().translate("alias"));
            this.retiro_list_data.Columns.Add(Idioma.GetInstance().translate("tipo_solic"), Idioma.GetInstance().translate("tipo_solic"));
            this.retiro_list_data.Columns.Add(Idioma.GetInstance().translate("cbu"), Idioma.GetInstance().translate("cbu"));
            this.retiro_list_data.Columns.Add(Idioma.GetInstance().translate("valor"), Idioma.GetInstance().translate("valor"));
        }

        private void fillData() 
        {
            List<SolicOperacionBE> list = new OperacionesBL().getPendings();
            this.retiro_list_data.Rows.Clear();

            foreach (SolicOperacionBE ope in list)
            {
                string tipo_solic = "";

                if (ope.tipoOperacion == TipoSolicOperacion.INGRESO_SALDO)
                    tipo_solic = "Ingresar saldo";

                if (ope.tipoOperacion == TipoSolicOperacion.RETIRO_SALDO)
                    tipo_solic = "Retirar saldo";

                this.retiro_list_data.Rows.Add(new string[] {
                    ope.idoperacion.ToString(),
                    ope.usuario.alias,
                    tipo_solic,
                    ope.cbu,
                    "$ "+ope.valor.getValue().ToString()
                });
            }               

        }

        private void frm_lista_retiro_Load(object sender, EventArgs e)
        {
            this.translateText();

            //Cargo datos.
            this.loadColumns();
            this.fillData();            
        }

        private void btn_retiro_ok_Click(object sender, EventArgs e)
        {
            if (this.retiro_list_data.SelectedCells.Count > 0)
            {
                int selectedrowindex = this.retiro_list_data.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.retiro_list_data.Rows[selectedrowindex];
                string idValue = Convert.ToString(selectedRow.Cells[0].Value);

                if (idValue != "" && idValue != null)
                {
                    SolicOperacionBE ope = new OperacionesBL().findById(int.Parse(idValue));
                    ope.estadoSolic = SolicEstados.APROBADA;

                    //Actualizo.
                    new OperacionesBL().update(ope);
                    MessageBox.Show("Operacion aprobada");

                    //Recargo.
                    this.fillData();
                }
            }
        }

        private void btn_retiro_reject_Click(object sender, EventArgs e)
        {
            if (this.retiro_list_data.SelectedCells.Count > 0)
            {
                int selectedrowindex = this.retiro_list_data.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.retiro_list_data.Rows[selectedrowindex];
                string idValue = Convert.ToString(selectedRow.Cells[0].Value);

                if (idValue != "" && idValue != null)
                {
                    SolicOperacionBE ope = new OperacionesBL().findById(int.Parse(idValue));
                    ope.estadoSolic = SolicEstados.RECHAZADA;

                    //Actualizo.
                    new OperacionesBL().update(ope);
                    MessageBox.Show("Operacion rechazada");

                    //Recargo.
                    this.fillData();
                }
            }
        }
    }
}
