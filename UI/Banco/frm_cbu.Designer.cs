namespace UI.Banco
{
    partial class frm_cbu
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
            this.cbu_title_descip = new System.Windows.Forms.Label();
            this.cbu_title = new System.Windows.Forms.Label();
            this.txt_cbu = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_copy = new System.Windows.Forms.Button();
            this.txt_bank = new System.Windows.Forms.Label();
            this.txt_alias = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.warning_title = new System.Windows.Forms.Label();
            this.warning_title_descrip = new System.Windows.Forms.Label();
            this.btn_profile = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbu_title_descip
            // 
            this.cbu_title_descip.AutoSize = true;
            this.cbu_title_descip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbu_title_descip.Location = new System.Drawing.Point(100, 58);
            this.cbu_title_descip.Name = "cbu_title_descip";
            this.cbu_title_descip.Size = new System.Drawing.Size(130, 20);
            this.cbu_title_descip.TabIndex = 65;
            this.cbu_title_descip.Text = "cbu_title_descip";
            this.cbu_title_descip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbu_title
            // 
            this.cbu_title.AutoSize = true;
            this.cbu_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbu_title.Location = new System.Drawing.Point(96, 19);
            this.cbu_title.Name = "cbu_title";
            this.cbu_title.Size = new System.Drawing.Size(122, 32);
            this.cbu_title.TabIndex = 63;
            this.cbu_title.Text = "cbu_title";
            this.cbu_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_cbu
            // 
            this.txt_cbu.AutoSize = true;
            this.txt_cbu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cbu.Location = new System.Drawing.Point(16, 20);
            this.txt_cbu.Name = "txt_cbu";
            this.txt_cbu.Size = new System.Drawing.Size(75, 25);
            this.txt_cbu.TabIndex = 43;
            this.txt_cbu.Text = "txt_cbu";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_copy);
            this.panel1.Controls.Add(this.txt_bank);
            this.panel1.Controls.Add(this.txt_alias);
            this.panel1.Controls.Add(this.txt_cbu);
            this.panel1.Location = new System.Drawing.Point(19, 121);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 152);
            this.panel1.TabIndex = 66;
            // 
            // btn_copy
            // 
            this.btn_copy.Location = new System.Drawing.Point(475, 16);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(66, 38);
            this.btn_copy.TabIndex = 68;
            this.btn_copy.Text = "btn_copy";
            this.btn_copy.UseVisualStyleBackColor = true;
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // txt_bank
            // 
            this.txt_bank.AutoSize = true;
            this.txt_bank.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_bank.Location = new System.Drawing.Point(16, 103);
            this.txt_bank.Name = "txt_bank";
            this.txt_bank.Size = new System.Drawing.Size(86, 25);
            this.txt_bank.TabIndex = 67;
            this.txt_bank.Text = "txt_bank";
            // 
            // txt_alias
            // 
            this.txt_alias.AutoSize = true;
            this.txt_alias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_alias.Location = new System.Drawing.Point(16, 62);
            this.txt_alias.Name = "txt_alias";
            this.txt_alias.Size = new System.Drawing.Size(83, 25);
            this.txt_alias.TabIndex = 44;
            this.txt_alias.Text = "txt_alias";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.bank;
            this.pictureBox1.Location = new System.Drawing.Point(19, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 64;
            this.pictureBox1.TabStop = false;
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(433, 374);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(143, 49);
            this.btn_close.TabIndex = 67;
            this.btn_close.Text = "btn_close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // warning_title
            // 
            this.warning_title.AutoSize = true;
            this.warning_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warning_title.Location = new System.Drawing.Point(13, 293);
            this.warning_title.Name = "warning_title";
            this.warning_title.Size = new System.Drawing.Size(103, 20);
            this.warning_title.TabIndex = 68;
            this.warning_title.Text = "warning_title";
            this.warning_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // warning_title_descrip
            // 
            this.warning_title_descrip.AutoSize = true;
            this.warning_title_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warning_title_descrip.Location = new System.Drawing.Point(12, 320);
            this.warning_title_descrip.Name = "warning_title_descrip";
            this.warning_title_descrip.Size = new System.Drawing.Size(167, 20);
            this.warning_title_descrip.TabIndex = 69;
            this.warning_title_descrip.Text = "warning_title_descrip";
            this.warning_title_descrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_profile
            // 
            this.btn_profile.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_profile.Location = new System.Drawing.Point(275, 374);
            this.btn_profile.Name = "btn_profile";
            this.btn_profile.Size = new System.Drawing.Size(143, 49);
            this.btn_profile.TabIndex = 70;
            this.btn_profile.Text = "btn_profile";
            this.btn_profile.UseVisualStyleBackColor = false;
            this.btn_profile.Click += new System.EventHandler(this.btn_profile_Click);
            // 
            // frm_cbu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 446);
            this.Controls.Add(this.btn_profile);
            this.Controls.Add(this.warning_title_descrip);
            this.Controls.Add(this.warning_title);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbu_title_descip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbu_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_cbu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de CBU";
            this.Load += new System.EventHandler(this.frm_cbu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cbu_title_descip;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label cbu_title;
        private System.Windows.Forms.Label txt_cbu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label warning_title;
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.Label txt_bank;
        private System.Windows.Forms.Label txt_alias;
        private System.Windows.Forms.Label warning_title_descrip;
        private System.Windows.Forms.Button btn_profile;
    }
}