using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace UI.Installer
{
    public class CommandLine
    {
        //Ejecuto el proceso.
        public (string, int) runCmd(string strCmdText,string binary=null)
        {
            Debug.WriteLine("********************************");
            Debug.WriteLine("> Command:" + strCmdText);

            //Armo el proceso.
            Process process = new Process();
            process.StartInfo.FileName = (binary==null)?"cmd.exe":binary;
            //process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.StandardInput.WriteLine(strCmdText);
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();

            string stdout = process.StandardOutput.ReadToEnd();

            Debug.WriteLine("> Command stdout:" + stdout);
            Debug.WriteLine("********************************");
            Debug.WriteLine("");

            return (stdout, process.ExitCode);
        }
    }
}