namespace UI.Banco
{
    partial class frm_buscar_cbu
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
            this.search_cbu_title_descrip = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.search_cbu_title = new System.Windows.Forms.Label();
            this.search_cbu_btn_close = new System.Windows.Forms.Button();
            this.usr_search_data = new System.Windows.Forms.DataGridView();
            this.search_cbu_txt_input = new System.Windows.Forms.TextBox();
            this.search_cbu_btn_search = new System.Windows.Forms.Button();
            this.search_cbu_write = new System.Windows.Forms.Label();
            this.search_cbu_btn_cashin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usr_search_data)).BeginInit();
            this.SuspendLayout();
            // 
            // search_cbu_title_descrip
            // 
            this.search_cbu_title_descrip.AutoSize = true;
            this.search_cbu_title_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_cbu_title_descrip.Location = new System.Drawing.Point(105, 60);
            this.search_cbu_title_descrip.Name = "search_cbu_title_descrip";
            this.search_cbu_title_descrip.Size = new System.Drawing.Size(196, 20);
            this.search_cbu_title_descrip.TabIndex = 68;
            this.search_cbu_title_descrip.Text = "search_cbu_title_descrip";
            this.search_cbu_title_descrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.bank;
            this.pictureBox1.Location = new System.Drawing.Point(24, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 67;
            this.pictureBox1.TabStop = false;
            // 
            // search_cbu_title
            // 
            this.search_cbu_title.AutoSize = true;
            this.search_cbu_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_cbu_title.Location = new System.Drawing.Point(101, 21);
            this.search_cbu_title.Name = "search_cbu_title";
            this.search_cbu_title.Size = new System.Drawing.Size(222, 32);
            this.search_cbu_title.TabIndex = 66;
            this.search_cbu_title.Text = "search_cbu_title";
            this.search_cbu_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // search_cbu_btn_close
            // 
            this.search_cbu_btn_close.Location = new System.Drawing.Point(558, 677);
            this.search_cbu_btn_close.Name = "search_cbu_btn_close";
            this.search_cbu_btn_close.Size = new System.Drawing.Size(143, 49);
            this.search_cbu_btn_close.TabIndex = 69;
            this.search_cbu_btn_close.Text = "search_cbu_btn_close";
            this.search_cbu_btn_close.UseVisualStyleBackColor = true;
            this.search_cbu_btn_close.Click += new System.EventHandler(this.search_cbu_btn_close_Click);
            // 
            // usr_search_data
            // 
            this.usr_search_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usr_search_data.Location = new System.Drawing.Point(24, 215);
            this.usr_search_data.Name = "usr_search_data";
            this.usr_search_data.RowHeadersWidth = 51;
            this.usr_search_data.RowTemplate.Height = 24;
            this.usr_search_data.Size = new System.Drawing.Size(677, 444);
            this.usr_search_data.TabIndex = 70;
            // 
            // search_cbu_txt_input
            // 
            this.search_cbu_txt_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_cbu_txt_input.Location = new System.Drawing.Point(24, 158);
            this.search_cbu_txt_input.Name = "search_cbu_txt_input";
            this.search_cbu_txt_input.Size = new System.Drawing.Size(286, 30);
            this.search_cbu_txt_input.TabIndex = 71;
            // 
            // search_cbu_btn_search
            // 
            this.search_cbu_btn_search.BackColor = System.Drawing.Color.LightGreen;
            this.search_cbu_btn_search.Location = new System.Drawing.Point(327, 155);
            this.search_cbu_btn_search.Name = "search_cbu_btn_search";
            this.search_cbu_btn_search.Size = new System.Drawing.Size(119, 38);
            this.search_cbu_btn_search.TabIndex = 72;
            this.search_cbu_btn_search.Text = "search_cbu_btn_search";
            this.search_cbu_btn_search.UseVisualStyleBackColor = false;
            this.search_cbu_btn_search.Click += new System.EventHandler(this.search_cbu_btn_search_Click);
            // 
            // search_cbu_write
            // 
            this.search_cbu_write.AutoSize = true;
            this.search_cbu_write.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_cbu_write.Location = new System.Drawing.Point(20, 119);
            this.search_cbu_write.Name = "search_cbu_write";
            this.search_cbu_write.Size = new System.Drawing.Size(157, 20);
            this.search_cbu_write.TabIndex = 73;
            this.search_cbu_write.Text = "search_cbu_write";
            this.search_cbu_write.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // search_cbu_btn_cashin
            // 
            this.search_cbu_btn_cashin.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.search_cbu_btn_cashin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.search_cbu_btn_cashin.Location = new System.Drawing.Point(463, 155);
            this.search_cbu_btn_cashin.Name = "search_cbu_btn_cashin";
            this.search_cbu_btn_cashin.Size = new System.Drawing.Size(238, 38);
            this.search_cbu_btn_cashin.TabIndex = 68;
            this.search_cbu_btn_cashin.Text = "search_cbu_btn_cashin";
            this.search_cbu_btn_cashin.UseVisualStyleBackColor = false;
            this.search_cbu_btn_cashin.Click += new System.EventHandler(this.search_cbu_btn_cashin_Click);
            // 
            // frm_buscar_cbu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 748);
            this.Controls.Add(this.search_cbu_btn_cashin);
            this.Controls.Add(this.search_cbu_write);
            this.Controls.Add(this.search_cbu_btn_search);
            this.Controls.Add(this.search_cbu_txt_input);
            this.Controls.Add(this.usr_search_data);
            this.Controls.Add(this.search_cbu_btn_close);
            this.Controls.Add(this.search_cbu_title_descrip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.search_cbu_title);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_buscar_cbu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar CBU";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frm_buscar_cbu_HelpButtonClicked);
            this.Load += new System.EventHandler(this.frm_buscar_cbu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usr_search_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label search_cbu_title_descrip;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label search_cbu_title;
        private System.Windows.Forms.Button search_cbu_btn_close;
        private System.Windows.Forms.DataGridView usr_search_data;
        private System.Windows.Forms.TextBox search_cbu_txt_input;
        private System.Windows.Forms.Button search_cbu_btn_search;
        private System.Windows.Forms.Label search_cbu_write;
        private System.Windows.Forms.Button search_cbu_btn_cashin;
    }
}