namespace UI.Comisiones
{
    partial class frm_ganancias
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
            this.btn_close = new System.Windows.Forms.Button();
            this.bitacora_data = new System.Windows.Forms.DataGridView();
            this.activ_title = new System.Windows.Forms.Label();
            this.to_title = new System.Windows.Forms.Label();
            this.from_title = new System.Windows.Forms.Label();
            this.date_to_txt = new System.Windows.Forms.DateTimePicker();
            this.date_from_txt = new System.Windows.Forms.DateTimePicker();
            this.activ_combo = new System.Windows.Forms.ComboBox();
            this.search_descrip = new System.Windows.Forms.Label();
            this.search_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bitacora_data)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btn_close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_close.Location = new System.Drawing.Point(552, 640);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(152, 49);
            this.btn_close.TabIndex = 58;
            this.btn_close.Text = "Cobrar comisiones";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // bitacora_data
            // 
            this.bitacora_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bitacora_data.Location = new System.Drawing.Point(28, 233);
            this.bitacora_data.Name = "bitacora_data";
            this.bitacora_data.RowHeadersWidth = 51;
            this.bitacora_data.RowTemplate.Height = 24;
            this.bitacora_data.Size = new System.Drawing.Size(830, 383);
            this.bitacora_data.TabIndex = 57;
            // 
            // activ_title
            // 
            this.activ_title.AutoSize = true;
            this.activ_title.Location = new System.Drawing.Point(441, 22);
            this.activ_title.Name = "activ_title";
            this.activ_title.Size = new System.Drawing.Size(36, 17);
            this.activ_title.TabIndex = 43;
            this.activ_title.Text = "Tipo";
            // 
            // to_title
            // 
            this.to_title.AutoSize = true;
            this.to_title.Location = new System.Drawing.Point(229, 22);
            this.to_title.Name = "to_title";
            this.to_title.Size = new System.Drawing.Size(45, 17);
            this.to_title.TabIndex = 42;
            this.to_title.Text = "Hasta";
            // 
            // from_title
            // 
            this.from_title.AutoSize = true;
            this.from_title.Location = new System.Drawing.Point(19, 22);
            this.from_title.Name = "from_title";
            this.from_title.Size = new System.Drawing.Size(49, 17);
            this.from_title.TabIndex = 41;
            this.from_title.Text = "Desde";
            // 
            // date_to_txt
            // 
            this.date_to_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_to_txt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_to_txt.Location = new System.Drawing.Point(232, 45);
            this.date_to_txt.Name = "date_to_txt";
            this.date_to_txt.Size = new System.Drawing.Size(189, 27);
            this.date_to_txt.TabIndex = 40;
            // 
            // date_from_txt
            // 
            this.date_from_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_from_txt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_from_txt.Location = new System.Drawing.Point(22, 44);
            this.date_from_txt.Name = "date_from_txt";
            this.date_from_txt.Size = new System.Drawing.Size(189, 27);
            this.date_from_txt.TabIndex = 39;
            // 
            // activ_combo
            // 
            this.activ_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.activ_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activ_combo.FormattingEnabled = true;
            this.activ_combo.Location = new System.Drawing.Point(444, 47);
            this.activ_combo.Name = "activ_combo";
            this.activ_combo.Size = new System.Drawing.Size(189, 28);
            this.activ_combo.TabIndex = 38;
            // 
            // search_descrip
            // 
            this.search_descrip.AutoSize = true;
            this.search_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_descrip.Location = new System.Drawing.Point(109, 62);
            this.search_descrip.Name = "search_descrip";
            this.search_descrip.Size = new System.Drawing.Size(531, 20);
            this.search_descrip.TabIndex = 55;
            this.search_descrip.Text = "En esta sección podes consultar las ganancias cobradas / por cobrar.";
            this.search_descrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // search_title
            // 
            this.search_title.AutoSize = true;
            this.search_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_title.Location = new System.Drawing.Point(105, 23);
            this.search_title.Name = "search_title";
            this.search_title.Size = new System.Drawing.Size(247, 32);
            this.search_title.TabIndex = 53;
            this.search_title.Text = "Reporte de cobros";
            this.search_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.from_title);
            this.panel1.Controls.Add(this.activ_title);
            this.panel1.Controls.Add(this.date_from_txt);
            this.panel1.Controls.Add(this.date_to_txt);
            this.panel1.Controls.Add(this.activ_combo);
            this.panel1.Controls.Add(this.to_title);
            this.panel1.Location = new System.Drawing.Point(28, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 101);
            this.panel1.TabIndex = 59;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGreen;
            this.button1.Location = new System.Drawing.Point(664, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 38);
            this.button1.TabIndex = 40;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.money;
            this.pictureBox1.Location = new System.Drawing.Point(28, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(715, 639);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 49);
            this.button3.TabIndex = 61;
            this.button3.Text = "Cerrar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // frm_ganancias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 711);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.bitacora_data);
            this.Controls.Add(this.search_descrip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.search_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ganancias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_ganancias";
            ((System.ComponentModel.ISupportInitialize)(this.bitacora_data)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.DataGridView bitacora_data;
        private System.Windows.Forms.Label activ_title;
        private System.Windows.Forms.Label to_title;
        private System.Windows.Forms.Label from_title;
        private System.Windows.Forms.DateTimePicker date_to_txt;
        private System.Windows.Forms.DateTimePicker date_from_txt;
        private System.Windows.Forms.ComboBox activ_combo;
        private System.Windows.Forms.Label search_descrip;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label search_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}