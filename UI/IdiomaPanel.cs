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
using UI;

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

        private void fillDataGrid(Dictionary<string, string> languages)
        {
            this.idioma_list.ReadOnly = true;
            
            //Load columns.
            this.idioma_list.Columns.Clear();
            this.idioma_list.Columns.Add("Codigo","Codigo");
            this.idioma_list.Columns.Add("Valor", "Valor");

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
            IdiomaBL langBiz = new IdiomaBL();            
            this.idiomas = langBiz.getList();
            this.idioma_combo.Text = this.idiomas[0].code;
            this.fillDataCombo(idiomas);
            this.fillDataGrid(langBiz.loadWords(this.idiomas[this.idioma_combo.SelectedIndex].code));
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

                if (value != "")
                {
                    //Actualizo la palabra.
                    new IdiomaBL().updateWord(this.selectedIdioma.code, idValue, value);

                    //Cargo la lista de palabras.
                    this.fillDataGrid(new IdiomaBL().loadWords(this.selectedIdioma.code));

                    MessageBox.Show("Valor actualizado!");
                }
                else
                    MessageBox.Show("Debe completar un valor actualizar");

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
                InputForm frm = new InputForm("Crear nuevo idioma", "Nombre del idioma");
                frm.ShowDialog();

                //Obtengo el valor. 
                string value = frm.getValue();

                if (value != "")
                {
                    new IdiomaBL().create(value);                   
                    this.reloadLanguages();

                    MessageBox.Show("Idioma nuevo creado!");
                }
                else
                    MessageBox.Show("Debe completar un valor para crear el idioma");          
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al crear el idioma");
            }
            
        }
    }
}



