using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SL;
using BE;
using DAL;
using BL;

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
        public List<NotificacionBE> findByClient(ClienteBE client)
        {
            return new NotificacionDAL().pendingToRead(client);
        }
    }
}
