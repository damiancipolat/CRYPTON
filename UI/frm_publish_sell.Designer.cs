namespace UI
{
    partial class frm_publish_sell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_publish_sell));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_saldo_money = new System.Windows.Forms.Label();
            this.txt_ammount_enter = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.moneda_a_combo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.signup_cancel = new System.Windows.Forms.Button();
            this.publish_ok = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ammount_receive = new System.Windows.Forms.TextBox();
            this.moneda_b_combo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quiero vender...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // txt_saldo_money
            // 
            this.txt_saldo_money.AutoSize = true;
            this.txt_saldo_money.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_saldo_money.ForeColor = System.Drawing.Color.Chocolate;
            this.txt_saldo_money.Location = new System.Drawing.Point(104, 61);
            this.txt_saldo_money.Name = "txt_saldo_money";
            this.txt_saldo_money.Size = new System.Drawing.Size(287, 24);
            this.txt_saldo_money.TabIndex = 1;
            this.txt_saldo_money.Text = "Saldo actual: XXXXXXX BTC";
            // 
            // txt_ammount_enter
            // 
            this.txt_ammount_enter.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ammount_enter.Location = new System.Drawing.Point(33, 150);
            this.txt_ammount_enter.Name = "txt_ammount_enter";
            this.txt_ammount_enter.Size = new System.Drawing.Size(279, 34);
            this.txt_ammount_enter.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(330, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "Moneda:";
            // 
            // moneda_a_combo
            // 
            this.moneda_a_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.moneda_a_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moneda_a_combo.FormattingEnabled = true;
            this.moneda_a_combo.Location = new System.Drawing.Point(330, 148);
            this.moneda_a_combo.Name = "moneda_a_combo";
            this.moneda_a_combo.Size = new System.Drawing.Size(155, 37);
            this.moneda_a_combo.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(33, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Ingrese la cantidad:";
            // 
            // signup_cancel
            // 
            this.signup_cancel.BackColor = System.Drawing.Color.Crimson;
            this.signup_cancel.ForeColor = System.Drawing.Color.White;
            this.signup_cancel.Location = new System.Drawing.Point(320, 341);
            this.signup_cancel.Name = "signup_cancel";
            this.signup_cancel.Size = new System.Drawing.Size(165, 49);
            this.signup_cancel.TabIndex = 12;
            this.signup_cancel.Text = "Cancelar";
            this.signup_cancel.UseVisualStyleBackColor = false;
            // 
            // publish_ok
            // 
            this.publish_ok.Location = new System.Drawing.Point(164, 341);
            this.publish_ok.Name = "publish_ok";
            this.publish_ok.Size = new System.Drawing.Size(143, 49);
            this.publish_ok.TabIndex = 11;
            this.publish_ok.Text = "Publicar";
            this.publish_ok.UseVisualStyleBackColor = true;
            this.publish_ok.Click += new System.EventHandler(this.Publish_ok_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(330, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Moneda:";
            // 
            // txt_ammount_receive
            // 
            this.txt_ammount_receive.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ammount_receive.Location = new System.Drawing.Point(29, 277);
            this.txt_ammount_receive.Name = "txt_ammount_receive";
            this.txt_ammount_receive.Size = new System.Drawing.Size(278, 34);
            this.txt_ammount_receive.TabIndex = 16;
            // 
            // moneda_b_combo
            // 
            this.moneda_b_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.moneda_b_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moneda_b_combo.FormattingEnabled = true;
            this.moneda_b_combo.Location = new System.Drawing.Point(330, 277);
            this.moneda_b_combo.Name = "moneda_b_combo";
            this.moneda_b_combo.Size = new System.Drawing.Size(155, 37);
            this.moneda_b_combo.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tú recibiras:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(35, 239);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(61, 21);
            this.radioButton1.TabIndex = 17;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Libre";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(113, 239);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(136, 21);
            this.radioButton2.TabIndex = 18;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Cotizacion actual";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // frm_publish_sell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 425);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_ammount_receive);
            this.Controls.Add(this.moneda_b_combo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_ammount_enter);
            this.Controls.Add(this.moneda_a_combo);
            this.Controls.Add(this.signup_cancel);
            this.Controls.Add(this.publish_ok);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_saldo_money);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_publish_sell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_publish_sell";
            this.Load += new System.EventHandler(this.Frm_publish_sell_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txt_saldo_money;
        private System.Windows.Forms.ComboBox moneda_a_combo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_ammount_enter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button signup_cancel;
        private System.Windows.Forms.Button publish_ok;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ammount_receive;
        private System.Windows.Forms.ComboBox moneda_b_combo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}