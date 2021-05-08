﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.DAO;

namespace DAL
{
    public class BitacoraDAL
    {
        //Agrega un nuevo registro en la bitacora.
        public int insert(BitacoraBE bitacora)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"idusuario",bitacora.usuario.idusuario},
                { "type",bitacora.type},
                { "fec_log",bitacora.fecLog},
                { "payload",bitacora.payload}
            };

            QueryInsert builder = new QueryInsert();
            return builder.insertSchema(schema, "bitacora");
        }
    }
}