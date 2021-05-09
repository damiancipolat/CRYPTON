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
        //Este metodo recibe un objeto plano y lo tranforma en un insert para una tabla.
        public int insertSchema(Dictionary<string, Object> schema, string tabla, bool getIdentity=false)
        {
            //Genero el sql dinamico.
            string fields = this.utilText.fieldFromSchema(schema);
            string values = this.utilText.valuesFromSchema(schema);
            string sql = "insert into " + tabla + "(" + fields + ") values(" + values + ");";

            //Agrego el retorno del ultimo identity agregado, por defecto es disabled.
            if (getIdentity)
                sql = sql + "SELECT SCOPE_IDENTITY();";

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