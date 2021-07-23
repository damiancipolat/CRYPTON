using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE;
using DAL.DAO;


namespace DAL.Idiomas
{
    public class IdiomaDAL : AbstractDAL<IdiomaDAL>
    {
        //Bindeo datos con esquema.
        private IdiomaBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            IdiomaBE userTarget = new IdiomaBE();

            //Bindeo campos con la lista de resultados.
            this.binder.match(fieldData, userTarget);

            return userTarget;
        }

        //Idiomas--------------------------------------------------------

        //Obtengo la lista completa de idiomas.
        public List<IdiomaBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = new QuerySelect().selectAll("idiomas");
 
            //Lista resultado.
            List <IdiomaBE> lista = new List<IdiomaBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Este metodo obtiene en base al ID el usuario.
        public IdiomaBE findByCode(string langCode)
        {
            //Busco en la bd por id.
            List<Object> result = new QuerySelect().selectAnd(new Dictionary<string, Object>{
                {"code", langCode}
            }, "idiomas");

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Agrega un nuevo idioma.
        public int insert(IdiomaBE idioma)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"code",idioma.code},
                {"descripcion",idioma.descripcion }
            };

            return this.getInsert().insertSchema(schema, "idiomas", false);
        }

        //Borro el idioma.
        public int delete(IdiomaBE idioma)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"code",idioma.code}
            };

            return this.getDelete().deleteSchema(schema, "idiomas");
        }

        //Palabras--------------------------------------------------------

        //Obtengo las palabras de un idioma.
        public Dictionary<string, string> loadWords(string langCode)
        {
            List<Object> words= new QuerySelect().selectAnd(new Dictionary<string, Object>{
                {"code", langCode}
            }, "idioma_palabras");

            //Validateresult.
            Dictionary<string, string> result = new Dictionary<string, string>();

            if (words.Count == 0)
                return result;

            //Load the dictionary.
            foreach (List<object> row in words)
            {
                //Convierto a diccionario y extraigo los campos de la tabla de palabras "clave" y "valor".
                Dictionary<string, object> word = new SqlParser().rowToDictionary(row);
                Debug.WriteLine("Loading word>"+ word["clave"].ToString()+":"+ word["valor"].ToString());

                //Agrego en la lista.
                result.Add(word["clave"].ToString(), word["valor"].ToString());
            }

            return result;
        }

        //Grabo una palabra para un lenguaje.
        public int recordWord(string key,string word, string code)
        {
            string sql = "insert into idioma_palabras(code, clave, valor) values('" + code + "', '" + key + "', '" + word + "');";
            return this.getInsert().query(sql);
        }

        //Actualizo el valor del idioma.
        public int updateWord(string langCode,string langKey,string langValue)
        {            
            string sql = "update idioma_palabras set valor='" + langValue + "' where code='" + langCode + "' and clave='" + langKey + "';";
            return this.getUpdate().query(sql);
        }

        //Borro la palabra.
        public int deleteWord(string langCode, string langKey)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"code",langCode},
                {"clave",langKey }
            };

            return this.getDelete().deleteSchema(schema, "idioma_palabras");
        }

        //Borro todas las palabra de un idioma.
        public int deleteLanguageWords(string langCode)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"code",langCode}
            };

            return this.getDelete().deleteSchema(schema, "idioma_palabras");
        }
    }
}