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
            this.sell_title = new System.Windows.Forms.Label();
            this.txt_ammount_enter = new System.Windows.Forms.TextBox();
            this.sell_money1 = new System.Windows.Forms.Label();
            this.moneda_a_combo = new System.Windows.Forms.ComboBox();
            this.sell_input = new System.Windows.Forms.Label();
            this.sell_close = new System.Windows.Forms.Button();
            this.sell_publish = new System.Windows.Forms.Button();
            this.sell_money2 = new System.Windows.Forms.Label();
            this.txt_ammount_receive = new System.Windows.Forms.TextBox();
            this.moneda_b_combo = new System.Windows.Forms.ComboBox();
            this.sell_receive = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sell_tax = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sell_title
            // 
            this.sell_title.AutoSize = true;
            this.sell_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sell_title.Location = new System.Drawing.Point(103, 16);
            this.sell_title.Name = "sell_title";
            this.sell_title.Size = new System.Drawing.Size(144, 38);
            this.sell_title.TabIndex = 0;
            this.sell_title.Text = "sell_title";
            this.sell_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sell_title.Click += new System.EventHandler(this.Label1_Click);
            // 
            // txt_ammount_enter
            // 
            this.txt_ammount_enter.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ammount_enter.Location = new System.Drawing.Point(33, 150);
            this.txt_ammount_enter.Name = "txt_ammount_enter";
            this.txt_ammount_enter.Size = new System.Drawing.Size(279, 34);
            this.txt_ammount_enter.TabIndex = 12;
            this.txt_ammount_enter.Click += new System.EventHandler(this.Txt_ammount_enter_Click);
            this.txt_ammount_enter.Leave += new System.EventHandler(this.Txt_ammount_enter_Leave);
            // 
            // sell_money1
            // 
            this.sell_money1.AutoSize = true;
            this.sell_money1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sell_money1.Location = new System.Drawing.Point(330, 121);
            this.sell_money1.Name = "sell_money1";
            this.sell_money1.Size = new System.Drawing.Size(89, 17);
            this.sell_money1.TabIndex = 11;
            this.sell_money1.Text = "sell_money";
            this.sell_money1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // sell_input
            // 
            this.sell_input.AutoSize = true;
            this.sell_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sell_input.Location = new System.Drawing.Point(33, 121);
            this.sell_input.Name = "sell_input";
            this.sell_input.Size = new System.Drawing.Size(78, 17);
            this.sell_input.TabIndex = 9;
            this.sell_input.Text = "sell_input";
            this.sell_input.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sell_close
            // 
            this.sell_close.BackColor = System.Drawing.Color.Crimson;
            this.sell_close.ForeColor = System.Drawing.Color.White;
            this.sell_close.Location = new System.Drawing.Point(320, 381);
            this.sell_close.Name = "sell_close";
            this.sell_close.Size = new System.Drawing.Size(165, 49);
            this.sell_close.TabIndex = 12;
            this.sell_close.Text = "sell_close";
            this.sell_close.UseVisualStyleBackColor = false;
            this.sell_close.Click += new System.EventHandler(this.Signup_cancel_Click);
            // 
            // sell_publish
            // 
            this.sell_publish.Location = new System.Drawing.Point(164, 381);
            this.sell_publish.Name = "sell_publish";
            this.sell_publish.Size = new System.Drawing.Size(143, 49);
            this.sell_publish.TabIndex = 11;
            this.sell_publish.Text = "sell_publish";
            this.sell_publish.UseVisualStyleBackColor = true;
            this.sell_publish.Click += new System.EventHandler(this.Publish_ok_Click);
            // 
            // sell_money2
            // 
            this.sell_money2.AutoSize = true;
            this.sell_money2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sell_money2.Location = new System.Drawing.Point(330, 243);
            this.sell_money2.Name = "sell_money2";
            this.sell_money2.Size = new System.Drawing.Size(89, 17);
            this.sell_money2.TabIndex = 15;
            this.sell_money2.Text = "sell_money";
            // 
            // txt_ammount_receive
            // 
            this.txt_ammount_receive.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ammount_receive.Location = new System.Drawing.Point(29, 277);
            this.txt_ammount_receive.Name = "txt_ammount_receive";
            this.txt_ammount_receive.Size = new System.Drawing.Size(278, 34);
            this.txt_ammount_receive.TabIndex = 16;
            this.txt_ammount_receive.Click += new System.EventHandler(this.Txt_ammount_receive_Click);
            this.txt_ammount_receive.TextChanged += new System.EventHandler(this.Txt_ammount_receive_TextChanged);
            this.txt_ammount_receive.Enter += new System.EventHandler(this.Txt_ammount_receive_Enter);
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
            // sell_receive
            // 
            this.sell_receive.AutoSize = true;
            this.sell_receive.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sell_receive.Location = new System.Drawing.Point(30, 208);
            this.sell_receive.Name = "sell_receive";
            this.sell_receive.Size = new System.Drawing.Size(95, 17);
            this.sell_receive.TabIndex = 13;
            this.sell_receive.Text = "sell_receive";
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
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(125, 239);
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
            // sell_tax
            // 
            this.sell_tax.AutoSize = true;
            this.sell_tax.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sell_tax.ForeColor = System.Drawing.Color.DarkOrange;
            this.sell_tax.Location = new System.Drawing.Point(26, 336);
            this.sell_tax.Name = "sell_tax";
            this.sell_tax.Size = new System.Drawing.Size(63, 17);
            this.sell_tax.TabIndex = 22;
            this.sell_tax.Text = "sell_tax";
            // 
            // frm_publish_sell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 469);
            this.Controls.Add(this.sell_tax);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.sell_money2);
            this.Controls.Add(this.txt_ammount_receive);
            this.Controls.Add(this.moneda_b_combo);
            this.Controls.Add(this.sell_receive);
            this.Controls.Add(this.sell_money1);
            this.Controls.Add(this.txt_ammount_enter);
            this.Controls.Add(this.moneda_a_combo);
            this.Controls.Add(this.sell_close);
            this.Controls.Add(this.sell_publish);
            this.Controls.Add(this.sell_input);
            this.Controls.Add(this.sell_title);
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

        private System.Windows.Forms.Label sell_title;
        private System.Windows.Forms.ComboBox moneda_a_combo;
        private System.Windows.Forms.Label sell_input;
        private System.Windows.Forms.TextBox txt_ammount_enter;
        private System.Windows.Forms.Label sell_money1;
        private System.Windows.Forms.Button sell_close;
        private System.Windows.Forms.Button sell_publish;
        private System.Windows.Forms.Label sell_money2;
        private System.Windows.Forms.TextBox txt_ammount_receive;
        private System.Windows.Forms.ComboBox moneda_b_combo;
        private System.Windows.Forms.Label sell_receive;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label sell_tax;
    }
}