
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
            this.button1 = new System.Windows.Forms.Button();
            this.install_detail = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // install_btn
            // 
            this.install_btn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.install_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.install_btn.ForeColor = System.Drawing.Color.White;
            this.install_btn.Location = new System.Drawing.Point(27, 253);
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
            this.install_message.Location = new System.Drawing.Point(27, 48);
            this.install_message.Multiline = true;
            this.install_message.Name = "install_message";
            this.install_message.ReadOnly = true;
            this.install_message.Size = new System.Drawing.Size(317, 190);
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(26, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(317, 43);
            this.button1.TabIndex = 7;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // install_detail
            // 
            this.install_detail.AutoSize = true;
            this.install_detail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.install_detail.Location = new System.Drawing.Point(59, 265);
            this.install_detail.Name = "install_detail";
            this.install_detail.Size = new System.Drawing.Size(246, 17);
            this.install_detail.TabIndex = 6;
            this.install_detail.Text = "Espere unos minutos por favor...";
            this.install_detail.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.install_detail.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.RoyalBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(27, 302);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(317, 43);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cerrar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // frm_installer
            // 
            this.ClientSize = new System.Drawing.Size(372, 363);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.install_detail);
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
            this.TopMost = true;
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frm_installer_HelpButtonClicked);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_installer_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button install_btn;
        private System.Windows.Forms.TextBox install_message;
        private System.Windows.Forms.Label install_title;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label install_detail;
        private System.Windows.Forms.Button button2;
    }
}
