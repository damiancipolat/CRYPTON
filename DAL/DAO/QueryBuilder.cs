﻿using System;
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
using DAL.DAO;

namespace DAL
{
    public class QueryBuilder
    {
        protected SqlConnection bdConnection;
        protected SqlText utilText;
        protected SqlParser utilParser;

        //Armo una conexion al crear la clase.
        public QueryBuilder()
        {
            this.utilText = new SqlText();
            this.utilParser = new SqlParser();
            this.bdConnection = this.getConnection();
            this.bdConnection.Open();
        }

        //Genero la conexion con la bd.
        protected SqlConnection getConnection()
        {
            //Traigo el connection string de la configuracion.
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

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