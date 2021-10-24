using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Globalization;
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

            /*
            //Actualizo el tipo de usuario que es un enum.            
            Dictionary<string, object> mapa = this.getParser().rowToDictionary(fieldData);

            //Bindeo campos.
            UsuarioBE user = new UsuarioDAL().findById((long)mapa["idusuario"]);

            if (user != null)
            {
                userTarget.alias = user.alias;
                userTarget.nombre = user.nombre;
                userTarget.apellido = user.apellido;
                userTarget.email = user.email;
                userTarget.tipoUsuario = UsuarioTipo.CLIENTE;
            }
            */








            return bitacora;

        }

        //Agrega un nuevo registro en la bitacora.
        public int insert(BitacoraBE bitacora)
        {
            long iduser = (bitacora.usuario != null) ? bitacora.usuario.idusuario : 0;

            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"idusuario",iduser},                
                { "fec_log",bitacora.fecLog.ToString("yyyy-mm-dd HH:MM:ss.fff")},
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

            //Convierto formato de fechas.
            from = DateTime.ParseExact(from, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
            to = DateTime.ParseExact(to,"dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
            
            //Agrego el filtro de fecha.
            where = where + ($"fec_log>= '{from}' and fec_log<='{to}'");

            //Agrego la busqueda por regext.
            where = where + ((text != "") ? $"and payload like '%{text}%'" : "");

            //Instancio el sql builder y ejecuto el query.
            string sql = $"select id,idusuario,activity,payload,fec_log from bitacora where {where}";
            QuerySelect builder = new QuerySelect();
            SqlDataReader reader = builder.query(sql);           

            var lista = new List<BitacoraBE>();

            while (reader.Read())
            {                
                int iduser = Convert.ToInt32(reader.GetValue(1));

                //Armo la estructura.
                BitacoraBE logBE = new BitacoraBE();
                logBE.id = Convert.ToInt32(reader.GetValue(0));
                logBE.usuario = (iduser!=0)?new UsuarioDAL().findById(Convert.ToInt32(reader.GetValue(1))):null;
                logBE.actividad = reader.GetValue(2).ToString();
                logBE.payload = reader.GetValue(3).ToString();
                logBE.fecLog = Convert.ToDateTime(reader.GetValue(4));
                
                lista.Add(logBE);
            }

            return lista;
        }
    }
}