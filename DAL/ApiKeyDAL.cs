using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class ApiKeysDAL : AbstractDAL<ApiKeysBE>
    {
        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private ApiKeysBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            ApiKeysBE api = new ApiKeysBE();

            //Bindeo campos con la lista de resultados.
            this.binder.match(fieldData, api);

            return api;

        }

        //Este metodo obtiene en base al ID el usuario.
        public ApiKeysBE findByCode(string code)
        {
            //Busco en la bd por id.            
            List<Object> result = this.getSelect().selectAnd(new Dictionary<string, Object>{
                {"ambiente",code}
            }, "api_keys");

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Este metodo retorna una lista de clientes.
        public List<ApiKeysBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("moneda");

            //Lista resultado.
            List<ApiKeysBE> lista = new List<ApiKeysBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }
    }
    
}
