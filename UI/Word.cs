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

namespace UI
{
    public partial class Word : Form
    {
        private string key;
        private IdiomaBE lang;

        public Word(string key,IdiomaBE idioma)
        {
            this.key = key;
            this.lang = idioma;

            InitializeComponent();
        }

        private void Btn_update_permission_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_compound_permission_Click(object sender, EventArgs e)
        {
            new IdiomaBL().recordWord(this.lang.code, this.txt_key.Text, this.txt_value.Text);
            MessageBox.Show("Palabra creada");
            this.Close();
        }
    }
}
