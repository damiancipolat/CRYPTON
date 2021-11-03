namespace UI
{
    partial class frm_user_status
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_user_status));
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.user_status_title = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.user_status_alias = new System.Windows.Forms.Label();
            this.user_status_label = new System.Windows.Forms.Label();
            this.usr_status_cmb = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_ok.ForeColor = System.Drawing.Color.White;
            this.btn_ok.Location = new System.Drawing.Point(25, 225);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(208, 46);
            this.btn_ok.TabIndex = 44;
            this.btn_ok.Text = "Aceptar";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.Btn_ok_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.LightCoral;
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Location = new System.Drawing.Point(253, 225);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(202, 46);
            this.btn_close.TabIndex = 43;
            this.btn_close.Text = "Cancelar";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // user_status_title
            // 
            this.user_status_title.AutoSize = true;
            this.user_status_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_status_title.Location = new System.Drawing.Point(118, 24);
            this.user_status_title.Name = "user_status_title";
            this.user_status_title.Size = new System.Drawing.Size(249, 36);
            this.user_status_title.TabIndex = 45;
            this.user_status_title.Text = "user_status_title";
            this.user_status_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(25, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // user_status_alias
            // 
            this.user_status_alias.AutoSize = true;
            this.user_status_alias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_status_alias.Location = new System.Drawing.Point(120, 79);
            this.user_status_alias.Name = "user_status_alias";
            this.user_status_alias.Size = new System.Drawing.Size(151, 24);
            this.user_status_alias.TabIndex = 47;
            this.user_status_alias.Text = "user_status_alias";
            // 
            // user_status_label
            // 
            this.user_status_label.AutoSize = true;
            this.user_status_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_status_label.ForeColor = System.Drawing.Color.MediumBlue;
            this.user_status_label.Location = new System.Drawing.Point(25, 125);
            this.user_status_label.Name = "user_status_label";
            this.user_status_label.Size = new System.Drawing.Size(182, 25);
            this.user_status_label.TabIndex = 48;
            this.user_status_label.Text = "user_status_label";
            // 
            // usr_status_cmb
            // 
            this.usr_status_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.usr_status_cmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usr_status_cmb.FormattingEnabled = true;
            this.usr_status_cmb.Location = new System.Drawing.Point(25, 164);
            this.usr_status_cmb.Name = "usr_status_cmb";
            this.usr_status_cmb.Size = new System.Drawing.Size(430, 33);
            this.usr_status_cmb.TabIndex = 49;
            // 
            // frm_user_status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 303);
            this.Controls.Add(this.usr_status_cmb);
            this.Controls.Add(this.user_status_label);
            this.Controls.Add(this.user_status_alias);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.user_status_title);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_user_status";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_user_status";
            this.Load += new System.EventHandler(this.frm_user_status_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label user_status_title;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label user_status_alias;
        private System.Windows.Forms.Label user_status_label;
        private System.Windows.Forms.ComboBox usr_status_cmb;
    }
}