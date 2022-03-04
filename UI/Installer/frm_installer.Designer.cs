
namespace UI.Installer
{
    partial class frm_installer
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.install_btn = new System.Windows.Forms.Button();
            this.install_message = new System.Windows.Forms.TextBox();
            this.install_title = new System.Windows.Forms.Label();
            this.install_progress = new System.Windows.Forms.ProgressBar();
            this.install_detail = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // install_btn
            // 
            this.install_btn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.install_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.install_btn.ForeColor = System.Drawing.Color.White;
            this.install_btn.Location = new System.Drawing.Point(27, 239);
            this.install_btn.Name = "install_btn";
            this.install_btn.Size = new System.Drawing.Size(317, 43);
            this.install_btn.TabIndex = 3;
            this.install_btn.Text = "Iniciar instalación >";
            this.install_btn.UseVisualStyleBackColor = false;
            this.install_btn.Click += new System.EventHandler(this.install_btn_Click);
            // 
            // install_message
            // 
            this.install_message.BackColor = System.Drawing.SystemColors.Info;
            this.install_message.Location = new System.Drawing.Point(27, 49);
            this.install_message.Multiline = true;
            this.install_message.Name = "install_message";
            this.install_message.ReadOnly = true;
            this.install_message.Size = new System.Drawing.Size(317, 92);
            this.install_message.TabIndex = 4;
            this.install_message.Text = "Para terminar la instalación es necesario:\r\n- Crear BD.\r\n- Cargar datos de sistem" +
    "a.\r\n\r\nPara esto instalaremos un SQL SERVER 2019 expres.\r\nEsta etapa puede durar " +
    "varios minutos!.";
            // 
            // install_title
            // 
            this.install_title.AutoSize = true;
            this.install_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.install_title.Location = new System.Drawing.Point(28, 14);
            this.install_title.Name = "install_title";
            this.install_title.Size = new System.Drawing.Size(199, 24);
            this.install_title.TabIndex = 5;
            this.install_title.Text = "Terminar instalación";
            // 
            // install_progress
            // 
            this.install_progress.Location = new System.Drawing.Point(31, 191);
            this.install_progress.MarqueeAnimationSpeed = 7;
            this.install_progress.Maximum = 7;
            this.install_progress.Name = "install_progress";
            this.install_progress.Size = new System.Drawing.Size(313, 23);
            this.install_progress.Step = 0;
            this.install_progress.TabIndex = 0;
            this.install_progress.Visible = false;
            // 
            // install_detail
            // 
            this.install_detail.AutoSize = true;
            this.install_detail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.install_detail.Location = new System.Drawing.Point(32, 161);
            this.install_detail.Name = "install_detail";
            this.install_detail.Size = new System.Drawing.Size(162, 17);
            this.install_detail.TabIndex = 6;
            this.install_detail.Text = "Copiando archivos....";
            this.install_detail.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(26, 297);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(317, 43);
            this.button1.TabIndex = 7;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(538, 206);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 45);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(448, 53);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 49);
            this.button3.TabIndex = 9;
            this.button3.Text = "1";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(525, 53);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(62, 49);
            this.button4.TabIndex = 10;
            this.button4.Text = "2";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(611, 53);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(62, 49);
            this.button5.TabIndex = 11;
            this.button5.Text = "3";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(448, 119);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(62, 49);
            this.button6.TabIndex = 12;
            this.button6.Text = "4";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(527, 121);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(60, 47);
            this.button7.TabIndex = 13;
            this.button7.Text = "5";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(611, 121);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(62, 49);
            this.button8.TabIndex = 14;
            this.button8.Text = "6";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(448, 191);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(62, 49);
            this.button9.TabIndex = 15;
            this.button9.Text = "7";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // frm_installer
            // 
            this.ClientSize = new System.Drawing.Size(1014, 363);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.install_detail);
            this.Controls.Add(this.install_progress);
            this.Controls.Add(this.install_title);
            this.Controls.Add(this.install_message);
            this.Controls.Add(this.install_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_installer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instalación";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frm_installer_HelpButtonClicked);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_installer_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button install_btn;
        private System.Windows.Forms.TextBox install_message;
        private System.Windows.Forms.Label install_title;
        private System.Windows.Forms.ProgressBar install_progress;
        private System.Windows.Forms.Label install_detail;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
    }
}
