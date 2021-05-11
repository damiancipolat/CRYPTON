using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE;
using DAL.DAO;

namespace DAL
{
    public class ClienteDAL
    {
        private string getString(object o)
        {

            if (o == DBNull.Value) return null;
            return (string)o;
        }

        //Agrega un nuevo usuario.
        public int insert(ClienteBE client)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"idusuario",client.usuario.idusuario},
                {"tipoDoc",client.tipoDoc},
                {"numero",client.numero},
                {"fec_nac",client.fec_nac},
                {"num_tramite",client.num_tramite},
                {"domicilio",client.domicilio},
                {"telefono",client.telefono},
                {"valido",client.valido}
            };

            QueryInsert builder = new QueryInsert();
            return builder.insertSchema(schema, "cliente", true);
        }
    }
}
