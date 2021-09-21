using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BL;
using SL;
using SEC;
using UI.Permisos;
using UI.Admin;

namespace UI
{
    public partial class UsersControl : Form
    {
        public UsersControl()
        {
            InitializeComponent();
        }

        private void translateTexts()
        {
            this.Text = Idioma.GetInstance().translate("USR_SEARCHER");
            this.usr_perm_btn.Text = Idioma.GetInstance().translate("USR_PERM_BTN");
            this.usr_search.Text = Idioma.GetInstance().translate("USR_SEARCH");
            this.usr_search_descrip.Text = Idioma.GetInstance().translate("USR_SEARCH_DESCRIP");
            this.usr_search_label.Text = Idioma.GetInstance().translate("USR_SEARCH_LABEL");
            this.usr_search_btn.Text = Idioma.GetInstance().translate("USR_SEARCH_BTN");
            this.usr_search_close.Text = Idioma.GetInstance().translate("USR_SEARCH_CLOSE");
            this.usr_ctrl_changes.Text = Idioma.GetInstance().translate("USR_CONTROL_BTN_CHANGE");            
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsersControl_Load(object sender, EventArgs e)
        {
            this.usr_perm_btn.Enabled = false;
            this.usr_ctrl_changes.Enabled = false;

            //Translate text.
            this.translateTexts();
            this.usr_data.ReadOnly = true;

            //Load columns.
            this.usr_data.Columns.Clear();
            this.usr_data.Columns.Add(Idioma.GetInstance().translate("USR_COL_ID"), Idioma.GetInstance().translate("USR_COL_ID"));
            this.usr_data.Columns.Add(Idioma.GetInstance().translate("USR_COL_NAME"), Idioma.GetInstance().translate("USR_COL_NAME"));
            this.usr_data.Columns.Add(Idioma.GetInstance().translate("USR_COL_SURNAME"), Idioma.GetInstance().translate("USR_COL_SURNAME"));
            this.usr_data.Columns.Add(Idioma.GetInstance().translate("USR_COL_EMAIL"), Idioma.GetInstance().translate("USR_COL_EMAIL"));
            this.usr_data.Columns.Add(Idioma.GetInstance().translate("USR_COL_TYPE"), Idioma.GetInstance().translate("USR_COL_TYPE"));
        }

        private void fillData(List<UsuarioBE> users)
        {
            this.usr_data.Rows.Clear();

            //Loop to fill data.
            foreach (UsuarioBE user in users)
            {
                this.usr_data.Rows.Add(
                    new string[] {
                        user.idusuario.ToString(),
                        user.nombre,
                        user.apellido,
                        Cripto.GetInstance().Decrypt(user.email),
                        user.tipoUsuario==UsuarioTipo.CLIENTE?"Cliente":"Empleado"
                });
            }
            
        }

        private void Usr_search_btn_Click(object sender, EventArgs e)
        {
            if (this.usr_search_txt.Text != "")
            {
                Bitacora.GetInstance().log("USER", "User:" +Session.GetInstance().getUser().email+" buscando:"+ this.usr_search_txt.Text);

                //Buscar.
                List<UsuarioBE> users = new UsuarioBL().searchByText(this.usr_search_txt.Text);
                this.usr_data.Rows.Clear();

                if (users.Count > 0)
                {
                    usr_perm_btn.Enabled = true;
                    usr_ctrl_changes.Enabled = false;

                    //Fill the grid with data.
                    this.fillData(users);
                }
                else
                {
                    usr_perm_btn.Enabled = false;
                    usr_ctrl_changes.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Debe escribir un valor");
            }
        }

        private void Usr_perm_btn_Click(object sender, EventArgs e)
        {
            if (this.usr_data.SelectedCells.Count > 0)
            {
                int selectedrowindex = this.usr_data.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.usr_data.Rows[selectedrowindex];
                string idValue = Convert.ToString(selectedRow.Cells["id"].Value);

                UsuarioBE user = new UsuarioBL().findById(Int32.Parse(idValue));

                if (user != null)
                    new UserTreeFrm(user).Show();
            }
            else
            {
                MessageBox.Show("Seleccione una celda para acceder a permisos");
            }
        }

        private void Usr_ctrl_changes_Click(object sender, EventArgs e)
        {
            int selectedrowindex = this.usr_data.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = this.usr_data.Rows[selectedrowindex];

            //Busco el usuario en base al id.
            string selectedId = selectedRow.Cells[0].Value.ToString();
            UsuarioBE user = new UsuarioBL().findById(Convert.ToInt32(selectedId));

            //Traigo el cliente en base al usuario.
            ClienteBE cli = new ClienteBL().findByUser(user);

            //Muestro la UI.
            new frm_cambios(cli.idcliente).Show();            
        }

        private void Usr_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Usr_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.usr_data.SelectedCells.Count > 0)
            {
                int selectedrowindex = this.usr_data.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.usr_data.Rows[selectedrowindex];

                //Oculto/muetro el boton.
                usr_ctrl_changes.Enabled = selectedRow.Cells[4].Value == "Cliente";
            }
            else
            {
                usr_ctrl_changes.Enabled = false;
            }
        }
    }
}

