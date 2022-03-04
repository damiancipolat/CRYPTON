using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE.Permisos;

namespace UI
{
    public partial class ComponenteSelectorFrm : Form
    {
        private string title;
        private string description;
        private List<Componente> compList = new List<Componente>();
        private int selectedIx = -1;

        public ComponenteSelectorFrm(string title, string description, List<Componente> innerList)
        {
            InitializeComponent();
            this.title = title;
            this.description = description;
            this.compList = innerList;
        }

        public int getSelected()
        {
            return this.selectedIx;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.selectedIx = this.comp_list.SelectedIndex;
            this.Close();
        }

        private void fillItems(List<Componente> list)
        {
            this.comp_list.Items.Clear();

            foreach (Componente comp in list)
                this.comp_list.Items.Add(comp.Nombre);
        }

        private void ComponenteListFrm_Load(object sender, EventArgs e)
        {
            //Bind text.
            this.Text = this.title;
            this.comp_title.Text = this.title;
            this.comp_description.Text = this.description;

            //Fill rows
            this.fillItems(this.compList);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Comp_list_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
