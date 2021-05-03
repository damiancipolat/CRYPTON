﻿using System;
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
        //Transform a list key / pair to a dictionary.
        public Dictionary<string, object> getAsDictionary(List<Object> rows)
        {
            //Valida si la lista tiene un 1 registro, sino tiro error.
            if (!(rows != null && rows.Count > 0))
                throw new Exception("Unable to bind with data source");

            Dictionary<string, object> result = new Dictionary<string, object>();

            foreach (KeyValuePair<string, object> data in rows)
                result.Add(data.Key, data.Value);

            return result;
        }

        //Bindeo la lista de resultados con el data reader.
        public List<object> bindWithList(SqlDataReader reader)
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
        public List<Object> selectById(string table, string key, int id)
        {
            //Genero el query en base a parametros.
            string sql = "select * from " + table + " where " + key + "=" + id + ";";
            Debug.WriteLine("Generated SQL:" + sql);

            //Eejcuto el query.
            SqlDataReader dataReader = this.query(sql);            

            //Parseo el data reader a una lista de columnas/valores.
            List<Object> result = bindWithList(dataReader);
            this.bdConnection.Close();

            return result;
        }

        //Dice si es un numero.
        private bool IsNumber(object value)
        {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }

        //Genera el bloque sql where en base un esquema,
        public string whereFromSchema(Dictionary<string, Object> schema)
        {
            string fields = "";

            foreach (var kvp in schema)
            {

                //Check type
                Boolean isInt = IsNumber(kvp.Value);
                Boolean isStr = kvp.Value is String;
                Boolean isDate = kvp.Value is DateTime;

                //Append value, handle types.
                if (isInt)
                    fields = fields +" "+kvp.Key+"="+kvp.Value +" and";

                if (isStr)
                    fields = fields +" "+ kvp.Key+"='" + kvp.Value + "'" + " and";
            }

            return fields.Remove(fields.Length - 4);

        }

        //Genera una consulta sql pudiendo definir el whee dinamicamente
        public List<Object> selectAnd(Dictionary<string, Object> schema, string table)
        {
            string where = whereFromSchema(schema);
            string sql = "select * from " + table + " where " + where + ";";

            SqlDataReader reader = this.query(sql);
            return bindWithList(reader);
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