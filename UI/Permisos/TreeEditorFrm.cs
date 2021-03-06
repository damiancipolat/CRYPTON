using System;
using System.Collections;
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
        private List<Familia> innerFamilia = new List<Familia>();
        private List<Patente> innerPatente = new List<Patente>();        
        private Familia seleccion;
        private List<Tuple<string,int, int, string>> operations = new List<Tuple<string, int, int, string>> ();

        public TreeEditorFrm()
        {
            InitializeComponent();            
        }

        //CRUD arbol ---------------------------------------------------------

        //Agregar FAMILIA.
        private void Button5_Click(object sender, EventArgs e)
        {
            //Load data.
            List<Componente> compList = new List<Componente>();

            foreach (Familia fam in this.innerFamilia)
                compList.Add((Componente)fam);

            //Show input.
            ComponenteSelectorFrm frm = new ComponenteSelectorFrm(Idioma.GetInstance().translate("EDIT_FAMILY_SELECTOR_TITLE"), Idioma.GetInstance().translate("EDIT_FAMILY_SELECTOR_DESCRIP"), compList);
            frm.ShowDialog();

            //Obtengo el valor. 
            int value = frm.getSelected();

            if ((value < 0)|| (this.seleccion == null))
                return;
            
            //Extraigo la familia.
            Familia familia = this.innerFamilia[value];

            if (familia != null)
            {
                PermisoBL repo = new PermisoBL();

                if (repo.Existe(this.seleccion, familia.Id))
                    MessageBox.Show(Idioma.GetInstance().translate("TREE_FAMILY_EXISTS"));
                else
                {
                    //Registro la operacion en el buffer de operaciones.
                    this.operations.Add(
                        Tuple.Create(
                            "add",
                            this.seleccion.Id
                            ,familia.Id,
                            "")
                    );

                    //Impacto el cambio en la ui.
                    repo.FillFamilyComponents(familia);
                    this.seleccion.AgregarHijo(familia);
                    MostrarFamilia(false);

                    //Purgar la grilla.
                    this.purgeFromOps();
                }
            }
        }

        //Agregar PATENTE.
        private void Button4_Click(object sender, EventArgs e)
        {
            //Load data.
            List<Componente> tmp2 = new List<Componente>();

            foreach (Patente pat in this.innerPatente)
                tmp2.Add((Componente)pat);

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
                var patente = (Patente)this.innerPatente[value];

                if (patente != null)
                {
                    if (new PermisoBL().Existe(seleccion, patente.Id))
                        MessageBox.Show(Idioma.GetInstance().translate("TREE_PATENT_EXISTS"));
                    else
                    {
                        //Registro la operacion en el buffer de operaciones.
                        this.operations.Add(
                            Tuple.Create(
                                "add", 
                                this.seleccion.Id, 
                                patente.Id,"")
                        );

                        //Impactio en UI.
                        seleccion.AgregarHijo(patente);
                        MostrarFamilia(false);

                        //Purgar la grilla.
                        this.purgeFromOps();
                    }
                }
            }
        }

        //Purgo el arbol.
        private void purgeFromOps()
        {
            foreach (Tuple<string, int, int, string> ops in this.operations)
            {
                if (ops.Item1 == "del")
                {
                    //Busco el nodo.
                    TreeNode node = new NodeSearch().GetNode(this.permission_tree.Nodes, ops.Item4);

                    //Si existe, lo borro en el control.
                    if (node != null)
                    {
                        node.BackColor = Color.Yellow;
                        Debug.WriteLine("Encontre:" + node.Name + "," + node.ImageKey);
                        this.permission_tree.Nodes.Remove(node);
                    }
                }
            }
        }

        //Render del arbol ---------------------------------------------------

        //Muestra el contenido de una familia.
        private void MostrarFamilia(bool init)
        {
            if (seleccion == null) return;

            IList<Componente> flia = null;
            if (init)
            {
                //traigo los hijos de la base
                flia = new PermisoBL().GetAll("=" + seleccion.Id);

                foreach (Componente i in flia)
                {
                    seleccion.AgregarHijo(i);
                }
                    
            }
            else
            {
                flia = seleccion.Hijos;
            }

            //Borro la lista de nodos.
            this.permission_tree.Nodes.Clear();

            //Armo el root padre y lo cargo.
            TreeNode root = new TreeNode(seleccion.Nombre);
            root.Tag = seleccion.Id.ToString();
            this.permission_tree.Nodes.Add(root);

            //Cargo recursivamente.
            foreach (var item in flia)
                MostrarEnTreeView(root, item);

            //Expando la lista de items.
            permission_tree.ExpandAll();
        }

        //Dibuja en el treeview.
        private void MostrarEnTreeView(TreeNode tn, Componente c)
        {
            TreeNode n = new TreeNode(c.Nombre);
            n.Tag = c.Id.ToString();
            n.ImageKey= this.seleccion.Id + ":" + c.Id.ToString()+":"+c.Nombre;
            
            tn.Nodes.Add(n);

            if (c.Hijos != null)
            {
                foreach (var item in c.Hijos)
                    MostrarEnTreeView(n, item);
            }
        }

        //Eventos UI ---------------------------------------------------------

        private void translateText()
        {
            this.Text= Idioma.GetInstance().translate("TREE_TITLE_EDITOR");
            this.tree_title_editor.Text = Idioma.GetInstance().translate("TREE_TITLE_EDITOR");
            this.tree_descrip_editor.Text = Idioma.GetInstance().translate("TREE_DESCRIP_EDITOR");
            this.tree_crud_family.Text = Idioma.GetInstance().translate("TREE_CRUD_FAMILY");
            this.tree_crud_patent.Text = Idioma.GetInstance().translate("TREE_CRUD_PATENT");
            this.tree_crud_view.Text = Idioma.GetInstance().translate("TREE_CRUD_VIEW");
            this.tree_crud_add_family.Text = Idioma.GetInstance().translate("TREE_CRUD_ADD_FAMILY");
            this.tree_crud_add_patent.Text = Idioma.GetInstance().translate("TREE_CRUD_ADD_PATENT");
            this.tree_crud_save.Text = Idioma.GetInstance().translate("TREE_CRUD_SAVE");
            this.tree_crud_close.Text= Idioma.GetInstance().translate("TREE_CRUD_CLOSE");
            this.tree_crud_delete.Text= Idioma.GetInstance().translate("TREE_CRUD_DELETE");
        }

        private void refreshData()
        {
            //Traduzco.
            this.translateText();

            //Load familia and patente.
            this.innerFamilia.Clear();
            this.innerPatente.Clear();

            this.innerFamilia = new FamiliaBL().getAll();
            this.innerPatente = new PatenteBL().getAll();

            //Cargo el combo de lista de familias.
            this.tree_family_list.Items.Clear();

            foreach (Familia family in this.innerFamilia)
                this.tree_family_list.Items.Add(family.Nombre);

            //Si hay datos selecciono por defecto el 1ro.
            if (this.innerFamilia.Count > 0)
            {
                //Seteo defaults.
                this.tree_family_list.SelectedIndex = 0;
                this.seleccion = this.innerFamilia[0];
                this.verFamilia();
            }
        }

        private void TreeEditorFrm_Load(object sender, EventArgs e)
        {
            this.refreshData();
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

        //Cuando selecciona el combo.
        private void Tree_family_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.seleccion != null)
                this.verFamilia();
        }

        private void Permission_tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.permission_tree.SelectedNode != null)
            {
                TreeNode node = this.permission_tree.SelectedNode;
                Debug.WriteLine("Haz clickeado sobre:" + node.ImageKey + " " + node.Text + "__" + node.Name + " tag:" + node.Tag+ " >"+node.ImageKey);
            }
        }

        private void verFamilia()
        {
            //Borro las operaciones.
            this.operations.Clear();

            //Rendereo.
            var tmp = (Familia)this.innerFamilia[this.tree_family_list.SelectedIndex];
            this.seleccion = new Familia();
            this.seleccion.Id = tmp.Id;
            this.seleccion.Nombre = tmp.Nombre;

            this.MostrarFamilia(true);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.verFamilia();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //Armo una lista de proceso.
            List<Tuple<string, int, int>> process = new List<Tuple<string, int, int>>();

            //Itero y cargo.
            foreach (Tuple<string, int, int, string> tuple in this.operations)
                process.Add(Tuple.Create(tuple.Item1,tuple.Item2,tuple.Item3));

            //Proceso el guardado.
            new PermisoBL().GuardarFamilia(process);

            //Fin y exito.
            MessageBox.Show("Save ok!");
            this.verFamilia();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (this.permission_tree.SelectedNode != null)
            {
                DialogResult selection = MessageBox.Show(
                    Idioma.GetInstance().translate("COMP_CRUD_DELETE_CONFIRM"),
                    Idioma.GetInstance().translate("COMP_CRUD_DELETE_TITLE"),
                    MessageBoxButtons.YesNo);

                if (selection == DialogResult.Yes)
                {
                    //Obtengo el nodo elegido.
                    TreeNode node = this.permission_tree.SelectedNode;

                    //Registro en el buffer.;
                    this.operations.Add(
                        Tuple.Create(
                            "del", 
                            Int32.Parse(node.Parent.Tag.ToString()), 
                            Int32.Parse(node.Tag.ToString()), 
                            node.ImageKey)
                     );

                    //Borro el nodo.
                    this.permission_tree.Nodes.Remove(node);
                }
            }
        }

        //-----------------------------------------------------------------------

        private void Button1_Click_2(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            foreach (Tuple<string, int, int, string> ops in this.operations)
            {
                Debug.WriteLine("----->" + ops.Item1 + "," + ops.Item2 + "," + ops.Item3 + "," + ops.Item4);
            }
        }

        private void Button1_Click_3(object sender, EventArgs e)
        {
            this.refreshData();
        }
    }
}