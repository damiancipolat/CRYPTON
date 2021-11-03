using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using BE;
using BE.Permisos;
using DAL;
using DAL.Permiso;
using IO;
using BL;

namespace BL
{
    public class UsuarioBloqBL
    {
        public UsuarioBloqBL()
        {
            //..
        }

        //Buscar por id.
        public UsuarioBloqBE findById(int id)
        {
            return new UsuarioBloqDAL().findById(id);
        }

        //Envio el email.
        private void sendMail(UsuarioBloqBE userBloq) 
        {
            //Get administrator account.
            string emailHost = ConfigurationManager.AppSettings["EmailHost"];

            //Get system delivery.
            string delivery = "Crypton System <" + "crypton.system@" + emailHost + ">";

            //Envio el email.
            new Mailer().send(delivery, userBloq.usuario.email, "Tu usuario fue bloqueado", userBloq.motivo);
        }

        //Registra un nuevo usuario bloqueado.
        public int save(UsuarioBloqBE userBloq)
        {
            //Envio el email.
            this.sendMail(userBloq);

            //Registro.
            return new UsuarioBloqDAL().save(userBloq);
        }

        //Actualiza un nuevo usuario bloqueado.
        public int update(UsuarioBloqBE userBloq)
        {
            return new UsuarioBloqDAL().update(userBloq);
        }
    }
}