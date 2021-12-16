using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using BE;
using DAL;
using DAL.DAO;
using DAL.Idiomas;
using SL;

namespace SL
{
    public class Idioma
    {        
        //Variable de intancia.
        private static Idioma _instance;

        //Almacena la seleccion temporal del idioma.
        private IdiomaBE defaultIdioma;
        private Dictionary<string, string> words;

        //Retorna la instancia unica.
        public static Idioma GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Idioma();
            }

            return _instance;
        }

        //Obtengo la lista de lenguajes.
        public List<IdiomaBE> getAll()
        {
            return new IdiomaDAL().findAll();
        }

        //Busco el idioma en base al codigo.
        public IdiomaBE getIdioma(string code)
        {
            return new IdiomaDAL().findByCode(code);
        }

        //Obtengo la lista de palabras de un lenguaje en base a su codigo
        public Dictionary<string, string> getWords(string code)
        {
            return new IdiomaDAL().loadWords(code);
        }

        //Obtengo la lista de palabras de un lenguaje en base a un idioma.
        public Dictionary<string, string> getWords1(IdiomaBE idioma)
        {
            return new IdiomaDAL().loadWords(idioma.code);
        }

        //Obtengo la lista cargados por defecto.
        public Dictionary<string, string> getDefaultWords()
        {
            return this.words;
        }

        //Seteo el idioma por defecto.
        public void setDefault(IdiomaBE idioma)
        {
            this.defaultIdioma = idioma;

            //Seteo las palabras al cambiar el idioma.
            this.words = this.getWords1(this.defaultIdioma);
        }

        //Obtengo el lenguaje por defecto de la config.
        public IdiomaBE getDefault()
        {
            return this.defaultIdioma;
        }

        //Traduzco la clave usando el idioma por defecto.
        public string translate(string key)
        {/*
            if (this.words.ContainsKey(key))
            {
                string word = this.words[key];

                if (word != "")
                    return this.words[key];
                else
                    return key;
            }
            else
            {
                return key;
            }*/
            return "";
        }

        //Traduzco la clave en base a un idioma.
        public string translate(IdiomaBE idioma,string key)
        {
           // Dictionary<string, string> tmpWords = this.getWords(idioma);
            //return tmpWords.ContainsKey(key) ? tmpWords[key] : key;
            return "";
        }
    }
}