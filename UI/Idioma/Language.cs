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
using UI.Notifications;

namespace UI
{
    public partial class Language : Form
    {
        private List<IdiomaBE> languages;
        private Notificator uiEvents;

        //Actualizo los textos en base al idioma elegido.
        private void translateTexts()
        {            
            //Labels.
            this.Text= Idioma.GetInstance().translate("MAIN_MENU_LANGUAGE");
            this.language_txt_title.Text = Idioma.GetInstance().translate("LANG_CHOOSE_TITLE");
            this.language_accept.Text = Idioma.GetInstance().translate("BUTTON_OK");
            this.language_cancel.Text = Idioma.GetInstance().translate("BUTTON_CANCEL");
        }

        public Language(Notificator events)
        {
            InitializeComponent();
            this.uiEvents = events;
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
            //Get the default language.
            string defaultLang = Idioma.GetInstance().getDefault().code;
            int defaultIx = 0;

            //Clean combo items.
            this.language_combo.Items.Clear();

            //Get all languages.            
            List<IdiomaBE> langs = Idioma.GetInstance().getAll();
            this.languages = langs;

            if (langs.Count == 0)
                throw new Exception("No language founds");

            //Fill text in combo.
            for (int i = 0; i <= langs.Count - 1; i++)
            {
                IdiomaBE idioma = langs[i];

                //Set the default language in the combo.
                if (idioma.code == defaultLang)
                    defaultIx = i;

                //Fill items.
                this.language_combo.Items.Add(idioma.descripcion);
            }            

            //Define default item.
            this.language_combo.SelectedIndex = defaultIx;
        }

        private void Language_accept_Click(object sender, EventArgs e)
        {
            if (this.languages.Count > 0)
            {
                //Traigo la lista de idiomas.
                IdiomaBE lang = this.languages[this.language_combo.SelectedIndex];

                //Seteo el idioma por defecto.
                Idioma.GetInstance().setDefault(lang);

                //Notifico cambio de eventos.
                MessageBox.Show(Idioma.GetInstance().translate("LANGUAGE_CHANGE_OK"));
                this.uiEvents.Notify();

                this.Close();
            }
            else
            {
                MessageBox.Show(Idioma.GetInstance().translate("LANGUAGE_CHANGE_OK"));
                this.Close();
            }
            
        }

        private void Language_Load(object sender, EventArgs e)
        {
            this.translateTexts();
        }
    }
}