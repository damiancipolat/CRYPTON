using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class ComisionValorDAL : AbstractDAL<ComisionValorBE>
    {

        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private ComisionValorBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            ComisionValorBE comisionTarget = new ComisionValorBE();

            //Bindeo campos con la lista de resultados.
            this.binder.match(fieldData, comisionTarget);

            return comisionTarget;

        }

        //Este metodo obtiene en base al codigo de operacion.
        public ComisionValorBE findById(long id)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("comision_operacion_valor", "idope", id);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Este metodo retorna una lista de usuarios.
        public List<ComisionValorBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("comision_operacion_valor");

            //Lista resultado.
            List<ComisionValorBE> lista = new List<ComisionValorBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Borra el usuario.
        public int delete(long id)
        {
            return this.getDelete().deleteById("idope", id, "comision_operacion_valor");
        }

        //Actualizar el usuario.
        public int update(ComisionValorBE comision)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"descrip",comision.descrip},
                { "valor",comision.valor}
            };

            return this.getUpdate().updateSchemaById(schema, "comision_operacion_valor", "idope", comision.idope);
        }

        //Agrega un nuevo usuario.
        public int save(ComisionValorBE comision)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                 {"descrip",comision.descrip},
                { "valor",comision.valor}
            };

            return this.getInsert().insertSchema(schema, "comision_operacion_valor", true);
        }
    }
}
