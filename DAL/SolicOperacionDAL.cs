using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class SolicOperacionDAL : AbstractDAL<SolicOperacionBE>
    {

        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private SolicOperacionBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            SolicOperacionBE solicOperation = new SolicOperacionBE();

            //Bindeo campos con la lista de resultados.
            this.binder.match(fieldData, solicOperation);

            return solicOperation;

        }

        //Este metodo obtiene en base al ID el usuario.
        public SolicOperacionBE findById(int id)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("solic_operacion", "idoperacion", id);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Traigo la lista de solicitudes pendientes. TODO
        public List<SolicOperacionBE> getPendings()
        {
            return new List<SolicOperacionBE>();
        }

        //Este metodo retorna una lista de clientes.
        public List<SolicOperacionBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("solic_operacion");

            //Lista resultado.
            List<SolicOperacionBE> lista = new List<SolicOperacionBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Agrega un nuevo usuario.
        public int save(SolicOperacionBE ops)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"idusuario",ops.usuario.idusuario},
                {"tipo_solic",(int)ops.estadoSolic},
                {"idwallet",ops.billetera.idwallet},
                { "valor",ops.valor.getValue()},
                { "cbu",ops.cbu},
                { "operador",ops.operador.idusuario},
                { "estado_solic",(int)ops.estadoSolic},
                { "fecRegistro",ops.fecRegistro},
                { "fecProceso",ops.fecProceso}
            };

            return this.getInsert().insertSchema(schema, "solic_operacion", true);
        }

        //Borra el usuario.
        public int delete(int id)
        {
            return this.getDelete().deleteById("idoperacion", id, "solic_operacion");
        }

        //Actualizar el usuario.
        public int update(SolicOperacionBE ops)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"idusuario",ops.usuario.idusuario},
                {"tipo_solic",(int)ops.estadoSolic},
                {"idwallet",ops.billetera.idwallet},
                { "valor",ops.valor.getValue()},
                { "cbu",ops.cbu},
                { "operador",ops.operador.idusuario},
                { "estado_solic",(int)ops.estadoSolic},
                { "fecRegistro",ops.fecRegistro},
                { "fecProceso",ops.fecProceso}
            };

            return this.getUpdate().updateSchemaById(schema, "solic_operacion", "idoperacion", ops.idoperacion);
        }
    }
}
