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
            this.permission_label = new System.Windows.Forms.Label();
            this.permission_title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_key = new System.Windows.Forms.TextBox();
            this.txt_value = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_update_permission = new System.Windows.Forms.Button();
            this.btn_compound_permission = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // permission_label
            // 
            this.permission_label.AutoSize = true;
            this.permission_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.permission_label.Location = new System.Drawing.Point(26, 70);
            this.permission_label.Name = "permission_label";
            this.permission_label.Size = new System.Drawing.Size(429, 20);
            this.permission_label.TabIndex = 25;
            this.permission_label.Text = "Escriba la nueva palabra que formara parte del lenguaje.";
            this.permission_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // permission_title
            // 
            this.permission_title.AutoSize = true;
            this.permission_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.permission_title.Location = new System.Drawing.Point(23, 19);
            this.permission_title.Name = "permission_title";
            this.permission_title.Size = new System.Drawing.Size(198, 38);
            this.permission_title.TabIndex = 24;
            this.permission_title.Text = "Nueva clave";
            this.permission_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Clave";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Traducción:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_key);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.permission_label);
            this.Controls.Add(this.permission_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Word";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Word";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label permission_label;
        private System.Windows.Forms.Label permission_title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_key;
        private System.Windows.Forms.TextBox txt_value;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_update_permission;
        private System.Windows.Forms.Button btn_compound_permission;
    }
}