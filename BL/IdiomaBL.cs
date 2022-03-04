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
            Debug.WriteLine("Loading words from template");

            //Recupero el 1ero.
            return new IdiomaDAL().loadTemplate();

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

        //Borro un idioma.
        public int delete(IdiomaBE idioma)
        {
            IdiomaDAL lang = new IdiomaDAL();

            //Borro todas las palabras del idioma.
            lang.deleteLanguageWords(idioma.code);

            //Borro el idioma.
            return lang.delete(idioma);
        }

        //PALABRAS ------------------------------------------------------------

        //Traigo el template.
        public Dictionary<string, string> loadTemplate()
        {
            return new IdiomaDAL().loadTemplate();
        }

        //Grabo las palabras de un idioma nuevo.
        private void fillWords(string code)
        {
            IdiomaDAL lang = new IdiomaDAL();

            //Traigo el template.
            Dictionary<string, string> template = this.getTemplate();

            //Guardo en forma de bulk.
            lang.recordBulkWord(template,code);

            /*
            foreach (KeyValuePair<string, string> word in template)
            {
                Debug.WriteLine("Record word:" + word.Key + "-" + code);
                lang.recordWord(word.Key, "", code);
            }*/
        }

        //Grabo la palabra.
        public int recordWord(string langCode, string langKey, string langValue)
        {
            return new IdiomaDAL().recordWord(langKey, langValue, langCode);
        }

        //Actualizo la palabra.
        public int updateWord(string langCode, string langKey, string langValue)
        {
            return new IdiomaDAL().updateWord(langCode, langKey.ToUpper(), langValue);
        }
        
        //Borro la palabra.
        public int deleteWord(string langCode, string langKey)
        {
            return new IdiomaDAL().deleteWord(langCode,langKey);
        }

        //Borro una palabra en todos los idiomas.
        public void deleteWordAll(string key)
        {
            //Borro la clave.
            new IdiomaDAL().deleteTemplateKey(key);

            //Traigo todos los idiomas.
            List<IdiomaBE> idiomas = this.getList();

            //Borro de cada idioma.
            foreach (IdiomaBE idioma in idiomas)
                this.deleteWord(idioma.code,key);
        }

        //Agrego una palabra en todos los idiomas.
        public void createWordAll(string key)
        {
            //Grabo la nueva clave.
            new IdiomaDAL().addTemplateKey(key);

            //Traigo todos los idiomas.
            List<IdiomaBE> idiomas = this.getList();

            //Los guardo en la tabla de palabras idioma.
            foreach (IdiomaBE idioma in idiomas)
                this.recordWord(idioma.code, key, "");
        }
    }
}
