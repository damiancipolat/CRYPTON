using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Dynamic;
using System.Reflection;
using DAL.DAO;

namespace DAL
{
    public class QueryBuilder
    {
        protected SqlConnection bdConnection;
        protected SqlText utilText;
        protected SqlParser utilParser;

        //Reviso la conexion.
        public bool checkConnection() 
        {
            try
            {
                //Armo una nueva conexion.
                SqlConnection bdConnection = this.getConnection();
                bool status = this.bdConnection.State == ConnectionState.Open;

                //Cierro la conexion para evitar dejarla inactiva.
                if (status)
                    bdConnection.Close();

                return status;
            }
            catch (Exception err) 
            {
                Debug.WriteLine("---++++" + err.Message);
                return false;
            }
        }

        //Armo una conexion al crear la clase.
        public QueryBuilder()
        {
            this.utilText = new SqlText();
            this.utilParser = new SqlParser();
            this.bdConnection = this.getConnection();

            if (this.bdConnection.State != ConnectionState.Open)
                this.bdConnection.Open();
        }

        //Genero la conexion con la bd.
        protected SqlConnection getConnection()
        {
            //Traigo el connection string de la configuracion.
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            Debug.WriteLine("Conexion usando:" + connectionString);

            //Armo una nueva conexion.
            return new SqlConnection(connectionString);
        }

        //Traigo las utilities.
        public SqlParser getParsers()
        {
            return this.utilParser;
        }

        //Cierro la conexion.
        public void closeConnection()
        {
            this.bdConnection.Close();
        }
    }
}
