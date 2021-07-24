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
using BE;
using BE.Permisos;
using SL;
using BL.Permisos;

namespace UI.Permisos
{
    public partial class TreeEditorFrm : Form
    {
        private List<Familia2> innerFamilia = new List<Familia2>();
        private List<Patente2> innerPatente = new List<Patente2>();
        private Familia2 selectedFamily;

        public TreeEditorFrm()
        {
            InitializeComponent();            
        }

        private void TreeEditorFrm_Load(object sender, EventArgs e)
        {
            //Load familia and patente.
            this.innerFamilia = new FamiliaBL().getAll();
            this.innerPatente = new PatenteBL().getAll();

            //Borro
            this.tree_family_list.Items.Clear();

            //Cargo items.
            foreach (Familia2 family in this.innerFamilia)
                this.tree_family_list.Items.Add(family.Nombre);

            if (this.innerFamilia.Count > 0)
            {
                //Seteo defaults.
                this.tree_family_list.SelectedIndex = 0;
                this.selectedFamily = this.innerFamilia[this.tree_family_list.SelectedIndex];

                //Dibujo el arbol.
                this.MostrarFamilia(this.selectedFamily, true);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new ComponentCrudFrm("family").Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new ComponentCrudFrm("patent").Show();
        }

        private void Usr_lang_del_all_language_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //Load data.
            List<Familia2> familias = new FamiliaBL().getAll();
            List<Componente2> compList = new List<Componente2>();

            foreach (Familia2 fam in familias)
                compList.Add((Componente2)fam);

            //Show input.
            ComponenteSelectorFrm frm = new ComponenteSelectorFrm(Idioma.GetInstance().translate("EDIT_FAMILY_SELECTOR_TITLE"), Idioma.GetInstance().translate("EDIT_FAMILY_SELECTOR_DESCRIP"), compList);
            frm.ShowDialog();

            //Obtengo el valor. 
            int value = frm.getSelected();

            if (value >= 0)
            {
                MessageBox.Show("---->" + value.ToString());
                //new IdiomaBL().create(value);
                // this.reloadLanguages();

                //MessageBox.Show(Idioma.GetInstance().translate("USR_LANG_NEW_OK"));
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //Load data.
            List<Componente2> tmp2 = new List<Componente2>();

            foreach (Patente2 pat in this.innerPatente)
                tmp2.Add((Componente2)pat);

            //Show input.            
            ComponenteSelectorFrm frm = new ComponenteSelectorFrm(Idioma.GetInstance().translate("EDIT_PATENTE_SELECTOR_TITLE"), Idioma.GetInstance().translate("EDIT_PATENTE_SELECTOR_DESCRIP"), tmp2);
            frm.ShowDialog();

            //Obtengo el valor. 
            int value = frm.getSelected();

            //Validaciones.
            if (value < 0)
                return;

            if (this.selectedFamily == null)
                return;

            //Traigo la patente.
            Patente2 selectedPatente = this.innerPatente[value];

            if (selectedPatente != null)
            {
                var esta = new PermisoBL().Existe(this.selectedFamily, selectedPatente.Id);
                if (esta)
                    MessageBox.Show("ya exsite la patente indicada");
                else
                {
                    this.selectedFamily.AgregarHijo(selectedPatente);
                    MostrarFamilia(this.selectedFamily,false);
                }
            }
        }


        //Render del arbol --------------------------------------------------

        //Muestra el contenido de una familia.
        private void MostrarFamilia(Familia2 seleccion, bool init)
        {
            IList<Componente2> flia = null;

            if (init)
            {
                //traigo los hijos de la base
                flia = new PermisoBL().GetAll("=" + this.selectedFamily.Id.ToString());

                foreach (var i in flia)
                    seleccion.AgregarHijo(i);
            }
            else
            {
                flia = seleccion.Hijos;
            }

            this.permission_tree.Nodes.Clear();

            TreeNode root = new TreeNode(seleccion.Nombre);
            root.Tag = seleccion;
            this.permission_tree.Nodes.Add(root);

            foreach (var item in flia)
                MostrarEnTreeView(root, item);

            permission_tree.ExpandAll();
        }

        //Dibuja en el treeview.
        private void MostrarEnTreeView(TreeNode tn, Componente2 c)
        {
            TreeNode n = new TreeNode(c.Nombre);
            tn.Tag = c;
            tn.Nodes.Add(n);

            if (c.Hijos != null)
            {
                foreach (var item in c.Hijos)
                    MostrarEnTreeView(n, item);
            }
        }

        //Cuando selecciona el combo.
        private void Tree_family_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Actualizo.
            this.selectedFamily = this.innerFamilia[this.tree_family_list.SelectedIndex];

            //Dibujo el arbol.
            this.MostrarFamilia(this.selectedFamily, true);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
           
        }

        private void Btn_update_permission_Click(object sender, EventArgs e)
        {

        }
    }
}
