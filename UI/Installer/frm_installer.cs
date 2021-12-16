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
using BL.Installer;
using BL.Exceptions;
using SL;
using VL;
using VL.Exceptions;
using DAL.Admin;

namespace UI.Installer
{
    public partial class frm_installer : Form
    {
        //Lista de comandos.
        private string[] commands = {
            "run_bd_setup.bat 1",
            "run_bd_setup.bat 2",
            "run_bd_setup.bat 3",
            "run_bd_setup.bat 4",
            "run_bd_setup.bat 5",
            "run_bd_setup.bat 6",
            "run_bd_setup.bat 7",
            "run_bd_setup.bat 8"
        };

        //Detalle de comandos.
        private string[] info = {
                "Creando directorio temporal...",
                "Extrayendo instalador...",
                "Copiando configuración...",
                "Copiando backup...",
                "Extrayendo archivos del instalador...",
                "Instalando SQL SERVER...",
                "Creando BD y cargando datos...",                
                "Borrando directorio temporal..."
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

        //Ejecutar bat.
        private void runBatch() 
        {
            this.install_progress.Maximum = this.commands.Count();

            //Ejecuto en forma de  lote.
            CommandLine cmdLin = new CommandLine();

            //Itero ejecutando.
            for (int i = 0; i <= this.commands.Count() - 1; i++)
            {
                string cmd = commands[i];

                //Cambio el detalle.
                this.install_detail.Text = this.info[i];

                //Actualizo progreso.
                this.install_progress.Value = (i + 1);

                //Ejecuto comando.
                (string stdout, int code) = cmdLin.runCmd(cmd);

                //Analizo el resultado.
                if (stdout.Contains("OK"))
                {
                    //Delay
                    System.Threading.Thread.Sleep(100);

                    //Dibujo.
                    this.Update();
                }
                else
                {
                    throw new Exception("No se pudo ejecutar:"+info[i]+" cmd:"+cmd+ "salida:"+stdout);
                }                    
            }
        }

        private void install_btn_Click(object sender, EventArgs e)
        {
            try
            {
                this.install_detail.Visible = true;
                this.install_progress.Visible = true;
                this.install_btn.Enabled = false;

                //Ejecuto proceso.
                this.runBatch();

                //Corro validaciones.
                this.install_detail.Text = "Verificando instalación...";
                new InstallerBL().validate();

                //Marco la instlación como terminada.
                new InstallerBL().markAsRequired();

                //Muestro exito.
                MessageBox.Show("Instalación exitosa ya podes usar Crypton!");
                this.Close();
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

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_installer_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void frm_installer_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManual.GetInstance().openForClient("install");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string path = @"C:\Program Files\Default Company Name\Crypton Exchange";
            string cmd = "icacls \"" + path+ "\" /q /c /t /grant Users:F";
            
            CommandLine cmdLin = new CommandLine();
            (string stdout, int code) = cmdLin.runCmd(cmd);

            Debug.WriteLine("-->" + stdout+"   "+code.ToString());
        }
    }
}
