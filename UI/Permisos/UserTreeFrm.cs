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

namespace UI.Permisos
{
    public partial class UserTreeFrm : Form
    {
        private UsuarioBE selected;
        private List<Familia2> innerFamilia = new List<Familia2>();
        private List<Patente2> innerPatente = new List<Patente2>();
        private List<UsuarioBE> innerUsers = new List<UsuarioBE>();

        public UserTreeFrm()
        {
            InitializeComponent();
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
                this.user_tree_family_list.SelectedIndex = 0;
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

        void LlenarTreeView(TreeNode padre, Componente2 c)
        {
            TreeNode hijo = new TreeNode(c.Nombre);
            hijo.Tag = c;
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

        //Eventos UI ------------------------------------------------------------------

        private void User_tree_crud_delete_Click(object sender, EventArgs e)
        {

        }

        private void User_tree_crud_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tree_family_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.loadUserData();
        }

        private void User_tree_crud_add_family_Click(object sender, EventArgs e)
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

            if (value < 0)
                return;

            //Obtengo la familia seleccionada.
            Familia2 familia = this.innerFamilia[value];

            if (familia != null)
            {
                MessageBox.Show("@@" + familia.Nombre);
            }
        }

        //Revisa si el permiso existe.
        private bool existPatente(List<Componente2> permisos, Patente2 patente)
        {
            foreach (Componente2 item in permisos)
            {
                if (new PermisoBL2().Existe(item, patente.Id))
                    return true;
            }

            return false;
        }

        private void User_tree_crud_add_patent_Click(object sender, EventArgs e)
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

            //Obtengo la familia seleccionada.
            Patente2 patente = this.innerPatente[value];

            if (patente != null)
            {
                //Traigo el usuario elegido.
                UsuarioBE user = this.selected;

                //Revisa si la patente existe.
                if (this.existPatente(user.Permisos,patente))
                    MessageBox.Show("El usuario ya tiene la patente indicada");
                else
                {
                    user.Permisos.Add(patente);
                    MostrarPermisos(user);
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            UsuarioBE seleccion = this.innerUsers[0];

            UsuarioBE tmp = new UsuarioBE();
            tmp.idusuario = seleccion.idusuario;
            tmp.nombre = seleccion.nombre;

            Debug.WriteLine("--aaaaaaaaaaaaaa-->" + tmp.nombre);
            UserPermisoBL repo = new UserPermisoBL();
            repo.FillUserComponents(tmp);

            Debug.WriteLine(">>>" + tmp.Permisos.Count.ToString());
            MostrarPermisos(tmp);
        }

        private void User_tree_crud_save_Click(object sender, EventArgs e)
        {
            try
            {
                // repo.GuardarPermisos(tmp);
                MessageBox.Show("Usuario guardado correctamente");
            }
            catch (Exception)
            {

                MessageBox.Show("Error al guardar el usuario");

            }
        }
    }
}
