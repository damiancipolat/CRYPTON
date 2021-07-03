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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.language_txt_title = new System.Windows.Forms.Label();
            this.idioma_list = new System.Windows.Forms.DataGridView();
            this.usr_perm_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.usr_search_close = new System.Windows.Forms.Button();
            this.idioma_combo = new System.Windows.Forms.ComboBox();
            this.usr_language_label = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idioma_list)).BeginInit();
            this.SuspendLayout();
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
            // language_txt_title
            // 
            this.language_txt_title.AutoSize = true;
            this.language_txt_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.language_txt_title.Location = new System.Drawing.Point(71, 21);
            this.language_txt_title.Name = "language_txt_title";
            this.language_txt_title.Size = new System.Drawing.Size(200, 29);
            this.language_txt_title.TabIndex = 3;
            this.language_txt_title.Text = "language_txt_title";
            // 
            // idioma_list
            // 
            this.idioma_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.idioma_list.Location = new System.Drawing.Point(12, 214);
            this.idioma_list.Name = "idioma_list";
            this.idioma_list.RowHeadersWidth = 51;
            this.idioma_list.RowTemplate.Height = 24;
            this.idioma_list.Size = new System.Drawing.Size(703, 565);
            this.idioma_list.TabIndex = 39;
            // 
            // usr_perm_btn
            // 
            this.usr_perm_btn.BackColor = System.Drawing.SystemColors.Info;
            this.usr_perm_btn.Location = new System.Drawing.Point(272, 158);
            this.usr_perm_btn.Name = "usr_perm_btn";
            this.usr_perm_btn.Size = new System.Drawing.Size(139, 38);
            this.usr_perm_btn.TabIndex = 43;
            this.usr_perm_btn.Text = "Editar";
            this.usr_perm_btn.UseVisualStyleBackColor = false;
            this.usr_perm_btn.Click += new System.EventHandler(this.Usr_perm_btn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightCoral;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(576, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 38);
            this.button1.TabIndex = 44;
            this.button1.Text = "Borrar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button2.Location = new System.Drawing.Point(425, 158);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 38);
            this.button2.TabIndex = 45;
            this.button2.Text = "Agregar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // usr_search_close
            // 
            this.usr_search_close.Location = new System.Drawing.Point(550, 801);
            this.usr_search_close.Name = "usr_search_close";
            this.usr_search_close.Size = new System.Drawing.Size(165, 46);
            this.usr_search_close.TabIndex = 46;
            this.usr_search_close.Text = "usr_search_close";
            this.usr_search_close.UseVisualStyleBackColor = true;
            this.usr_search_close.Click += new System.EventHandler(this.Usr_search_close_Click);
            // 
            // idioma_combo
            // 
            this.idioma_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.idioma_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idioma_combo.FormattingEnabled = true;
            this.idioma_combo.Location = new System.Drawing.Point(22, 100);
            this.idioma_combo.Name = "idioma_combo";
            this.idioma_combo.Size = new System.Drawing.Size(590, 37);
            this.idioma_combo.TabIndex = 47;
            this.idioma_combo.SelectedIndexChanged += new System.EventHandler(this.Idioma_combo_SelectedIndexChanged);
            // 
            // usr_language_label
            // 
            this.usr_language_label.AutoSize = true;
            this.usr_language_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usr_language_label.Location = new System.Drawing.Point(21, 66);
            this.usr_language_label.Name = "usr_language_label";
            this.usr_language_label.Size = new System.Drawing.Size(175, 24);
            this.usr_language_label.TabIndex = 48;
            this.usr_language_label.Text = "usr_language_label";
            this.usr_language_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Gold;
            this.button3.Location = new System.Drawing.Point(631, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 38);
            this.button3.TabIndex = 49;
            this.button3.Text = "Nuevo";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightGreen;
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(12, 158);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(89, 38);
            this.button4.TabIndex = 50;
            this.button4.Text = "Actualizar";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // IdiomaPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 859);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.usr_language_label);
            this.Controls.Add(this.idioma_combo);
            this.Controls.Add(this.usr_search_close);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.usr_perm_btn);
            this.Controls.Add(this.idioma_list);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.language_txt_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IdiomaPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IdiomaPanel";
            this.Load += new System.EventHandler(this.IdiomaPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idioma_list)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label language_txt_title;
        private System.Windows.Forms.DataGridView idioma_list;
        private System.Windows.Forms.Button usr_perm_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button usr_search_close;
        private System.Windows.Forms.ComboBox idioma_combo;
        private System.Windows.Forms.Label usr_language_label;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}