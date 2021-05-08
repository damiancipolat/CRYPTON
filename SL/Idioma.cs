using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using DAL.DAO;
using DAL.Idiomas;
using System.Configuration;
using SL;

namespace SL
{
    public class Idioma
    {
        //Singleton logic.
        private static Idioma _instance;

        public static Idioma GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Idioma();
            }

            return _instance;
        }

        //Obtengo el lenguaje por defecto de la config.
        public string getDefault()
        {            
            return ConfigurationManager.AppSettings["Language"];
        }

        //Obtengo la lista de lenguajes.
        public List<IdiomaBE> getAll()
        {
            return new IdiomaDAL().findAll();
        }

        //Obtengo la lista de palabras de un lenguaje.
        public Dictionary<string, string> getWords(string code)
        {
            return new IdiomaDAL().loadWords(code);
        }

        //Obtengo las palabras del lenguaje por defecto.
        public Dictionary<string, string> getWordsDefault(string code)
        {            
            return new IdiomaDAL().loadWords(this.getDefault());
        }

        //Traduzco directamente el mensaje.
        public string translateWord(string key)
        {
            Dictionary<string,string> result = new IdiomaDAL().loadWords(this.getDefault());
            return result.ContainsKey(key) ? result[key] : "";
        }

        //Traduzco directamente pero usando el diccionario desde la session.
        public string translateKey(string key)
        {
            Dictionary<string, string> dictionaryKeys = Session.GetInstance().getLanguangeWords();
            return dictionaryKeys[key];
        }
    }
}
