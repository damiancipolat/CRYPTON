using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using BE;
using DAL;
using DAL.Idiomas;
using BL;

namespace BL
{
    public class IdiomaBL
    {
        //Clona un lenguaje y lo retorna para mostrarlo en una ui.
        public Dictionary<string, string> getTemplate()
        {
            IdiomaDAL lang = new IdiomaDAL();
            string langCode = ConfigurationManager.AppSettings["Language"];

            Debug.WriteLine("Loading words from language:"+ langCode);

            //Recupero el 1ero.
            return lang.loadWords(langCode);

        }

        //Traigo la lista de idiomas.
        public List<IdiomaBE> getList()
        {
            return new IdiomaDAL().findAll();
        }

        //Traigo las palabras de un idioma.
        public Dictionary<string, string> loadWords(string code)
        {
            Debug.WriteLine("Loading words from:" + code);
            return new IdiomaDAL().loadWords(code);
        }

        //Grabo las palabras de un
        private void fillWords(string code)
        {
            IdiomaDAL lang = new IdiomaDAL();

            //Traigo el template.
            Dictionary<string, string> template = this.getTemplate();

            foreach (KeyValuePair<string, string> word in template)
            {
                Debug.WriteLine("Record word:"+word.Key+"-"+code);
                lang.recordWord(word.Key, "", code);
            }                
        }

        //Actualizo la palabra.
        public int updateWord(string langCode, string langKey, string langValue)
        {
            return new IdiomaDAL().updateWord(langCode,langKey,langValue);
        }

        //Agrego un nuevo idioma.
        public void create(string descrip)
        {
            //Creo el idioma y lo guardo en la bd.
            IdiomaBE lang = new IdiomaBE();
            lang.code = descrip.Substring(0,3).ToUpper();
            lang.descripcion = descrip;

            new IdiomaDAL().insert(lang);

            //Grabo el template para el pais.
            this.fillWords(lang.code);
        }
    }
}
