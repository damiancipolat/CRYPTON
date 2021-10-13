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
            this.button1 = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.bitacora_data = new System.Windows.Forms.DataGridView();
            this.search_descrip = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.search_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.activ_title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bitacora_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(666, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 49);
            this.button1.TabIndex = 40;
            this.button1.Text = "Cobrar comisiones";
            this.button1.UseVisualStyleBackColor = false;
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
            // bitacora_data
            // 
            this.bitacora_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bitacora_data.Location = new System.Drawing.Point(25, 204);
            this.bitacora_data.Name = "bitacora_data";
            this.bitacora_data.RowHeadersWidth = 51;
            this.bitacora_data.RowTemplate.Height = 24;
            this.bitacora_data.Size = new System.Drawing.Size(830, 413);
            this.bitacora_data.TabIndex = 63;
            // 
            // search_descrip
            // 
            this.search_descrip.AutoSize = true;
            this.search_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_descrip.Location = new System.Drawing.Point(106, 63);
            this.search_descrip.Name = "search_descrip";
            this.search_descrip.Size = new System.Drawing.Size(426, 20);
            this.search_descrip.TabIndex = 62;
            this.search_descrip.Text = "Aqui se ve la lista de comisiones pendientes por cobrar.";
            this.search_descrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // search_title
            // 
            this.search_title.AutoSize = true;
            this.search_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_title.Location = new System.Drawing.Point(102, 24);
            this.search_title.Name = "search_title";
            this.search_title.Size = new System.Drawing.Size(251, 32);
            this.search_title.TabIndex = 60;
            this.search_title.Text = "Cobrar comisiones";
            this.search_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.activ_title);
            this.panel1.Location = new System.Drawing.Point(25, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 69);
            this.panel1.TabIndex = 65;
            // 
            // activ_title
            // 
            this.activ_title.AutoSize = true;
            this.activ_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activ_title.Location = new System.Drawing.Point(16, 20);
            this.activ_title.Name = "activ_title";
            this.activ_title.Size = new System.Drawing.Size(370, 25);
            this.activ_title.TabIndex = 43;
            this.activ_title.Text = "Total pendiente por cobrar:  AR$ 150.250";
            // 
            // frm_cobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 712);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.bitacora_data);
            this.Controls.Add(this.search_descrip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.search_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_cobrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_cobrar";
            ((System.ComponentModel.ISupportInitialize)(this.bitacora_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.DataGridView bitacora_data;
        private System.Windows.Forms.Label search_descrip;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label search_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label activ_title;
    }
}