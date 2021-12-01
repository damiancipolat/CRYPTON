using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics;
using BE;
using BL;
using BL.Exceptions;
using SL;
using VL;
using VL.Exceptions;

namespace UI.Installer
{
    public partial class frm_installer : Form
    {
        //Lista de comandos.
        private string[] commands = {
        /*    "(if not exist \"c:\\crypton-install-tmp\" mkdir c:\\crypton-install-tmp)",
            "sql_server_setup /ACTION=Download /MEDIAPATH=c:\\crypton-install-tmp /MEDIATYPE=Core /QUIET",
            "copy config_bd_file.ini c:\\crypton-install-tmp",
            "copy bd_backup.sql c:\\crypton-install-tmp",*/
            "run_bd_setup.bat"
        };

        //"setup.exe /SECURITYMODE=SQL /SAPWD=\"HJH35uQ2\" /SQLSVCPASSWORD=\"HJH35uQ2\" /AGTSVCPASSWORD=\"HJH35uQ2\" /ASSVCPASSWORD=\"HJH35uQ2\" /ISSVCPASSWORD=\"HJH35uQ2\" /RSSVCPASSWORD=\"HJH35uQ2\" /ConfigurationFile=config_bd_file.ini"+ " && echo OK"

        //Detalle de comandos.
        private string[] info = {
                "Seteo directorio de inicio",
                "Creo directorio temporal si no existe",
                "Creo directorio temporal de sql express",
                "Copio archivo de configuración",
                "Copio dump backup sql",
                "Ejecutando instalación SQL SERVER",
                "",
                "",
                ""
            };

        public frm_installer()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        //Ejecuto en forma de lote.
        private void runBatch() 
        {
            //Ejecuto en forma de  lote.
            CommandLine cmdLin = new CommandLine();

            //Itero ejecutando.
            for (int i = 0; i <= this.commands.Count() - 1; i++)
            {
                string cmd = commands[i];

                //Cambio el detalle.
                this.install_detail.Text = this.commands[i];

                //Ejecuto comando.
                (string stdout, int code) = cmdLin.runCmd(cmd);

                //Analizo el resultado.
                if (stdout.Contains("OK"))                 
                {
                    //Actualizo progreso.
                    this.install_progress.Value = (i + 1);

                    //Delay
                    System.Threading.Thread.Sleep(100);

                    //Dibujo.
                    this.Update();
                }
                else
                {
                    //throw new Exception("No se pudo ejecutar:"+info[i]);
                }                    
            }
        }

        private void install_btn_Click(object sender, EventArgs e)
        {
            try
            {
                //Oculto.
                this.install_detail.Visible = true;
                this.install_progress.Visible = true;
                this.install_progress.Maximum = this.commands.Count();
                this.install_progress.Value = 0;

                //Proceso.
                this.runBatch();
            }
            catch(Exception error){
                //Oculto.
                this.install_detail.Visible = false;
                this.install_progress.Visible = false;
                this.install_progress.Value = 0;

                MessageBox.Show(error.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
