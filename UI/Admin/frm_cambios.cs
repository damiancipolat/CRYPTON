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
using BL.ChangeControl;

namespace UI.Admin
{
    public partial class frm_cambios : Form
    {
        private long clientId;
        private List<ClienteChangeBE> listChanges = new List<ClienteChangeBE>();

        public frm_cambios(long id)
        {
            InitializeComponent();
            this.clientId = id;

            //Cargo los cambios.
            this.listChanges = new ClientChangeBL().findFromClient(id);
        }

        private void tranlateTexts()
        {
            this.Text = Idioma.GetInstance().translate("FRM_CHANGE_CONTROL");
            this.change_btn_apply.Text = Idioma.GetInstance().translate("USR_CHANGE_CLOSE");
            this.change_btn_apply.Text = Idioma.GetInstance().translate("FRM_CHANGE_CONTROL_BTN_RECOVE");
            this.usr_change_close.Text = Idioma.GetInstance().translate("USR_CHANGE_CLOSE");
        }

        private void fillData()
        {
            this.usr_data.Rows.Clear();

            //Loop to fill data.
            foreach (ClienteChangeBE client in this.listChanges)
            {
                this.usr_data.Rows.Add(
                    new string[] {
                        client.idchange.ToString(),
                        client.tipoDoc,
                        client.numero,
                        client.fec_nac.ToString("yyyy-mm-dd"),
                        client.num_tramite,
                        client.domicilio,
                        client.telefono
                });
            }
        }

        private void Frm_cambios_Load(object sender, EventArgs e)
        {
            this.tranlateTexts();

            //Load columns.
            this.usr_data.Columns.Clear();
            this.usr_data.ReadOnly = true;
        
            //Create columns.
            this.usr_data.Columns.Add(Idioma.GetInstance().translate("ID"), Idioma.GetInstance().translate("ID"));
            this.usr_data.Columns.Add(Idioma.GetInstance().translate("USR_CONTROL_COL_CHANGE_TDOC"), Idioma.GetInstance().translate("USR_CONTROL_COL_CHANGE_TDOC"));
            this.usr_data.Columns.Add(Idioma.GetInstance().translate("USR_CONTROL_COL_CHANGE_NUM"), Idioma.GetInstance().translate("USR_CONTROL_COL_CHANGE_NUM"));
            this.usr_data.Columns.Add(Idioma.GetInstance().translate("USR_CONTROL_COL_CHANGE_FEC_NAC"), Idioma.GetInstance().translate("USR_CONTROL_COL_CHANGE_FEC_NAC"));
            this.usr_data.Columns.Add(Idioma.GetInstance().translate("USR_CONTROL_COL_CHANGRE_NUM_TRAMITE"), Idioma.GetInstance().translate("USR_CONTROL_COL_CHANGRE_NUM_TRAMITE"));
            this.usr_data.Columns.Add(Idioma.GetInstance().translate("USR_CONTROL_COL_CHANGE_ADDRESS"), Idioma.GetInstance().translate("USR_CONTROL_COL_CHANGE_ADDRESS"));
            this.usr_data.Columns.Add(Idioma.GetInstance().translate("USR_CONTROL_COL_CHANGE_PHONE"), Idioma.GetInstance().translate("USR_CONTROL_COL_CHANGE_PHONE"));

            //Load data.
            this.fillData();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            /*
            int selectedrowindex = this.usr_data.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = this.usr_data.Rows[selectedrowindex];

            //Busco el usuario en base al id.
            string selectedId = selectedRow.Cells[0].Value.ToString();
            */
        }

        private void Usr_change_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Usr_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
