﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Permiso.nuevo;
using BE.Permisos;

namespace BL.Permisos
{
    public class PatenteBL
    {
        public List<Patente2> getAll()
        {
            return new PatenteDAL().getAll();
        }
    }
}
