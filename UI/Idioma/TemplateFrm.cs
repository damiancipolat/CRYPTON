using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SL;
using BL;
using UI;

namespace UI
{
    public partial class TemplateFrm : Form
    {
        public TemplateFrm()
        {
            InitializeComponent();
        }

        private void translateTexts()
        {
            this.template_close.Text = Idioma.GetInstance().translate("USR_SEARCH_CLOSE");
            this.template_add.Text = Idioma.GetInstance().translate("TEMPLATE_EDITOR_ADD");
            this.template_delete.Text = Idioma.GetInstance().translate("TEMPLATE_EDITOR_DELETE");
            this.template_editor.Text = Idioma.GetInstance().translate("TEMPLATE_EDITOR");
            this.Text = Idioma.GetInstance().translate("TEMPLATE_EDITOR");
        }
        private void Usr_lang_ui_close_language_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadTemplate(Dictionary<string, string> languages)
        {
            this.idioma_list.ReadOnly = true;

            //Load columns.
            this.idioma_list.Columns.Clear();
            this.idioma_list.Columns.Add(Idioma.GetInstance().translate("USR_LANG_COL_CODE"), Idioma.GetInstance().translate("USR_LANG_COL_CODE"));
            this.idioma_list.Rows.Clear();

            foreach (KeyValuePair<string, string> entry in languages)
                this.idioma_list.Rows.Add(new string[] { entry.Key, entry.Value });
        }

        private void TemplateFrm_Load(object sender, EventArgs e)
        {
            this.translateTexts();
            this.loadTemplate(new IdiomaBL().loadTemplate());
        }

        private void Template_add_Click(object sender, EventArgs e)
        {
            //Traigo el idioma.
            InputForm frm = new InputForm(Idioma.GetInstance().translate("TEMPLATE_EDITOR_ADD"), Idioma.GetInstance().translate("TEMPLATE_EDITOR_ADD"));
            frm.ShowDialog();

            //Obtengo el valor. 
            string value = frm.getValue();

            if (value != null)
            {
                //Actualizo la palabra.
                new IdiomaBL().createWordAll(value.ToUpper());

                //Cargo la lista de palabras.
                this.loadTemplate(new IdiomaBL().loadTemplate());
                MessageBox.Show(Idioma.GetInstance().translate("TEMPLATE_EDITOR_ADD_OK"));
            }
        }

        private void Template_delete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                Idioma.GetInstance().translate("TEMPLATE_CONFIRM_DELETE"),
                Idioma.GetInstance().translate("USR_LANG_UI_DEL_LANGUAGE"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                //Get code from grid.
                int selectedrowindex = this.idioma_list.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.idioma_list.Rows[selectedrowindex];
                string idValue = Convert.ToString(selectedRow.Cells[0].Value);

                //Borro el idioma
                new IdiomaBL().deleteWordAll(idValue.ToUpper());

                //Cargo la lista de palabras.
                this.loadTemplate(new IdiomaBL().loadTemplate());
                MessageBox.Show(Idioma.GetInstance().translate("TEMPLATE_EDITOR_DELETE_OK"));
            }
        }
    }
}
