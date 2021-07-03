using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL.DAO
{
    public class QueryDelete : QueryBuilder
    {
        //Genera una consulta sql pudiendo definir el where dinamicamente
        public int deleteSchema(Dictionary<string, Object> schema, string tabla)
        {
            string whereSql = this.utilText.whereAndFromSchema(schema);

            //Armo el query en base a la cantidad de los primeros registros.
            string sql = "delete from " + tabla + " where " + whereSql + ";";

            //Ejcuto el query.
            int result = this.query(sql);

            //Cierro conexion.
            this.bdConnection.Close();

            return result;
        }

        //Borro en base al id y clave.
        public int deleteById(string key, long id, string tabla)
        {
            //Genero el sql dinamico.
            string sql = "delete from "+tabla+" where "+key+"id="+id+";";
            Debug.WriteLine("Generated sql:" + sql);

            //Ejecuto la consulta.
            int result = this.query(sql);

            //Cierro conexion.
            this.bdConnection.Close();

            return result;
        }

        //Baja logica por tabla, clave, id
        public int logicalDeleteById(string key, long id, string tabla)
        {
            //Genero el sql dinamico.
            string sql = "updete " + tabla + " set deleted=GETDATE() where " + key + "id=" + id + ";";
            Debug.WriteLine("Generated sql:" + sql);

            //Ejecuto la consulta.
            int result = this.query(sql);

            //Cierro conexion.
            this.bdConnection.Close();

            return result;
        }

        //Ejecuta el query que recibe como parametro.
        public int query(string sql)
        {
            SqlCommand command = new SqlCommand(sql, this.bdConnection);
            Debug.WriteLine("Generated sql:" + sql);
            return command.ExecuteNonQuery();
        }

    }
}