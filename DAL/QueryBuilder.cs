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

namespace DAL
{
    public class QueryBuilder
    {
        //Genero la conexion con la bd.
        private SqlConnection getConnection()
        {
            //Traigo el connection string de la configuracion.
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            //Armo una nueva conexion.
            return new SqlConnection(connectionString);
        }

        //Bindeo la lista de resultados con el data reader.
        private List<object> bindWithList(SqlDataReader reader)
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

        //Genera una consulta sql que trae todos los resultados.
        public List<Object> selectAll(string table)
        {
            //Creo la conexion.
            SqlConnection conn = this.getConnection();
            conn.Open();

            //Creo el comando
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            //Genero el query dinamico.
            string sql = "select * from " + table + ";";
            cmd.CommandText = sql;
            
            //Armo un list de respuesta.
            SqlDataReader reader = cmd.ExecuteReader();
            List<Object> result = bindWithList(reader);

            reader.Close();
            conn.Close();

            return result;
        }

        //Genera una consulta sql, filtrando por ID.
        public List<Object> selectById(string table,string key,int id)
        {
            //Creo la conexion.
            SqlConnection conn = this.getConnection();
            conn.Open();

            //Creo el comando
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            //Genero el query dinamico.
            string sql = "select * from " + table + " where "+key+"="+id+";";
            cmd.CommandText = sql;

            Debug.WriteLine("Generated SQL:"+sql);

            //Armo un list de respuesta.
            var reader = cmd.ExecuteReader();
            List<Object> result = bindWithList(reader);

            reader.Close();
            conn.Close();

            return result;
        }
    }
}
