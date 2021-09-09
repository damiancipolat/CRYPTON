using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using BE;
using SL;

namespace UI.Admin
{
    public partial class frm_bitacora : Form
    {
        List<string> activities = new List<string>();

        public frm_bitacora()
        {
            InitializeComponent();
        }

        private void loadCombo()
        {
            List<string> logList = new BitacoraBL().getActivities();

            //Agreg el 1ro.
            this.activities.Add("*");

            //Agrego valores.
            foreach (string activ in logList)
                this.activities.Add(activ);

            //Borro la lista de actividades.
            this.activ_combo.Items.Clear();

            foreach (string activStr in this.activities)
                this.activ_combo.Items.Add(activStr);

            if (this.activities.Count > 0)
                this.activ_combo.SelectedIndex = 0;
        }

        private void loadGrid()
        {
            //Load columns.
            this.bitacora_data.ReadOnly = true;
            this.bitacora_data.Columns.Clear();
            this.bitacora_data.Columns.Add(Idioma.GetInstance().translate("LOG_COL_ID"), Idioma.GetInstance().translate("LOG_COL_ID"));
            this.bitacora_data.Columns.Add(Idioma.GetInstance().translate("LOG_COL_FECHA"), Idioma.GetInstance().translate("LOG_COL_FECHA"));
            this.bitacora_data.Columns.Add(Idioma.GetInstance().translate("LOG_COL_USUARIO"), Idioma.GetInstance().translate("LOG_COL_USUARIO"));
            this.bitacora_data.Columns.Add(Idioma.GetInstance().translate("LOG_COL_ACTIVIDAD"), Idioma.GetInstance().translate("LOG_COL_ACTIVIDAD"));
            this.bitacora_data.Columns.Add(Idioma.GetInstance().translate("LOG_COL_TEXTO"), Idioma.GetInstance().translate("LOG_COL_TEXTO"));
        }

        private void translateText()
        {
            this.Text= Idioma.GetInstance().translate("LOG_SEARCH_TITLE");
            this.search_title.Text = Idioma.GetInstance().translate("LOG_SEARCH_TITLE");
            this.search_descrip.Text = Idioma.GetInstance().translate("LOG_SEARCH_DESCRIP");
            this.btn_search.Text = Idioma.GetInstance().translate("LOG_BTN_SEARCH");
            this.btn_close.Text = Idioma.GetInstance().translate("LOG_BTN_CLOSE");
            this.activ_title.Text= Idioma.GetInstance().translate("LOG_ACTIV_TITLE");
            this.from_title.Text = Idioma.GetInstance().translate("LOG_FROM_TITLE");
            this.to_title.Text = Idioma.GetInstance().translate("LOG_TO_TITLE");
            this.text_title.Text= Idioma.GetInstance().translate("LOG_TEXT_TITLE");
        }

        private void Frm_bitacora_Load(object sender, EventArgs e)
        {
            this.loadCombo();
            this.loadGrid();
            this.translateText();
        }

        private void Btn_search_Click(object sender, EventArgs e)
        {
            //Obtengo el valor elegido.
            string activTxt = this.activities[this.activ_combo.SelectedIndex];

            //Busco en la bd.
            List<BitacoraBE> listLog = new BitacoraBL().search(activTxt, this.date_from_txt.Text, this.date_to_txt.Text, this.payload_txt.Text);

            //Dibujo grilla.
            if (listLog.Count > 0)
            {
                //Loop to fill data.
                foreach (BitacoraBE log in listLog)
                {
                    string userStr = log.usuario != null ? log.usuario.nombre : "Indet.";

                    this.bitacora_data.Rows.Add(
                        new string[] {
                        log.id.ToString(),
                        log.fecLog.ToString(),
                        userStr,
                        log.actividad,
                        log.payload
                    });
                }
            }
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
