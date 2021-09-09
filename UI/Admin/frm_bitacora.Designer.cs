namespace UI.Admin
{
    partial class frm_bitacora
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_search = new System.Windows.Forms.Button();
            this.activ_combo = new System.Windows.Forms.ComboBox();
            this.search_descrip = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.search_title = new System.Windows.Forms.Label();
            this.date_from_txt = new System.Windows.Forms.DateTimePicker();
            this.date_to_txt = new System.Windows.Forms.DateTimePicker();
            this.from_title = new System.Windows.Forms.Label();
            this.to_title = new System.Windows.Forms.Label();
            this.activ_title = new System.Windows.Forms.Label();
            this.payload_txt = new System.Windows.Forms.TextBox();
            this.text_title = new System.Windows.Forms.Label();
            this.bitacora_data = new System.Windows.Forms.DataGridView();
            this.btn_close = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitacora_data)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.text_title);
            this.panel1.Controls.Add(this.payload_txt);
            this.panel1.Controls.Add(this.activ_title);
            this.panel1.Controls.Add(this.to_title);
            this.panel1.Controls.Add(this.from_title);
            this.panel1.Controls.Add(this.date_to_txt);
            this.panel1.Controls.Add(this.date_from_txt);
            this.panel1.Controls.Add(this.activ_combo);
            this.panel1.Location = new System.Drawing.Point(22, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 381);
            this.panel1.TabIndex = 50;
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.LightGreen;
            this.btn_search.Location = new System.Drawing.Point(23, 315);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(189, 38);
            this.btn_search.TabIndex = 40;
            this.btn_search.Text = "btn_search";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.Btn_search_Click);
            // 
            // activ_combo
            // 
            this.activ_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.activ_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activ_combo.FormattingEnabled = true;
            this.activ_combo.Location = new System.Drawing.Point(23, 56);
            this.activ_combo.Name = "activ_combo";
            this.activ_combo.Size = new System.Drawing.Size(189, 28);
            this.activ_combo.TabIndex = 38;
            // 
            // search_descrip
            // 
            this.search_descrip.AutoSize = true;
            this.search_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_descrip.Location = new System.Drawing.Point(104, 55);
            this.search_descrip.Name = "search_descrip";
            this.search_descrip.Size = new System.Drawing.Size(124, 20);
            this.search_descrip.TabIndex = 49;
            this.search_descrip.Text = "search_descrip";
            this.search_descrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.magnifying_glass;
            this.pictureBox1.Location = new System.Drawing.Point(23, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            // 
            // search_title
            // 
            this.search_title.AutoSize = true;
            this.search_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_title.Location = new System.Drawing.Point(100, 16);
            this.search_title.Name = "search_title";
            this.search_title.Size = new System.Drawing.Size(161, 32);
            this.search_title.TabIndex = 47;
            this.search_title.Text = "search_title";
            this.search_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // date_from_txt
            // 
            this.date_from_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_from_txt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_from_txt.Location = new System.Drawing.Point(23, 122);
            this.date_from_txt.Name = "date_from_txt";
            this.date_from_txt.Size = new System.Drawing.Size(189, 27);
            this.date_from_txt.TabIndex = 39;
            // 
            // date_to_txt
            // 
            this.date_to_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_to_txt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_to_txt.Location = new System.Drawing.Point(23, 191);
            this.date_to_txt.Name = "date_to_txt";
            this.date_to_txt.Size = new System.Drawing.Size(189, 27);
            this.date_to_txt.TabIndex = 40;
            // 
            // from_title
            // 
            this.from_title.AutoSize = true;
            this.from_title.Location = new System.Drawing.Point(20, 100);
            this.from_title.Name = "from_title";
            this.from_title.Size = new System.Drawing.Size(66, 17);
            this.from_title.TabIndex = 41;
            this.from_title.Text = "from_title";
            // 
            // to_title
            // 
            this.to_title.AutoSize = true;
            this.to_title.Location = new System.Drawing.Point(20, 162);
            this.to_title.Name = "to_title";
            this.to_title.Size = new System.Drawing.Size(50, 17);
            this.to_title.TabIndex = 42;
            this.to_title.Text = "to_title";
            // 
            // activ_title
            // 
            this.activ_title.AutoSize = true;
            this.activ_title.Location = new System.Drawing.Point(20, 27);
            this.activ_title.Name = "activ_title";
            this.activ_title.Size = new System.Drawing.Size(67, 17);
            this.activ_title.TabIndex = 43;
            this.activ_title.Text = "activ_title";
            // 
            // payload_txt
            // 
            this.payload_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payload_txt.Location = new System.Drawing.Point(23, 267);
            this.payload_txt.Name = "payload_txt";
            this.payload_txt.Size = new System.Drawing.Size(189, 27);
            this.payload_txt.TabIndex = 44;
            // 
            // text_title
            // 
            this.text_title.AutoSize = true;
            this.text_title.Location = new System.Drawing.Point(25, 240);
            this.text_title.Name = "text_title";
            this.text_title.Size = new System.Drawing.Size(60, 17);
            this.text_title.TabIndex = 45;
            this.text_title.Text = "text_title";
            // 
            // bitacora_data
            // 
            this.bitacora_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bitacora_data.Location = new System.Drawing.Point(280, 103);
            this.bitacora_data.Name = "bitacora_data";
            this.bitacora_data.RowHeadersWidth = 51;
            this.bitacora_data.RowTemplate.Height = 24;
            this.bitacora_data.Size = new System.Drawing.Size(1032, 383);
            this.bitacora_data.TabIndex = 51;
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(1169, 508);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(143, 49);
            this.btn_close.TabIndex = 52;
            this.btn_close.Text = "btn_close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // frm_bitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 574);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.bitacora_data);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.search_descrip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.search_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_bitacora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_bitacora";
            this.Load += new System.EventHandler(this.Frm_bitacora_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitacora_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker date_from_txt;
        private System.Windows.Forms.ComboBox activ_combo;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label search_descrip;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label search_title;
        private System.Windows.Forms.Label text_title;
        private System.Windows.Forms.TextBox payload_txt;
        private System.Windows.Forms.Label activ_title;
        private System.Windows.Forms.Label to_title;
        private System.Windows.Forms.Label from_title;
        private System.Windows.Forms.DateTimePicker date_to_txt;
        private System.Windows.Forms.DataGridView bitacora_data;
        private System.Windows.Forms.Button btn_close;
    }
}