using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE.Permisos;
using BE;
using DAL.DAO;
using DAL.Permiso;

namespace DAL.Permiso
{
    public class PermisoUserDAL : DAL.PermisoDAL
    {
        //Obtiene recursivamente la lista de componentes filtrando por usuario.
        public List<Componente> FindAll(string familia, long userid)
        {
            //Obtengo el sql para buscar todos recursivamente.
            string sql = this.sqlGen.getAllByUser(familia, userid);
            Debug.WriteLine("QUERY:" + sql);

            return this.Find(sql);
        }

        //Traigo la lista de permisos para un usuario, setea el rol.
        public List<Componente> FindAllClient(UsuarioBE user)
        {
            string family = (user.tipoUsuario == UsuarioTipo.CLIENTE) ? "R002" : "R003";

            //Traigo la lista de permisos del rol cliente.
            return this.FindAll(family,user.idusuario);
        }

    }
}
