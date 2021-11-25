namespace UI
{
    partial class UsersControl
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
            this.usr_search_descrip = new System.Windows.Forms.Label();
            this.usr_search = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.usr_search_close = new System.Windows.Forms.Button();
            this.usr_data = new System.Windows.Forms.DataGridView();
            this.usr_search_txt = new System.Windows.Forms.TextBox();
            this.usr_search_label = new System.Windows.Forms.Label();
            this.usr_perm_btn = new System.Windows.Forms.Button();
            this.usr_ctrl_changes = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.usr_search_btn = new System.Windows.Forms.Button();
            this.usr_ctrl_change_state = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usr_data)).BeginInit();
            this.SuspendLayout();
            // 
            // usr_search_descrip
            // 
            this.usr_search_descrip.AutoSize = true;
            this.usr_search_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usr_search_descrip.Location = new System.Drawing.Point(104, 64);
            this.usr_search_descrip.Name = "usr_search_descrip";
            this.usr_search_descrip.Size = new System.Drawing.Size(193, 24);
            this.usr_search_descrip.TabIndex = 34;
            this.usr_search_descrip.Text = "usr_search_descrip";
            this.usr_search_descrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // usr_search
            // 
            this.usr_search.AutoSize = true;
            this.usr_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usr_search.Location = new System.Drawing.Point(103, 22);
            this.usr_search.Name = "usr_search";
            this.usr_search.Size = new System.Drawing.Size(154, 32);
            this.usr_search.TabIndex = 33;
            this.usr_search.Text = "usr_search";
            this.usr_search.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.magnifying_glass;
            this.pictureBox1.Location = new System.Drawing.Point(26, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // usr_search_close
            // 
            this.usr_search_close.BackColor = System.Drawing.Color.LightCoral;
            this.usr_search_close.ForeColor = System.Drawing.Color.White;
            this.usr_search_close.Location = new System.Drawing.Point(953, 693);
            this.usr_search_close.Name = "usr_search_close";
            this.usr_search_close.Size = new System.Drawing.Size(165, 46);
            this.usr_search_close.TabIndex = 37;
            this.usr_search_close.Text = "usr_search_close";
            this.usr_search_close.UseVisualStyleBackColor = false;
            this.usr_search_close.Click += new System.EventHandler(this.Button1_Click);
            // 
            // usr_data
            // 
            this.usr_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usr_data.Location = new System.Drawing.Point(26, 239);
            this.usr_data.Name = "usr_data";
            this.usr_data.RowHeadersWidth = 51;
            this.usr_data.RowTemplate.Height = 24;
            this.usr_data.Size = new System.Drawing.Size(1089, 430);
            this.usr_data.TabIndex = 38;
            this.usr_data.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Usr_data_CellClick);
            this.usr_data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Usr_data_CellContentClick);
            // 
            // usr_search_txt
            // 
            this.usr_search_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usr_search_txt.Location = new System.Drawing.Point(543, 181);
            this.usr_search_txt.Name = "usr_search_txt";
            this.usr_search_txt.Size = new System.Drawing.Size(419, 34);
            this.usr_search_txt.TabIndex = 40;
            // 
            // usr_search_label
            // 
            this.usr_search_label.AutoSize = true;
            this.usr_search_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usr_search_label.Location = new System.Drawing.Point(543, 143);
            this.usr_search_label.Name = "usr_search_label";
            this.usr_search_label.Size = new System.Drawing.Size(153, 24);
            this.usr_search_label.TabIndex = 41;
            this.usr_search_label.Text = "usr_search_label";
            this.usr_search_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // usr_perm_btn
            // 
            this.usr_perm_btn.BackColor = System.Drawing.SystemColors.Info;
            this.usr_perm_btn.Location = new System.Drawing.Point(26, 177);
            this.usr_perm_btn.Name = "usr_perm_btn";
            this.usr_perm_btn.Size = new System.Drawing.Size(139, 38);
            this.usr_perm_btn.TabIndex = 42;
            this.usr_perm_btn.Text = "usr_perm_btn";
            this.usr_perm_btn.UseVisualStyleBackColor = false;
            this.usr_perm_btn.Click += new System.EventHandler(this.Usr_perm_btn_Click);
            // 
            // usr_ctrl_changes
            // 
            this.usr_ctrl_changes.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.usr_ctrl_changes.Location = new System.Drawing.Point(177, 177);
            this.usr_ctrl_changes.Name = "usr_ctrl_changes";
            this.usr_ctrl_changes.Size = new System.Drawing.Size(139, 38);
            this.usr_ctrl_changes.TabIndex = 43;
            this.usr_ctrl_changes.Text = "usr_ctrl_changes";
            this.usr_ctrl_changes.UseVisualStyleBackColor = false;
            this.usr_ctrl_changes.Click += new System.EventHandler(this.Usr_ctrl_changes_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(26, 109);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1089, 10);
            this.panel3.TabIndex = 46;
            // 
            // usr_search_btn
            // 
            this.usr_search_btn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.usr_search_btn.Location = new System.Drawing.Point(974, 180);
            this.usr_search_btn.Name = "usr_search_btn";
            this.usr_search_btn.Size = new System.Drawing.Size(139, 38);
            this.usr_search_btn.TabIndex = 39;
            this.usr_search_btn.Text = "usr_search_btn";
            this.usr_search_btn.UseVisualStyleBackColor = false;
            this.usr_search_btn.Click += new System.EventHandler(this.Usr_search_btn_Click);
            // 
            // usr_ctrl_change_state
            // 
            this.usr_ctrl_change_state.BackColor = System.Drawing.Color.MediumPurple;
            this.usr_ctrl_change_state.Enabled = false;
            this.usr_ctrl_change_state.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.usr_ctrl_change_state.Location = new System.Drawing.Point(332, 177);
            this.usr_ctrl_change_state.Name = "usr_ctrl_change_state";
            this.usr_ctrl_change_state.Size = new System.Drawing.Size(139, 38);
            this.usr_ctrl_change_state.TabIndex = 47;
            this.usr_ctrl_change_state.Text = "Cambiar estado";
            this.usr_ctrl_change_state.UseVisualStyleBackColor = false;
            this.usr_ctrl_change_state.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // UsersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 758);
            this.Controls.Add(this.usr_ctrl_change_state);
            this.Controls.Add(this.usr_ctrl_changes);
            this.Controls.Add(this.usr_search_label);
            this.Controls.Add(this.usr_perm_btn);
            this.Controls.Add(this.usr_search_btn);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.usr_search_txt);
            this.Controls.Add(this.usr_data);
            this.Controls.Add(this.usr_search_close);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.usr_search_descrip);
            this.Controls.Add(this.usr_search);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsersControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UsersControl";
            this.Load += new System.EventHandler(this.UsersControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usr_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usr_search_descrip;
        private System.Windows.Forms.Label usr_search;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button usr_search_close;
        private System.Windows.Forms.DataGridView usr_data;
        private System.Windows.Forms.TextBox usr_search_txt;
        private System.Windows.Forms.Label usr_search_label;
        private System.Windows.Forms.Button usr_perm_btn;
        private System.Windows.Forms.Button usr_ctrl_changes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button usr_search_btn;
        private System.Windows.Forms.Button usr_ctrl_change_state;
    }
}