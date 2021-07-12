using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SL;
using BE;
using BL;

namespace UI
{
    public partial class NotificationsFrm : Form
    {
        private ClienteBE cliente;
        public NotificationsFrm(ClienteBE cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        private void translateText()
        {
            //Labels.
            this.Text = Idioma.GetInstance().translate("NOTIF_TITLE");
            this.notif_title.Text = Idioma.GetInstance().translate("NOTIF_TITLE");
            this.notif_descrip.Text = Idioma.GetInstance().translate("NOTIF_DESCRIP");
            this.notif_close.Text = Idioma.GetInstance().translate("NOTIF_CLOSE");
        }

        private void fillData(List<NotificacionBE> notifications)
        {
            this.notif_data.Rows.Clear();

            if (notifications.Count > 0)
            {
                //Loop to fill data.
                foreach (NotificacionBE notif in notifications)
                {
                    this.notif_data.Rows.Add(
                        new string[] {
                            notif.fecRegistro.ToString("yyyy-MM-dd HH:mm:ss"),
                            notif.payload
                    });
                }
            }
            else
            {
                this.notif_data.Rows.Add(
                    new string[] {
                        "Sin resultados"
                });
            }
        }

        private void Notifications_Load(object sender, EventArgs e)
        {
            this.translateText();

            //Traigo los datos.
            List<NotificacionBE> list = new NotificacionBL().pendingToRead(this.cliente);

            //Dibujo las columnas.
            //Creo las columnas.
            this.notif_data.ReadOnly = true;

            //Load columns.
            this.notif_data.Columns.Clear();
            this.notif_data.Columns.Add(Idioma.GetInstance().translate("NOTIF_DATE"), Idioma.GetInstance().translate("NOTIF_DATE"));
            this.notif_data.Columns.Add(Idioma.GetInstance().translate("NOTIF_TEXT"), Idioma.GetInstance().translate("NOTIF_TEXT"));
         
            //Dibujo la lista.
            this.fillData(list);
        }

        private void Notif_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
