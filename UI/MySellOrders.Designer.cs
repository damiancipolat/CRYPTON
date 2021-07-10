namespace UI
{
    partial class MySellOrders
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
            this.usr_orders_data = new System.Windows.Forms.DataGridView();
            this.my_sell_orders_title = new System.Windows.Forms.Label();
            this.btn_finish = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usr_orders_data)).BeginInit();
            this.SuspendLayout();
            // 
            // usr_orders_data
            // 
            this.usr_orders_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usr_orders_data.Location = new System.Drawing.Point(29, 121);
            this.usr_orders_data.Name = "usr_orders_data";
            this.usr_orders_data.RowHeadersWidth = 51;
            this.usr_orders_data.RowTemplate.Height = 24;
            this.usr_orders_data.Size = new System.Drawing.Size(743, 383);
            this.usr_orders_data.TabIndex = 44;
            // 
            // my_sell_orders_title
            // 
            this.my_sell_orders_title.AutoSize = true;
            this.my_sell_orders_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.my_sell_orders_title.Location = new System.Drawing.Point(23, 14);
            this.my_sell_orders_title.Name = "my_sell_orders_title";
            this.my_sell_orders_title.Size = new System.Drawing.Size(267, 32);
            this.my_sell_orders_title.TabIndex = 45;
            this.my_sell_orders_title.Text = "my_sell_orders_title";
            this.my_sell_orders_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_finish
            // 
            this.btn_finish.BackColor = System.Drawing.Color.Tomato;
            this.btn_finish.ForeColor = System.Drawing.Color.Transparent;
            this.btn_finish.Location = new System.Drawing.Point(653, 67);
            this.btn_finish.Name = "btn_finish";
            this.btn_finish.Size = new System.Drawing.Size(119, 38);
            this.btn_finish.TabIndex = 46;
            this.btn_finish.Text = "btn_finish";
            this.btn_finish.UseVisualStyleBackColor = false;
            this.btn_finish.Click += new System.EventHandler(this.Btn_finish_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(629, 533);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(143, 49);
            this.btn_close.TabIndex = 47;
            this.btn_close.Text = "btn_close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.BackColor = System.Drawing.Color.Bisque;
            this.btn_refresh.ForeColor = System.Drawing.Color.Black;
            this.btn_refresh.Location = new System.Drawing.Point(29, 67);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(119, 38);
            this.btn_refresh.TabIndex = 48;
            this.btn_refresh.Text = "btn_refresh";
            this.btn_refresh.UseVisualStyleBackColor = false;
            this.btn_refresh.Click += new System.EventHandler(this.Btn_refresh_Click);
            // 
            // MySellOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 604);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_finish);
            this.Controls.Add(this.my_sell_orders_title);
            this.Controls.Add(this.usr_orders_data);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MySellOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MySellOrders";
            this.Load += new System.EventHandler(this.MySellOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usr_orders_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView usr_orders_data;
        private System.Windows.Forms.Label my_sell_orders_title;
        private System.Windows.Forms.Button btn_finish;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_refresh;
    }
}