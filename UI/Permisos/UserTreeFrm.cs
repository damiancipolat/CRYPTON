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
using BL.Permisos;
using BL;
using SL;
using UI.Permisos;

namespace UI.Permisos
{
    public partial class UserTreeFrm : Form
    {
        private UsuarioBE selected;

        //Listas.
        private List<Familia> innerFamilia = new List<Familia>();
        private List<Patente> innerPatente = new List<Patente>();
        private List<UsuarioBE> innerUsers = new List<UsuarioBE>();
        private UsuarioBE innerSelected=null;

        //Operaciones
        private List<Tuple<string, int, int>> operations = new List<Tuple<string, int, int>>();

        public UserTreeFrm(UsuarioBE userDefault=null)
        {
            InitializeComponent();

            if (userDefault != null)
                this.innerSelected = userDefault;
        }

        //Carga de datos -----------------------------------------------------------------

        public void translateText()
        {
            this.Text = Idioma.GetInstance().translate("TREE_TITLE_EDITOR");
            this.user_tree_title_editor.Text = Idioma.GetInstance().translate("TREE_TITLE_EDITOR");
            this.user_tree_descrip_editor.Text = Idioma.GetInstance().translate("TREE_DESCRIP_EDITOR");
            this.user_tree_crud_add_family.Text = Idioma.GetInstance().translate("TREE_CRUD_ADD_FAMILY");
            this.user_tree_crud_add_patent.Text = Idioma.GetInstance().translate("TREE_CRUD_ADD_PATENT");
            this.user_tree_crud_save.Text = Idioma.GetInstance().translate("TREE_CRUD_SAVE");
            this.user_tree_crud_close.Text = Idioma.GetInstance().translate("TREE_CRUD_CLOSE");
            this.user_tree_crud_delete.Text = Idioma.GetInstance().translate("TREE_CRUD_DELETE");
        }

        private void loadData()
        {
            //Borro las listas.
            this.innerFamilia.Clear();
            this.innerPatente.Clear();
            this.innerUsers.Clear();

            //Cargo data.
            this.innerUsers = new UsuarioBL().getAll();
            this.innerFamilia = new FamiliaBL().getAll();
            this.innerPatente = new PatenteBL().getAll();

            foreach (UsuarioBE user in this.innerUsers)
                this.user_tree_family_list.Items.Add(user.nombre + "," + user.apellido);

            if (this.innerUsers.Count > 0)
            {
                //Si hay un usuario seteado por defecto.
                if (this.innerSelected != null)
                {
                    //Encuentro su ubicacion dentro del combo para marcarlo.
                    for (int i = 0; i <=this.innerUsers.Count-1; i++)
                    {
                        UsuarioBE user = this.innerUsers[i];
                        if (user.idusuario == this.innerSelected.idusuario)
                        {
                            Debug.WriteLine("user selected"+i.ToString());
                            this.user_tree_family_list.SelectedIndex = i;
                        }                            
                    }
                }
                else
                {
                    this.user_tree_family_list.SelectedIndex = 0;
                }
            }                
        }

        private void loadUserData()
        {
            //Selecciono el usuario.
            UsuarioBE seleccion = this.innerUsers[this.user_tree_family_list.SelectedIndex];

            //Creo el usuario.
            UsuarioBE tmpUser = new UsuarioBE();
            tmpUser.idusuario = seleccion.idusuario;
            tmpUser.nombre = seleccion.nombre;

            //Cargo los permisos.
            UserPermisoBL repo = new UserPermisoBL();
            repo.FillUserComponents(tmpUser);

            //Seteo el user elegido.
            this.selected = tmpUser;

            //Renderizo.
            MostrarPermisos(tmpUser);
        }

        private void UserTreeFrm_Load(object sender, EventArgs e)
        {
            this.translateText();
            this.loadData();
            this.loadUserData();
        }

        //Traigo el usuario que esta seleccionado.
        public UsuarioBE getSelected()
        {
            return this.innerUsers[this.user_tree_family_list.SelectedIndex];
        }

        //Render arbol ----------------------------------------------------------------

        public void LlenarTreeView(TreeNode padre, Componente c)
        {
            TreeNode hijo = new TreeNode(c.Nombre);
            hijo.Tag = c.Id;
            padre.Nodes.Add(hijo);

            foreach (var item in c.Hijos)
            {
                this.LlenarTreeView(hijo, item);
            }

        }

        public void MostrarPermisos(UsuarioBE u)
        {
            this.user_permission_tree.Nodes.Clear();
            TreeNode root = new TreeNode(u.nombre);

            foreach (var item in u.Permisos)
            {
                this.LlenarTreeView(root, item);
            }

            this.user_permission_tree.Nodes.Add(root);
            this.user_permission_tree.ExpandAll();
        }

        //Purgo el arbol.
        private void purgeFromOps()
        {
            foreach (Tuple<string, int, int> ops in this.operations)
            {
                if (ops.Item1 == "del")
                {
                    //Busco el nodo.
                    TreeNode node = new NodeSearch().GetNode(this.user_permission_tree.Nodes,ops.Item3.ToString());

                    //Si existe, lo borro en el control.
                    if (node != null)
                    {
                        node.BackColor = Color.Yellow;
                        Debug.WriteLine("Encontre:" + node.Name + "," + node.ImageKey);
                        this.user_permission_tree.Nodes.Remove(node);
                    }
                }
            }
        }

        //Eventos UI ------------------------------------------------------------------

        private void User_tree_crud_delete_Click(object sender, EventArgs e)
        {
            if (this.user_permission_tree.SelectedNode != null)
            {
                DialogResult selection = MessageBox.Show(
                    Idioma.GetInstance().translate("COMP_CRUD_DELETE_CONFIRM"),
                    Idioma.GetInstance().translate("COMP_CRUD_DELETE_TITLE"),
                    MessageBoxButtons.YesNo);

                if (selection == DialogResult.Yes)
                {
                    //Obtengo el nodo elegido.
                    TreeNode node = this.user_permission_tree.SelectedNode;

                    //Registro en el buffer.;
                    this.operations.Add(
                        Tuple.Create(
                            "del",
                            Int32.Parse(this.selected.idusuario.ToString()),
                            Int32.Parse(node.Tag.ToString()))
                     );

                    //Borro el nodo.
                    this.user_permission_tree.Nodes.Remove(node);
                }
            }
        }

        private void User_tree_crud_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tree_family_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.operations.Clear();
            this.loadUserData();
        }

        private void User_tree_crud_add_family_Click(object sender, EventArgs e)
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

            if (value < 0)
                return;

            //Obtengo la familia seleccionada.
            Familia familia = this.innerFamilia[value];

            if (familia != null)
            {
                UsuarioBE user = this.selected;

                //Revisa si la patente existe.
                if (this.existComponente(user.Permisos, familia))
                    MessageBox.Show("El usuario ya tiene la familia indicada");
                else
                {
                    //Agrego dentro del user.
                    user.Permisos.Add(familia);

                    //Guardo la operacion.
                    this.operations.Add(
                        Tuple.Create(
                            "add",
                            Int32.Parse(this.selected.idusuario.ToString()),
                            Int32.Parse(familia.Id.ToString()))
                     );

                    //Actualizo ui.
                    MostrarPermisos(user);
                }
            }
        }

        //Revisa si el permiso existe.
        private bool existComponente(List<Componente> permisos, Componente comp)
        {
            foreach (Componente item in permisos)
            {
                if (new PermisoBL().Existe(item, comp.Id))
                    return true;
            }

            return false;
        }

        private void User_tree_crud_add_patent_Click(object sender, EventArgs e)
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

            //Obtengo la familia seleccionada.
            Patente patente = this.innerPatente[value];

            if (patente != null)
            {
                //Traigo el usuario elegido.
                UsuarioBE user = this.selected;

                //Revisa si la patente existe.
                if (this.existComponente(user.Permisos,patente))
                    MessageBox.Show("El usuario ya tiene la patente indicada");
                else
                {
                    //Agrego dentro de usuarios.
                    user.Permisos.Add(patente);

                    //Guardo la operacion.
                    this.operations.Add(
                        Tuple.Create(
                            "add",
                            Int32.Parse(this.selected.idusuario.ToString()),
                            Int32.Parse(patente.Id.ToString()))
                     );

                    //Actualizo UI.
                    MostrarPermisos(user);
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void User_tree_crud_save_Click(object sender, EventArgs e)
        {
            //Proceso la operacion.
            new UserPermisoBL().GuardarPermisos(this.operations);

            //Fin y exito.
            MessageBox.Show("Save ok!");

            //Recargo
            this.operations.Clear();
            this.loadUserData();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            foreach (Tuple<string, int, int> ops in this.operations)
                Debug.WriteLine(">>>"+ops.Item1+","+ops.Item2+","+ops.Item3);
        }
    }
}
