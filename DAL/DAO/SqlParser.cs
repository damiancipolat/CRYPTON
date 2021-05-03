using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL.DAO
{
    public class SqlParser
    {
        //Bindeo la lista de resultados con el data reader.
        public List<object> dataReaderToList(SqlDataReader reader)
        {
            List<Object> result = new List<Object>();

            //Recorro el resulset.
            while (reader.Read())
            {
                //Armo una lista para cargar las columnas.
                List<Object> row = new List<Object>();

                //Itero las filas para ir columna por columna.
                for (int i = 0; i <= reader.FieldCount - 1; i++)
                    row.Add(new KeyValuePair<string, object>(reader.GetName(i), reader.GetValue(i)));

                result.Add(row);
            }

            return result;
        }

        //Convert the row in a dictionary.
        public Dictionary<string, object> rowToDictionary(List<Object> rows)
        {
            //Valida si la lista tiene un 1 registro, sino tiro error.
            if (!(rows != null && rows.Count > 0))
                throw new Exception("Unable to bind with data source");

            Dictionary<string, object> result = new Dictionary<string, object>();

            foreach (KeyValuePair<string, object> data in rows)
                result.Add(data.Key, data.Value);

            return result;
        }
    }
}
