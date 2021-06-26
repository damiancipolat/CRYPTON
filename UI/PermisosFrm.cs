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

namespace UI
{
    public partial class PermisosFrm : Form
    {
        private UsuarioBE user;

        public PermisosFrm(UsuarioBE user)
        {
            InitializeComponent();
            this.user = user;
        }

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
                    if (nodo.Cod != tmp.Cod && tmp.Hijos == null)
                    {
                        TreeNode hoja = new TreeNode();
                        hoja.Text = tmp.Nombre;
                        hoja.Name = tmp.Cod;

                        Debug.WriteLine(">>" + tmp.Cod + ":" + tmp.Nombre + "/");
                        rama.Nodes.Add(hoja);
                    }

                    //Rama
                    if (tmp.Hijos != null && tmp.Hijos.Count > 0)
                    {
                        TreeNode newRama = new TreeNode();
                        rama.Nodes.Add(newRama);
                        Debug.WriteLine("Segunda carga");
                        fillTree(tmp, newRama);
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

        private void Permisos_Load(object sender, EventArgs e)
        {
            //Dibujo el tree view.
            this.drawPermissionTree();
        }

        private void Permission_tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.permission_tree.SelectedNode != null)
            {
                TreeNode node = this.permission_tree.SelectedNode;
                Debug.WriteLine("-)-)"+node.Text+"__"+node.Name);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (this.permission_tree.SelectedNode != null)
            {
                DialogResult selection = MessageBox.Show("Desea borrar", "Important Question", MessageBoxButtons.YesNo);

                if (selection == DialogResult.Yes)
                {
                    //Remove permission.
                    TreeNode node = this.permission_tree.SelectedNode;
                    new PermisoBL().removeToUser(node.Name, this.user);

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

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
