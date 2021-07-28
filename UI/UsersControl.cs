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
using BL;
using SL;
using SEC;

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
            this.Text = Idioma.GetInstance().translate("USR_PERM_BTN");
            this.usr_perm_btn.Text = Idioma.GetInstance().translate("USR_PERM_BTN");
            this.usr_search.Text = Idioma.GetInstance().translate("USR_SEARCH");
            this.usr_search_descrip.Text = Idioma.GetInstance().translate("USR_SEARCH_DESCRIP");
            this.usr_search_label.Text = Idioma.GetInstance().translate("USR_SEARCH_LABEL");
            this.usr_search_btn.Text = Idioma.GetInstance().translate("USR_SEARCH_BTN");
            this.usr_search_close.Text = Idioma.GetInstance().translate("USR_SEARCH_CLOSE");
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsersControl_Load(object sender, EventArgs e)
        {
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
                List<UsuarioBE> users = new UsuarioBL().searchByText(this.usr_search_txt.Text);
                this.fillData(users);
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

                //UsuarioBE user = new UsuarioBL().findById(Int32.Parse(idValue));
                //new PermisosFrm(user).Show();

            }
            else
            {
                MessageBox.Show("Seleccione una celda para acceder a permisos");
            }
        }
    }
}

