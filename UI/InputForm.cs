using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class InputForm : Form
    {
        private string value=null;
        private string title;
        private string description;

        public InputForm(string title, string descrip)
        {
            InitializeComponent();
            this.title = title;
            this.description = descrip;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            this.Text = this.title;
            this.prompt_input.Text = this.title;
            this.prompt_description.Text = this.description;
        }

        public string getValue()
        {
            return this.value;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (this.frm_input.Text != "")
            {
                this.value = this.frm_input.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe completar un valor");
            }
        }
    }
}
