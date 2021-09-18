namespace UI
{
    partial class frm_profile
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
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.txt_profile_type_doc = new System.Windows.Forms.Label();
            this.txt_type_doc = new System.Windows.Forms.TextBox();
            this.txt_num_doc = new System.Windows.Forms.TextBox();
            this.txt_profile_doc_number = new System.Windows.Forms.Label();
            this.txt_birth_date = new System.Windows.Forms.DateTimePicker();
            this.txt_profile_birth_date = new System.Windows.Forms.Label();
            this.txt_tramite = new System.Windows.Forms.TextBox();
            this.txt_profile_tramite = new System.Windows.Forms.Label();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.txt_profile_address = new System.Windows.Forms.Label();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.txt_profile_phone = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.LightCoral;
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Location = new System.Drawing.Point(181, 546);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(150, 46);
            this.btn_close.TabIndex = 41;
            this.btn_close.Text = "usr_change_close";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.Usr_change_close_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_ok.ForeColor = System.Drawing.Color.White;
            this.btn_ok.Location = new System.Drawing.Point(18, 546);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(148, 46);
            this.btn_ok.TabIndex = 42;
            this.btn_ok.Text = "button1";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txt_profile_type_doc
            // 
            this.txt_profile_type_doc.AutoSize = true;
            this.txt_profile_type_doc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_profile_type_doc.Location = new System.Drawing.Point(18, 24);
            this.txt_profile_type_doc.Name = "txt_profile_type_doc";
            this.txt_profile_type_doc.Size = new System.Drawing.Size(223, 25);
            this.txt_profile_type_doc.TabIndex = 43;
            this.txt_profile_type_doc.Text = "txt_profile_type_doc";
            // 
            // txt_type_doc
            // 
            this.txt_type_doc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_type_doc.Location = new System.Drawing.Point(18, 58);
            this.txt_type_doc.Name = "txt_type_doc";
            this.txt_type_doc.Size = new System.Drawing.Size(313, 27);
            this.txt_type_doc.TabIndex = 44;
            // 
            // txt_num_doc
            // 
            this.txt_num_doc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_num_doc.Location = new System.Drawing.Point(22, 142);
            this.txt_num_doc.Name = "txt_num_doc";
            this.txt_num_doc.Size = new System.Drawing.Size(309, 27);
            this.txt_num_doc.TabIndex = 46;
            // 
            // txt_profile_doc_number
            // 
            this.txt_profile_doc_number.AutoSize = true;
            this.txt_profile_doc_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_profile_doc_number.Location = new System.Drawing.Point(22, 108);
            this.txt_profile_doc_number.Name = "txt_profile_doc_number";
            this.txt_profile_doc_number.Size = new System.Drawing.Size(256, 25);
            this.txt_profile_doc_number.TabIndex = 45;
            this.txt_profile_doc_number.Text = "txt_profile_doc_number";
            // 
            // txt_birth_date
            // 
            this.txt_birth_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_birth_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_birth_date.Location = new System.Drawing.Point(22, 224);
            this.txt_birth_date.Name = "txt_birth_date";
            this.txt_birth_date.Size = new System.Drawing.Size(189, 27);
            this.txt_birth_date.TabIndex = 47;
            // 
            // txt_profile_birth_date
            // 
            this.txt_profile_birth_date.AutoSize = true;
            this.txt_profile_birth_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_profile_birth_date.Location = new System.Drawing.Point(22, 193);
            this.txt_profile_birth_date.Name = "txt_profile_birth_date";
            this.txt_profile_birth_date.Size = new System.Drawing.Size(234, 25);
            this.txt_profile_birth_date.TabIndex = 48;
            this.txt_profile_birth_date.Text = "txt_profile_birth_date";
            // 
            // txt_tramite
            // 
            this.txt_tramite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tramite.Location = new System.Drawing.Point(22, 311);
            this.txt_tramite.Name = "txt_tramite";
            this.txt_tramite.Size = new System.Drawing.Size(309, 27);
            this.txt_tramite.TabIndex = 50;
            // 
            // txt_profile_tramite
            // 
            this.txt_profile_tramite.AutoSize = true;
            this.txt_profile_tramite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_profile_tramite.Location = new System.Drawing.Point(22, 280);
            this.txt_profile_tramite.Name = "txt_profile_tramite";
            this.txt_profile_tramite.Size = new System.Drawing.Size(203, 25);
            this.txt_profile_tramite.TabIndex = 49;
            this.txt_profile_tramite.Text = "txt_profile_tramite";
            // 
            // txt_address
            // 
            this.txt_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_address.Location = new System.Drawing.Point(22, 391);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(309, 27);
            this.txt_address.TabIndex = 52;
            // 
            // txt_profile_address
            // 
            this.txt_profile_address.AutoSize = true;
            this.txt_profile_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_profile_address.Location = new System.Drawing.Point(22, 360);
            this.txt_profile_address.Name = "txt_profile_address";
            this.txt_profile_address.Size = new System.Drawing.Size(213, 25);
            this.txt_profile_address.TabIndex = 51;
            this.txt_profile_address.Text = "txt_profile_address";
            // 
            // txt_phone
            // 
            this.txt_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_phone.Location = new System.Drawing.Point(22, 483);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(309, 27);
            this.txt_phone.TabIndex = 54;
            // 
            // txt_profile_phone
            // 
            this.txt_profile_phone.AutoSize = true;
            this.txt_profile_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_profile_phone.Location = new System.Drawing.Point(22, 452);
            this.txt_profile_phone.Name = "txt_profile_phone";
            this.txt_profile_phone.Size = new System.Drawing.Size(191, 25);
            this.txt_profile_phone.TabIndex = 53;
            this.txt_profile_phone.Text = "txt_profile_phone";
            // 
            // frm_profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 620);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.txt_profile_phone);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.txt_profile_address);
            this.Controls.Add(this.txt_tramite);
            this.Controls.Add(this.txt_profile_tramite);
            this.Controls.Add(this.txt_profile_birth_date);
            this.Controls.Add(this.txt_birth_date);
            this.Controls.Add(this.txt_num_doc);
            this.Controls.Add(this.txt_profile_doc_number);
            this.Controls.Add(this.txt_type_doc);
            this.Controls.Add(this.txt_profile_type_doc);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_profile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_profile";
            this.Load += new System.EventHandler(this.Frm_profile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label txt_profile_type_doc;
        private System.Windows.Forms.TextBox txt_type_doc;
        private System.Windows.Forms.TextBox txt_num_doc;
        private System.Windows.Forms.Label txt_profile_doc_number;
        private System.Windows.Forms.DateTimePicker txt_birth_date;
        private System.Windows.Forms.Label txt_profile_birth_date;
        private System.Windows.Forms.TextBox txt_tramite;
        private System.Windows.Forms.Label txt_profile_tramite;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.Label txt_profile_address;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.Label txt_profile_phone;
    }
}