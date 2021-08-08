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
    public class BilleteraDAL2 : AbstractDAL<BilleteraBE2>
    {
        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private BilleteraBE2 bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            BilleteraBE2 wallet = new BilleteraBE2();

            //Bindeo campos con la lista de resultados.
            this.binder.match(fieldData, wallet);

            //Transfomrmo a diccionario.
            Dictionary<string, object> mapa = this.getParser().rowToDictionary(fieldData);

            //Traigo la cuenta.
            if (mapa["idcuenta"] != System.DBNull.Value)
                wallet.cuenta = new CuentaDAL().findById((long)mapa["idcuenta"]);

            //Traigo la moneda.
            wallet.moneda = new MonedaDAL().findByCode(mapa["moneda"].ToString());

            //Traigo el cliente.
            wallet.cliente = new ClienteDAL().findById((long)mapa["idcliente"]);

            //Si la moneda no es crypto cargo el saldo.
            if (wallet.moneda.cod == "ARS")
            {
                wallet.saldo = new Money(mapa["saldo"]);
                wallet.saldo_pending = new Money("0");
            }

            return wallet;

        }

        //Este metodo obtiene en base al ID el usuario.
        public BilleteraBE2 findById(long id)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("billetera", "idwallet", id);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Este metodo retorna una lista de clientes.
        public List<BilleteraBE2> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("billetera");

            //Lista resultado.
            List<BilleteraBE2> lista = new List<BilleteraBE2>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Este metodo retorna las billeteras de una cuenta.
        public List<BilleteraBE2> findByCuenta(long cuentaId)
        {
            //Creo un esquema dinamico para ser guardado.
            var filter = new Dictionary<string, Object>{
                {"idcuenta",cuentaId}
            };

            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAnd(filter, "billetera");

            //Lista resultado.
            List<BilleteraBE2> lista = new List<BilleteraBE2>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Agrega un nuevo usuario.
        public int insert(BilleteraBE2 wallet)
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
        public int update(BilleteraBE2 wallet)
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
