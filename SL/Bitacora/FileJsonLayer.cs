using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using BE;


namespace SL
{
    public class FileJsonLayer
    {
        public FileJsonLayer() { }

        //Receive a log be and convert to json format.
        private string serializeLog(BitacoraBE logBE)
        {
            // Create a stream to serialize the object to.
            var ms = new MemoryStream();
            var log = logBE;

            // Serializer the User object to the stream.
            var ser = new DataContractJsonSerializer(typeof(BitacoraBE));
            ser.WriteObject(ms, log);
            byte[] json = ms.ToArray();
            ms.Close();

            return Encoding.UTF8.GetString(json, 0, json.Length);
        }

        //rEGISTRO.
        public void log(string actividad, string payload)
        {
            //Creo la entidad bitacora.
            BitacoraBE logBE = new BitacoraBE();
            logBE.payload = payload;
            logBE.usuario = Session.GetInstance().getUser();
            logBE.fecLog = DateTime.Now;
            logBE.actividad = actividad != null ? actividad : "LOG";

            //Guardo en el archivo un registro en formato json.
            string path = AppDomain.CurrentDomain.BaseDirectory + "jsonLog.json";
            Debug.WriteLine("Write JSON log in:"+path);

            //Obtengo el json
            string json = this.serializeLog(logBE);

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(json);
            }
        }
    }
}
