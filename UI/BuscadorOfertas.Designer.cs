namespace UI
{
    partial class BuscadorOfertas
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
            this.search_title = new System.Windows.Forms.Label();
            this.search_descrip = new System.Windows.Forms.Label();
            this.moneda_ofrece = new System.Windows.Forms.ComboBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_by = new System.Windows.Forms.Label();
            this.moneda_pide = new System.Windows.Forms.ComboBox();
            this.usr_search_data = new System.Windows.Forms.DataGridView();
            this.btn_close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_view = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.usr_search_data)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // search_title
            // 
            this.search_title.AutoSize = true;
            this.search_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_title.Location = new System.Drawing.Point(98, 12);
            this.search_title.Name = "search_title";
            this.search_title.Size = new System.Drawing.Size(161, 32);
            this.search_title.TabIndex = 0;
            this.search_title.Text = "search_title";
            this.search_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // search_descrip
            // 
            this.search_descrip.AutoSize = true;
            this.search_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_descrip.Location = new System.Drawing.Point(102, 52);
            this.search_descrip.Name = "search_descrip";
            this.search_descrip.Size = new System.Drawing.Size(124, 20);
            this.search_descrip.TabIndex = 37;
            this.search_descrip.Text = "search_descrip";
            this.search_descrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.search_descrip.Click += new System.EventHandler(this.Label2_Click);
            // 
            // moneda_ofrece
            // 
            this.moneda_ofrece.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.moneda_ofrece.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moneda_ofrece.FormattingEnabled = true;
            this.moneda_ofrece.Location = new System.Drawing.Point(18, 16);
            this.moneda_ofrece.Name = "moneda_ofrece";
            this.moneda_ofrece.Size = new System.Drawing.Size(254, 28);
            this.moneda_ofrece.TabIndex = 38;
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.LightGreen;
            this.btn_search.Location = new System.Drawing.Point(660, 12);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(119, 38);
            this.btn_search.TabIndex = 40;
            this.btn_search.Text = "btn_search";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.Btn_buscar_Click);
            // 
            // btn_by
            // 
            this.btn_by.AutoSize = true;
            this.btn_by.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_by.Location = new System.Drawing.Point(287, 20);
            this.btn_by.Name = "btn_by";
            this.btn_by.Size = new System.Drawing.Size(64, 20);
            this.btn_by.TabIndex = 41;
            this.btn_by.Text = "btn_by";
            this.btn_by.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // moneda_pide
            // 
            this.moneda_pide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.moneda_pide.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moneda_pide.FormattingEnabled = true;
            this.moneda_pide.Location = new System.Drawing.Point(362, 16);
            this.moneda_pide.Name = "moneda_pide";
            this.moneda_pide.Size = new System.Drawing.Size(254, 28);
            this.moneda_pide.TabIndex = 42;
            // 
            // usr_search_data
            // 
            this.usr_search_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usr_search_data.Location = new System.Drawing.Point(26, 175);
            this.usr_search_data.Name = "usr_search_data";
            this.usr_search_data.RowHeadersWidth = 51;
            this.usr_search_data.RowTemplate.Height = 24;
            this.usr_search_data.Size = new System.Drawing.Size(933, 383);
            this.usr_search_data.TabIndex = 43;
            this.usr_search_data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Usr_data_CellContentClick);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(816, 576);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(143, 49);
            this.btn_close.TabIndex = 44;
            this.btn_close.Text = "btn_close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.Publish_ok_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.moneda_pide);
            this.panel1.Controls.Add(this.moneda_ofrece);
            this.panel1.Controls.Add(this.btn_by);
            this.panel1.Location = new System.Drawing.Point(164, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(795, 64);
            this.panel1.TabIndex = 45;
            // 
            // btn_view
            // 
            this.btn_view.BackColor = System.Drawing.Color.Bisque;
            this.btn_view.Location = new System.Drawing.Point(26, 95);
            this.btn_view.Name = "btn_view";
            this.btn_view.Size = new System.Drawing.Size(119, 64);
            this.btn_view.TabIndex = 46;
            this.btn_view.Text = "btn_view";
            this.btn_view.UseVisualStyleBackColor = false;
            this.btn_view.Click += new System.EventHandler(this.Button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.magnifying_glass;
            this.pictureBox1.Location = new System.Drawing.Point(26, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // BuscadorOfertas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 645);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_view);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.usr_search_data);
            this.Controls.Add(this.search_descrip);
            this.Controls.Add(this.search_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuscadorOfertas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscador form";
            this.Load += new System.EventHandler(this.BuscadorOfertas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usr_search_data)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label search_title;
        private System.Windows.Forms.Label search_descrip;
        private System.Windows.Forms.ComboBox moneda_ofrece;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label btn_by;
        private System.Windows.Forms.ComboBox moneda_pide;
        private System.Windows.Forms.DataGridView usr_search_data;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_view;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}