using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.DAO;

namespace DAL
{
    public class DvvDAL : AbstractDAL<UsuarioBE>
    {
        //Bindea el schema de usuario con el data reader.
        private DvhBE bindSchema(List<Object> result)
        {
            //Armo el usuario resultado.
            DvhBE userTarget = new DvhBE();

            //Bindeo campos
            new EntityBinder().match(result, userTarget);

            return userTarget;
        }

        //Buscar por tabla.
        public DvhBE find(string tabla)
        {
            List<Object> result = this.getSelect().selectAnd(
                new Dictionary<string, Object>{
                    {"tabla",tabla}
            }, "dvv");

            return this.bindSchema((List<Object>)result[0]);
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

            return this.getInsert().insertSchema(schema, "dvv");
        }

        //Actualizo el digito.
        public int update(DvhBE digito)
        {
            return this.getUpdate().updateSchemaWhereAnd(
                new Dictionary<string, Object>{
                    {"hash",digito.hash},
                    { "fecUpdate",digito.fecUpdate}
                }, new Dictionary<string, Object>{
                    {"tabla",digito.tabla}
            }, "dvv");

        }

        //Actualizo el hash y fecha.
        public int updateHash(string tabla, string hash)
        {
            return this.getUpdate().updateSchemaWhereAnd(
                new Dictionary<string, Object>{
                    {"hash",hash},
                    { "fecUpdate",DateTime.Now}
                }, new Dictionary<string, Object>{
                    {"tabla",tabla}
            }, "dvv");

        }
    }
}