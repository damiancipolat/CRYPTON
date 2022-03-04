using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class MonedaDAL : AbstractDAL<MonedaBE>
    {
        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private MonedaBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            MonedaBE money = new MonedaBE();

            //Bindeo campos con la lista de resultados.
            this.binder.match(fieldData, money);

            return money;

        }

        //Este metodo obtiene en base al ID el usuario.
        public MonedaBE findByCode(string code)
        {
            //Busco en la bd por id.            
            List<Object> result = this.getSelect().selectAnd(new Dictionary<string, Object>{
                {"cod",code}
            }, "moneda");

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Este metodo retorna una lista de clientes.
        public List<MonedaBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("moneda");

            //Lista resultado.
            List<MonedaBE> lista = new List<MonedaBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }
    }
    
}
