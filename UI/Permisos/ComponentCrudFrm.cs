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
using BE.Permisos;
using BL;
using SL;
using BL.Permisos;

namespace UI.Permisos
{
    public partial class ComponentCrudFrm : Form
    {
        private string mode;
        private List<Componente> innerList = new List<Componente>();

        public ComponentCrudFrm(string mode)
        {
            InitializeComponent();
            this.mode = mode;
        }

        private void translateText()
        {
            if (this.mode=="family")
                this.comp_crud_title.Text = Idioma.GetInstance().translate("COMP_CRUD_TITLE_FAMILY");

            if (this.mode == "patent")
                this.comp_crud_title.Text = Idioma.GetInstance().translate("COMP_CRUD_TITLE_PATENT");

            this.Text = this.comp_crud_title.Text;
            this.comp_crud_description.Text = Idioma.GetInstance().translate("COMP_CRUD_DESCRIPTION");
            this.comp_crud_add.Text = Idioma.GetInstance().translate("COMP_CRUD_ADD");
            this.comp_crud_close.Text = Idioma.GetInstance().translate("COMP_CRUD_CLOSE");
            this.comp_crud_delete.Text = Idioma.GetInstance().translate("COMP_CRUD_DELETE");
        }

        private void loadData()
        {
            //Cargo contenido.
            List<Componente> compList = new List<Componente>();

            if (this.mode == "family")
            {
                List<Familia> familias = new FamiliaBL().getAll();
                foreach (Familia fam in familias)
                    compList.Add((Componente)fam);
            }

            if (this.mode == "patent")
            {
                List<Patente> patentes = new PatenteBL().getAll();
                foreach (Patente pat in patentes)
                    compList.Add((Componente)pat);
            }

            this.innerList = compList;

            //Cargo la ui.
            this.comp_crud_list.Items.Clear();

            foreach (Componente comp in compList)
                this.comp_crud_list.Items.Add(comp.Nombre);
        }

        private void ComponentCrudFrm_Load(object sender, EventArgs e)
        {
            this.translateText();
            this.loadData();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Comp_crud_delete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                Idioma.GetInstance().translate("COMP_CRUD_DELETE_CONFIRM"),
                Idioma.GetInstance().translate("COMP_CRUD_DELETE_TITLE"),                
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                Componente comp = this.innerList[this.comp_crud_list.SelectedIndex];

                //Grabo.
                if (this.mode == "family")
                    new FamiliaBL().delete(comp.Id);

                if (this.mode == "patent")
                    new PatenteBL().delete(comp.Id);

                //Recargo.
                this.loadData();

                //Exitos.
                MessageBox.Show(Idioma.GetInstance().translate("COMP_CRUD_DELETE_OK"));
            }
        }

        private void Comp_crud_add_Click(object sender, EventArgs e)
        {
            //Cargo y muestro.
            InputForm frm = new InputForm(Idioma.GetInstance().translate("COMP_CRUD_ADD_VALUE"), Idioma.GetInstance().translate("COMP_CRUD_ADD_DESCRIP"));
            frm.ShowDialog();

            //Obtengo el valor. 
            string value = frm.getValue();

            if (value != null)
            {
                //Grabo.
                if (this.mode == "family")
                    new FamiliaBL().save(value);

                if (this.mode == "patent")
                    new PatenteBL().save(value);

                //Recargo.
                this.loadData();

                //Exitos.
                MessageBox.Show(Idioma.GetInstance().translate("TEMPLATE_EDITOR_ADD_OK"));
            }
        }
    }
}
