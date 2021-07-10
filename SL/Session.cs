using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Permisos;
using DAL;

namespace SL
{
    public class Session
    {
        //Singleton logic.
        private static Session _instance;

        public static Session GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Session();
            }

            return _instance;
        }

        //Session user variables.
        private bool active = false;
        private UsuarioBE user;

        //Session dates.
        private DateTime startDate;
        private DateTime endDate;

        //Permission list.
        private List<Componente> permissions;

        //Get the user.
        public UsuarioBE getUser()
        {
            return this.user;
        }

        //Get the active if is a client.
        public ClienteBE getActiveClient()
        {
            UsuarioBE me = this.getUser();

            if (me.tipoUsuario == UsuarioTipo.CLIENTE)
                return new ClienteDAL().findByUser(me);
            else
                throw new Exception("Is not allow to request a client when is no the current type logged");
        }

        //Start the session bind values.
        public void start(UsuarioBE userParam)
        {
            Bitacora.GetInstance().log("An user has started session - email:" + userParam.email);

            //Deny active an active session.
            if (active)
                throw new Exception("The session is already active");

            //Active session flags.
            active = true;
            user = userParam;

            //Set dates.
            startDate = DateTime.Now;
        }

        //Finish the session.
        public void close()
        {
            Bitacora.GetInstance().log("An user has closed the session");

            //Active session flags.
            active = false;

            //Set dates.
            endDate = DateTime.Now;
        }

        //Set permission list.
        public void setPermission(List<Componente> permissions)
        {
            this.permissions = permissions;
        }

        //Get list of permission.
        public List<Componente> getPermissions()
        {
            return this.permissions;
        }

        //Indica si la sesion esta activa o no.
        public bool isActive()
        {
            return this.active == true;
        }
    }
}