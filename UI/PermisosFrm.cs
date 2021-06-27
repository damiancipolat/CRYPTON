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
        private List<String> permisos;

        public PermisosFrm(UsuarioBE user)
        {
            InitializeComponent();
            this.user = user;
            this.permisos = new List<String>();
        }

        //ARBOL DE PERMISOS ------------------------------------------------

        //Carga el arbol en Treenodes.
        private void fillTree(Componente nodo, TreeNode rama)
        {
            rama.Text = nodo.Nombre;
            rama.Name = nodo.Cod;

            Debug.WriteLine("->" + nodo.Cod + ":" + nodo.Nombre);

            if (nodo != null && nodo.Hijos.Count > 0)
            {
                foreach (Componente tmp in nodo.Hijos)
                {
                    //Hoja
                    if (tmp.Hijos != null)
                    {
                        TreeNode newRama = new TreeNode();
                        newRama.Tag = nodo.Cod;
                        rama.Nodes.Add(newRama);
                        Debug.WriteLine("Segunda carga em " + nodo.Cod);
                        fillTree(tmp, newRama);
                    }
                    else
                    {
                        TreeNode hoja = new TreeNode();
                        hoja.Text = tmp.Nombre;
                        hoja.Name = tmp.Cod;
                        hoja.Tag = nodo.Cod;//Uso el tag para guardar la ref al padre.

                        Debug.WriteLine(">>" + tmp.Cod + ":" + tmp.Nombre + "/");
                        rama.Nodes.Add(hoja);
                    }
                }
            }
        }

        //Redibuja los nodos en el tree view.
        private void drawPermissionTree()
        {
            //Cargo los permisos.
            List<Componente> tree = new PermisoUserDAL().FindAll("", this.user.idusuario);

            if (tree.Count > 0)
            {
                TreeNode rootNode = new TreeNode();
                this.fillTree(tree[0], rootNode);
                this.permission_tree.Nodes.Clear();
                this.permission_tree.Nodes.Add(rootNode);
            }
        }

        //LISTA DE PERMISOS -----------------------------------------------

        //Cargo la lista de permisos.
        private void fillList()
        {
            List<Componente> compList = new PermisoBL().getRaw();

            foreach (Componente nodo in compList)
            {
               // if (nodo.esPatente)
               // {
                    this.list_perm.Items.Add(nodo.Cod + " - " + nodo.Nombre);
                    this.permisos.Add(nodo.Cod);
               // }
            }
        }

        //Dibujo la lista de permisos.
        private void drawPermissionList()
        {
          this.fillList();              
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
                Debug.WriteLine("-)-)"+node.Text+"__"+node.Name);
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
                    string codPermiso = this.permisos[this.list_perm.SelectedIndex];

                    //Bindeo el permiso.
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
