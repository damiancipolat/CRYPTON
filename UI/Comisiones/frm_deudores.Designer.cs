namespace UI.Comisiones
{
    partial class frm_deudores
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
            this.list_comision_data = new System.Windows.Forms.DataGridView();
            this.commision_debts_title_descrip = new System.Windows.Forms.Label();
            this.commision_debts_title = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.commision_debts_notify_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.list_comision_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(599, 675);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(143, 49);
            this.btn_close.TabIndex = 70;
            this.btn_close.Text = "Cerrar";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // list_comision_data
            // 
            this.list_comision_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.list_comision_data.Location = new System.Drawing.Point(26, 168);
            this.list_comision_data.Name = "list_comision_data";
            this.list_comision_data.RowHeadersWidth = 51;
            this.list_comision_data.RowTemplate.Height = 24;
            this.list_comision_data.Size = new System.Drawing.Size(716, 481);
            this.list_comision_data.TabIndex = 69;
            // 
            // commision_debts_title_descrip
            // 
            this.commision_debts_title_descrip.AutoSize = true;
            this.commision_debts_title_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commision_debts_title_descrip.Location = new System.Drawing.Point(107, 60);
            this.commision_debts_title_descrip.Name = "commision_debts_title_descrip";
            this.commision_debts_title_descrip.Size = new System.Drawing.Size(240, 20);
            this.commision_debts_title_descrip.TabIndex = 68;
            this.commision_debts_title_descrip.Text = "commision_debts_title_descrip";
            this.commision_debts_title_descrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // commision_debts_title
            // 
            this.commision_debts_title.AutoSize = true;
            this.commision_debts_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commision_debts_title.Location = new System.Drawing.Point(103, 21);
            this.commision_debts_title.Name = "commision_debts_title";
            this.commision_debts_title.Size = new System.Drawing.Size(297, 32);
            this.commision_debts_title.TabIndex = 66;
            this.commision_debts_title.Text = "commision_debts_title";
            this.commision_debts_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.deuda;
            this.pictureBox1.Location = new System.Drawing.Point(26, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 67;
            this.pictureBox1.TabStop = false;
            // 
            // commision_debts_notify_btn
            // 
            this.commision_debts_notify_btn.BackColor = System.Drawing.SystemColors.Info;
            this.commision_debts_notify_btn.Location = new System.Drawing.Point(600, 111);
            this.commision_debts_notify_btn.Name = "commision_debts_notify_btn";
            this.commision_debts_notify_btn.Size = new System.Drawing.Size(143, 38);
            this.commision_debts_notify_btn.TabIndex = 72;
            this.commision_debts_notify_btn.Text = "commision_debts_notify_btn";
            this.commision_debts_notify_btn.UseVisualStyleBackColor = false;
            this.commision_debts_notify_btn.Click += new System.EventHandler(this.commision_debts_notify_btn_Click);
            // 
            // frm_deudores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 746);
            this.Controls.Add(this.commision_debts_notify_btn);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.list_comision_data);
            this.Controls.Add(this.commision_debts_title_descrip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.commision_debts_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_deudores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_deudores";
            this.Load += new System.EventHandler(this.frm_deudores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.list_comision_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.DataGridView list_comision_data;
        private System.Windows.Forms.Label commision_debts_title_descrip;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label commision_debts_title;
        private System.Windows.Forms.Button commision_debts_notify_btn;
    }
}