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
    public class BancoBL
    {
        public BancoBL()
        {
            //..
        }

        //Traigo todos los datos.
        public List<BancoBE> findAll()
        {
            return new BancoDAL().findAll();
        }

        //Buscar por id.
        public BancoBE findById(int id)
        {
            return new BancoDAL().findById(id);
        }

        //Registra un nuevo usuario bloqueado.
        public int save(BancoBE bank)
        {
            return new BancoDAL().save(bank);
        }

        //Actualiza un nuevo usuario bloqueado.
        public int update(BancoBE bank)
        {
            return new BancoDAL().update(bank);
        }
    }
}