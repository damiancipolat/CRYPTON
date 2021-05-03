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
        //Borro en base al id y clave.
        public int deleteById(string key, int id, string tabla)
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

        //Ejecuta el query que recibe como parametro.
        public int query(string sql)
        {
            SqlCommand command = new SqlCommand(sql, this.bdConnection);
            return command.ExecuteNonQuery();
        }

    }
}