namespace UI
{
    partial class IdiomaPanel
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
            this.usr_lang_ui_title = new System.Windows.Forms.Label();
            this.idioma_list = new System.Windows.Forms.DataGridView();
            this.usr_lang_ui_edit_language = new System.Windows.Forms.Button();
            this.usr_lang_ui_close_language = new System.Windows.Forms.Button();
            this.idioma_combo = new System.Windows.Forms.ComboBox();
            this.usr_lang_ui_descrip = new System.Windows.Forms.Label();
            this.usr_lang_ui_new_language = new System.Windows.Forms.Button();
            this.usr_lang_ui_refresh_language = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.usr_lang_del_all_language = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.idioma_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // usr_lang_ui_title
            // 
            this.usr_lang_ui_title.AutoSize = true;
            this.usr_lang_ui_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usr_lang_ui_title.Location = new System.Drawing.Point(71, 21);
            this.usr_lang_ui_title.Name = "usr_lang_ui_title";
            this.usr_lang_ui_title.Size = new System.Drawing.Size(188, 29);
            this.usr_lang_ui_title.TabIndex = 3;
            this.usr_lang_ui_title.Text = "usr_lang_ui_title";
            // 
            // idioma_list
            // 
            this.idioma_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.idioma_list.Location = new System.Drawing.Point(12, 230);
            this.idioma_list.Name = "idioma_list";
            this.idioma_list.RowHeadersWidth = 51;
            this.idioma_list.RowTemplate.Height = 24;
            this.idioma_list.Size = new System.Drawing.Size(703, 549);
            this.idioma_list.TabIndex = 39;
            // 
            // usr_lang_ui_edit_language
            // 
            this.usr_lang_ui_edit_language.BackColor = System.Drawing.SystemColors.Info;
            this.usr_lang_ui_edit_language.Location = new System.Drawing.Point(571, 176);
            this.usr_lang_ui_edit_language.Name = "usr_lang_ui_edit_language";
            this.usr_lang_ui_edit_language.Size = new System.Drawing.Size(139, 38);
            this.usr_lang_ui_edit_language.TabIndex = 43;
            this.usr_lang_ui_edit_language.Text = "usr_lang_ui_edit_language";
            this.usr_lang_ui_edit_language.UseVisualStyleBackColor = false;
            this.usr_lang_ui_edit_language.Click += new System.EventHandler(this.Usr_perm_btn_Click);
            // 
            // usr_lang_ui_close_language
            // 
            this.usr_lang_ui_close_language.Location = new System.Drawing.Point(550, 801);
            this.usr_lang_ui_close_language.Name = "usr_lang_ui_close_language";
            this.usr_lang_ui_close_language.Size = new System.Drawing.Size(165, 46);
            this.usr_lang_ui_close_language.TabIndex = 46;
            this.usr_lang_ui_close_language.Text = "usr_lang_ui_close_language";
            this.usr_lang_ui_close_language.UseVisualStyleBackColor = true;
            this.usr_lang_ui_close_language.Click += new System.EventHandler(this.Usr_search_close_Click);
            // 
            // idioma_combo
            // 
            this.idioma_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.idioma_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idioma_combo.FormattingEnabled = true;
            this.idioma_combo.Location = new System.Drawing.Point(22, 100);
            this.idioma_combo.Name = "idioma_combo";
            this.idioma_combo.Size = new System.Drawing.Size(503, 37);
            this.idioma_combo.TabIndex = 47;
            this.idioma_combo.SelectedIndexChanged += new System.EventHandler(this.Idioma_combo_SelectedIndexChanged);
            // 
            // usr_lang_ui_descrip
            // 
            this.usr_lang_ui_descrip.AutoSize = true;
            this.usr_lang_ui_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usr_lang_ui_descrip.Location = new System.Drawing.Point(21, 66);
            this.usr_lang_ui_descrip.Name = "usr_lang_ui_descrip";
            this.usr_lang_ui_descrip.Size = new System.Drawing.Size(179, 24);
            this.usr_lang_ui_descrip.TabIndex = 48;
            this.usr_lang_ui_descrip.Text = "usr_lang_ui_descrip";
            this.usr_lang_ui_descrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // usr_lang_ui_new_language
            // 
            this.usr_lang_ui_new_language.BackColor = System.Drawing.Color.Gold;
            this.usr_lang_ui_new_language.Location = new System.Drawing.Point(631, 100);
            this.usr_lang_ui_new_language.Name = "usr_lang_ui_new_language";
            this.usr_lang_ui_new_language.Size = new System.Drawing.Size(84, 38);
            this.usr_lang_ui_new_language.TabIndex = 49;
            this.usr_lang_ui_new_language.Text = "usr_lang_ui_new_language";
            this.usr_lang_ui_new_language.UseVisualStyleBackColor = false;
            this.usr_lang_ui_new_language.Click += new System.EventHandler(this.Button3_Click);
            // 
            // usr_lang_ui_refresh_language
            // 
            this.usr_lang_ui_refresh_language.BackColor = System.Drawing.Color.LightGreen;
            this.usr_lang_ui_refresh_language.ForeColor = System.Drawing.Color.Black;
            this.usr_lang_ui_refresh_language.Location = new System.Drawing.Point(470, 176);
            this.usr_lang_ui_refresh_language.Name = "usr_lang_ui_refresh_language";
            this.usr_lang_ui_refresh_language.Size = new System.Drawing.Size(89, 38);
            this.usr_lang_ui_refresh_language.TabIndex = 50;
            this.usr_lang_ui_refresh_language.Text = "usr_lang_ui_refresh_language";
            this.usr_lang_ui_refresh_language.UseVisualStyleBackColor = false;
            this.usr_lang_ui_refresh_language.Click += new System.EventHandler(this.Button4_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Location = new System.Drawing.Point(23, 157);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 1);
            this.panel1.TabIndex = 51;
            // 
            // usr_lang_del_all_language
            // 
            this.usr_lang_del_all_language.BackColor = System.Drawing.Color.LightCoral;
            this.usr_lang_del_all_language.ForeColor = System.Drawing.Color.White;
            this.usr_lang_del_all_language.Location = new System.Drawing.Point(539, 100);
            this.usr_lang_del_all_language.Name = "usr_lang_del_all_language";
            this.usr_lang_del_all_language.Size = new System.Drawing.Size(84, 38);
            this.usr_lang_del_all_language.TabIndex = 52;
            this.usr_lang_del_all_language.Text = "usr_lang_ui_del_language";
            this.usr_lang_del_all_language.UseVisualStyleBackColor = false;
            this.usr_lang_del_all_language.Click += new System.EventHandler(this.Usr_lang_del_all_language_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 38);
            this.button1.TabIndex = 53;
            this.button1.Text = "Template";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.globe;
            this.pictureBox1.Location = new System.Drawing.Point(22, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // IdiomaPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 859);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.usr_lang_del_all_language);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.usr_lang_ui_refresh_language);
            this.Controls.Add(this.usr_lang_ui_new_language);
            this.Controls.Add(this.usr_lang_ui_descrip);
            this.Controls.Add(this.idioma_combo);
            this.Controls.Add(this.usr_lang_ui_close_language);
            this.Controls.Add(this.usr_lang_ui_edit_language);
            this.Controls.Add(this.idioma_list);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.usr_lang_ui_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IdiomaPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IdiomaPanel";
            this.Load += new System.EventHandler(this.IdiomaPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.idioma_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label usr_lang_ui_title;
        private System.Windows.Forms.DataGridView idioma_list;
        private System.Windows.Forms.Button usr_lang_ui_edit_language;
        private System.Windows.Forms.Button usr_lang_ui_close_language;
        private System.Windows.Forms.ComboBox idioma_combo;
        private System.Windows.Forms.Label usr_lang_ui_descrip;
        private System.Windows.Forms.Button usr_lang_ui_new_language;
        private System.Windows.Forms.Button usr_lang_ui_refresh_language;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button usr_lang_del_all_language;
        private System.Windows.Forms.Button button1;
    }
}