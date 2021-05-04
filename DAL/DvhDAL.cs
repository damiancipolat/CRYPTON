﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.DAO;

namespace DAL
{
    public class DvhDAL
    {
        //Bindea el schema de usuario con el data reader.
        private DvhBE bindSchema(List<Object> result)
        {
            if (!(result.Count > 0))
                return null;

            //Armo el usuario resultado.
            DvhBE userTarget = new DvhBE();

            //Bindeo campos
            EntityBinder.bindOne(result, userTarget);

            return userTarget;
        }

        //Buscar por tabla.
        public DvhBE find(string tabla)
        {
            List<Object> result = new QuerySelect().selectAnd(
                new Dictionary<string, Object>{
                    {"tabla",tabla}
            }, "dvh");

            return this.bindSchema(result);
        }

        //Agrega un nuevo registro en el dvh.
        public int insert(DvhBE digito)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"tabla",digito.tabla},
                { "hash",digito.hash},
                { "fecUpdate",digito.fecUpdate}
            };

            QueryInsert builder = new QueryInsert();
            return builder.insertSchema(schema, "dvh");
        }

        //Actualizo el digito.
        public int update(DvhBE digito)
        {
            QueryUpdate upd = new QueryUpdate();

            return upd.updateSchemaWhereAnd(
                new Dictionary<string, Object>{
                    {"hash",digito.hash},
                    { "fecUpdate",digito.fecUpdate}
                }, new Dictionary<string, Object>{
                    {"tabla",digito.tabla}
            }, "dvh");

        }

        //Actualizo el hash y fecha.
        public int updateHash(string tabla, string hash)
        {
            QueryUpdate upd = new QueryUpdate();

            return upd.updateSchemaWhereAnd(
                new Dictionary<string, Object>{
                    {"hash",hash},
                    { "fecUpdate",DateTime.Now}
                }, new Dictionary<string, Object>{
                    {"tabla",tabla}
            }, "dvh");

        }
    }
}