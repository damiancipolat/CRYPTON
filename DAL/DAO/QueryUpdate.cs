using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DAL.DAO
{
    public class QueryUpdate : QueryBuilder
    {
        //Es
        public int updateSchemaById(Dictionary<string, Object> schema, string tabla,string key, int id)
        {
            //Genero el sql dinamico.
            string fields = this.utilText.setsFromSchema(schema);
            string sql = "update "+tabla+" set "+fields+" where "+key+"="+id+";";

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
