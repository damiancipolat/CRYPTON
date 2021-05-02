using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL.DAO
{
    public class QueryInsert : QueryBuilder
    {
        //Dice si es un numero.
        private bool IsNumber(object value)
        {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }

        //Obtengo los atributos concatenados por comas
        public string fieldFromSchema(Dictionary<string, Object> schema)
        {
            string fields = "";
            foreach (var kvp in schema)
                fields = fields + kvp.Key + ",";

            return fields.Remove(fields.Length - 1);
        }

        //Obtengo los valores concatenados por comas, si es numero mantengo las comillas.
        public string valuesFromSchema(Dictionary<string, Object> schema)
        {
            string fields = "";

            foreach (var kvp in schema)
            {

                //Check type
                Boolean isInt = IsNumber(kvp.Value);
                Boolean isStr = kvp.Value is String;
                Boolean isDate = kvp.Value is DateTime;

                //Append value, handle types.
                if (isInt)
                    fields = fields + kvp.Value + ",";

                if (isStr)
                    fields = fields + "'" + kvp.Value + "'" + ",";
            }

            return fields.Remove(fields.Length - 1);

        }

        //Este metodo recibe un objeto plano y lo tranforma en un insert para una tabla.
        public int insertSchema(Dictionary<string, Object> schema, string tabla)
        {
            //Genero el sql dinamico.
            string fields = this.fieldFromSchema(schema);
            string values = this.valuesFromSchema(schema);
            string sql = "insert into " + tabla + "(" + fields + ") values(" + values + ");";

            Debug.WriteLine("Generated sql:" + sql);

            //Ejecuto la consulta.
            int result = this.query(sql);

            //Cierro conexion.
            this.bdConnection.Close();

            return result;
        }

        //Ejecuta el query directamente que recibe como parametro.
        public int query(string sql)
        {
            SqlCommand command = new SqlCommand(sql, this.bdConnection);
            return command.ExecuteNonQuery();
        }

    }
}