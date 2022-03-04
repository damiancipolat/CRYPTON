using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.DAO;
using DAL;

namespace DAL
{
    public class BancoDAL : AbstractDAL<BancoBE>
    {
        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private BancoBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            BancoBE bank = new BancoBE();
            this.binder.match(fieldData, bank);

            return bank;

        }

        //Este metodo retorna una lista de usuarios.
        public List<BancoBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("banco_data");

            //Lista resultado.
            List<BancoBE> lista = new List<BancoBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Este metodo obtiene en base al ID el usuario.
        public BancoBE findById(long id)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("idbanco", "banco_data", id);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);
        }

        //Borra el usuario bloqueado.
        public int delete(int id)
        {
            return this.getDelete().deleteById("idbanco", id, "banco_data");
        }

        //Actualizar el usuario bloqueado.
        public int update(BancoBE bank)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"nombre",bank.nombre},
                {"cbu",bank.cbu},
                {"alias",bank.alias}
            };

            return this.getUpdate().updateSchemaById(schema, "banco_data", "idbanco", bank.idbanco);
        }

        //Agrega un nuevo usuario bloquedo.
        public int save(BancoBE bank)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"nombre",bank.nombre},
                {"cbu",bank.cbu},
                {"alias",bank.alias}
            };

            return this.getInsert().insertSchema(schema, "banco_data", true);
        }
    }
}
