namespace UI
{
    partial class TemplateFrm
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
            this.template_editor = new System.Windows.Forms.Label();
            this.template_close = new System.Windows.Forms.Button();
            this.idioma_list = new System.Windows.Forms.DataGridView();
            this.template_add = new System.Windows.Forms.Button();
            this.template_delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idioma_list)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.globe;
            this.pictureBox1.Location = new System.Drawing.Point(22, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // template_editor
            // 
            this.template_editor.AutoSize = true;
            this.template_editor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.template_editor.Location = new System.Drawing.Point(71, 23);
            this.template_editor.Name = "template_editor";
            this.template_editor.Size = new System.Drawing.Size(181, 29);
            this.template_editor.TabIndex = 5;
            this.template_editor.Text = "template_editor";
            // 
            // template_close
            // 
            this.template_close.Location = new System.Drawing.Point(613, 591);
            this.template_close.Name = "template_close";
            this.template_close.Size = new System.Drawing.Size(165, 46);
            this.template_close.TabIndex = 47;
            this.template_close.Text = "template_close";
            this.template_close.UseVisualStyleBackColor = true;
            this.template_close.Click += new System.EventHandler(this.Usr_lang_ui_close_language_Click);
            // 
            // idioma_list
            // 
            this.idioma_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.idioma_list.Location = new System.Drawing.Point(22, 129);
            this.idioma_list.Name = "idioma_list";
            this.idioma_list.RowHeadersWidth = 51;
            this.idioma_list.RowTemplate.Height = 24;
            this.idioma_list.Size = new System.Drawing.Size(756, 437);
            this.idioma_list.TabIndex = 48;
            // 
            // template_add
            // 
            this.template_add.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.template_add.Location = new System.Drawing.Point(484, 70);
            this.template_add.Name = "template_add";
            this.template_add.Size = new System.Drawing.Size(139, 38);
            this.template_add.TabIndex = 50;
            this.template_add.Text = "template_add";
            this.template_add.UseVisualStyleBackColor = false;
            this.template_add.Click += new System.EventHandler(this.Template_add_Click);
            // 
            // template_delete
            // 
            this.template_delete.BackColor = System.Drawing.Color.LightCoral;
            this.template_delete.ForeColor = System.Drawing.Color.White;
            this.template_delete.Location = new System.Drawing.Point(639, 70);
            this.template_delete.Name = "template_delete";
            this.template_delete.Size = new System.Drawing.Size(139, 38);
            this.template_delete.TabIndex = 49;
            this.template_delete.Text = "template_delete";
            this.template_delete.UseVisualStyleBackColor = false;
            this.template_delete.Click += new System.EventHandler(this.Template_delete_Click);
            // 
            // TemplateFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 662);
            this.Controls.Add(this.template_add);
            this.Controls.Add(this.template_delete);
            this.Controls.Add(this.idioma_list);
            this.Controls.Add(this.template_close);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.template_editor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TemplateFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Template editor";
            this.Load += new System.EventHandler(this.TemplateFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idioma_list)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label template_editor;
        private System.Windows.Forms.Button template_close;
        private System.Windows.Forms.DataGridView idioma_list;
        private System.Windows.Forms.Button template_add;
        private System.Windows.Forms.Button template_delete;
    }
}