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
    public class IdiomaDAL
    {
        //Bindeo datos con esquema.
        private IdiomaBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            IdiomaBE userTarget = new IdiomaBE();

            //Bindeo campos con la lista de resultados.
            new EntityBinder().match(fieldData, userTarget);

            return userTarget;
        }

        //Obtengo la lista completa de idiomas.
        public List<IdiomaBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = new QuerySelect().selectAll("idiomas");

            //Lista resultado.
            List<IdiomaBE> lista = new List<IdiomaBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

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
                result.Add(word["clave"].ToString(), word["valor"].ToString());
            }

            return result;
        }

    }
}
