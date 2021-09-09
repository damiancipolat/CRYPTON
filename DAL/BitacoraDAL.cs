using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE;
using DAL.DAO;

namespace DAL
{
    public class BitacoraDAL : AbstractDAL<BitacoraBE>
    {
        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private BitacoraBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo el objeto bitacora.
            BitacoraBE bitacora = new BitacoraBE();

            //Bindeo campos con la lista de resultados.
            this.binder.match(fieldData, bitacora);

            return bitacora;

        }

        //Agrega un nuevo registro en la bitacora.
        public int insert(BitacoraBE bitacora)
        {
            long iduser = (bitacora.usuario != null) ? bitacora.usuario.idusuario : 0;

            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"idusuario",iduser},                
                { "fec_log",bitacora.fecLog.ToString("yyyy-MM-dd HH:mm:ss.fff")},
                { "activity",bitacora.actividad},
                { "payload",bitacora.payload}
            };
            
            return this.getInsert().insertSchema(schema, "bitacora");
        }

        //Traigo la lista de actividades
        public List<string> getActivities()
        {
            //Hago la consulta.
            string sql = "select distinct activity from bitacora;";
            SqlDataReader reader = this.getSelect().query(sql);

            List<string> activList = new List<string>();

            //Loppeo cargando.
            while (reader.Read())
                activList.Add(reader.GetValue(0).ToString());

            return activList;
        }

        //Busqueda por filtros.
        public List<BitacoraBE> search(string activity, string from, string to, string text)
        {
            string where = "";

            //Agrego el filtro de actividad.
            where = (activity == "*") ? "" : $"activity='{activity}' and ";

            //Agrego el filtro de fecha.
            where = where + ($"fec_log>= '{from}' and fec_log<='{to}'");

            //Agrego la busqueda por regext.
            where = where + ((text != "") ? $"and like '%{text}%'" : "");

            Debug.WriteLine(">>>>>"+where);
            /*
            //Instancio el sql builder y ejecuto el query.
            string sql = "select * from permiso p where p.permiso is not null;";
            QuerySelect builder = new QuerySelect();
            SqlDataReader reader = builder.query(sql);

            var lista = new List<BitacoraBE>();

            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("id"));
                string nombre = reader.GetString(reader.GetOrdinal("nombre"));

                Patente c = new Patente();
                c.Id = id;
                c.Nombre = nombre;
                lista.Add(c);
            }

            return lista;*/
            return new List<BitacoraBE>();
        }

    }
}