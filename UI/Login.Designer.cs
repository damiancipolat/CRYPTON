namespace UI
{
    partial class frm_login
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
            this.login_title_1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.login_title_email = new System.Windows.Forms.Label();
            this.login_title_password = new System.Windows.Forms.Label();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.login_btn_ingresar = new System.Windows.Forms.Button();
            this.login_btn_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // login_title_1
            // 
            this.login_title_1.AutoSize = true;
            this.login_title_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_title_1.Location = new System.Drawing.Point(148, 28);
            this.login_title_1.Name = "login_title_1";
            this.login_title_1.Size = new System.Drawing.Size(189, 38);
            this.login_title_1.TabIndex = 0;
            this.login_title_1.Text = "login_title_1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.login1;
            this.pictureBox1.Location = new System.Drawing.Point(27, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // txt_email
            // 
            this.txt_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.Location = new System.Drawing.Point(154, 121);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(334, 34);
            this.txt_email.TabIndex = 3;
            // 
            // login_title_email
            // 
            this.login_title_email.AutoSize = true;
            this.login_title_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_title_email.Location = new System.Drawing.Point(151, 83);
            this.login_title_email.Name = "login_title_email";
            this.login_title_email.Size = new System.Drawing.Size(143, 24);
            this.login_title_email.TabIndex = 5;
            this.login_title_email.Text = "login_title_email";
            // 
            // login_title_password
            // 
            this.login_title_password.AutoSize = true;
            this.login_title_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_title_password.Location = new System.Drawing.Point(151, 180);
            this.login_title_password.Name = "login_title_password";
            this.login_title_password.Size = new System.Drawing.Size(179, 24);
            this.login_title_password.TabIndex = 6;
            this.login_title_password.Text = "login_title_password";
            // 
            // txt_pwd
            // 
            this.txt_pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pwd.Location = new System.Drawing.Point(157, 218);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.PasswordChar = '*';
            this.txt_pwd.Size = new System.Drawing.Size(331, 34);
            this.txt_pwd.TabIndex = 7;
            // 
            // login_btn_ingresar
            // 
            this.login_btn_ingresar.Location = new System.Drawing.Point(157, 273);
            this.login_btn_ingresar.Name = "login_btn_ingresar";
            this.login_btn_ingresar.Size = new System.Drawing.Size(143, 49);
            this.login_btn_ingresar.TabIndex = 8;
            this.login_btn_ingresar.Text = "login_btn_ingresar";
            this.login_btn_ingresar.UseVisualStyleBackColor = true;
            this.login_btn_ingresar.Click += new System.EventHandler(this.Button1_Click);
            // 
            // login_btn_cancel
            // 
            this.login_btn_cancel.BackColor = System.Drawing.Color.Crimson;
            this.login_btn_cancel.ForeColor = System.Drawing.Color.White;
            this.login_btn_cancel.Location = new System.Drawing.Point(323, 273);
            this.login_btn_cancel.Name = "login_btn_cancel";
            this.login_btn_cancel.Size = new System.Drawing.Size(165, 49);
            this.login_btn_cancel.TabIndex = 9;
            this.login_btn_cancel.Text = "login_btn_cancel";
            this.login_btn_cancel.UseVisualStyleBackColor = false;
            this.login_btn_cancel.Click += new System.EventHandler(this.Login_btn_cancel_Click);
            // 
            // frm_login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(558, 364);
            this.Controls.Add(this.login_btn_cancel);
            this.Controls.Add(this.login_btn_ingresar);
            this.Controls.Add(this.txt_pwd);
            this.Controls.Add(this.login_title_password);
            this.Controls.Add(this.login_title_email);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.login_title_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frm_login_HelpButtonClicked);
            this.Load += new System.EventHandler(this.Frm_login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label login_title_1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label login_title_email;
        private System.Windows.Forms.Label login_title_password;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.Button login_btn_ingresar;
        private System.Windows.Forms.Button login_btn_cancel;
    }
}