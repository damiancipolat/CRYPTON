using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using SL;
using BE;
using DAL;
using BL;
using IO;

namespace BL
{
    public class NotificacionBL
    {
        public NotificacionBE findById(int id)
        {
            return new NotificacionDAL().findById(id);
        }

        public int save(NotificacionBE notif)
        {
            return new NotificacionDAL().save(notif);
        }
        public List<NotificacionBE> pendingToRead(ClienteBE client)
        {
            return new NotificacionDAL().pendingToRead(client);
        }

        public void notifyAdmin(string subject,string payload)
        {
            //Get administrator account.
            string adminAccount = ConfigurationManager.AppSettings["AdminAccount"];
            string emailHost = ConfigurationManager.AppSettings["EmailHost"];

            //Get system delivery.
            string delivery = "Crypton System <"+ "crypton.system@" + emailHost + ">";

            //Envio el email.
            new Mailer().send(delivery, adminAccount, subject, payload);
        }
    }
}