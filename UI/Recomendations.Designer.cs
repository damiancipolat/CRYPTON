namespace UI
{
    partial class frm_recomendations
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
            this.recom_title = new System.Windows.Forms.Label();
            this.recom_descrip = new System.Windows.Forms.Label();
            this.frm_recom_list = new System.Windows.Forms.DataGridView();
            this.sell_close = new System.Windows.Forms.Button();
            this.btn_view = new System.Windows.Forms.Button();
            this.recom_progress = new System.Windows.Forms.ProgressBar();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.frm_recom_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // recom_title
            // 
            this.recom_title.AutoSize = true;
            this.recom_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recom_title.Location = new System.Drawing.Point(100, 17);
            this.recom_title.Name = "recom_title";
            this.recom_title.Size = new System.Drawing.Size(143, 29);
            this.recom_title.TabIndex = 0;
            this.recom_title.Text = "recom_title";
            // 
            // recom_descrip
            // 
            this.recom_descrip.AutoSize = true;
            this.recom_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recom_descrip.Location = new System.Drawing.Point(102, 55);
            this.recom_descrip.Name = "recom_descrip";
            this.recom_descrip.Size = new System.Drawing.Size(120, 20);
            this.recom_descrip.TabIndex = 1;
            this.recom_descrip.Text = "recom_descrip";
            // 
            // frm_recom_list
            // 
            this.frm_recom_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.frm_recom_list.Location = new System.Drawing.Point(25, 150);
            this.frm_recom_list.Name = "frm_recom_list";
            this.frm_recom_list.RowHeadersWidth = 51;
            this.frm_recom_list.RowTemplate.Height = 24;
            this.frm_recom_list.Size = new System.Drawing.Size(1025, 401);
            this.frm_recom_list.TabIndex = 2;
            this.frm_recom_list.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Frm_recom_list_CellContentClick);
            // 
            // sell_close
            // 
            this.sell_close.BackColor = System.Drawing.Color.Crimson;
            this.sell_close.ForeColor = System.Drawing.Color.White;
            this.sell_close.Location = new System.Drawing.Point(885, 579);
            this.sell_close.Name = "sell_close";
            this.sell_close.Size = new System.Drawing.Size(165, 49);
            this.sell_close.TabIndex = 13;
            this.sell_close.Text = "sell_close";
            this.sell_close.UseVisualStyleBackColor = false;
            this.sell_close.Click += new System.EventHandler(this.Sell_close_Click);
            // 
            // btn_view
            // 
            this.btn_view.BackColor = System.Drawing.Color.LightYellow;
            this.btn_view.ForeColor = System.Drawing.Color.Black;
            this.btn_view.Location = new System.Drawing.Point(25, 95);
            this.btn_view.Name = "btn_view";
            this.btn_view.Size = new System.Drawing.Size(119, 38);
            this.btn_view.TabIndex = 49;
            this.btn_view.Text = "btn_view";
            this.btn_view.UseVisualStyleBackColor = false;
            this.btn_view.Click += new System.EventHandler(this.Btn_refresh_Click);
            // 
            // recom_progress
            // 
            this.recom_progress.Location = new System.Drawing.Point(884, 101);
            this.recom_progress.Name = "recom_progress";
            this.recom_progress.Size = new System.Drawing.Size(165, 28);
            this.recom_progress.TabIndex = 51;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::UI.Properties.Resources.list;
            this.pictureBox2.Location = new System.Drawing.Point(25, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 52;
            this.pictureBox2.TabStop = false;
            // 
            // frm_recomendations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 648);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.recom_progress);
            this.Controls.Add(this.btn_view);
            this.Controls.Add(this.sell_close);
            this.Controls.Add(this.frm_recom_list);
            this.Controls.Add(this.recom_descrip);
            this.Controls.Add(this.recom_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_recomendations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frm_recomendations_HelpButtonClicked);
            this.Load += new System.EventHandler(this.Frm_recomendations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.frm_recom_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label recom_title;
        private System.Windows.Forms.Label recom_descrip;
        private System.Windows.Forms.DataGridView frm_recom_list;
        private System.Windows.Forms.Button sell_close;
        private System.Windows.Forms.Button btn_view;
        private System.Windows.Forms.ProgressBar recom_progress;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}