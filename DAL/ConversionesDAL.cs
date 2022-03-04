using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.DAO;

namespace DAL
{
        public class ConversionesDAL : AbstractDAL<ConversionesBE>
        {
            //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
            private ConversionesBE bindSchema(List<Object> fieldData)
            {
                if (fieldData.Count == 0)
                    return null;

                //Armo un usuario que sera el cual se actualizara los campos.
                ConversionesBE money = new ConversionesBE();

                //Bindeo campos con la lista de resultados.
                this.binder.match(fieldData, money);

                //Transfomrmo a diccionario.
                Dictionary<string, object> mapa = this.getParser().rowToDictionary(fieldData);

                //Traigo la moneda.
                money.moneda = new MonedaDAL().findByCode(mapa["codCripto"].ToString());

                return money;

            }

            //Este metodo obtiene en base al codigo del usuario.
            public ConversionesBE findByCode(string code)
            {
                //Busco en la bd por id.            
                List<Object> result = this.getSelect().selectAnd(new Dictionary<string, Object>{
                    {"codCripto",code}
                }, "conversiones");

                //Bindeo con el esquema.
                return this.bindSchema((List<object>)result[0]);

            }

            //Este metodo retorna una lista de clientes.
            public List<ConversionesBE> findAll()
            {
                //Busco en la bd por id.
                List<object> result = this.getSelect().selectAll("moneda");

                //Lista resultado.
                List<ConversionesBE> lista = new List<ConversionesBE>();

                foreach (List<object> row in result)
                    lista.Add(this.bindSchema(row));

                return lista;
            }
        }
}
