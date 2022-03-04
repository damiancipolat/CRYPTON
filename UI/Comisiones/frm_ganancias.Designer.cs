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
            this.report_dbt_pay = new System.Windows.Forms.Button();
            this.bitacora_data = new System.Windows.Forms.DataGridView();
            this.report_dbt_type = new System.Windows.Forms.Label();
            this.report_dbt_hasta = new System.Windows.Forms.Label();
            this.report_dbt_desde = new System.Windows.Forms.Label();
            this.date_to_txt = new System.Windows.Forms.DateTimePicker();
            this.date_from_txt = new System.Windows.Forms.DateTimePicker();
            this.report_type_combo = new System.Windows.Forms.ComboBox();
            this.report_dbt_descrip = new System.Windows.Forms.Label();
            this.report_dbt_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.report_dbt_search = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.report_dbt_close = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.report_total_value = new System.Windows.Forms.Label();
            this.report_download = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.bitacora_data)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // report_dbt_pay
            // 
            this.report_dbt_pay.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.report_dbt_pay.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.report_dbt_pay.Location = new System.Drawing.Point(551, 712);
            this.report_dbt_pay.Name = "report_dbt_pay";
            this.report_dbt_pay.Size = new System.Drawing.Size(152, 49);
            this.report_dbt_pay.TabIndex = 58;
            this.report_dbt_pay.Text = "report_dbt_pay";
            this.report_dbt_pay.UseVisualStyleBackColor = false;
            this.report_dbt_pay.Click += new System.EventHandler(this.Btn_close_Click);
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
            // report_dbt_type
            // 
            this.report_dbt_type.AutoSize = true;
            this.report_dbt_type.Location = new System.Drawing.Point(441, 22);
            this.report_dbt_type.Name = "report_dbt_type";
            this.report_dbt_type.Size = new System.Drawing.Size(109, 17);
            this.report_dbt_type.TabIndex = 43;
            this.report_dbt_type.Text = "report_dbt_type";
            // 
            // report_dbt_hasta
            // 
            this.report_dbt_hasta.AutoSize = true;
            this.report_dbt_hasta.Location = new System.Drawing.Point(229, 22);
            this.report_dbt_hasta.Name = "report_dbt_hasta";
            this.report_dbt_hasta.Size = new System.Drawing.Size(117, 17);
            this.report_dbt_hasta.TabIndex = 42;
            this.report_dbt_hasta.Text = "report_dbt_hasta";
            // 
            // report_dbt_desde
            // 
            this.report_dbt_desde.AutoSize = true;
            this.report_dbt_desde.Location = new System.Drawing.Point(19, 22);
            this.report_dbt_desde.Name = "report_dbt_desde";
            this.report_dbt_desde.Size = new System.Drawing.Size(121, 17);
            this.report_dbt_desde.TabIndex = 41;
            this.report_dbt_desde.Text = "report_dbt_desde";
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
            // report_type_combo
            // 
            this.report_type_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.report_type_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.report_type_combo.FormattingEnabled = true;
            this.report_type_combo.Location = new System.Drawing.Point(444, 47);
            this.report_type_combo.Name = "report_type_combo";
            this.report_type_combo.Size = new System.Drawing.Size(189, 28);
            this.report_type_combo.TabIndex = 38;
            this.report_type_combo.SelectedIndexChanged += new System.EventHandler(this.activ_combo_SelectedIndexChanged);
            // 
            // report_dbt_descrip
            // 
            this.report_dbt_descrip.AutoSize = true;
            this.report_dbt_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.report_dbt_descrip.Location = new System.Drawing.Point(109, 62);
            this.report_dbt_descrip.Name = "report_dbt_descrip";
            this.report_dbt_descrip.Size = new System.Drawing.Size(149, 20);
            this.report_dbt_descrip.TabIndex = 55;
            this.report_dbt_descrip.Text = "report_dbt_descrip";
            this.report_dbt_descrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // report_dbt_title
            // 
            this.report_dbt_title.AutoSize = true;
            this.report_dbt_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.report_dbt_title.Location = new System.Drawing.Point(105, 23);
            this.report_dbt_title.Name = "report_dbt_title";
            this.report_dbt_title.Size = new System.Drawing.Size(205, 32);
            this.report_dbt_title.TabIndex = 53;
            this.report_dbt_title.Text = "report_dbt_title";
            this.report_dbt_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.report_dbt_search);
            this.panel1.Controls.Add(this.report_dbt_desde);
            this.panel1.Controls.Add(this.report_dbt_type);
            this.panel1.Controls.Add(this.date_from_txt);
            this.panel1.Controls.Add(this.date_to_txt);
            this.panel1.Controls.Add(this.report_type_combo);
            this.panel1.Controls.Add(this.report_dbt_hasta);
            this.panel1.Location = new System.Drawing.Point(28, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 101);
            this.panel1.TabIndex = 59;
            // 
            // report_dbt_search
            // 
            this.report_dbt_search.BackColor = System.Drawing.Color.LightGreen;
            this.report_dbt_search.Location = new System.Drawing.Point(664, 41);
            this.report_dbt_search.Name = "report_dbt_search";
            this.report_dbt_search.Size = new System.Drawing.Size(145, 38);
            this.report_dbt_search.TabIndex = 40;
            this.report_dbt_search.Text = "report_dbt_search";
            this.report_dbt_search.UseVisualStyleBackColor = false;
            this.report_dbt_search.Click += new System.EventHandler(this.report_dbt_search_Click);
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
            // report_dbt_close
            // 
            this.report_dbt_close.Location = new System.Drawing.Point(715, 711);
            this.report_dbt_close.Name = "report_dbt_close";
            this.report_dbt_close.Size = new System.Drawing.Size(143, 49);
            this.report_dbt_close.TabIndex = 61;
            this.report_dbt_close.Text = "report_dbt_close";
            this.report_dbt_close.UseVisualStyleBackColor = true;
            this.report_dbt_close.Click += new System.EventHandler(this.Button3_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.report_total_value);
            this.panel2.Location = new System.Drawing.Point(28, 635);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(830, 54);
            this.panel2.TabIndex = 62;
            // 
            // report_total_value
            // 
            this.report_total_value.AutoSize = true;
            this.report_total_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.report_total_value.Location = new System.Drawing.Point(18, 14);
            this.report_total_value.Name = "report_total_value";
            this.report_total_value.Size = new System.Drawing.Size(175, 24);
            this.report_total_value.TabIndex = 63;
            this.report_total_value.Text = "report_total_value";
            this.report_total_value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // report_download
            // 
            this.report_download.BackColor = System.Drawing.Color.SandyBrown;
            this.report_download.ForeColor = System.Drawing.Color.White;
            this.report_download.Location = new System.Drawing.Point(384, 713);
            this.report_download.Name = "report_download";
            this.report_download.Size = new System.Drawing.Size(152, 48);
            this.report_download.TabIndex = 63;
            this.report_download.Text = "report_download";
            this.report_download.UseVisualStyleBackColor = false;
            this.report_download.Click += new System.EventHandler(this.report_download_Click);
            // 
            // frm_ganancias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 783);
            this.Controls.Add(this.report_download);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.report_dbt_close);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.report_dbt_pay);
            this.Controls.Add(this.bitacora_data);
            this.Controls.Add(this.report_dbt_descrip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.report_dbt_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ganancias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_ganancias";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frm_ganancias_HelpButtonClicked);
            this.Load += new System.EventHandler(this.frm_ganancias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bitacora_data)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button report_dbt_pay;
        private System.Windows.Forms.DataGridView bitacora_data;
        private System.Windows.Forms.Label report_dbt_type;
        private System.Windows.Forms.Label report_dbt_hasta;
        private System.Windows.Forms.Label report_dbt_desde;
        private System.Windows.Forms.DateTimePicker date_to_txt;
        private System.Windows.Forms.DateTimePicker date_from_txt;
        private System.Windows.Forms.ComboBox report_type_combo;
        private System.Windows.Forms.Label report_dbt_descrip;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label report_dbt_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button report_dbt_search;
        private System.Windows.Forms.Button report_dbt_close;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label report_total_value;
        private System.Windows.Forms.Button report_download;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}