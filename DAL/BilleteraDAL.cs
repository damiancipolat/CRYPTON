using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class BilleteraDAL : AbstractDAL<BilleteraBE>
    {
        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private BilleteraBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            BilleteraBE wallet = new BilleteraBE();

            //Bindeo campos con la lista de resultados.
            this.binder.match(fieldData, wallet);

            //Traigo la cuenta.
            wallet.cuenta = new CuentaDAL().findById(wallet.cuenta.idcuenta);

            return wallet;

        }

        //Este metodo obtiene en base al ID el usuario.
        public BilleteraBE findById(int id)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("billetera", "idwallet", id);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Este metodo retorna una lista de clientes.
        public List<BilleteraBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("solic_onboarding");

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
                {"direccion", wallet.direccion},
                {"fecCreacion", wallet.fecCreacion},
                {"saldo", wallet.saldo}
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
                {"saldo", wallet.saldo}
            };

            return this.getUpdate().updateSchemaById(schema, "billetera", "idwallet", wallet.idwallet);
        }
    }
    
}
