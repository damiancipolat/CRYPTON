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
using BE.Admin;
using BL;
using SL;

namespace UI.Admin
{
    public partial class frm_backup : Form
    {
        public frm_backup()
        {
            InitializeComponent();
        }

        private void translateTexts()
        {
            this.Text= Idioma.GetInstance().translate("TXT_BACKUP_TITLE");
            this.txt_backup_title.Text = Idioma.GetInstance().translate("TXT_BACKUP_TITLE");
            this.txt_backup_descrip.Text = Idioma.GetInstance().translate("TXT_BACKUP_DESCRIP");
            this.btn_close_backup.Text= Idioma.GetInstance().translate("BTN_CLOSE_BACKUP");
            this.btn_new_backup.Text = Idioma.GetInstance().translate("BTN_NEW_BACKUP");
            this.btn_load_backup.Text = Idioma.GetInstance().translate("BTN_LOAD_BACKUP");
        }

        private void Usr_change_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Txt_backup_title_Click(object sender, EventArgs e)
        {

        }

        private void Frm_backup_Load(object sender, EventArgs e)
        {
            this.translateTexts();
        }
    }
}
