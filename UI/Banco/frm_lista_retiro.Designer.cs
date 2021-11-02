namespace UI.Banco
{
    partial class frm_lista_retiro
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
            this.btn_retiro_reject = new System.Windows.Forms.Button();
            this.btn_retiro_ok = new System.Windows.Forms.Button();
            this.retiro_list_data = new System.Windows.Forms.DataGridView();
            this.btn_close = new System.Windows.Forms.Button();
            this.retiro_title_descrip = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.retiro_title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.retiro_list_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_retiro_reject
            // 
            this.btn_retiro_reject.BackColor = System.Drawing.Color.LightSalmon;
            this.btn_retiro_reject.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_retiro_reject.Location = new System.Drawing.Point(587, 120);
            this.btn_retiro_reject.Name = "btn_retiro_reject";
            this.btn_retiro_reject.Size = new System.Drawing.Size(119, 38);
            this.btn_retiro_reject.TabIndex = 76;
            this.btn_retiro_reject.Text = "btn_retiro_reject";
            this.btn_retiro_reject.UseVisualStyleBackColor = false;
            this.btn_retiro_reject.Click += new System.EventHandler(this.btn_retiro_reject_Click);
            // 
            // btn_retiro_ok
            // 
            this.btn_retiro_ok.BackColor = System.Drawing.Color.LightGreen;
            this.btn_retiro_ok.Location = new System.Drawing.Point(455, 120);
            this.btn_retiro_ok.Name = "btn_retiro_ok";
            this.btn_retiro_ok.Size = new System.Drawing.Size(119, 38);
            this.btn_retiro_ok.TabIndex = 81;
            this.btn_retiro_ok.Text = "btn_retiro_ok";
            this.btn_retiro_ok.UseVisualStyleBackColor = false;
            this.btn_retiro_ok.Click += new System.EventHandler(this.btn_retiro_ok_Click);
            // 
            // retiro_list_data
            // 
            this.retiro_list_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.retiro_list_data.Location = new System.Drawing.Point(29, 182);
            this.retiro_list_data.Name = "retiro_list_data";
            this.retiro_list_data.RowHeadersWidth = 51;
            this.retiro_list_data.RowTemplate.Height = 24;
            this.retiro_list_data.Size = new System.Drawing.Size(677, 486);
            this.retiro_list_data.TabIndex = 79;
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(563, 686);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(143, 49);
            this.btn_close.TabIndex = 78;
            this.btn_close.Text = "Cerrar";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // retiro_title_descrip
            // 
            this.retiro_title_descrip.AutoSize = true;
            this.retiro_title_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retiro_title_descrip.Location = new System.Drawing.Point(110, 69);
            this.retiro_title_descrip.Name = "retiro_title_descrip";
            this.retiro_title_descrip.Size = new System.Drawing.Size(148, 20);
            this.retiro_title_descrip.TabIndex = 77;
            this.retiro_title_descrip.Text = "retiro_title_descrip";
            this.retiro_title_descrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.bank;
            this.pictureBox1.Location = new System.Drawing.Point(29, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 75;
            this.pictureBox1.TabStop = false;
            // 
            // retiro_title
            // 
            this.retiro_title.AutoSize = true;
            this.retiro_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retiro_title.Location = new System.Drawing.Point(106, 30);
            this.retiro_title.Name = "retiro_title";
            this.retiro_title.Size = new System.Drawing.Size(141, 32);
            this.retiro_title.TabIndex = 74;
            this.retiro_title.Text = "retiro_title";
            this.retiro_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frm_lista_retiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 755);
            this.Controls.Add(this.btn_retiro_reject);
            this.Controls.Add(this.btn_retiro_ok);
            this.Controls.Add(this.retiro_list_data);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.retiro_title_descrip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.retiro_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_lista_retiro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitudes de extraccion.";
            this.Load += new System.EventHandler(this.frm_lista_retiro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.retiro_list_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_retiro_reject;
        private System.Windows.Forms.Button btn_retiro_ok;
        private System.Windows.Forms.DataGridView retiro_list_data;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label retiro_title_descrip;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label retiro_title;
    }
}