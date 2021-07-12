using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;
using SL;

namespace BL.Operations
{
    public class NotificateBuySuccess
    {
        //Registro la notificación.
        private int notificateClient(ClienteBE cli,string payload)
        {
            NotificacionBE notif = new NotificacionBE();
            notif.cliente = cli;
            notif.fecRegistro = DateTime.Now;
            notif.marked = 0;
            notif.payload = payload;

            return new NotificacionBL().save(notif);
        }

        //Envio la notificacion al vendedor.
        private int notificateSeller(OrdenVentaBE orden,ClienteBE buyer)
        {
            string message = Idioma.GetInstance().translate("NOTIF_BUY_SUCCESS").Replace("%c",buyer.usuario.alias);
            return this.notificateClient(orden.vendedor, message);
        }

        //Envio la notificacion al comprador.
        private int notificateBuyer(ClienteBE buyer)
        {
            string message = Idioma.GetInstance().translate("NOTIF_BUY_OK_SUCCESS").Replace("%c", buyer.usuario.alias);
            return this.notificateClient(buyer, message);
        }

        public void notificate(OrdenCompraBE orden)
        {
            //Notificar al vendedor.
            this.notificateSeller(orden.ordenVenta, orden.comprador);

            //Notificar al comprador.
            this.notificateBuyer(orden.comprador);
        }
    }
}
