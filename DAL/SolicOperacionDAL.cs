using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.ValueObject;
using SEC;
using DAL.DAO;

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

            //Actualizo el tipo de usuario que es un enum.            
            Dictionary<string, object> mapa = this.getParser().rowToDictionary(fieldData);

            //Agrego el usuario.
            solicOperation.usuario = new UsuarioDAL().findById((long)mapa["idusuario"]); ;
            solicOperation.valor = new Money((double)mapa["valor"]);
            solicOperation.billetera= new BilleteraDAL().findById((long)mapa["idwallet"]);

            if ((int)mapa["tipo_solic"] == 1)
                solicOperation.tipoOperacion = TipoSolicOperacion.INGRESO_SALDO;

            if ((int)mapa["tipo_solic"] == 2)
                solicOperation.tipoOperacion = TipoSolicOperacion.RETIRO_SALDO;

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

        //Traigo la lista de solicitudes pendientes.
        public List<SolicOperacionBE> getPendings()
        {
            //Armo el query.
            string sql = @"select sop.idoperacion,sop.tipo_solic,sop.idwallet,sop.valor,
                                  sop.estado_solic,sop.fecRegistro,sop.fecProceso,sop.cbu,
                                  usr.idusuario,usr.nombre,usr.apellido,usr.alias,usr.email,usr.tipo_usuario
                            from solic_operacion as sop
                            inner join usuario as usr on usr.idusuario = sop.idusuario
                            where sop.tipo_solic = 2 and sop.estado_solic = 3;";

            //Ejecuto el query.
            QuerySelect builder = new QuerySelect();
            SqlDataReader reader = builder.query(sql);

            //Lista resultado.
            List<SolicOperacionBE> lista = new List<SolicOperacionBE>();

            while (reader.Read())
            {
                SolicOperacionBE ope = new SolicOperacionBE();
                ope.idoperacion = Convert.ToInt64(reader.GetValue(0));

                if (Convert.ToInt32(reader.GetValue(1)) == 1)
                    ope.tipoOperacion = TipoSolicOperacion.INGRESO_SALDO;

                if (Convert.ToInt32(reader.GetValue(1)) == 2)
                    ope.tipoOperacion = TipoSolicOperacion.RETIRO_SALDO;

                ope.valor = new Money(Convert.ToDouble(reader.GetValue(3)));
                ope.cbu = Convert.ToString(reader.GetValue(7));
                ope.fecRegistro = Convert.ToDateTime(reader.GetValue(5));
                ope.fecProceso = Convert.ToDateTime(reader.GetValue(6));

                UsuarioBE user = new UsuarioBE();
                user.idusuario= Convert.ToInt64(reader.GetValue(8));
                user.nombre = Convert.ToString(reader.GetValue(9));
                user.apellido = Convert.ToString(reader.GetValue(10));
                user.alias = Convert.ToString(reader.GetValue(11));
                user.email = Cripto.GetInstance().Decrypt(Convert.ToString(reader.GetValue(12)));
                ope.usuario = user;                

                lista.Add(ope);
            }

            return lista;
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
                {"tipo_solic",(int)ops.tipoOperacion},
                {"idwallet",ops.billetera.idwallet},
                { "valor",ops.valor.getValue()},
                { "cbu",ops.cbu},
                { "operador",ops.operador!=null?ops.operador.idusuario:0},
                { "estado_solic",(int)ops.estadoSolic},
                { "fecRegistro",ops.fecRegistro.ToString("yyyy-MM-dd HH:mm:ss.fff")},
                { "fecProceso",ops.fecProceso.ToString("yyyy-MM-dd HH:mm:ss.fff")}
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
                { "operador",ops.operador!=null?ops.operador.idusuario:0},
                { "estado_solic",(int)ops.estadoSolic},
                { "fecRegistro",ops.fecRegistro},
                { "fecProceso",ops.fecProceso}
            };

            return this.getUpdate().updateSchemaById(schema, "solic_operacion", "idoperacion", ops.idoperacion);
        }
    }
}
