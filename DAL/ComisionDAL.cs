using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.ValueObject;

namespace DAL
{
    public class ComisionDAL : AbstractDAL<ComisionBE>
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
            comisionTarget.tipo_operacion = (Operaciones)mapa["tipo_operacion"];
            comisionTarget.valor = new Money((double)mapa["valor"]);

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

        //Traigo lista de comisiones pendientes de una walley.
        public List<ComisionBE> pendingByWallet(BilleteraBE wallet)
        {
            //Busco en la bd por wallet y estado.
            List<Object> result = this.getSelect().selectAnd(new Dictionary<string, Object>{
                {"idwallet",wallet.idwallet},
                {"processed",0}
            }, "comisiones");

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
                {"operacion",comision.tipo_operacion},
                { "referencia",comision.referencia},
                { "moneda",comision.moneda.cod},
                { "valor",comision.valor.ToFormatString()},
                { "fecCobro",comision.fecCobro},
                { "processed",comision.processed},
                { "idwallet",comision.idwallet}
            };

            return this.getUpdate().updateSchemaById(schema, "comisiones", "idcobro", comision.idcobro);
        }

        //Agrega un nuevo usuario.
        public int save(ComisionBE comision)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                { "tipo_operacion",(int)comision.tipo_operacion },
                { "referencia",comision.referencia},
                { "moneda",comision.moneda.cod},
                { "valor",comision.valor.ToFormatString()},
                { "fecCobro",(comision.fecCobro != null) ? comision.fecCobro.ToString("yyyy-MM-dd HH:mm:ss") :null},
                { "processed",comision.processed},
                { "idwallet",comision.idwallet}
            };

            return this.getInsert().insertSchema(schema, "comisiones", true);
        }
    }
}
