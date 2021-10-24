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
            this.comision_data = new System.Windows.Forms.DataGridView();
            this.search_descrip = new System.Windows.Forms.Label();
            this.search_title = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.comision_data)).BeginInit();
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
            // 
            // comision_data
            // 
            this.comision_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.comision_data.Location = new System.Drawing.Point(26, 168);
            this.comision_data.Name = "comision_data";
            this.comision_data.RowHeadersWidth = 51;
            this.comision_data.RowTemplate.Height = 24;
            this.comision_data.Size = new System.Drawing.Size(716, 481);
            this.comision_data.TabIndex = 69;
            // 
            // search_descrip
            // 
            this.search_descrip.AutoSize = true;
            this.search_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_descrip.Location = new System.Drawing.Point(107, 60);
            this.search_descrip.Name = "search_descrip";
            this.search_descrip.Size = new System.Drawing.Size(426, 20);
            this.search_descrip.TabIndex = 68;
            this.search_descrip.Text = "Aqui se ve la lista de comisiones pendientes por cobrar.";
            this.search_descrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // search_title
            // 
            this.search_title.AutoSize = true;
            this.search_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_title.Location = new System.Drawing.Point(103, 21);
            this.search_title.Name = "search_title";
            this.search_title.Size = new System.Drawing.Size(138, 32);
            this.search_title.TabIndex = 66;
            this.search_title.Text = "Deudores";
            this.search_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Info;
            this.button2.Location = new System.Drawing.Point(600, 111);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 38);
            this.button2.TabIndex = 72;
            this.button2.Text = "Notificar deuda";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // frm_deudores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 746);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.comision_data);
            this.Controls.Add(this.search_descrip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.search_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_deudores";
            this.Text = "frm_deudores";
            ((System.ComponentModel.ISupportInitialize)(this.comision_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.DataGridView comision_data;
        private System.Windows.Forms.Label search_descrip;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label search_title;
        private System.Windows.Forms.Button button2;
    }
}