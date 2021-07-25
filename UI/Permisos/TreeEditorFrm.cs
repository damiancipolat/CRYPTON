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
        private int selectedFamilyId;
        private Familia2 seleccion;

        public TreeEditorFrm()
        {
            InitializeComponent();            
        }

        private void TreeEditorFrm_Load(object sender, EventArgs e)
        {
            //Load familia and patente.
            this.innerFamilia = new FamiliaBL().getAll();
            this.innerPatente = new PatenteBL().getAll();

            //Cargo el combo de lista de familias.
            this.tree_family_list.Items.Clear();

            foreach (Familia2 family in this.innerFamilia)
                this.tree_family_list.Items.Add(family.Nombre);

            //Si hay datos selecciono por defecto el 1ro.
            if (this.innerFamilia.Count > 0)
            {
                //Seteo defaults.
                this.tree_family_list.SelectedIndex = 0;
                this.seleccion = this.innerFamilia[0];
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

        //CRUD arbol ---------------------------------------------------------

        //Agregar FAMILIA.
        private void Button5_Click(object sender, EventArgs e)
        {
            //Load data.
            List<Componente2> compList = new List<Componente2>();

            foreach (Familia2 fam in this.innerFamilia)
                compList.Add((Componente2)fam);

            //Show input.
            ComponenteSelectorFrm frm = new ComponenteSelectorFrm(Idioma.GetInstance().translate("EDIT_FAMILY_SELECTOR_TITLE"), Idioma.GetInstance().translate("EDIT_FAMILY_SELECTOR_DESCRIP"), compList);
            frm.ShowDialog();

            //Obtengo el valor. 
            int value = frm.getSelected();

            if ((value < 0)|| (this.seleccion == null))
                return;
            
            //Extraigo la familia.
            Familia2 familia = this.innerFamilia[value];

            if (familia != null)
            {
                PermisoBL repo = new PermisoBL();

                if (repo.Existe(this.seleccion, familia.Id))
                    MessageBox.Show("ya exsite la familia indicada");
                else
                {
                    repo.FillFamilyComponents(familia);
                    this.seleccion.AgregarHijo(familia);
                    MostrarFamilia(false);
                }
            }
        }

        //Agregar PATENTE.
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

            if (seleccion != null)
            {
                var patente = (Patente2)this.innerPatente[value];

                if (patente != null)
                {
                    if (new PermisoBL().Existe(seleccion, patente.Id))
                        MessageBox.Show("ya exsite la patente indicada");
                    else
                    {
                        seleccion.AgregarHijo(patente);
                        MostrarFamilia(false);
                    }
                }
            }
        }

        //Render del arbol --------------------------------------------------

        //Muestra el contenido de una familia.
        private void MostrarFamilia(bool init)
        {
            if (seleccion == null) return;

            IList<Componente2> flia = null;
            if (init)
            {
                //traigo los hijos de la base
                flia = new PermisoBL().GetAll("=" + seleccion.Id);


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
            {
                MostrarEnTreeView(root, item);
            }

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
                {
                    Debug.WriteLine(">>>>" + item.Nombre);
                    MostrarEnTreeView(n, item);
                }                    
            }
        }

        //Cuando selecciona el combo.
        private void Tree_family_list_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Permission_tree_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            var tmp = (Familia2)this.innerFamilia[this.tree_family_list.SelectedIndex];
            this.seleccion = new Familia2();
            this.seleccion.Id = tmp.Id;
            this.seleccion.Nombre = tmp.Nombre;

            this.MostrarFamilia(true);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (this.seleccion != null)
            {
                new PermisoBL().GuardarFamilia(this.seleccion);
                MessageBox.Show("Save ok!");
            }
        }
    }
}
