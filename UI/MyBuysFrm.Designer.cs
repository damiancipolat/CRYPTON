namespace UI
{
    partial class MyBuysFrm
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
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.my_buy_orders_title = new System.Windows.Forms.Label();
            this.usr_orders_data = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.usr_orders_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_refresh
            // 
            this.btn_refresh.BackColor = System.Drawing.Color.Bisque;
            this.btn_refresh.ForeColor = System.Drawing.Color.Black;
            this.btn_refresh.Location = new System.Drawing.Point(27, 89);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(119, 38);
            this.btn_refresh.TabIndex = 54;
            this.btn_refresh.Text = "btn_refresh";
            this.btn_refresh.UseVisualStyleBackColor = false;
            this.btn_refresh.Click += new System.EventHandler(this.Btn_refresh_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(627, 555);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(143, 49);
            this.btn_close.TabIndex = 53;
            this.btn_close.Text = "btn_close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // my_buy_orders_title
            // 
            this.my_buy_orders_title.AutoSize = true;
            this.my_buy_orders_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.my_buy_orders_title.Location = new System.Drawing.Point(90, 25);
            this.my_buy_orders_title.Name = "my_buy_orders_title";
            this.my_buy_orders_title.Size = new System.Drawing.Size(269, 32);
            this.my_buy_orders_title.TabIndex = 51;
            this.my_buy_orders_title.Text = "my_buy_orders_title";
            this.my_buy_orders_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // usr_orders_data
            // 
            this.usr_orders_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usr_orders_data.Location = new System.Drawing.Point(27, 143);
            this.usr_orders_data.Name = "usr_orders_data";
            this.usr_orders_data.RowHeadersWidth = 51;
            this.usr_orders_data.RowTemplate.Height = 24;
            this.usr_orders_data.Size = new System.Drawing.Size(743, 383);
            this.usr_orders_data.TabIndex = 50;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.shopping_bag;
            this.pictureBox1.Location = new System.Drawing.Point(27, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            // 
            // MyBuysFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 628);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.my_buy_orders_title);
            this.Controls.Add(this.usr_orders_data);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyBuysFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyBuysFrm";
            this.Load += new System.EventHandler(this.MyBuysFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usr_orders_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label my_buy_orders_title;
        private System.Windows.Forms.DataGridView usr_orders_data;
    }
}