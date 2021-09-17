namespace UI.Admin
{
    partial class frm_cambios
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
            this.change_btn_apply = new System.Windows.Forms.Button();
            this.usr_data = new System.Windows.Forms.DataGridView();
            this.usr_change_close = new System.Windows.Forms.Button();
            this.txt_ctrl_title = new System.Windows.Forms.Label();
            this.txt_ctrl_descrip = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.usr_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // change_btn_apply
            // 
            this.change_btn_apply.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.change_btn_apply.Location = new System.Drawing.Point(19, 121);
            this.change_btn_apply.Name = "change_btn_apply";
            this.change_btn_apply.Size = new System.Drawing.Size(165, 46);
            this.change_btn_apply.TabIndex = 0;
            this.change_btn_apply.Text = "change_btn_apply";
            this.change_btn_apply.UseVisualStyleBackColor = false;
            this.change_btn_apply.Click += new System.EventHandler(this.Button1_Click);
            // 
            // usr_data
            // 
            this.usr_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usr_data.Location = new System.Drawing.Point(19, 189);
            this.usr_data.Name = "usr_data";
            this.usr_data.RowHeadersWidth = 51;
            this.usr_data.RowTemplate.Height = 24;
            this.usr_data.Size = new System.Drawing.Size(817, 583);
            this.usr_data.TabIndex = 39;
            // 
            // usr_change_close
            // 
            this.usr_change_close.BackColor = System.Drawing.Color.LightCoral;
            this.usr_change_close.ForeColor = System.Drawing.Color.White;
            this.usr_change_close.Location = new System.Drawing.Point(672, 795);
            this.usr_change_close.Name = "usr_change_close";
            this.usr_change_close.Size = new System.Drawing.Size(165, 46);
            this.usr_change_close.TabIndex = 40;
            this.usr_change_close.Text = "usr_change_close";
            this.usr_change_close.UseVisualStyleBackColor = false;
            this.usr_change_close.Click += new System.EventHandler(this.Usr_change_close_Click_1);
            // 
            // txt_ctrl_title
            // 
            this.txt_ctrl_title.AutoSize = true;
            this.txt_ctrl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ctrl_title.Location = new System.Drawing.Point(116, 25);
            this.txt_ctrl_title.Name = "txt_ctrl_title";
            this.txt_ctrl_title.Size = new System.Drawing.Size(196, 38);
            this.txt_ctrl_title.TabIndex = 41;
            this.txt_ctrl_title.Text = "txt_ctrl_title";
            // 
            // txt_ctrl_descrip
            // 
            this.txt_ctrl_descrip.AutoSize = true;
            this.txt_ctrl_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ctrl_descrip.Location = new System.Drawing.Point(116, 77);
            this.txt_ctrl_descrip.Name = "txt_ctrl_descrip";
            this.txt_ctrl_descrip.Size = new System.Drawing.Size(124, 20);
            this.txt_ctrl_descrip.TabIndex = 42;
            this.txt_ctrl_descrip.Text = "txt_ctrl_descrip";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::UI.Properties.Resources.registros_medicos;
            this.pictureBox1.Location = new System.Drawing.Point(19, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // frm_cambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 863);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txt_ctrl_descrip);
            this.Controls.Add(this.txt_ctrl_title);
            this.Controls.Add(this.usr_change_close);
            this.Controls.Add(this.usr_data);
            this.Controls.Add(this.change_btn_apply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_cambios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_cambios";
            this.Load += new System.EventHandler(this.Frm_cambios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usr_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button change_btn_apply;
        private System.Windows.Forms.DataGridView usr_data;
        private System.Windows.Forms.Button usr_change_close;
        private System.Windows.Forms.Label txt_ctrl_title;
        private System.Windows.Forms.Label txt_ctrl_descrip;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}