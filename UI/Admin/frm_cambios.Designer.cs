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
            ((System.ComponentModel.ISupportInitialize)(this.usr_data)).BeginInit();
            this.SuspendLayout();
            // 
            // change_btn_apply
            // 
            this.change_btn_apply.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.change_btn_apply.Location = new System.Drawing.Point(19, 22);
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
            this.usr_data.Location = new System.Drawing.Point(19, 89);
            this.usr_data.Name = "usr_data";
            this.usr_data.RowHeadersWidth = 51;
            this.usr_data.RowTemplate.Height = 24;
            this.usr_data.Size = new System.Drawing.Size(817, 583);
            this.usr_data.TabIndex = 39;
            this.usr_data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Usr_data_CellContentClick);
            // 
            // usr_change_close
            // 
            this.usr_change_close.BackColor = System.Drawing.Color.LightCoral;
            this.usr_change_close.ForeColor = System.Drawing.Color.White;
            this.usr_change_close.Location = new System.Drawing.Point(672, 695);
            this.usr_change_close.Name = "usr_change_close";
            this.usr_change_close.Size = new System.Drawing.Size(165, 46);
            this.usr_change_close.TabIndex = 40;
            this.usr_change_close.Text = "usr_change_close";
            this.usr_change_close.UseVisualStyleBackColor = false;
            this.usr_change_close.Click += new System.EventHandler(this.Usr_change_close_Click);
            // 
            // frm_cambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 758);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button change_btn_apply;
        private System.Windows.Forms.DataGridView usr_data;
        private System.Windows.Forms.Button usr_change_close;
    }
}