using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Diagnostics;
using System.Dynamic;
using System.Reflection;

namespace DAL
{
    public class QueryBuilder
    {
        //Genero la conexion con la bd.
        protected SqlConnection getConnection()
        {
            //Traigo el connection string de la configuracion.
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            //Armo una nueva conexion.
            return new SqlConnection(connectionString);
        }


    }
}
