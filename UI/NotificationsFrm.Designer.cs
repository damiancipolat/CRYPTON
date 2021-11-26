namespace UI
{
    partial class NotificationsFrm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.notif_descrip = new System.Windows.Forms.Label();
            this.notif_title = new System.Windows.Forms.Label();
            this.notif_close = new System.Windows.Forms.Button();
            this.notif_data = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notif_data)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.notification;
            this.pictureBox1.Location = new System.Drawing.Point(26, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // notif_descrip
            // 
            this.notif_descrip.AutoSize = true;
            this.notif_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notif_descrip.Location = new System.Drawing.Point(97, 58);
            this.notif_descrip.Name = "notif_descrip";
            this.notif_descrip.Size = new System.Drawing.Size(105, 20);
            this.notif_descrip.TabIndex = 39;
            this.notif_descrip.Text = "notif_descrip";
            this.notif_descrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notif_title
            // 
            this.notif_title.AutoSize = true;
            this.notif_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notif_title.Location = new System.Drawing.Point(95, 14);
            this.notif_title.Name = "notif_title";
            this.notif_title.Size = new System.Drawing.Size(131, 32);
            this.notif_title.TabIndex = 38;
            this.notif_title.Text = "notif_title";
            this.notif_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notif_close
            // 
            this.notif_close.BackColor = System.Drawing.Color.Crimson;
            this.notif_close.ForeColor = System.Drawing.Color.White;
            this.notif_close.Location = new System.Drawing.Point(612, 677);
            this.notif_close.Name = "notif_close";
            this.notif_close.Size = new System.Drawing.Size(165, 49);
            this.notif_close.TabIndex = 40;
            this.notif_close.Text = "notif_close";
            this.notif_close.UseVisualStyleBackColor = false;
            this.notif_close.Click += new System.EventHandler(this.Notif_close_Click);
            // 
            // notif_data
            // 
            this.notif_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.notif_data.Location = new System.Drawing.Point(29, 100);
            this.notif_data.Name = "notif_data";
            this.notif_data.RowHeadersWidth = 51;
            this.notif_data.RowTemplate.Height = 24;
            this.notif_data.Size = new System.Drawing.Size(748, 550);
            this.notif_data.TabIndex = 44;
            // 
            // NotificationsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 745);
            this.Controls.Add(this.notif_data);
            this.Controls.Add(this.notif_close);
            this.Controls.Add(this.notif_descrip);
            this.Controls.Add(this.notif_title);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotificationsFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notifications";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.NotificationsFrm_HelpButtonClicked);
            this.Load += new System.EventHandler(this.Notifications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notif_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label notif_descrip;
        private System.Windows.Forms.Label notif_title;
        private System.Windows.Forms.Button notif_close;
        private System.Windows.Forms.DataGridView notif_data;
    }
}