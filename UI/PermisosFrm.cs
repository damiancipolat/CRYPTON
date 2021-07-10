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
using DAL;
using DAL.Permiso;
using BL;
using SL;

namespace UI
{
    public partial class PermisosFrm : Form
    {
        private UsuarioBE user;
        private List<Componente> permisos;

        public PermisosFrm(UsuarioBE user)
        {
            InitializeComponent();
            this.user = user;
            this.permisos = new List<Componente>();
        }

        //ARBOL DE PERMISOS ------------------------------------------------

        //Carga el arbol en Treenodes.
        private void fillTree(Componente nodo, TreeNode rama)
        {
            Debug.WriteLine("+ ____>" + nodo.Cod + "," + nodo.Nombre + "," + nodo.Hijos.Count().ToString());
            rama.Text = nodo.Nombre;
            rama.Name = nodo.Cod;
            rama.Tag = nodo.esPatente ? "P" : "F";

            if (nodo.Hijos != null)
            {
                foreach (Componente item in nodo.Hijos)
                {
                    if (item.Hijos != null)
                    {
                        TreeNode newRama = new TreeNode();
                        newRama.Tag = "F";
                        newRama.Name = item.Nombre;
                        rama.Nodes.Add(newRama);

                        //Call recursive.
                        this.fillTree(item, newRama);
                    }
                    else
                    {
                        TreeNode hoja = new TreeNode();
                        hoja.Text = item.Nombre;
                        hoja.Name = item.Cod;
                        hoja.Tag ="P";
                        rama.Nodes.Add(hoja);
                        Debug.WriteLine("hoja ____>" + item.Cod + "," + item.Nombre + ", hoja *");
                    }
                }
            }
        }

        //Redibuja los nodos en el tree view.
        private void drawPermissionTree()
        {
            //Cargo los permisos.
            List<Componente> tree = new PermisoBL().findAll(this.user);

            if (tree.Count > 0)
            {
                TreeNode rootNode = new TreeNode();
                this.fillTree(tree[0], rootNode);
                this.permission_tree.Nodes.Clear();
                this.permission_tree.Nodes.Add(rootNode);
            }
        }

        //LISTA DE PERMISOS -----------------------------------------------

        //Dibujo la lista de permisos.
        private void drawPermissionList()
        {
            List<Componente> compList = new PermisoBL().getRaw();

            foreach (Componente nodo in compList)
            {
                if (nodo.esPatente)
                    this.list_perm.Items.Add("Atom >>" + nodo.Cod + " - " + nodo.Nombre);
                else
                    this.list_perm.Items.Add("Comp >>" + nodo.Cod + " - " + nodo.Nombre);                

                this.permisos.Add(nodo);
            }
        }

        //EVENTOS DE UI ----------------------------------------------------

        //Traducir textos.
        private void translateTexts()
        {
            this.permission_title.Text = Idioma.GetInstance().translate("PERMISSION_TITLE");
            this.permission_label.Text = Idioma.GetInstance().translate("PERMISSION_LABEL");
            this.permission_abm.Text = Idioma.GetInstance().translate("PERMISSION_ABM");
            this.btn_del_permission.Text = Idioma.GetInstance().translate("BTN_DEL_PERMISSION");
            this.btn_close_permission.Text = Idioma.GetInstance().translate("BTN_CLOSE_PERMISSION");
            this.btn_update_permission.Text = Idioma.GetInstance().translate("BTN_UPDATE_PERMISSION");
            this.btn_compound_permission.Text = Idioma.GetInstance().translate("BTN_COMPOUND_PERMISSION");
            this.Text = Idioma.GetInstance().translate("PERMISSION_TITLE");
        }

        //Al cargar la ventana.
        private void Permisos_Load(object sender, EventArgs e)
        {
            //Translate ui.
            this.translateTexts();

            //Dibujo el tree view.
            this.drawPermissionTree();
            this.drawPermissionList();

            //Load name.
            this.usr_custom.Text = this.user.nombre + "," + this.user.apellido;
        }

        //Al seleccionar en el treeview.
        private void Permission_tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.permission_tree.SelectedNode != null)
            {
                TreeNode node = this.permission_tree.SelectedNode;
                Debug.WriteLine("-)-)"+node.Text+"__"+node.Name+" tag:"+node.Tag);
            }
        }

        //Click en boton borrar
        private void Button1_Click(object sender, EventArgs e)
        {
            if (this.permission_tree.SelectedNode != null)
            {
                DialogResult selection = MessageBox.Show("Desea borrar", "Important Question", MessageBoxButtons.YesNo);

                if (selection == DialogResult.Yes)
                {
                    //Remove permission.
                    TreeNode node = this.permission_tree.SelectedNode;
                    new PermisoBL().removeToUser(node.Tag.ToString(),node.Name, this.user.idusuario);

                    //Draw the tree.
                    this.drawPermissionTree();
                    MessageBox.Show("Permiso borrado!");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un permiso primero");
            }
        }

        //Click en cancelar
        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Click en boton agregar.
        private void Button2_Click(object sender, EventArgs e)
        {            
            if (this.permission_tree.SelectedNode != null&& this.list_perm.SelectedItem != null)
            {
                DialogResult selection = MessageBox.Show("Desea agregar", "Important Question", MessageBoxButtons.YesNo);

               if (selection == DialogResult.Yes)
               {
                    //Extraigo valores.
                    TreeNode node = this.permission_tree.SelectedNode;
                    string codRol = node.Name;

                    //Obtengo el permiso elegido.
                    Componente selected = this.permisos[this.list_perm.SelectedIndex];
                    Debug.WriteLine("@@@ A"+selected.esPatente.ToString()+" B"+node.Tag);
                    
                    //Valido el que no se puede agregar un compuesto, en una hoja.
                    if (node.Tag == "P")
                    {
                        MessageBox.Show("No se puede dentro de una patente");
                        return;
                    }

                    //Bindeo el permiso.
                    string codPermiso = selected.Cod;
                    new PermisoBL().bindSpecificToUser(codRol, codPermiso, this.user.idusuario);

                    //Redibujo el arbol de permisos.
                    this.drawPermissionTree();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un permiso en el arbol y en la lista de permisos.");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            InputForm input = new InputForm("Nuevo permiso compuesto", "escriba aqui");            
            input.ShowDialog();

            string value = input.getValue();

            if (value != null)
            {
                new PermisoBL().createCompound(value);
                MessageBox.Show("Nuevo compuesto!");
                this.list_perm.Items.Clear();
                this.drawPermissionList();
            }
            
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.list_perm.Items.Clear();
            this.drawPermissionList();
        }
    }
}
