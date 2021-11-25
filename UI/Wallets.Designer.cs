namespace UI
{
    partial class frm_wallets
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
            this.wallet_descrip = new System.Windows.Forms.Label();
            this.wallet_title = new System.Windows.Forms.Label();
            this.wallet_btn_refresh = new System.Windows.Forms.Button();
            this.frm_wallet_list = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.wallet_btn_close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.frm_wallet_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // wallet_descrip
            // 
            this.wallet_descrip.AutoSize = true;
            this.wallet_descrip.BackColor = System.Drawing.Color.Transparent;
            this.wallet_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallet_descrip.Location = new System.Drawing.Point(99, 60);
            this.wallet_descrip.Name = "wallet_descrip";
            this.wallet_descrip.Size = new System.Drawing.Size(116, 20);
            this.wallet_descrip.TabIndex = 51;
            this.wallet_descrip.Text = "wallet_descrip";
            // 
            // wallet_title
            // 
            this.wallet_title.AutoSize = true;
            this.wallet_title.Cursor = System.Windows.Forms.Cursors.Default;
            this.wallet_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallet_title.Location = new System.Drawing.Point(95, 26);
            this.wallet_title.Name = "wallet_title";
            this.wallet_title.Size = new System.Drawing.Size(113, 25);
            this.wallet_title.TabIndex = 50;
            this.wallet_title.Text = "wallet_title";
            // 
            // wallet_btn_refresh
            // 
            this.wallet_btn_refresh.Location = new System.Drawing.Point(639, 78);
            this.wallet_btn_refresh.Name = "wallet_btn_refresh";
            this.wallet_btn_refresh.Size = new System.Drawing.Size(95, 38);
            this.wallet_btn_refresh.TabIndex = 49;
            this.wallet_btn_refresh.Text = "wallet_btn_refresh";
            this.wallet_btn_refresh.UseVisualStyleBackColor = true;
            this.wallet_btn_refresh.Click += new System.EventHandler(this.Button2_Click);
            // 
            // frm_wallet_list
            // 
            this.frm_wallet_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.frm_wallet_list.Location = new System.Drawing.Point(31, 132);
            this.frm_wallet_list.Name = "frm_wallet_list";
            this.frm_wallet_list.RowHeadersWidth = 51;
            this.frm_wallet_list.RowTemplate.Height = 24;
            this.frm_wallet_list.Size = new System.Drawing.Size(703, 188);
            this.frm_wallet_list.TabIndex = 36;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.wallet1;
            this.pictureBox1.Location = new System.Drawing.Point(31, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 52;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox10.Image = global::UI.Properties.Resources.BTC;
            this.pictureBox10.Location = new System.Drawing.Point(69, 348);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(30, 30);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 32;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox6.Image = global::UI.Properties.Resources.LTC;
            this.pictureBox6.Location = new System.Drawing.Point(107, 348);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(30, 30);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 32;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox5.Image = global::UI.Properties.Resources.argentina;
            this.pictureBox5.Location = new System.Drawing.Point(31, 348);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(30, 30);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 29;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox4.Image = global::UI.Properties.Resources.DOGE;
            this.pictureBox4.Location = new System.Drawing.Point(145, 348);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 30);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 32;
            this.pictureBox4.TabStop = false;
            // 
            // wallet_btn_close
            // 
            this.wallet_btn_close.BackColor = System.Drawing.Color.Crimson;
            this.wallet_btn_close.ForeColor = System.Drawing.Color.White;
            this.wallet_btn_close.Location = new System.Drawing.Point(569, 338);
            this.wallet_btn_close.Name = "wallet_btn_close";
            this.wallet_btn_close.Size = new System.Drawing.Size(165, 49);
            this.wallet_btn_close.TabIndex = 54;
            this.wallet_btn_close.Text = "wallet_btn_close";
            this.wallet_btn_close.UseVisualStyleBackColor = false;
            this.wallet_btn_close.Click += new System.EventHandler(this.Wallet_btn_close_Click);
            // 
            // frm_wallets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(766, 410);
            this.Controls.Add(this.wallet_btn_close);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.wallet_btn_refresh);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.wallet_descrip);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.frm_wallet_list);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.wallet_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_wallets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Billeteras";
            this.Load += new System.EventHandler(this.Frm_wallets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.frm_wallet_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button wallet_btn_refresh;
        private System.Windows.Forms.Label wallet_title;
        private System.Windows.Forms.Label wallet_descrip;
        private System.Windows.Forms.DataGridView frm_wallet_list;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button wallet_btn_close;
    }
}