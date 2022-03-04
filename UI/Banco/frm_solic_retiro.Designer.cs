namespace UI.Banco
{
    partial class frm_solic_retiro
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
            this.extract_ars_descrip = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.extract_ars_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.extract_ars_ammount = new System.Windows.Forms.Label();
            this.extract_ars_cbu = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.extract_ars_value_label_descrip = new System.Windows.Forms.Label();
            this.extract_ars_input = new System.Windows.Forms.TextBox();
            this.extract_ars_value_label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // extract_ars_descrip
            // 
            this.extract_ars_descrip.AutoSize = true;
            this.extract_ars_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extract_ars_descrip.Location = new System.Drawing.Point(105, 57);
            this.extract_ars_descrip.Name = "extract_ars_descrip";
            this.extract_ars_descrip.Size = new System.Drawing.Size(157, 20);
            this.extract_ars_descrip.TabIndex = 68;
            this.extract_ars_descrip.Text = "extract_ars_descrip";
            this.extract_ars_descrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.bank;
            this.pictureBox1.Location = new System.Drawing.Point(24, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 67;
            this.pictureBox1.TabStop = false;
            // 
            // extract_ars_title
            // 
            this.extract_ars_title.AutoSize = true;
            this.extract_ars_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extract_ars_title.Location = new System.Drawing.Point(101, 18);
            this.extract_ars_title.Name = "extract_ars_title";
            this.extract_ars_title.Size = new System.Drawing.Size(215, 32);
            this.extract_ars_title.TabIndex = 66;
            this.extract_ars_title.Text = "extract_ars_title";
            this.extract_ars_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.extract_ars_ammount);
            this.panel1.Controls.Add(this.extract_ars_cbu);
            this.panel1.Location = new System.Drawing.Point(24, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 110);
            this.panel1.TabIndex = 69;
            // 
            // extract_ars_ammount
            // 
            this.extract_ars_ammount.AutoSize = true;
            this.extract_ars_ammount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extract_ars_ammount.Location = new System.Drawing.Point(16, 62);
            this.extract_ars_ammount.Name = "extract_ars_ammount";
            this.extract_ars_ammount.Size = new System.Drawing.Size(200, 25);
            this.extract_ars_ammount.TabIndex = 44;
            this.extract_ars_ammount.Text = "extract_ars_ammount";
            // 
            // extract_ars_cbu
            // 
            this.extract_ars_cbu.AutoSize = true;
            this.extract_ars_cbu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extract_ars_cbu.Location = new System.Drawing.Point(16, 20);
            this.extract_ars_cbu.Name = "extract_ars_cbu";
            this.extract_ars_cbu.Size = new System.Drawing.Size(151, 25);
            this.extract_ars_cbu.TabIndex = 43;
            this.extract_ars_cbu.Text = "extract_ars_cbu";
            this.extract_ars_cbu.Click += new System.EventHandler(this.Activ_title_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.LightGreen;
            this.btn_ok.Location = new System.Drawing.Point(318, 407);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(143, 49);
            this.btn_ok.TabIndex = 73;
            this.btn_ok.Text = "btn_ok";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Tomato;
            this.btn_close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_close.Location = new System.Drawing.Point(471, 407);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(143, 49);
            this.btn_close.TabIndex = 72;
            this.btn_close.Text = "btn_close";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // extract_ars_value_label_descrip
            // 
            this.extract_ars_value_label_descrip.AutoSize = true;
            this.extract_ars_value_label_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extract_ars_value_label_descrip.Location = new System.Drawing.Point(22, 51);
            this.extract_ars_value_label_descrip.Name = "extract_ars_value_label_descrip";
            this.extract_ars_value_label_descrip.Size = new System.Drawing.Size(249, 20);
            this.extract_ars_value_label_descrip.TabIndex = 76;
            this.extract_ars_value_label_descrip.Text = "extract_ars_value_label_descrip";
            this.extract_ars_value_label_descrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // extract_ars_input
            // 
            this.extract_ars_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extract_ars_input.Location = new System.Drawing.Point(23, 86);
            this.extract_ars_input.Name = "extract_ars_input";
            this.extract_ars_input.Size = new System.Drawing.Size(328, 30);
            this.extract_ars_input.TabIndex = 75;
            // 
            // extract_ars_value_label
            // 
            this.extract_ars_value_label.AutoSize = true;
            this.extract_ars_value_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extract_ars_value_label.Location = new System.Drawing.Point(19, 19);
            this.extract_ars_value_label.Name = "extract_ars_value_label";
            this.extract_ars_value_label.Size = new System.Drawing.Size(208, 20);
            this.extract_ars_value_label.TabIndex = 74;
            this.extract_ars_value_label.Text = "extract_ars_value_label";
            this.extract_ars_value_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.extract_ars_value_label);
            this.panel2.Controls.Add(this.extract_ars_value_label_descrip);
            this.panel2.Controls.Add(this.extract_ars_input);
            this.panel2.Location = new System.Drawing.Point(24, 238);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(590, 142);
            this.panel2.TabIndex = 77;
            // 
            // frm_solic_retiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 478);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.extract_ars_descrip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.extract_ars_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_solic_retiro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitar extracción";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frm_solic_retiro_HelpButtonClicked);
            this.Load += new System.EventHandler(this.frm_solic_retiro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label extract_ars_descrip;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label extract_ars_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label extract_ars_ammount;
        private System.Windows.Forms.Label extract_ars_cbu;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label extract_ars_value_label_descrip;
        private System.Windows.Forms.TextBox extract_ars_input;
        private System.Windows.Forms.Label extract_ars_value_label;
        private System.Windows.Forms.Panel panel2;
    }
}