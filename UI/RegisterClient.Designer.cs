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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.signup_cancel = new System.Windows.Forms.Button();
            this.signup_ok = new System.Windows.Forms.Button();
            this.signup_title = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.phone_number_txt = new System.Windows.Forms.TextBox();
            this.birth_date_txt = new System.Windows.Forms.MaskedTextBox();
            this.document_number = new System.Windows.Forms.Label();
            this.document_number_txt = new System.Windows.Forms.TextBox();
            this.phone_number = new System.Windows.Forms.Label();
            this.order_number = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.Label();
            this.address_txt = new System.Windows.Forms.TextBox();
            this.order_number_txt = new System.Windows.Forms.TextBox();
            this.birth_date = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.signup_name = new System.Windows.Forms.Label();
            this.signup_txt_pwd = new System.Windows.Forms.TextBox();
            this.signup_txt_name = new System.Windows.Forms.TextBox();
            this.signup_pwd = new System.Windows.Forms.Label();
            this.signup_surname = new System.Windows.Forms.Label();
            this.signup_email = new System.Windows.Forms.Label();
            this.signup_txt_email = new System.Windows.Forms.TextBox();
            this.signup_txt_surname = new System.Windows.Forms.TextBox();
            this.signup_txt_alias = new System.Windows.Forms.TextBox();
            this.signup_alias = new System.Windows.Forms.Label();
            this.signup_description = new System.Windows.Forms.Label();
            this.your_documents = new System.Windows.Forms.Label();
            this.your_user_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.signup_cancel.ForeColor = System.Drawing.Color.White;
            this.signup_cancel.Location = new System.Drawing.Point(649, 606);
            this.signup_cancel.Name = "signup_cancel";
            this.signup_cancel.Size = new System.Drawing.Size(165, 49);
            this.signup_cancel.TabIndex = 12;
            this.signup_cancel.Text = "signup_cancel";
            this.signup_cancel.UseVisualStyleBackColor = false;
            this.signup_cancel.Click += new System.EventHandler(this.Login_btn_cancel_Click);
            // 
            // signup_ok
            // 
            this.signup_ok.Location = new System.Drawing.Point(487, 606);
            this.signup_ok.Name = "signup_ok";
            this.signup_ok.Size = new System.Drawing.Size(143, 49);
            this.signup_ok.TabIndex = 11;
            this.signup_ok.Text = "signup_ok";
            this.signup_ok.UseVisualStyleBackColor = true;
            this.signup_ok.Click += new System.EventHandler(this.Signup_ok_Click);
            // 
            // signup_title
            // 
            this.signup_title.AutoSize = true;
            this.signup_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_title.Location = new System.Drawing.Point(144, 24);
            this.signup_title.Name = "signup_title";
            this.signup_title.Size = new System.Drawing.Size(181, 38);
            this.signup_title.TabIndex = 10;
            this.signup_title.Text = "signup_title";
            this.signup_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.phone_number_txt);
            this.panel2.Controls.Add(this.birth_date_txt);
            this.panel2.Controls.Add(this.document_number);
            this.panel2.Controls.Add(this.document_number_txt);
            this.panel2.Controls.Add(this.phone_number);
            this.panel2.Controls.Add(this.order_number);
            this.panel2.Controls.Add(this.address);
            this.panel2.Controls.Add(this.address_txt);
            this.panel2.Controls.Add(this.order_number_txt);
            this.panel2.Controls.Add(this.birth_date);
            this.panel2.Location = new System.Drawing.Point(499, 121);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 458);
            this.panel2.TabIndex = 24;
            // 
            // phone_number_txt
            // 
            this.phone_number_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone_number_txt.Location = new System.Drawing.Point(30, 393);
            this.phone_number_txt.Name = "phone_number_txt";
            this.phone_number_txt.Size = new System.Drawing.Size(246, 34);
            this.phone_number_txt.TabIndex = 29;
            // 
            // birth_date_txt
            // 
            this.birth_date_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.birth_date_txt.Location = new System.Drawing.Point(28, 134);
            this.birth_date_txt.Mask = "00/00/0000";
            this.birth_date_txt.Name = "birth_date_txt";
            this.birth_date_txt.Size = new System.Drawing.Size(248, 28);
            this.birth_date_txt.TabIndex = 7;
            this.birth_date_txt.ValidatingType = typeof(System.DateTime);
            // 
            // document_number
            // 
            this.document_number.AutoSize = true;
            this.document_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.document_number.Location = new System.Drawing.Point(24, 21);
            this.document_number.Name = "document_number";
            this.document_number.Size = new System.Drawing.Size(171, 24);
            this.document_number.TabIndex = 12;
            this.document_number.Text = "document_number";
            // 
            // document_number_txt
            // 
            this.document_number_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.document_number_txt.Location = new System.Drawing.Point(28, 51);
            this.document_number_txt.Name = "document_number_txt";
            this.document_number_txt.Size = new System.Drawing.Size(246, 34);
            this.document_number_txt.TabIndex = 6;
            // 
            // phone_number
            // 
            this.phone_number.AutoSize = true;
            this.phone_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone_number.Location = new System.Drawing.Point(33, 355);
            this.phone_number.Name = "phone_number";
            this.phone_number.Size = new System.Drawing.Size(141, 24);
            this.phone_number.TabIndex = 21;
            this.phone_number.Text = "phone_number";
            this.phone_number.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // order_number
            // 
            this.order_number.AutoSize = true;
            this.order_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.order_number.Location = new System.Drawing.Point(27, 186);
            this.order_number.Name = "order_number";
            this.order_number.Size = new System.Drawing.Size(131, 24);
            this.order_number.TabIndex = 13;
            this.order_number.Text = "order_number";
            this.order_number.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // address
            // 
            this.address.AutoSize = true;
            this.address.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address.Location = new System.Drawing.Point(27, 264);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(77, 24);
            this.address.TabIndex = 19;
            this.address.Text = "address";
            this.address.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // address_txt
            // 
            this.address_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address_txt.Location = new System.Drawing.Point(31, 299);
            this.address_txt.Name = "address_txt";
            this.address_txt.Size = new System.Drawing.Size(246, 34);
            this.address_txt.TabIndex = 9;
            // 
            // order_number_txt
            // 
            this.order_number_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.order_number_txt.Location = new System.Drawing.Point(29, 221);
            this.order_number_txt.Name = "order_number_txt";
            this.order_number_txt.Size = new System.Drawing.Size(245, 34);
            this.order_number_txt.TabIndex = 8;
            // 
            // birth_date
            // 
            this.birth_date.AutoSize = true;
            this.birth_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.birth_date.Location = new System.Drawing.Point(24, 103);
            this.birth_date.Name = "birth_date";
            this.birth_date.Size = new System.Drawing.Size(92, 24);
            this.birth_date.TabIndex = 17;
            this.birth_date.Text = "birth_date";
            this.birth_date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.signup_name);
            this.panel1.Controls.Add(this.signup_txt_pwd);
            this.panel1.Controls.Add(this.signup_txt_name);
            this.panel1.Controls.Add(this.signup_pwd);
            this.panel1.Controls.Add(this.signup_surname);
            this.panel1.Controls.Add(this.signup_email);
            this.panel1.Controls.Add(this.signup_txt_email);
            this.panel1.Controls.Add(this.signup_txt_surname);
            this.panel1.Controls.Add(this.signup_txt_alias);
            this.panel1.Controls.Add(this.signup_alias);
            this.panel1.Location = new System.Drawing.Point(151, 121);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 458);
            this.panel1.TabIndex = 25;
            // 
            // signup_name
            // 
            this.signup_name.AutoSize = true;
            this.signup_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_name.Location = new System.Drawing.Point(24, 21);
            this.signup_name.Name = "signup_name";
            this.signup_name.Size = new System.Drawing.Size(125, 24);
            this.signup_name.TabIndex = 12;
            this.signup_name.Text = "signup_name";
            // 
            // signup_txt_pwd
            // 
            this.signup_txt_pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_txt_pwd.Location = new System.Drawing.Point(32, 393);
            this.signup_txt_pwd.Name = "signup_txt_pwd";
            this.signup_txt_pwd.PasswordChar = '*';
            this.signup_txt_pwd.Size = new System.Drawing.Size(243, 34);
            this.signup_txt_pwd.TabIndex = 5;
            // 
            // signup_txt_name
            // 
            this.signup_txt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_txt_name.Location = new System.Drawing.Point(28, 51);
            this.signup_txt_name.Name = "signup_txt_name";
            this.signup_txt_name.Size = new System.Drawing.Size(246, 34);
            this.signup_txt_name.TabIndex = 1;
            // 
            // signup_pwd
            // 
            this.signup_pwd.AutoSize = true;
            this.signup_pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_pwd.Location = new System.Drawing.Point(33, 355);
            this.signup_pwd.Name = "signup_pwd";
            this.signup_pwd.Size = new System.Drawing.Size(113, 24);
            this.signup_pwd.TabIndex = 21;
            this.signup_pwd.Text = "signup_pwd";
            this.signup_pwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // signup_surname
            // 
            this.signup_surname.AutoSize = true;
            this.signup_surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_surname.Location = new System.Drawing.Point(27, 101);
            this.signup_surname.Name = "signup_surname";
            this.signup_surname.Size = new System.Drawing.Size(151, 24);
            this.signup_surname.TabIndex = 13;
            this.signup_surname.Text = "signup_surname";
            this.signup_surname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // signup_email
            // 
            this.signup_email.AutoSize = true;
            this.signup_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_email.Location = new System.Drawing.Point(27, 264);
            this.signup_email.Name = "signup_email";
            this.signup_email.Size = new System.Drawing.Size(122, 24);
            this.signup_email.TabIndex = 19;
            this.signup_email.Text = "signup_email";
            this.signup_email.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // signup_txt_email
            // 
            this.signup_txt_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_txt_email.Location = new System.Drawing.Point(31, 299);
            this.signup_txt_email.Name = "signup_txt_email";
            this.signup_txt_email.Size = new System.Drawing.Size(246, 34);
            this.signup_txt_email.TabIndex = 4;
            // 
            // signup_txt_surname
            // 
            this.signup_txt_surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_txt_surname.Location = new System.Drawing.Point(28, 135);
            this.signup_txt_surname.Name = "signup_txt_surname";
            this.signup_txt_surname.Size = new System.Drawing.Size(245, 34);
            this.signup_txt_surname.TabIndex = 2;
            // 
            // signup_txt_alias
            // 
            this.signup_txt_alias.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_txt_alias.Location = new System.Drawing.Point(29, 218);
            this.signup_txt_alias.Name = "signup_txt_alias";
            this.signup_txt_alias.Size = new System.Drawing.Size(246, 34);
            this.signup_txt_alias.TabIndex = 3;
            // 
            // signup_alias
            // 
            this.signup_alias.AutoSize = true;
            this.signup_alias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_alias.Location = new System.Drawing.Point(26, 183);
            this.signup_alias.Name = "signup_alias";
            this.signup_alias.Size = new System.Drawing.Size(114, 24);
            this.signup_alias.TabIndex = 17;
            this.signup_alias.Text = "signup_alias";
            this.signup_alias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // signup_description
            // 
            this.signup_description.AutoSize = true;
            this.signup_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_description.Location = new System.Drawing.Point(147, 66);
            this.signup_description.Name = "signup_description";
            this.signup_description.Size = new System.Drawing.Size(169, 24);
            this.signup_description.TabIndex = 26;
            this.signup_description.Text = "signup_description";
            // 
            // your_documents
            // 
            this.your_documents.AutoSize = true;
            this.your_documents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.your_documents.Location = new System.Drawing.Point(523, 107);
            this.your_documents.Name = "your_documents";
            this.your_documents.Size = new System.Drawing.Size(185, 24);
            this.your_documents.TabIndex = 27;
            this.your_documents.Text = "Tú documentacion";
            this.your_documents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // your_user_label
            // 
            this.your_user_label.AutoSize = true;
            this.your_user_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.your_user_label.Location = new System.Drawing.Point(176, 107);
            this.your_user_label.Name = "your_user_label";
            this.your_user_label.Size = new System.Drawing.Size(110, 24);
            this.your_user_label.TabIndex = 28;
            this.your_user_label.Text = "Tú usuario";
            this.your_user_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frm_signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 676);
            this.Controls.Add(this.your_user_label);
            this.Controls.Add(this.your_documents);
            this.Controls.Add(this.signup_description);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.signup_cancel);
            this.Controls.Add(this.signup_ok);
            this.Controls.Add(this.signup_title);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_signup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Frm_signup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button signup_cancel;
        private System.Windows.Forms.Button signup_ok;
        private System.Windows.Forms.Label signup_title;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label signup_name;
        private System.Windows.Forms.TextBox signup_txt_pwd;
        private System.Windows.Forms.TextBox signup_txt_name;
        private System.Windows.Forms.Label signup_pwd;
        private System.Windows.Forms.Label signup_surname;
        private System.Windows.Forms.Label signup_email;
        private System.Windows.Forms.TextBox signup_txt_email;
        private System.Windows.Forms.TextBox signup_txt_surname;
        private System.Windows.Forms.TextBox signup_txt_alias;
        private System.Windows.Forms.Label signup_alias;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label document_number;
        private System.Windows.Forms.TextBox document_number_txt;
        private System.Windows.Forms.Label phone_number;
        private System.Windows.Forms.Label order_number;
        private System.Windows.Forms.Label address;
        private System.Windows.Forms.TextBox address_txt;
        private System.Windows.Forms.TextBox order_number_txt;
        private System.Windows.Forms.Label birth_date;
        private System.Windows.Forms.Label signup_description;
        private System.Windows.Forms.Label your_documents;
        private System.Windows.Forms.Label your_user_label;
        private System.Windows.Forms.MaskedTextBox birth_date_txt;
        private System.Windows.Forms.TextBox phone_number_txt;
    }
}