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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.main_splash_title = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.main_change_language = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.main_menu_start = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_login = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_signup = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_signout = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_operate = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_recomendations = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_search = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_my_sells = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_balance = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_notifications = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_publish = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_it = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_it_add_user = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_it_user_manager = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_it_lang_manager = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.main_splash.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.main_menu_start,
            this.main_menu_operate,
            this.main_menu_it});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1428, 28);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1_ItemClicked);
            // 
            // main_menu_start
            // 
            this.main_menu_start.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.main_menu_login,
            this.main_menu_signup,
            this.main_menu_signout,
            this.main_menu_exit});
            this.main_menu_start.Name = "main_menu_start";
            this.main_menu_start.Size = new System.Drawing.Size(59, 24);
            this.main_menu_start.Text = "Inicio";
            this.main_menu_start.Click += new System.EventHandler(this.InicioToolStripMenuItem_Click);
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
            // main_menu_operate
            // 
            this.main_menu_operate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.main_menu_recomendations,
            this.main_menu_search,
            this.main_menu_my_sells,
            this.main_menu_balance,
            this.main_menu_notifications,
            this.main_menu_publish});
            this.main_menu_operate.Name = "main_menu_operate";
            this.main_menu_operate.Size = new System.Drawing.Size(69, 24);
            this.main_menu_operate.Text = "Operar";
            this.main_menu_operate.Click += new System.EventHandler(this.Main_menu_operate_Click);
            // 
            // main_menu_recomendations
            // 
            this.main_menu_recomendations.Name = "main_menu_recomendations";
            this.main_menu_recomendations.Size = new System.Drawing.Size(281, 26);
            this.main_menu_recomendations.Text = "main_menu_recomendations";
            this.main_menu_recomendations.Click += new System.EventHandler(this.Main_menu_recomendations_Click);
            // 
            // main_menu_search
            // 
            this.main_menu_search.Name = "main_menu_search";
            this.main_menu_search.Size = new System.Drawing.Size(281, 26);
            this.main_menu_search.Text = "main_menu_search";
            this.main_menu_search.Click += new System.EventHandler(this.Main_menu_search_Click);
            // 
            // main_menu_my_sells
            // 
            this.main_menu_my_sells.Name = "main_menu_my_sells";
            this.main_menu_my_sells.Size = new System.Drawing.Size(281, 26);
            this.main_menu_my_sells.Text = "main_menu_my_sells";
            this.main_menu_my_sells.Click += new System.EventHandler(this.Main_menu_my_sells_Click);
            // 
            // main_menu_balance
            // 
            this.main_menu_balance.Name = "main_menu_balance";
            this.main_menu_balance.Size = new System.Drawing.Size(281, 26);
            this.main_menu_balance.Text = "main_menu_balance";
            this.main_menu_balance.Click += new System.EventHandler(this.Main_menu_balance_Click);
            // 
            // main_menu_notifications
            // 
            this.main_menu_notifications.Name = "main_menu_notifications";
            this.main_menu_notifications.Size = new System.Drawing.Size(281, 26);
            this.main_menu_notifications.Text = "main_menu_notifications";
            this.main_menu_notifications.Click += new System.EventHandler(this.Main_menu_notifications_Click);
            // 
            // main_menu_publish
            // 
            this.main_menu_publish.Name = "main_menu_publish";
            this.main_menu_publish.Size = new System.Drawing.Size(281, 26);
            this.main_menu_publish.Text = "main_menu_publish";
            this.main_menu_publish.Click += new System.EventHandler(this.Main_menu_publish_Click);
            // 
            // main_menu_it
            // 
            this.main_menu_it.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.main_menu_it_add_user,
            this.main_menu_it_user_manager,
            this.main_menu_it_lang_manager});
            this.main_menu_it.Name = "main_menu_it";
            this.main_menu_it.Size = new System.Drawing.Size(35, 24);
            this.main_menu_it.Text = "IT";
            // 
            // main_menu_it_add_user
            // 
            this.main_menu_it_add_user.Name = "main_menu_it_add_user";
            this.main_menu_it_add_user.Size = new System.Drawing.Size(199, 26);
            this.main_menu_it_add_user.Text = "Alta de usuarios";
            this.main_menu_it_add_user.Click += new System.EventHandler(this.AltaDeUsuariosToolStripMenuItem_Click);
            // 
            // main_menu_it_user_manager
            // 
            this.main_menu_it_user_manager.Name = "main_menu_it_user_manager";
            this.main_menu_it_user_manager.Size = new System.Drawing.Size(199, 26);
            this.main_menu_it_user_manager.Text = "Gestor permisos";
            this.main_menu_it_user_manager.Click += new System.EventHandler(this.GestorPermisosToolStripMenuItem_Click);
            // 
            // main_menu_it_lang_manager
            // 
            this.main_menu_it_lang_manager.Name = "main_menu_it_lang_manager";
            this.main_menu_it_lang_manager.Size = new System.Drawing.Size(199, 26);
            this.main_menu_it_lang_manager.Text = "Gestor idiomas";
            this.main_menu_it_lang_manager.Click += new System.EventHandler(this.GestorIdiomasToolStripMenuItem_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem main_menu_start;
        private System.Windows.Forms.ToolStripMenuItem main_menu_login;
        private System.Windows.Forms.ToolStripMenuItem main_menu_signup;
        private System.Windows.Forms.ToolStripMenuItem main_menu_signout;
        private System.Windows.Forms.ToolStripMenuItem main_menu_exit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem main_menu_operate;
        private System.Windows.Forms.ToolStripMenuItem main_menu_it;
        private System.Windows.Forms.ToolStripMenuItem main_menu_it_add_user;
        private System.Windows.Forms.ToolStripMenuItem main_menu_it_user_manager;
        private System.Windows.Forms.ToolStripMenuItem main_menu_it_lang_manager;
        private System.Windows.Forms.ToolStripMenuItem main_menu_recomendations;
        private System.Windows.Forms.ToolStripMenuItem main_menu_search;
        private System.Windows.Forms.ToolStripMenuItem main_menu_my_sells;
        private System.Windows.Forms.ToolStripMenuItem main_menu_notifications;
        private System.Windows.Forms.ToolStripMenuItem main_menu_balance;
        private System.Windows.Forms.ToolStripMenuItem main_menu_publish;
    }
}

