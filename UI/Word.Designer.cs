namespace UI
{
    partial class Word
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
            this.ui_lang_new_key_descrip = new System.Windows.Forms.Label();
            this.ui_lang_new_key = new System.Windows.Forms.Label();
            this.ui_lang_new_key_title = new System.Windows.Forms.Label();
            this.txt_key = new System.Windows.Forms.TextBox();
            this.txt_value = new System.Windows.Forms.TextBox();
            this.ui_lang_new_value_title = new System.Windows.Forms.Label();
            this.btn_update_permission = new System.Windows.Forms.Button();
            this.btn_compound_permission = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ui_lang_new_key_descrip
            // 
            this.ui_lang_new_key_descrip.AutoSize = true;
            this.ui_lang_new_key_descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_lang_new_key_descrip.Location = new System.Drawing.Point(26, 70);
            this.ui_lang_new_key_descrip.Name = "ui_lang_new_key_descrip";
            this.ui_lang_new_key_descrip.Size = new System.Drawing.Size(249, 25);
            this.ui_lang_new_key_descrip.TabIndex = 25;
            this.ui_lang_new_key_descrip.Text = "ui_lang_new_key_descrip";
            this.ui_lang_new_key_descrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_lang_new_key
            // 
            this.ui_lang_new_key.AutoSize = true;
            this.ui_lang_new_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_lang_new_key.Location = new System.Drawing.Point(23, 19);
            this.ui_lang_new_key.Name = "ui_lang_new_key";
            this.ui_lang_new_key.Size = new System.Drawing.Size(336, 48);
            this.ui_lang_new_key.TabIndex = 24;
            this.ui_lang_new_key.Text = "ui_lang_new_key";
            this.ui_lang_new_key.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_lang_new_key_title
            // 
            this.ui_lang_new_key_title.AutoSize = true;
            this.ui_lang_new_key_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_lang_new_key_title.Location = new System.Drawing.Point(26, 111);
            this.ui_lang_new_key_title.Name = "ui_lang_new_key_title";
            this.ui_lang_new_key_title.Size = new System.Drawing.Size(240, 25);
            this.ui_lang_new_key_title.TabIndex = 26;
            this.ui_lang_new_key_title.Text = "ui_lang_new_key_title";
            this.ui_lang_new_key_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_key
            // 
            this.txt_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_key.Location = new System.Drawing.Point(30, 145);
            this.txt_key.Name = "txt_key";
            this.txt_key.Size = new System.Drawing.Size(425, 30);
            this.txt_key.TabIndex = 28;
            // 
            // txt_value
            // 
            this.txt_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_value.Location = new System.Drawing.Point(30, 233);
            this.txt_value.Name = "txt_value";
            this.txt_value.Size = new System.Drawing.Size(425, 30);
            this.txt_value.TabIndex = 30;
            // 
            // ui_lang_new_value_title
            // 
            this.ui_lang_new_value_title.AutoSize = true;
            this.ui_lang_new_value_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_lang_new_value_title.Location = new System.Drawing.Point(26, 195);
            this.ui_lang_new_value_title.Name = "ui_lang_new_value_title";
            this.ui_lang_new_value_title.Size = new System.Drawing.Size(260, 25);
            this.ui_lang_new_value_title.TabIndex = 29;
            this.ui_lang_new_value_title.Text = "ui_lang_new_value_title";
            this.ui_lang_new_value_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_update_permission
            // 
            this.btn_update_permission.BackColor = System.Drawing.Color.LightCoral;
            this.btn_update_permission.ForeColor = System.Drawing.Color.Transparent;
            this.btn_update_permission.Location = new System.Drawing.Point(342, 288);
            this.btn_update_permission.Name = "btn_update_permission";
            this.btn_update_permission.Size = new System.Drawing.Size(113, 45);
            this.btn_update_permission.TabIndex = 35;
            this.btn_update_permission.Text = "Cancelar";
            this.btn_update_permission.UseVisualStyleBackColor = false;
            this.btn_update_permission.Click += new System.EventHandler(this.Btn_update_permission_Click);
            // 
            // btn_compound_permission
            // 
            this.btn_compound_permission.Location = new System.Drawing.Point(180, 288);
            this.btn_compound_permission.Name = "btn_compound_permission";
            this.btn_compound_permission.Size = new System.Drawing.Size(147, 45);
            this.btn_compound_permission.TabIndex = 34;
            this.btn_compound_permission.Text = "Aceptar";
            this.btn_compound_permission.UseVisualStyleBackColor = true;
            this.btn_compound_permission.Click += new System.EventHandler(this.Btn_compound_permission_Click);
            // 
            // Word
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 357);
            this.Controls.Add(this.btn_update_permission);
            this.Controls.Add(this.btn_compound_permission);
            this.Controls.Add(this.txt_value);
            this.Controls.Add(this.ui_lang_new_value_title);
            this.Controls.Add(this.txt_key);
            this.Controls.Add(this.ui_lang_new_key_title);
            this.Controls.Add(this.ui_lang_new_key_descrip);
            this.Controls.Add(this.ui_lang_new_key);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Word";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Word";
            this.Load += new System.EventHandler(this.Word_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ui_lang_new_key_descrip;
        private System.Windows.Forms.Label ui_lang_new_key;
        private System.Windows.Forms.Label ui_lang_new_key_title;
        private System.Windows.Forms.TextBox txt_key;
        private System.Windows.Forms.TextBox txt_value;
        private System.Windows.Forms.Label ui_lang_new_value_title;
        private System.Windows.Forms.Button btn_update_permission;
        private System.Windows.Forms.Button btn_compound_permission;
    }
}