using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics;
using DAL.DAO;
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
            comisionTarget.valor = new Money(Convert.ToSingle(mapa["valor"]));
            comisionTarget.cliente = new ClienteDAL().findById((long)mapa["idcliente"]);
            comisionTarget.wallet = new BilleteraDAL().findById((long)mapa["idwallet"]);
            comisionTarget.moneda = new MonedaDAL().findByCode(mapa["moneda"].ToString());

            return comisionTarget;
        }

        //CRUD ------------------------------

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
                {"operacion",comision.tipo_operacion},
                { "referencia",comision.referencia},
                { "moneda",comision.moneda.cod},
                { "valor",comision.valor.getValue()},
                { "fecCobro",comision.fecCobro},
                { "processed",comision.processed},
                { "idwallet",comision.wallet.idwallet},
                { "idcliente",comision.cliente.idcliente}
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
                { "valor",comision.valor.getValue()},
                { "fecCobro",(comision.fecCobro != null) ? comision.fecCobro.ToString("yyyy-MM-dd HH:mm:ss") :null},
                {"fecRegister", comision.fecRegister.ToString("yyyy-MM-dd HH:mm:ss.fff")},
                { "processed",comision.processed},
                { "idwallet",comision.wallet.idwallet},
                { "idcliente",comision.cliente.idcliente}
            };

            return this.getInsert().insertSchema(schema, "comisiones", true);
        }

        //BUSQUEDAS ----------------------

        //Traigo las comisiones de un cliente.
        public List<ComisionBE> searchByClient(ClienteBE cliente)
        {
            //Busco en la bd por email.
            List<Object> result = this.getSelect().selectAnd(new Dictionary<string, Object>{
                {"idcliente",cliente.idcliente}
            }, "comisiones");

            //Lista resultado.
            List<ComisionBE> lista = new List<ComisionBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Traigo la lista de comisiones PENDIENTES por cobrar.
        public List<ComisionBE> searchByClientPendings(ClienteBE cliente) 
        {
            //Busco en la bd por email.
            List<Object> result = this.getSelect().selectAnd(new Dictionary<string, Object>{
                {"idcliente",cliente.idcliente},
                {"processed",0}                
            }, "comisiones");

            //Lista resultado.
            List<ComisionBE> lista = new List<ComisionBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Traigo la lista de comisiones PROCESADAS.
        public List<ComisionBE> searchByClientProcessed(ClienteBE cliente)
        {
            //Busco en la bd por email.
            List<Object> result = this.getSelect().selectAnd(new Dictionary<string, Object>{
                {"idcliente",cliente.idcliente},
                {"processed",1}
            }, "comisiones");

            //Lista resultado.
            List<ComisionBE> lista = new List<ComisionBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Traigo lista de comisiones pendientes de una wallet.
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

        //Buscar comisiones por fecha de creacion.
        public List<ComisionBE> findByDate(string type, string from, string to)
        {         
            //Convierto formato de fechas.
            from = DateTime.ParseExact(from, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
            to = DateTime.ParseExact(to, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");

            //Agrego el filtro de fecha.
            string sql="";

            //Traigo todos.
            if (type=="0")
                sql = ($"select * from comisiones where fecRegister>= '{from}' and fecRegister<='{to}'");

            //Traigo solo PROCESADOS.
            if (type == "1")
                sql = ($"select * from comisiones where fecRegister>= '{from}' and fecRegister<='{to}' and processed=1");

            //Traigo solo PENDIENTES.
            if (type == "2")
                sql = ($"select * from comisiones where fecRegister>= '{from}' and fecRegister<='{to}' and processed=0");

            //Busco en la bd por email.
            List<Object> result = this.getSelect().queryList(sql);

            //Lista resultado.
            List<ComisionBE> lista = new List<ComisionBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //REPORTES ----------------------

        //Traigo la lista de deudores pendientes de cobrar comisiones.
        public List<(int, int, string, float)> getDebtors() 
        {
            string sql = "select tipo_operacion,idcliente,moneda,SUM(valor) from comisiones where processed = 0 group by tipo_operacion,idcliente,moneda; ";
            SqlDataReader reader = this.getSelect().query(sql);

            List<(int, int, string, float)> result = new List<(int, int, string, float)>();

            while (reader.Read())
            {
                result.Add((
                    Convert.ToInt32(reader.GetValue(0)),
                    Convert.ToInt32(reader.GetValue(1)),
                    Convert.ToString(reader.GetValue(2)),
                    Convert.ToSingle(reader.GetValue(3))
                 ));                
            }

            //Cierro la conexion.
            this.getSelect().closeConnection();

            return result;
        }

        //Traigo la lista de comisiones pendientes a ser cobradas.
        public List<ComisionBE> getPendingsToPay()
        {
            //Busco en la bd por wallet y estado.
            List<Object> result = this.getSelect().selectAnd(new Dictionary<string, Object>{
                {"processed",0}
            }, "comisiones");

            //Lista resultado.
            List<ComisionBE> lista = new List<ComisionBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //? -----------------------------

        //Traer comisiones pendientes, TODO
        public List<ComisionBE> getPaymentsPending(string type, string from, string to)
        {
            var lista = new List<ComisionBE>();
            return lista;
        }
    }
}
