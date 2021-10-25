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
using BE.Admin;
using BL.Admin;
using SL;

namespace UI.Admin
{
    public partial class frm_backup : Form
    {

        public frm_backup()
        {
            InitializeComponent();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
        }

        private void translateTexts()
        {
            this.Text= Idioma.GetInstance().translate("TXT_BACKUP_TITLE");
            this.txt_backup_title.Text = Idioma.GetInstance().translate("TXT_BACKUP_TITLE");
            this.txt_backup_descrip.Text = Idioma.GetInstance().translate("TXT_BACKUP_DESCRIP");
            this.btn_close_backup.Text= Idioma.GetInstance().translate("BTN_CLOSE_BACKUP");
            this.btn_new_backup.Text = Idioma.GetInstance().translate("BTN_NEW_BACKUP");
            this.btn_load_backup.Text = Idioma.GetInstance().translate("BTN_LOAD_BACKUP");
            this.txt_backup_title_list.Text = Idioma.GetInstance().translate("TXT_BACKUP_TITLE_LIST");
        }

        private void Usr_change_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Txt_backup_title_Click(object sender, EventArgs e)
        {

        }

        private void fillData()
        {
            //Limpio la lista.
            this.usr_data.Rows.Clear();

            //Cargo datos.
            List<BackupBE> list = new BackupBL().findAll();
            list.Reverse(0, list.Count);

            //Loop to fill data.
            foreach (BackupBE backup in list)
            {
                this.usr_data.Rows.Add(
                    new string[] {
                        backup.idbackup.ToString(),
                        backup.path,
                        backup.fecRec.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                        backup.size.ToString()
                });
            }
        }

        private void Frm_backup_Load(object sender, EventArgs e)
        {
            this.translateTexts();

            //Load columns.
            this.usr_data.Columns.Clear();
            this.usr_data.ReadOnly = true;

            //Create columns.
            this.usr_data.Columns.Add(Idioma.GetInstance().translate("ID"), Idioma.GetInstance().translate("ID"));
            this.usr_data.Columns.Add(Idioma.GetInstance().translate("BACKUP_COL_PATH"), Idioma.GetInstance().translate("BACKUP_COL_PATH"));
            this.usr_data.Columns.Add(Idioma.GetInstance().translate("BACKUP_COL_FEC"), Idioma.GetInstance().translate("BACKUP_COL_FEC"));
            this.usr_data.Columns.Add(Idioma.GetInstance().translate("BACKUP_COL_SIZE"), Idioma.GetInstance().translate("BACKUP_COL_SIZE"));            

            //Load data.
            this.fillData();
        }

        private void Btn_new_backup_Click(object sender, EventArgs e)
        {
            //Msg de confirmacion.
            DialogResult dr = MessageBox.Show(
                Idioma.GetInstance().translate("BACKUP_MSG_DESCRIP"),
                Idioma.GetInstance().translate("BACKUP_MSG_TITLE"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                DialogResult result = this.folderBrowserDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    //Cargo el dto.
                    BackupBE backup = new BackupBE();
                    backup.type = "BACKUP";
                    backup.usuario = Session.GetInstance().getUser();
                    backup.fecRec = DateTime.Now;
                    backup.path= this.folderBrowserDialog1.SelectedPath;

                    //Hago el backup.
                    new BackupBL().makeBackup(backup);

                    //Recargo.
                    this.fillData();
                    MessageBox.Show("Backup ok!");
                }
            }
        }

        private void Btn_load_backup_Click(object sender, EventArgs e)
        {
            try
            {
                //Si esta seleccionado.
                if (this.usr_data.SelectedCells.Count > 0)
                {
                    //Obtengo la columna.
                    int selectedrowindex = this.usr_data.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = this.usr_data.Rows[selectedrowindex];

                    //Busco el usuario en base al id.
                    string selectedId = selectedRow.Cells[0].Value.ToString();

                    //Msg de confirmacion.
                    DialogResult dr = MessageBox.Show(
                        Idioma.GetInstance().translate("BACKUP_MSG_RESTORE_DESCRIP"),
                        Idioma.GetInstance().translate("BACKUP_MSG_TITLE"),
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (dr == DialogResult.Yes)
                    {
                        //Busco el backup.
                        BackupBE data = new BackupBL().findById(Convert.ToInt32(selectedId));

                        //Recupero.
                        new BackupBL().restoreBackup(data);
                        MessageBox.Show("Restore ok!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    Idioma.GetInstance().translate(ex.Message),
                    Idioma.GetInstance().translate("BACKUP_ERROR"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
