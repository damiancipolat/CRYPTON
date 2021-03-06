using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE;
using BE.ValueObject;

namespace DAL
{
    public class BilleteraDAL : AbstractDAL<BilleteraBE>
    {
        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private BilleteraBE bindSchema(List<Object> fieldData, Boolean clients=true,Boolean accounts=true)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            BilleteraBE wallet = new BilleteraBE();

            //Bindeo campos con la lista de resultados.
            this.binder.match(fieldData, wallet);
            
            //Transfomrmo a diccionario.
            Dictionary<string, object> mapa = this.getParser().rowToDictionary(fieldData);

            //Traigo la cuenta.
            if ((mapa["idcuenta"] != System.DBNull.Value) && accounts)
            {
                wallet.cuenta = new CuentaDAL().findById((long)mapa["idcuenta"]);
            }                

            //Traigo la moneda.
            wallet.moneda = new MonedaDAL().findByCode(mapa["moneda"].ToString());

            //Traigo el cliente.
            if (clients) 
            {
                wallet.cliente = new ClienteDAL().findById((long)mapa["idcliente"]);
            }                

            //Si la moneda no es crypto cargo el saldo.
            if (wallet.moneda.cod == "ARS")
            {
                wallet.saldo = new Money(mapa["saldo"]);
                wallet.saldo_pending = new Money("0");
            }

            return wallet;

        }

        //Este metodo obtiene en base al ID el usuario.
        public BilleteraBE findById(long id,bool rawupdate=true)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("billetera", "idwallet", id);

            //Bindeo con el esquema.
            if (rawupdate)
                return this.bindSchema((List<object>)result[0]);
            else
                return this.bindSchema((List<object>)result[0],false,false);

        }

        //Este metodo retorna una lista de clientes.
        public List<BilleteraBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("billetera");

            //Lista resultado.
            List<BilleteraBE> lista = new List<BilleteraBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Este metodo retorna las billeteras de una cuenta.
        public List<BilleteraBE> findByCuenta(long cuentaId)
        {
            //Creo un esquema dinamico para ser guardado.
            var filter = new Dictionary<string, Object>{
                {"idcuenta",cuentaId}
            };

            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAnd(filter, "billetera");

            //Lista resultado.
            List<BilleteraBE> lista = new List<BilleteraBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row,false,false));

            return lista;
        }

        //Este metodo retorna la billetera de una cuenta de una moneda
        public List<BilleteraBE> findByCuentaAndMoneda(long cuentaId, string moneda)
        {
            //Creo un esquema dinamico para ser guardado.
            var filter = new Dictionary<string, Object>{
                {"idcuenta",cuentaId},
                {"moneda",moneda}
            };

            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAnd(filter, "billetera");

            //Lista resultado.
            List<BilleteraBE> lista = new List<BilleteraBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Agrega un nuevo usuario.
        public int insert(BilleteraBE wallet)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"idcliente",wallet.cliente.idcliente},
                {"moneda", wallet.moneda.cod},
                {"idcuenta", wallet.cuenta.idcuenta},
                {"direccion", wallet.direccion},
                {"fecCreacion", wallet.fecCreacion.ToString("yyyy-MM-dd HH:mm:ss.fff")},
                {"saldo", wallet.saldo.ToFormatString()}
            };

            return this.getInsert().insertSchema(schema, "billetera", true);
        }

        //Borra el usuario.
        public int delete(int id)
        {
            return this.getDelete().deleteById("idwallet", id, "billetera");
        }

        //Actualizar el usuario.
        public int update(BilleteraBE wallet)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"idcliente",wallet.cliente.idcliente},
                {"moneda", wallet.moneda.cod},
                {"direccion", wallet.direccion},
                {"fecCreacion", wallet.fecCreacion},
                {"saldo", wallet.saldo.ToFormatString()}
            };

            return this.getUpdate().updateSchemaById(schema, "billetera", "idwallet", wallet.idwallet);
        }
    }
    
}
