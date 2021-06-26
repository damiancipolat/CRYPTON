using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace DAL
{
    public class CuentaDAL:AbstractDAL<CuentaBE>
    {
        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private CuentaBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            CuentaBE cuentaTarget = new CuentaBE();

            //Bindeo campos con la lista de resultados.
            this.binder.match(fieldData, cuentaTarget);

            return cuentaTarget;

        }

        private string getString(object o)
        {
            if (o == DBNull.Value) return null;
            return (string)o;
        }

        //Este metodo obtiene en base al ID el usuario.
        public CuentaBE findById(long id)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("cuentas", "idcuenta", id);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Este metodo retorna una lista de clientes.
        public List<CuentaBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("cuentas");

            //Lista resultado.
            List<CuentaBE> lista = new List<CuentaBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Agrega un nuevo usuario.
        public int insert(CuentaBE cuenta)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{                
                {"cliente",cuenta.cliente.idcliente },
                {"fecAlta",(cuenta.fecAlta!=null)?cuenta.fecAlta.ToString("yyyy-MM-dd HH:mm:ss"):null },
                {"estado",(int)cuenta.estado },
            };
            
            return this.getInsert().insertSchema(schema, "cuentas", true);
        }

        //Borra el usuario.
        public int delete(int id)
        {
            return this.getDelete().deleteById("idcuenta", id, "cuentas");
        }

        //Actualizar el usuario.
        public int update(CuentaBE cuenta)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"cliente",cuenta.cliente.idcliente },
                {"fecAlta",(cuenta.fecAlta!=null)?cuenta.fecAlta.ToString("yyyy-MM-dd HH:mm:ss"):null },
                {"estado",(CuentaEstado)cuenta.estado },
            };

            return this.getUpdate().updateSchemaById(schema, "cuentas", "idcuenta", cuenta.idcuenta);
        }

        //Traer cuenta activa de un cliente.
        public CuentaBE getActive(ClienteBE cliente)
        {
            //Busco en la bd por id.            
            List<Object> result = this.getSelect().selectAnd(new Dictionary<string, Object>{
                {"cliente",cliente.idcliente},
                {"estado",1},
            }, "cuentas");

            if (result.Count == 0)
                return null;

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);
        }

        //todo
        public List<BilleteraBE> getClientWallets(ClienteBE cliente) { return new List<BilleteraBE>(); }
    }
}