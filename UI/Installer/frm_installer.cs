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

        private void install_btn_Click(object sender, EventArgs e)
        {
            try
            {
                //Ocultos componentes
                this.install_detail.Visible = true;
                this.install_btn.Visible = false;
                this.install_btn.Enabled = false;

                //Ejecuto proceso.
                CommandLine cmdLin = new CommandLine();

                //Etapa 1
                this.install_detail.Text = "Aguarde por favor, etapa 1...";
                this.Update();
                cmdLin.runCmd("run_bd_setup_stage_1.bat");

                //Etapa 2
                /*
                this.install_detail.Text = "Aguarde por favor, etapa 2...";
                this.Update();
                cmdLin.runCmd("run_bd_setup_stage_2.bat");
                */

                //Corro validaciones.
                this.install_detail.Text = "Verificando instalación...";
                this.Update();
                new InstallerBL().validate();

                //Marco la instlación como terminada.
                new InstallerBL().markAsRequired();

                //Muestro exito.
                this.install_detail.Text = "Instalación exitosa ya podes usar Crypton!";
                this.Update();

                //Manejo botones.
                this.button1.Visible = false;
                this.button2.Visible = true;
            }
            catch(Exception error){
                this.install_message.Text = error.Message;
                this.button2.Visible = false;
                this.install_detail.Visible = true;
                this.install_detail.Text = "Hubo un error en la instalacion...";
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
        }

        private void button9_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
