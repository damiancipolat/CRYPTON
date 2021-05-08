namespace UI
{
    partial class frm_signup
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
            this.signup_cancel = new System.Windows.Forms.Button();
            this.signup_ok = new System.Windows.Forms.Button();
            this.signup_txt_surname = new System.Windows.Forms.TextBox();
            this.signup_surname = new System.Windows.Forms.Label();
            this.signup_name = new System.Windows.Forms.Label();
            this.signup_txt_name = new System.Windows.Forms.TextBox();
            this.signup_title = new System.Windows.Forms.Label();
            this.signup_txt_alias = new System.Windows.Forms.TextBox();
            this.signup_alias = new System.Windows.Forms.Label();
            this.signup_txt_email = new System.Windows.Forms.TextBox();
            this.signup_email = new System.Windows.Forms.Label();
            this.signup_txt_pwd = new System.Windows.Forms.TextBox();
            this.signup_pwd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.register;
            this.pictureBox1.Location = new System.Drawing.Point(25, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // signup_cancel
            // 
            this.signup_cancel.BackColor = System.Drawing.Color.Crimson;
            this.signup_cancel.Location = new System.Drawing.Point(315, 508);
            this.signup_cancel.Name = "signup_cancel";
            this.signup_cancel.Size = new System.Drawing.Size(165, 49);
            this.signup_cancel.TabIndex = 16;
            this.signup_cancel.Text = "signup_cancel";
            this.signup_cancel.UseVisualStyleBackColor = false;
            this.signup_cancel.Click += new System.EventHandler(this.Login_btn_cancel_Click);
            // 
            // signup_ok
            // 
            this.signup_ok.Location = new System.Drawing.Point(148, 507);
            this.signup_ok.Name = "signup_ok";
            this.signup_ok.Size = new System.Drawing.Size(143, 49);
            this.signup_ok.TabIndex = 15;
            this.signup_ok.Text = "signup_ok";
            this.signup_ok.UseVisualStyleBackColor = true;
            this.signup_ok.Click += new System.EventHandler(this.Signup_ok_Click);
            // 
            // signup_txt_surname
            // 
            this.signup_txt_surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_txt_surname.Location = new System.Drawing.Point(426, 118);
            this.signup_txt_surname.Name = "signup_txt_surname";
            this.signup_txt_surname.Size = new System.Drawing.Size(246, 34);
            this.signup_txt_surname.TabIndex = 14;
            // 
            // signup_surname
            // 
            this.signup_surname.AutoSize = true;
            this.signup_surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_surname.Location = new System.Drawing.Point(427, 79);
            this.signup_surname.Name = "signup_surname";
            this.signup_surname.Size = new System.Drawing.Size(151, 24);
            this.signup_surname.TabIndex = 13;
            this.signup_surname.Text = "signup_surname";
            this.signup_surname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // signup_name
            // 
            this.signup_name.AutoSize = true;
            this.signup_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_name.Location = new System.Drawing.Point(147, 80);
            this.signup_name.Name = "signup_name";
            this.signup_name.Size = new System.Drawing.Size(125, 24);
            this.signup_name.TabIndex = 12;
            this.signup_name.Text = "signup_name";
            // 
            // signup_txt_name
            // 
            this.signup_txt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_txt_name.Location = new System.Drawing.Point(150, 118);
            this.signup_txt_name.Name = "signup_txt_name";
            this.signup_txt_name.Size = new System.Drawing.Size(246, 34);
            this.signup_txt_name.TabIndex = 11;
            // 
            // signup_title
            // 
            this.signup_title.AutoSize = true;
            this.signup_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_title.Location = new System.Drawing.Point(144, 25);
            this.signup_title.Name = "signup_title";
            this.signup_title.Size = new System.Drawing.Size(181, 38);
            this.signup_title.TabIndex = 10;
            this.signup_title.Text = "signup_title";
            this.signup_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // signup_txt_alias
            // 
            this.signup_txt_alias.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_txt_alias.Location = new System.Drawing.Point(148, 220);
            this.signup_txt_alias.Name = "signup_txt_alias";
            this.signup_txt_alias.Size = new System.Drawing.Size(246, 34);
            this.signup_txt_alias.TabIndex = 18;
            // 
            // signup_alias
            // 
            this.signup_alias.AutoSize = true;
            this.signup_alias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_alias.Location = new System.Drawing.Point(149, 181);
            this.signup_alias.Name = "signup_alias";
            this.signup_alias.Size = new System.Drawing.Size(114, 24);
            this.signup_alias.TabIndex = 17;
            this.signup_alias.Text = "signup_alias";
            this.signup_alias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // signup_txt_email
            // 
            this.signup_txt_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_txt_email.Location = new System.Drawing.Point(148, 323);
            this.signup_txt_email.Name = "signup_txt_email";
            this.signup_txt_email.Size = new System.Drawing.Size(524, 34);
            this.signup_txt_email.TabIndex = 20;
            this.signup_txt_email.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // signup_email
            // 
            this.signup_email.AutoSize = true;
            this.signup_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_email.Location = new System.Drawing.Point(149, 284);
            this.signup_email.Name = "signup_email";
            this.signup_email.Size = new System.Drawing.Size(122, 24);
            this.signup_email.TabIndex = 19;
            this.signup_email.Text = "signup_email";
            this.signup_email.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.signup_email.Click += new System.EventHandler(this.Label2_Click);
            // 
            // signup_txt_pwd
            // 
            this.signup_txt_pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_txt_pwd.Location = new System.Drawing.Point(148, 436);
            this.signup_txt_pwd.Name = "signup_txt_pwd";
            this.signup_txt_pwd.PasswordChar = '*';
            this.signup_txt_pwd.Size = new System.Drawing.Size(246, 34);
            this.signup_txt_pwd.TabIndex = 22;
            // 
            // signup_pwd
            // 
            this.signup_pwd.AutoSize = true;
            this.signup_pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_pwd.Location = new System.Drawing.Point(149, 397);
            this.signup_pwd.Name = "signup_pwd";
            this.signup_pwd.Size = new System.Drawing.Size(113, 24);
            this.signup_pwd.TabIndex = 21;
            this.signup_pwd.Text = "signup_pwd";
            this.signup_pwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 588);
            this.Controls.Add(this.signup_txt_pwd);
            this.Controls.Add(this.signup_pwd);
            this.Controls.Add(this.signup_txt_email);
            this.Controls.Add(this.signup_email);
            this.Controls.Add(this.signup_txt_alias);
            this.Controls.Add(this.signup_alias);
            this.Controls.Add(this.signup_cancel);
            this.Controls.Add(this.signup_ok);
            this.Controls.Add(this.signup_txt_surname);
            this.Controls.Add(this.signup_surname);
            this.Controls.Add(this.signup_name);
            this.Controls.Add(this.signup_txt_name);
            this.Controls.Add(this.signup_title);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_signup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Frm_signup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button signup_cancel;
        private System.Windows.Forms.Button signup_ok;
        private System.Windows.Forms.TextBox signup_txt_surname;
        private System.Windows.Forms.Label signup_surname;
        private System.Windows.Forms.Label signup_name;
        private System.Windows.Forms.TextBox signup_txt_name;
        private System.Windows.Forms.Label signup_title;
        private System.Windows.Forms.TextBox signup_txt_alias;
        private System.Windows.Forms.Label signup_alias;
        private System.Windows.Forms.TextBox signup_txt_email;
        private System.Windows.Forms.Label signup_email;
        private System.Windows.Forms.TextBox signup_txt_pwd;
        private System.Windows.Forms.Label signup_pwd;
    }
}