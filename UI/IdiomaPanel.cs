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
using BL;
using BE;
using SL;

namespace UI
{
    public partial class IdiomaPanel : Form
    {
        private List<IdiomaBE> idiomas;
        private IdiomaBE selectedIdioma;

        public IdiomaPanel()
        {
            InitializeComponent();
        }

        private void Usr_search_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void translateTexts()
        {
            this.usr_lang_ui_title.Text = Idioma.GetInstance().translate("USR_LANG_UI_TITLE");
            this.usr_lang_ui_descrip.Text = Idioma.GetInstance().translate("USR_LANG_UI_DESCRIP");
            this.usr_lang_ui_new_language.Text = Idioma.GetInstance().translate("USR_LANG_UI_NEW_LANGUAGE");
            this.usr_lang_del_all_language.Text = Idioma.GetInstance().translate("USR_LANG_UI_DEL_LANGUAGE");            
            this.usr_lang_ui_refresh_language.Text = Idioma.GetInstance().translate("USR_LANG_UI_REFRESH_LANGUAGE");
            this.usr_lang_ui_edit_language.Text = Idioma.GetInstance().translate("USR_LANG_UI_EDIT_LANGUAGE");
            this.usr_lang_ui_add_language.Text = Idioma.GetInstance().translate("USR_LANG_UI_ADD_LANGUAGE");
            this.usr_lang_ui_del_language.Text = Idioma.GetInstance().translate("USR_LANG_UI_DEL_LANGUAGE");
            this.usr_lang_ui_close_language.Text = Idioma.GetInstance().translate("USR_LANG_UI_CLOSE_LANGUAGE");
            this.Text = Idioma.GetInstance().translate("USR_LANG_UI_TITLE");
        }


        private void fillDataGrid(Dictionary<string, string> languages)
        {
            this.idioma_list.ReadOnly = true;
            
            //Load columns.
            this.idioma_list.Columns.Clear();
            this.idioma_list.Columns.Add(Idioma.GetInstance().translate("USR_LANG_COL_CODE"), Idioma.GetInstance().translate("USR_LANG_COL_CODE"));
            this.idioma_list.Columns.Add(Idioma.GetInstance().translate("USR_LANG_COL_VALUE"), Idioma.GetInstance().translate("USR_LANG_COL_VALUE"));

            foreach (KeyValuePair<string, string> entry in languages)
                this.idioma_list.Rows.Add(new string[] {entry.Key,entry.Value});
        }

        private void fillDataCombo(List<IdiomaBE> langs)
        {
            this.idioma_combo.Items.Clear();

            foreach (IdiomaBE lang in langs)
                this.idioma_combo.Items.Add(lang.code+"-"+lang.descripcion);

            this.idioma_combo.SelectedIndex = 0;
        }

        private void IdiomaPanel_Load(object sender, EventArgs e)
        {
            //Load languages.
            IdiomaBL langBiz = new IdiomaBL();            
            this.idiomas = langBiz.getList();
            this.idioma_combo.Text = this.idiomas[0].code;
            this.fillDataCombo(idiomas);
            this.fillDataGrid(langBiz.loadWords(this.idiomas[this.idioma_combo.SelectedIndex].code));

            //Translate texte.
            this.translateTexts();
        }

        private void Usr_perm_btn_Click(object sender, EventArgs e)
        {
            if (this.idioma_list.SelectedCells.Count>0)
            {
                //Get code from grid.
                int selectedrowindex = this.idioma_list.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.idioma_list.Rows[selectedrowindex];
                string idValue = Convert.ToString(selectedRow.Cells[0].Value);
                string strValue = Convert.ToString(selectedRow.Cells[1].Value);

                //Traigo el idioma.
                InputForm frm = new InputForm("Editar - "+ idValue, strValue);
                frm.ShowDialog();

                //Obtengo el valor. 
                string value = frm.getValue();

                if (value != null)
                {
                    //Actualizo la palabra.
                    new IdiomaBL().updateWord(this.selectedIdioma.code, idValue, value);

                    //Cargo la lista de palabras.
                    this.fillDataGrid(new IdiomaBL().loadWords(this.selectedIdioma.code));
                    MessageBox.Show(Idioma.GetInstance().translate("USR_LANG_UPD_OK"));
                }
            }
        }

        private void reloadLanguages()
        {
            IdiomaBL langBiz = new IdiomaBL();
            this.idiomas = langBiz.getList();
            this.fillDataCombo(this.idiomas);
            this.fillDataGrid(langBiz.loadWords(this.idiomas[0].code));
        }

        private void Idioma_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            IdiomaBL langBiz = new IdiomaBL();

            //Relleno la lista.
            this.selectedIdioma = this.idiomas[this.idioma_combo.SelectedIndex];
            this.fillDataGrid(langBiz.loadWords(this.idiomas[this.idioma_combo.SelectedIndex].code));            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Cargo y muestro.
                InputForm frm = new InputForm(Idioma.GetInstance().translate("USR_LANG_NEW"), Idioma.GetInstance().translate("USR_LANG_NEW_NAME"));
                frm.ShowDialog();

                //Obtengo el valor. 
                string value = frm.getValue();

                if (value != null)
                {
                    new IdiomaBL().create(value);                   
                    this.reloadLanguages();

                    MessageBox.Show(Idioma.GetInstance().translate("USR_LANG_NEW_OK"));
                }         
            }
            catch (Exception ex)
            {
                MessageBox.Show(Idioma.GetInstance().translate("USR_LANG_NEW_ERROR"));
            }
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (this.idioma_list.SelectedCells.Count > 0)
            {
                //Get code from grid.
                int selectedrowindex = this.idioma_list.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.idioma_list.Rows[selectedrowindex];

                //Extract the cell values.
                string idValue = Convert.ToString(selectedRow.Cells[0].Value);
                string strValue = Convert.ToString(selectedRow.Cells[1].Value);

                //Show the ui
                new Word(idValue, this.selectedIdioma).Show();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.selectedIdioma = this.idiomas[this.idioma_combo.SelectedIndex];
            this.fillDataGrid(new IdiomaBL().loadWords(this.idiomas[this.idioma_combo.SelectedIndex].code));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                Idioma.GetInstance().translate("USR_LANG_DELETE_CONFIRM_TITLE"),
                Idioma.GetInstance().translate("USR_LANG_DELETE_CONFIRM"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes&& this.idioma_list.SelectedCells.Count > 0)
            {
                //Get code from grid.
                int selectedrowindex = this.idioma_list.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.idioma_list.Rows[selectedrowindex];
                string idValue = Convert.ToString(selectedRow.Cells[0].Value);
                string strValue = Convert.ToString(selectedRow.Cells[1].Value);

                //Borro la palabra.
                new IdiomaBL().deleteWord(this.selectedIdioma.code, idValue);
                MessageBox.Show(Idioma.GetInstance().translate("USR_LANG_DELETE_OK"));

                //Actualizo
                this.selectedIdioma = this.idiomas[this.idioma_combo.SelectedIndex];
                this.fillDataGrid(new IdiomaBL().loadWords(this.idiomas[this.idioma_combo.SelectedIndex].code));
            }
        }

        private void Usr_lang_del_all_language_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                Idioma.GetInstance().translate("USR_LANG_ALL_DELETE_CONFIRM_TITLE"),
                Idioma.GetInstance().translate("USR_LANG_UI_DEL_LANGUAGE"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                //Borro el idioma.
                new IdiomaBL().delete(this.selectedIdioma);

                //Mensaje de exito.
                MessageBox.Show(Idioma.GetInstance().translate("USR_LANG_DELETE_OK"));

                /*
                //Actualizo
                this.selectedIdioma = this.idiomas[this.idioma_combo.SelectedIndex];
                this.fillDataGrid(new IdiomaBL().loadWords(this.idiomas[this.idioma_combo.SelectedIndex].code));
                */
            }
        }
    }
}



