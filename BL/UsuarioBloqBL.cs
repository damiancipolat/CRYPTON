using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE;
using BE.Permisos;
using DAL;
using DAL.Permiso;
using SL;
using SEC;

namespace BL
{
    public class UsuarioBloqBL
    {
        public UsuarioBloqBL()
        {
            //..
        }

        //Traigo todos los datos.
        public List<UsuarioBloqBE> findAll()
        {
            return new UsuarioBloqDAL().findAll();
        }

        //Buscar por id.
        public UsuarioBloqBE findById(int id)
        {
            return new UsuarioBloqDAL().findById(id);
        }

        //Registra un nuevo usuario bloqueado.
        public int save(UsuarioBloqBE userBloq)
        {
            return new UsuarioBloqDAL().save(userBloq);
        }

        //Actualiza un nuevo usuario bloqueado.
        public int update(UsuarioBloqBE userBloq)
        {
            return new UsuarioBloqDAL().update(userBloq);
        }
    }
}