using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace SL
{
    public class FileLayer : ILogger
    {
        public FileLayer() { }

        public void log(string actividad, string payload)
        {
            string data = actividad+":"+payload;
            string path = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
            Debug.WriteLine("Write log in:"+path);

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(data);
            }
        }
    }
}
