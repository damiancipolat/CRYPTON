using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class SqlText
    {
        private TypeComparer comparer;

        public SqlText()
        {
            this.comparer = new TypeComparer();
        }

        //Obtengo los valores concatenados por comas, si es numero mantengo las comillas.
        public string valuesFromSchema(Dictionary<string, Object> schema)
        {
            string fields = "";

            foreach (var kvp in schema)
            {
                //Append value, handle types.
                if (this.comparer.IsNumber(kvp.Value))
                    fields = fields + kvp.Value.ToString().Replace(',', '.') + ",";

                if (this.comparer.isString(kvp.Value))
                    fields = fields + "'" + kvp.Value + "'" + ",";

                if (this.comparer.isDate(kvp.Value))
                    fields = fields + "'" + kvp.Value + "'" + ",";

                if (kvp.Value==null)
                    fields = fields + "NULL,";
            }

            return fields.Remove(fields.Length - 1);

        }

        //Obtengo los atributos concatenados por comas
        public string fieldFromSchema(Dictionary<string, Object> schema)
        {
            string fields = "";
            foreach (var kvp in schema)
                fields = fields + kvp.Key + ",";

            return fields.Remove(fields.Length - 1);
        }

        //Genera el bloque sql where en base un esquema,
        public string whereAndFromSchema(Dictionary<string, Object> schema)
        {
            string fields = "";

            foreach (var kvp in schema)
            {
                if (this.comparer.IsNumber(kvp.Value))
                    fields = fields + " " + kvp.Key + "=" + kvp.Value + " and";

                if (this.comparer.isString(kvp.Value))
                    fields = fields + " " + kvp.Key + "='" + kvp.Value + "'" + " and";
            }

            return fields.Remove(fields.Length - 4);
        }

        //Genera el bloque sql where en base un esquema,
        public string whereOrFromSchema(Dictionary<string, Object> schema)
        {
            string fields = "";

            foreach (var kvp in schema)
            {
                if (this.comparer.IsNumber(kvp.Value))
                    fields = fields + " " + kvp.Key + "=" + kvp.Value + " or";

                if (this.comparer.isString(kvp.Value))
                    fields = fields + " " + kvp.Key + "='" + kvp.Value + "'" + " or";
            }

            return fields.Remove(fields.Length - 4);
        }

        //Genero los valores separados por coma
        public string setsFromSchema(Dictionary<string, Object> schema)
        {
            string fields = "";

            foreach (var kvp in schema)
            {
                if (this.comparer.IsNumber(kvp.Value))
                    fields = fields + " " + kvp.Key + "=" + kvp.Value + " ,";

                if (this.comparer.isString(kvp.Value))
                    fields = fields + " " + kvp.Key + "='" + kvp.Value + "'" + " ,";
            }

            return fields.Remove(fields.Length - 1);

        }
    }
}
