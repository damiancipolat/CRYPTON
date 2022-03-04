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
        //Este metodo genera un sql por campos, para una tabla x filtrando por la pk.
        public int updateSchemaById(Dictionary<string, Object> schema, string tabla,string key, Int64 id)
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

        //Este metodo genera un sql que actualiza campos y filtra en ambos casos por schemas usando ands.
        public int updateSchemaWhereAnd(Dictionary<string, Object> schema, Dictionary<string, Object> where, string tabla)
        {
            //Genero los campos dinamicos en base al diccionario.
            string fields = this.utilText.setsFromSchema(schema);
            string whereSql = this.utilText.whereAndFromSchema(where);
            string sql = "update " + tabla + " set " + fields + " where " +whereSql+";";

            Debug.WriteLine("Generated sql:" + sql);

            //Ejecuto la consulta.
            int result = this.query(sql);

            //Cierro conexion.
            this.bdConnection.Close();

            return result;
        }

        //Este metodo genera un sql que actualiza campos y filtra en ambos casos por schemas usando ors.
        public int updateSchemaWhereOr(Dictionary<string, Object> schema, Dictionary<string, Object> where, string tabla)
        {
            //Genero los campos dinamicos en base al diccionario.
            string fields = this.utilText.setsFromSchema(schema);
            string whereSql = this.utilText.whereOrFromSchema(where);
            string sql = "update " + tabla + " set " + fields + " where " + whereSql + ";";

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
            Debug.WriteLine("Generated sql:" + sql);
            SqlCommand command = new SqlCommand(sql, this.bdConnection);
            return command.ExecuteNonQuery();
        }
    }
}
