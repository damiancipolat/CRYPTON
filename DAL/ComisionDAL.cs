using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class ComisionesDAL : AbstractDAL<ComisionBE>
    {

        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private ComisionBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            ComisionBE comisionTarget = new ComisionBE();

            //Bindeo campos con la lista de resultados.
            this.binder.match(fieldData, comisionTarget);

            //Seteo el valor.
            Dictionary<string, object> mapa = this.getParser().rowToDictionary(fieldData);
            comisionTarget.operacion = new ComisionValorDAL().findById((long)mapa["operacion"]);

            return comisionTarget;

        }

        //Este metodo obtiene en base al ID el usuario.
        public ComisionBE findById(int id)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("comisiones", "idcobro", id);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Este metodo retorna una lista de usuarios.
        public List<ComisionBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("comisiones");

            //Lista resultado.
            List<ComisionBE> lista = new List<ComisionBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Borra el usuario.
        public int delete(int id)
        {
            return this.getDelete().deleteById("idcobro", id, "comisiones");
        }

        //Actualizar el usuario.
        public int update(ComisionBE comision)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"operacion",comision.operacion},
                { "referencia",comision.referencia},
                { "moneda",comision.moneda.cod},
                { "valor",comision.valor},
                { "fecCobro",comision.fecCobro}
            };

            return this.getUpdate().updateSchemaById(schema, "comisiones", "idcobro", comision.idcobro);
        }

        //Agrega un nuevo usuario.
        public int save(ComisionBE comision)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"operacion",comision.operacion},
                { "referencia",comision.referencia},
                { "moneda",comision.moneda.cod},
                { "valor",comision.valor},
                { "fecCobro",comision.fecCobro}
            };

            return this.getInsert().insertSchema(schema, "comisiones", true);
        }
    }
}
