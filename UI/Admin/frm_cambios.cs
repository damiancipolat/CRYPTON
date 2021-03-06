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
            this.txt_ctrl_title.Text = Idioma.GetInstance().translate("USR_TXT_CTRL_TITLE");
            this.txt_ctrl_descrip.Text = Idioma.GetInstance().translate("USR_TXT_CTRL_DESCRIP");
        }

        private void fillData()
        {
            this.usr_data.Rows.Clear();
            this.listChanges.Reverse(0, this.listChanges.Count);

            //Loop to fill data.
            foreach (ClienteChangeBE change in this.listChanges)
            {
                this.usr_data.Rows.Add(
                    new string[] {
                        change.idchange.ToString(),
                        change.tipoDoc,
                        change.numero,
                        change.fec_nac.ToString("yyyy-mm-dd"),
                        change.num_tramite,
                        change.domicilio,
                        change.telefono,
                        change.rollbackUser!=null?change.rollbackUser.alias:"-"
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
            this.usr_data.Columns.Add(Idioma.GetInstance().translate("USR_CONTROL_COL_CHANGE_OPERATOR"), Idioma.GetInstance().translate("USR_CONTROL_COL_CHANGE_OPERATOR"));            

            //Load data.
            this.fillData();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Si esta seleccionado.
            if (this.usr_data.SelectedCells.Count > 0)
            {
                //Obtengo la columna.
                int selectedrowindex = this.usr_data.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.usr_data.Rows[selectedrowindex];

                //Busco el usuario en base al id.
                string selectedId = selectedRow.Cells[0].Value.ToString();

                //Msg de confirmacion.
                DialogResult dr = MessageBox.Show(
                    Idioma.GetInstance().translate("USR_CHANGE_TITLE"),
                    Idioma.GetInstance().translate("USR_CHANGE_CONFIRM"),                    
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes)
                {
                    //Busco la entidad y la restauro.
                    new ClientChangeBL().recoverFrom(Convert.ToInt64(selectedId));

                    //Comunico.
                    MessageBox.Show(Idioma.GetInstance().translate("USR_CHANGE_RESTORE_SUCCESS"));

                }
            }
        }

        private void Usr_change_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Usr_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Usr_change_close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}