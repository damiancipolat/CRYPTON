namespace UI
{
    partial class Language
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
            this.language_txt_title = new System.Windows.Forms.Label();
            this.language_combo = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.language_accept = new System.Windows.Forms.Button();
            this.language_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // language_txt_title
            // 
            this.language_txt_title.AutoSize = true;
            this.language_txt_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.language_txt_title.Location = new System.Drawing.Point(85, 28);
            this.language_txt_title.Name = "language_txt_title";
            this.language_txt_title.Size = new System.Drawing.Size(200, 29);
            this.language_txt_title.TabIndex = 0;
            this.language_txt_title.Text = "language_txt_title";
            this.language_txt_title.Click += new System.EventHandler(this.Language_txt_title_Click);
            // 
            // language_combo
            // 
            this.language_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.language_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.language_combo.FormattingEnabled = true;
            this.language_combo.Location = new System.Drawing.Point(36, 89);
            this.language_combo.Name = "language_combo";
            this.language_combo.Size = new System.Drawing.Size(327, 37);
            this.language_combo.TabIndex = 1;
            // 
            // language_accept
            // 
            this.language_accept.Location = new System.Drawing.Point(36, 152);
            this.language_accept.Name = "language_accept";
            this.language_accept.Size = new System.Drawing.Size(150, 37);
            this.language_accept.TabIndex = 3;
            this.language_accept.Text = "language_accept";
            this.language_accept.UseVisualStyleBackColor = true;
            this.language_accept.Click += new System.EventHandler(this.Language_accept_Click);
            // 
            // language_cancel
            // 
            this.language_cancel.Location = new System.Drawing.Point(213, 152);
            this.language_cancel.Name = "language_cancel";
            this.language_cancel.Size = new System.Drawing.Size(150, 37);
            this.language_cancel.TabIndex = 4;
            this.language_cancel.Text = "language_cancel";
            this.language_cancel.UseVisualStyleBackColor = true;
            this.language_cancel.Click += new System.EventHandler(this.Language_cancel_Click);
            // 
            // Language
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 226);
            this.Controls.Add(this.language_cancel);
            this.Controls.Add(this.language_accept);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.language_combo);
            this.Controls.Add(this.language_txt_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Language";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Language";
            this.Load += new System.EventHandler(this.Language_Load);
            this.Shown += new System.EventHandler(this.Language_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label language_txt_title;
        private System.Windows.Forms.ComboBox language_combo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button language_accept;
        private System.Windows.Forms.Button language_cancel;
    }
}