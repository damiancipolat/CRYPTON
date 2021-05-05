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
using DAL.Idiomas;
using BE;
using SL;

namespace UI
{
    public partial class Language : Form
    {
        private List<IdiomaBE> languages;

        public Language()
        {
            InitializeComponent();
        }

        private void Language_txt_title_Click(object sender, EventArgs e)
        {

        }

        private void Language_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Language_Shown(object sender, EventArgs e)
        {
            //Clean combo items.
            this.language_combo.Items.Clear();

            //Get all languages.
            List<IdiomaBE> langs = new IdiomaDAL().findAll();
            this.languages = langs;

            if (langs.Count == 0)
                throw new Exception("No language founds");

            //Fill text in combo.
            foreach (IdiomaBE idioma in langs)
                this.language_combo.Items.Add(idioma.descripcion);

            //Define default item.
            this.language_combo.SelectedIndex = 0;
        }

        private void Language_accept_Click(object sender, EventArgs e)
        {
            if (this.languages.Count > 0)
            {
                //Traigo la lista de idiomas.
                IdiomaBE lang = this.languages[this.language_combo.SelectedIndex];
                Session.GetInstance().setLanguage(lang.code, new IdiomaDAL().loadWords(lang.code));
                MessageBox.Show("Idioma cambiado con exito!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al cambiar el lenguaje");
                this.Close();
            }
            
        }
    }
}
