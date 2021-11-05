namespace UI.Comisiones
{
    partial class frm_cobrar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cobrar_btn_process = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.list_comision_data = new System.Windows.Forms.DataGridView();
            this.cobrar_frm_title_descrip = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cobrar_frm_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cobrar_total_label = new System.Windows.Forms.Label();
            this.cobrar_waiting = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.list_comision_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cobrar_btn_process
            // 
            this.cobrar_btn_process.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cobrar_btn_process.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cobrar_btn_process.Location = new System.Drawing.Point(666, 9);
            this.cobrar_btn_process.Name = "cobrar_btn_process";
            this.cobrar_btn_process.Size = new System.Drawing.Size(151, 49);
            this.cobrar_btn_process.TabIndex = 40;
            this.cobrar_btn_process.Text = "Cobrar comisiones";
            this.cobrar_btn_process.UseVisualStyleBackColor = false;
            this.cobrar_btn_process.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(712, 637);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(143, 49);
            this.btn_close.TabIndex = 64;
            this.btn_close.Text = "Cerrar";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // list_comision_data
            // 
            this.list_comision_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.list_comision_data.Location = new System.Drawing.Point(25, 204);
            this.list_comision_data.Name = "list_comision_data";
            this.list_comision_data.RowHeadersWidth = 51;
            this.list_comision_data.RowTemplate.Height = 24;
            this.list_comision_data.Size = new System.Drawing.Size(830, 413);
            this.list_comision_data.TabIndex = 63;
            // 
            // cobrar_frm_title_descrip
            // 
            this.cobrar_frm_title_descrip.AutoSize = true;
            this.cobrar_frm_title_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cobrar_frm_title_descrip.Location = new System.Drawing.Point(106, 63);
            this.cobrar_frm_title_descrip.Name = "cobrar_frm_title_descrip";
            this.cobrar_frm_title_descrip.Size = new System.Drawing.Size(191, 20);
            this.cobrar_frm_title_descrip.TabIndex = 62;
            this.cobrar_frm_title_descrip.Text = "cobrar_frm_title_descrip";
            this.cobrar_frm_title_descrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.money;
            this.pictureBox1.Location = new System.Drawing.Point(25, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 61;
            this.pictureBox1.TabStop = false;
            // 
            // cobrar_frm_title
            // 
            this.cobrar_frm_title.AutoSize = true;
            this.cobrar_frm_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cobrar_frm_title.Location = new System.Drawing.Point(102, 24);
            this.cobrar_frm_title.Name = "cobrar_frm_title";
            this.cobrar_frm_title.Size = new System.Drawing.Size(211, 32);
            this.cobrar_frm_title.TabIndex = 60;
            this.cobrar_frm_title.Text = "cobrar_frm_title";
            this.cobrar_frm_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cobrar_btn_process);
            this.panel1.Controls.Add(this.cobrar_total_label);
            this.panel1.Location = new System.Drawing.Point(25, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 69);
            this.panel1.TabIndex = 65;
            // 
            // cobrar_total_label
            // 
            this.cobrar_total_label.AutoSize = true;
            this.cobrar_total_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cobrar_total_label.Location = new System.Drawing.Point(16, 20);
            this.cobrar_total_label.Name = "cobrar_total_label";
            this.cobrar_total_label.Size = new System.Drawing.Size(166, 25);
            this.cobrar_total_label.TabIndex = 43;
            this.cobrar_total_label.Text = "cobrar_total_label";
            // 
            // cobrar_waiting
            // 
            this.cobrar_waiting.AutoSize = true;
            this.cobrar_waiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cobrar_waiting.Location = new System.Drawing.Point(31, 650);
            this.cobrar_waiting.Name = "cobrar_waiting";
            this.cobrar_waiting.Size = new System.Drawing.Size(118, 20);
            this.cobrar_waiting.TabIndex = 66;
            this.cobrar_waiting.Text = "cobrar_waiting";
            this.cobrar_waiting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cobrar_waiting.Visible = false;
            // 
            // frm_cobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 712);
            this.Controls.Add(this.cobrar_waiting);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.list_comision_data);
            this.Controls.Add(this.cobrar_frm_title_descrip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cobrar_frm_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_cobrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_cobrar";
            this.Load += new System.EventHandler(this.frm_cobrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.list_comision_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cobrar_btn_process;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.DataGridView list_comision_data;
        private System.Windows.Forms.Label cobrar_frm_title_descrip;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label cobrar_frm_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label cobrar_total_label;
        private System.Windows.Forms.Label cobrar_waiting;
    }
}