namespace UI
{
    partial class frm_main
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
            this.main_btn_login = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.main_splash = new System.Windows.Forms.Panel();
            this.main_btn_register = new System.Windows.Forms.Button();
            this.main_splash_title = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_login = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_signup = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_signout = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.main_menu_buy = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_sell = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_search = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_deposit = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_extract = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_operate = new System.Windows.Forms.ToolStripMenuItem();
            this.iTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestorPermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.main_change_language = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.main_splash.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // main_btn_login
            // 
            this.main_btn_login.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.main_btn_login.Location = new System.Drawing.Point(45, 210);
            this.main_btn_login.Name = "main_btn_login";
            this.main_btn_login.Size = new System.Drawing.Size(148, 40);
            this.main_btn_login.TabIndex = 0;
            this.main_btn_login.Text = "main_btn_login";
            this.main_btn_login.UseVisualStyleBackColor = false;
            this.main_btn_login.Click += new System.EventHandler(this.Button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Location = new System.Drawing.Point(1528, 348);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 119);
            this.panel2.TabIndex = 8;
            // 
            // main_splash
            // 
            this.main_splash.BackColor = System.Drawing.Color.White;
            this.main_splash.Controls.Add(this.main_btn_register);
            this.main_splash.Controls.Add(this.pictureBox3);
            this.main_splash.Controls.Add(this.main_splash_title);
            this.main_splash.Controls.Add(this.main_btn_login);
            this.main_splash.Location = new System.Drawing.Point(476, 290);
            this.main_splash.Name = "main_splash";
            this.main_splash.Size = new System.Drawing.Size(403, 272);
            this.main_splash.TabIndex = 10;
            this.main_splash.Resize += new System.EventHandler(this.Main_splash_Resize);
            // 
            // main_btn_register
            // 
            this.main_btn_register.BackColor = System.Drawing.Color.LightSkyBlue;
            this.main_btn_register.Location = new System.Drawing.Point(209, 210);
            this.main_btn_register.Name = "main_btn_register";
            this.main_btn_register.Size = new System.Drawing.Size(148, 40);
            this.main_btn_register.TabIndex = 14;
            this.main_btn_register.Text = "Registrar";
            this.main_btn_register.UseVisualStyleBackColor = false;
            this.main_btn_register.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // main_splash_title
            // 
            this.main_splash_title.AutoSize = true;
            this.main_splash_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_splash_title.ForeColor = System.Drawing.SystemColors.Highlight;
            this.main_splash_title.Location = new System.Drawing.Point(33, 161);
            this.main_splash_title.Name = "main_splash_title";
            this.main_splash_title.Size = new System.Drawing.Size(162, 25);
            this.main_splash_title.TabIndex = 12;
            this.main_splash_title.Text = "main_splash_title";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 754);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1428, 26);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.main_menu_operate,
            this.iTToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1428, 28);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1_ItemClicked);
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.main_menu_login,
            this.main_menu_signup,
            this.main_menu_signout,
            this.main_menu_exit});
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.inicioToolStripMenuItem.Text = "Inicio";
            this.inicioToolStripMenuItem.Click += new System.EventHandler(this.InicioToolStripMenuItem_Click);
            // 
            // main_menu_login
            // 
            this.main_menu_login.Name = "main_menu_login";
            this.main_menu_login.Size = new System.Drawing.Size(223, 26);
            this.main_menu_login.Text = "main_menu_login";
            this.main_menu_login.Click += new System.EventHandler(this.Main_menu_login_Click);
            // 
            // main_menu_signup
            // 
            this.main_menu_signup.Name = "main_menu_signup";
            this.main_menu_signup.Size = new System.Drawing.Size(223, 26);
            this.main_menu_signup.Text = "main_menu_signup";
            this.main_menu_signup.Click += new System.EventHandler(this.CerrarSesionToolStripMenuItem_Click);
            // 
            // main_menu_signout
            // 
            this.main_menu_signout.Name = "main_menu_signout";
            this.main_menu_signout.Size = new System.Drawing.Size(223, 26);
            this.main_menu_signout.Text = "main_menu_signout";
            this.main_menu_signout.Click += new System.EventHandler(this.Main_menu_signout_Click);
            // 
            // main_menu_exit
            // 
            this.main_menu_exit.Name = "main_menu_exit";
            this.main_menu_exit.Size = new System.Drawing.Size(223, 26);
            this.main_menu_exit.Text = "main_menu_exit";
            this.main_menu_exit.Click += new System.EventHandler(this.SalirToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(183, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 42);
            this.button2.TabIndex = 22;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click_4);
            // 
            // main_menu_buy
            // 
            this.main_menu_buy.Name = "main_menu_buy";
            this.main_menu_buy.Size = new System.Drawing.Size(224, 26);
            this.main_menu_buy.Text = "main_menu_buy";
            // 
            // main_menu_sell
            // 
            this.main_menu_sell.Name = "main_menu_sell";
            this.main_menu_sell.Size = new System.Drawing.Size(224, 26);
            this.main_menu_sell.Text = "main_menu_sell";
            // 
            // main_menu_search
            // 
            this.main_menu_search.Name = "main_menu_search";
            this.main_menu_search.Size = new System.Drawing.Size(224, 26);
            this.main_menu_search.Text = "main_menu_search";
            // 
            // main_menu_deposit
            // 
            this.main_menu_deposit.Name = "main_menu_deposit";
            this.main_menu_deposit.Size = new System.Drawing.Size(224, 26);
            this.main_menu_deposit.Text = "main_menu_deposit";
            // 
            // main_menu_extract
            // 
            this.main_menu_extract.Name = "main_menu_extract";
            this.main_menu_extract.Size = new System.Drawing.Size(224, 26);
            this.main_menu_extract.Text = "main_menu_extract";
            // 
            // main_menu_operate
            // 
            this.main_menu_operate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.main_menu_buy,
            this.main_menu_sell,
            this.main_menu_search,
            this.main_menu_deposit,
            this.main_menu_extract});
            this.main_menu_operate.Name = "main_menu_operate";
            this.main_menu_operate.Size = new System.Drawing.Size(69, 24);
            this.main_menu_operate.Text = "Operar";
            this.main_menu_operate.Click += new System.EventHandler(this.Main_menu_operate_Click);
            // 
            // iTToolStripMenuItem
            // 
            this.iTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaDeUsuariosToolStripMenuItem,
            this.gestorPermisosToolStripMenuItem});
            this.iTToolStripMenuItem.Name = "iTToolStripMenuItem";
            this.iTToolStripMenuItem.Size = new System.Drawing.Size(35, 24);
            this.iTToolStripMenuItem.Text = "IT";
            // 
            // altaDeUsuariosToolStripMenuItem
            // 
            this.altaDeUsuariosToolStripMenuItem.Name = "altaDeUsuariosToolStripMenuItem";
            this.altaDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.altaDeUsuariosToolStripMenuItem.Text = "Alta de usuarios";
            this.altaDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.AltaDeUsuariosToolStripMenuItem_Click);
            // 
            // gestorPermisosToolStripMenuItem
            // 
            this.gestorPermisosToolStripMenuItem.Name = "gestorPermisosToolStripMenuItem";
            this.gestorPermisosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.gestorPermisosToolStripMenuItem.Text = "Gestor permisos";
            this.gestorPermisosToolStripMenuItem.Click += new System.EventHandler(this.GestorPermisosToolStripMenuItem_Click);
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.main_change_language});
            this.toolStripSplitButton2.Image = global::UI.Properties.Resources.globe;
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(39, 24);
            this.toolStripSplitButton2.Text = "toolStripSplitButton2";
            // 
            // main_change_language
            // 
            this.main_change_language.Name = "main_change_language";
            this.main_change_language.Size = new System.Drawing.Size(247, 26);
            this.main_change_language.Text = "main_change_language";
            this.main_change_language.Click += new System.EventHandler(this.CambiarIdiomaToolStripMenuItem_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::UI.Properties.Resources.logo_11;
            this.pictureBox3.Location = new System.Drawing.Point(119, 23);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(161, 116);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::UI.Properties.Resources.background2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1428, 780);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 780);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.main_splash);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crypton - home";
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_Paint);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.main_splash.ResumeLayout(false);
            this.main_splash.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button main_btn_login;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel main_splash;
        private System.Windows.Forms.Label main_splash_title;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem main_change_language;
        private System.Windows.Forms.Button main_btn_register;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem main_menu_login;
        private System.Windows.Forms.ToolStripMenuItem main_menu_signup;
        private System.Windows.Forms.ToolStripMenuItem main_menu_signout;
        private System.Windows.Forms.ToolStripMenuItem main_menu_exit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem main_menu_operate;
        private System.Windows.Forms.ToolStripMenuItem main_menu_buy;
        private System.Windows.Forms.ToolStripMenuItem main_menu_sell;
        private System.Windows.Forms.ToolStripMenuItem main_menu_search;
        private System.Windows.Forms.ToolStripMenuItem main_menu_deposit;
        private System.Windows.Forms.ToolStripMenuItem main_menu_extract;
        private System.Windows.Forms.ToolStripMenuItem iTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestorPermisosToolStripMenuItem;
    }
}

