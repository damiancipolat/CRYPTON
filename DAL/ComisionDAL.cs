using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
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
            comisionTarget.valor = new Money(mapa["valor"]);
            comisionTarget.cliente = new ClienteDAL().findById((long)mapa["idcliente"]);
            comisionTarget.wallet = new BilleteraDAL().findById((long)mapa["idwallet"]);

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
                { "valor",comision.valor.ToFormatString()},
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
                { "valor",comision.valor.ToFormatString()},
                { "fecCobro",(comision.fecCobro != null) ? comision.fecCobro.ToString("yyyy-MM-dd HH:mm:ss") :null},
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

        //********

        //Traigo total de comisiones y costo de cada cliente, TODO
        public List<(ClienteBE,Money)> getClientPendingAmmounts()
        {
            var lista = new List<(ClienteBE, Money)>();
            return lista;
        }

        //Buscar comisiones por fecha, TODO
        public List<ComisionBE> findByDate(string type, string from, string to)
        {
            var lista = new List<ComisionBE>();
            return lista;
        }
       
        //Traer comisiones pendientes, TODO
        public List<ComisionBE> getPaymentsPending(string type, string from, string to)
        {
            var lista = new List<ComisionBE>();
            return lista;
        }
    }
}
