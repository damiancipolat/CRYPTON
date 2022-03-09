
namespace UI.Banco
{
    partial class frm_crypto_extract
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmb_wallets_list = new System.Windows.Forms.ComboBox();
            this.extract_crypto_wallet_alert = new System.Windows.Forms.Label();
            this.extract_crypto_wallet_title = new System.Windows.Forms.Label();
            this.extract_crypto_origin = new System.Windows.Forms.Label();
            this.extract_crypto_value = new System.Windows.Forms.Label();
            this.txt_value = new System.Windows.Forms.TextBox();
            this.wallet_btn_close = new System.Windows.Forms.Button();
            this.wallet_btn_ok = new System.Windows.Forms.Button();
            this.txt_destiny = new System.Windows.Forms.TextBox();
            this.extract_crypto_destiny = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_wallets_list
            // 
            this.cmb_wallets_list.BackColor = System.Drawing.SystemColors.Info;
            this.cmb_wallets_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_wallets_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_wallets_list.FormattingEnabled = true;
            this.cmb_wallets_list.Location = new System.Drawing.Point(28, 156);
            this.cmb_wallets_list.Name = "cmb_wallets_list";
            this.cmb_wallets_list.Size = new System.Drawing.Size(456, 37);
            this.cmb_wallets_list.TabIndex = 0;
            // 
            // extract_crypto_wallet_alert
            // 
            this.extract_crypto_wallet_alert.AutoSize = true;
            this.extract_crypto_wallet_alert.BackColor = System.Drawing.Color.Moccasin;
            this.extract_crypto_wallet_alert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extract_crypto_wallet_alert.Location = new System.Drawing.Point(85, 62);
            this.extract_crypto_wallet_alert.Name = "extract_crypto_wallet_alert";
            this.extract_crypto_wallet_alert.Size = new System.Drawing.Size(209, 20);
            this.extract_crypto_wallet_alert.TabIndex = 54;
            this.extract_crypto_wallet_alert.Text = "extract_crypto_wallet_alert";
            this.extract_crypto_wallet_alert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // extract_crypto_wallet_title
            // 
            this.extract_crypto_wallet_title.AutoSize = true;
            this.extract_crypto_wallet_title.Cursor = System.Windows.Forms.Cursors.Default;
            this.extract_crypto_wallet_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extract_crypto_wallet_title.Location = new System.Drawing.Point(86, 26);
            this.extract_crypto_wallet_title.Name = "extract_crypto_wallet_title";
            this.extract_crypto_wallet_title.Size = new System.Drawing.Size(261, 25);
            this.extract_crypto_wallet_title.TabIndex = 53;
            this.extract_crypto_wallet_title.Text = "extract_crypto_wallet_title";
            // 
            // extract_crypto_origin
            // 
            this.extract_crypto_origin.AutoSize = true;
            this.extract_crypto_origin.BackColor = System.Drawing.Color.Transparent;
            this.extract_crypto_origin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extract_crypto_origin.Location = new System.Drawing.Point(24, 124);
            this.extract_crypto_origin.Name = "extract_crypto_origin";
            this.extract_crypto_origin.Size = new System.Drawing.Size(186, 20);
            this.extract_crypto_origin.TabIndex = 56;
            this.extract_crypto_origin.Text = "extract_crypto_origin";
            // 
            // extract_crypto_value
            // 
            this.extract_crypto_value.AutoSize = true;
            this.extract_crypto_value.BackColor = System.Drawing.Color.Transparent;
            this.extract_crypto_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extract_crypto_value.Location = new System.Drawing.Point(24, 210);
            this.extract_crypto_value.Name = "extract_crypto_value";
            this.extract_crypto_value.Size = new System.Drawing.Size(183, 20);
            this.extract_crypto_value.TabIndex = 57;
            this.extract_crypto_value.Text = "extract_crypto_value";
            // 
            // txt_value
            // 
            this.txt_value.BackColor = System.Drawing.SystemColors.Info;
            this.txt_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_value.Location = new System.Drawing.Point(28, 243);
            this.txt_value.Name = "txt_value";
            this.txt_value.Size = new System.Drawing.Size(456, 34);
            this.txt_value.TabIndex = 58;
            // 
            // wallet_btn_close
            // 
            this.wallet_btn_close.BackColor = System.Drawing.Color.Crimson;
            this.wallet_btn_close.ForeColor = System.Drawing.Color.White;
            this.wallet_btn_close.Location = new System.Drawing.Point(334, 390);
            this.wallet_btn_close.Name = "wallet_btn_close";
            this.wallet_btn_close.Size = new System.Drawing.Size(151, 49);
            this.wallet_btn_close.TabIndex = 60;
            this.wallet_btn_close.Text = "wallet_btn_close";
            this.wallet_btn_close.UseVisualStyleBackColor = false;
            this.wallet_btn_close.Click += new System.EventHandler(this.wallet_btn_close_Click);
            // 
            // wallet_btn_ok
            // 
            this.wallet_btn_ok.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.wallet_btn_ok.ForeColor = System.Drawing.Color.White;
            this.wallet_btn_ok.Location = new System.Drawing.Point(172, 390);
            this.wallet_btn_ok.Name = "wallet_btn_ok";
            this.wallet_btn_ok.Size = new System.Drawing.Size(151, 49);
            this.wallet_btn_ok.TabIndex = 61;
            this.wallet_btn_ok.Text = "wallet_btn_ok";
            this.wallet_btn_ok.UseVisualStyleBackColor = false;
            this.wallet_btn_ok.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_destiny
            // 
            this.txt_destiny.BackColor = System.Drawing.SystemColors.Info;
            this.txt_destiny.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_destiny.Location = new System.Drawing.Point(28, 330);
            this.txt_destiny.Name = "txt_destiny";
            this.txt_destiny.Size = new System.Drawing.Size(456, 34);
            this.txt_destiny.TabIndex = 63;
            // 
            // extract_crypto_destiny
            // 
            this.extract_crypto_destiny.AutoSize = true;
            this.extract_crypto_destiny.BackColor = System.Drawing.Color.Transparent;
            this.extract_crypto_destiny.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extract_crypto_destiny.Location = new System.Drawing.Point(24, 297);
            this.extract_crypto_destiny.Name = "extract_crypto_destiny";
            this.extract_crypto_destiny.Size = new System.Drawing.Size(199, 20);
            this.extract_crypto_destiny.TabIndex = 62;
            this.extract_crypto_destiny.Text = "extract_crypto_destiny";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.money_transaction;
            this.pictureBox1.Location = new System.Drawing.Point(26, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            // 
            // frm_crypto_extract
            // 
            this.ClientSize = new System.Drawing.Size(514, 462);
            this.Controls.Add(this.txt_destiny);
            this.Controls.Add(this.extract_crypto_destiny);
            this.Controls.Add(this.wallet_btn_ok);
            this.Controls.Add(this.wallet_btn_close);
            this.Controls.Add(this.txt_value);
            this.Controls.Add(this.extract_crypto_value);
            this.Controls.Add(this.extract_crypto_origin);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.extract_crypto_wallet_alert);
            this.Controls.Add(this.extract_crypto_wallet_title);
            this.Controls.Add(this.cmb_wallets_list);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_crypto_extract";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retiro - crypto";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frm_crypto_extract_HelpButtonClicked);
            this.Load += new System.EventHandler(this.frm_crypto_extract_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_wallets_list;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label extract_crypto_wallet_alert;
        private System.Windows.Forms.Label extract_crypto_wallet_title;
        private System.Windows.Forms.Label extract_crypto_origin;
        private System.Windows.Forms.Label extract_crypto_value;
        private System.Windows.Forms.TextBox txt_value;
        private System.Windows.Forms.Button wallet_btn_close;
        private System.Windows.Forms.Button wallet_btn_ok;
        private System.Windows.Forms.TextBox txt_destiny;
        private System.Windows.Forms.Label extract_crypto_destiny;
    }
}
