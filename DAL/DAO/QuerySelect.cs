using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DAL.DAO
{
    public class QuerySelect:QueryBuilder
    {
        //Genera una consulta sql que trae todos los resultados.
        public List<Object> selectAll(string table)
        {
            string sql = "select * from " + table + ";";

            //Ejcuto el query.
            SqlDataReader reader = this.query(sql);

            //Parseo el data reader a una lista de columnas/valores.
            List<Object> result = this.utilParser.dataReaderToList(reader);
            this.bdConnection.Close();

            return result;
        }

        //Genera una consulta sql, filtrando por ID.
        public List<Object> selectById(string table, string key, int id)
        {
            //Genero el query en base a parametros.
            string sql = "select * from " + table + " where " + key + "=" + id + ";";
            Debug.WriteLine("Generated SQL:" + sql);

            //Ejcuto el query.
            SqlDataReader dataReader = this.query(sql);            

            //Parseo el data reader a una lista de columnas/valores.
            List<Object> result = this.utilParser.dataReaderToList(dataReader);
            this.bdConnection.Close();

            return result;
        }

        //Genera una consulta sql pudiendo definir el whee dinamicamente
        public List<Object> selectAnd(Dictionary<string, Object> schema, string table)
        {
            string where = this.utilText.whereFromSchema(schema);
            string sql = "select * from " + table + " where " + where + ";";

            //Ejcuto el query.
            SqlDataReader reader = this.query(sql);

            //Parseo el data reader a una lista de columnas/valores.
            List<Object> result =  this.utilParser.dataReaderToList(reader);
            this.bdConnection.Close();

            return result;
        }

        //Ejecutar un query directo.
        public SqlDataReader query(string sql)
        {
            //Creo el comando
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.bdConnection;
            cmd.CommandText = sql;

            Debug.WriteLine("RUN:" + sql);

            //Armo un list de respuesta.
            return cmd.ExecuteReader();
        }

    }
}