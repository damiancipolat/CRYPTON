namespace UI.Admin
{
    partial class frm_backup
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
            this.txt_backup_descrip = new System.Windows.Forms.Label();
            this.txt_backup_title = new System.Windows.Forms.Label();
            this.btn_close_backup = new System.Windows.Forms.Button();
            this.usr_data = new System.Windows.Forms.DataGridView();
            this.btn_new_backup = new System.Windows.Forms.Button();
            this.btn_load_backup = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_backup_title_list = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.usr_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_backup_descrip
            // 
            this.txt_backup_descrip.AutoSize = true;
            this.txt_backup_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_backup_descrip.Location = new System.Drawing.Point(130, 79);
            this.txt_backup_descrip.Name = "txt_backup_descrip";
            this.txt_backup_descrip.Size = new System.Drawing.Size(153, 20);
            this.txt_backup_descrip.TabIndex = 48;
            this.txt_backup_descrip.Text = "txt_backup_descrip";
            // 
            // txt_backup_title
            // 
            this.txt_backup_title.AutoSize = true;
            this.txt_backup_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_backup_title.Location = new System.Drawing.Point(130, 27);
            this.txt_backup_title.Name = "txt_backup_title";
            this.txt_backup_title.Size = new System.Drawing.Size(260, 38);
            this.txt_backup_title.TabIndex = 47;
            this.txt_backup_title.Text = "txt_backup_title";
            this.txt_backup_title.Click += new System.EventHandler(this.Txt_backup_title_Click);
            // 
            // btn_close_backup
            // 
            this.btn_close_backup.BackColor = System.Drawing.Color.LightCoral;
            this.btn_close_backup.ForeColor = System.Drawing.Color.White;
            this.btn_close_backup.Location = new System.Drawing.Point(686, 797);
            this.btn_close_backup.Name = "btn_close_backup";
            this.btn_close_backup.Size = new System.Drawing.Size(165, 46);
            this.btn_close_backup.TabIndex = 46;
            this.btn_close_backup.Text = "btn_close_backup";
            this.btn_close_backup.UseVisualStyleBackColor = false;
            this.btn_close_backup.Click += new System.EventHandler(this.Usr_change_close_Click);
            // 
            // usr_data
            // 
            this.usr_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usr_data.Location = new System.Drawing.Point(33, 242);
            this.usr_data.Name = "usr_data";
            this.usr_data.RowHeadersWidth = 51;
            this.usr_data.RowTemplate.Height = 24;
            this.usr_data.Size = new System.Drawing.Size(817, 532);
            this.usr_data.TabIndex = 45;
            // 
            // btn_new_backup
            // 
            this.btn_new_backup.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_new_backup.Location = new System.Drawing.Point(33, 130);
            this.btn_new_backup.Name = "btn_new_backup";
            this.btn_new_backup.Size = new System.Drawing.Size(165, 46);
            this.btn_new_backup.TabIndex = 44;
            this.btn_new_backup.Text = "btn_new_backup";
            this.btn_new_backup.UseVisualStyleBackColor = false;
            this.btn_new_backup.Click += new System.EventHandler(this.Btn_new_backup_Click);
            // 
            // btn_load_backup
            // 
            this.btn_load_backup.BackColor = System.Drawing.Color.SandyBrown;
            this.btn_load_backup.ForeColor = System.Drawing.Color.White;
            this.btn_load_backup.Location = new System.Drawing.Point(215, 130);
            this.btn_load_backup.Name = "btn_load_backup";
            this.btn_load_backup.Size = new System.Drawing.Size(165, 46);
            this.btn_load_backup.TabIndex = 50;
            this.btn_load_backup.Text = "btn_load_backup";
            this.btn_load_backup.UseVisualStyleBackColor = false;
            this.btn_load_backup.Click += new System.EventHandler(this.Btn_load_backup_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::UI.Properties.Resources.bd;
            this.pictureBox1.Location = new System.Drawing.Point(33, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // txt_backup_title_list
            // 
            this.txt_backup_title_list.AutoSize = true;
            this.txt_backup_title_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_backup_title_list.Location = new System.Drawing.Point(34, 199);
            this.txt_backup_title_list.Name = "txt_backup_title_list";
            this.txt_backup_title_list.Size = new System.Drawing.Size(221, 25);
            this.txt_backup_title_list.TabIndex = 51;
            this.txt_backup_title_list.Text = "txt_backup_title_list";
            // 
            // frm_backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 867);
            this.Controls.Add(this.txt_backup_title_list);
            this.Controls.Add(this.btn_load_backup);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txt_backup_descrip);
            this.Controls.Add(this.txt_backup_title);
            this.Controls.Add(this.btn_close_backup);
            this.Controls.Add(this.usr_data);
            this.Controls.Add(this.btn_new_backup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_backup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_backup";
            this.Load += new System.EventHandler(this.Frm_backup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usr_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txt_backup_descrip;
        private System.Windows.Forms.Label txt_backup_title;
        private System.Windows.Forms.Button btn_close_backup;
        private System.Windows.Forms.DataGridView usr_data;
        private System.Windows.Forms.Button btn_new_backup;
        private System.Windows.Forms.Button btn_load_backup;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label txt_backup_title_list;
    }
}