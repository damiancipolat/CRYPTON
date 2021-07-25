namespace UI.Permisos
{
    partial class TreeEditorFrm
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
            this.permission_tree = new System.Windows.Forms.TreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.usr_lang_del_all_language = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tree_family_list = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // permission_label
            // 
            this.permission_label.AutoSize = true;
            this.permission_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.permission_label.Location = new System.Drawing.Point(114, 66);
            this.permission_label.Name = "permission_label";
            this.permission_label.Size = new System.Drawing.Size(422, 20);
            this.permission_label.TabIndex = 37;
            this.permission_label.Text = "Aqui podes armar arboles de permisos -familia/patente.";
            this.permission_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // permission_title
            // 
            this.permission_title.AutoSize = true;
            this.permission_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.permission_title.Location = new System.Drawing.Point(110, 24);
            this.permission_title.Name = "permission_title";
            this.permission_title.Size = new System.Drawing.Size(102, 38);
            this.permission_title.TabIndex = 36;
            this.permission_title.Text = "Editor";
            this.permission_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // permission_tree
            // 
            this.permission_tree.Location = new System.Drawing.Point(23, 263);
            this.permission_tree.Name = "permission_tree";
            this.permission_tree.Size = new System.Drawing.Size(1182, 426);
            this.permission_tree.TabIndex = 35;
            this.permission_tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Permission_tree_AfterSelect);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.permiso;
            this.pictureBox1.Location = new System.Drawing.Point(23, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(187, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 45);
            this.button1.TabIndex = 53;
            this.button1.Text = "ABM Patente";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(23, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 45);
            this.button2.TabIndex = 54;
            this.button2.Text = "ABM Familia";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // usr_lang_del_all_language
            // 
            this.usr_lang_del_all_language.BackColor = System.Drawing.Color.LightCoral;
            this.usr_lang_del_all_language.ForeColor = System.Drawing.Color.White;
            this.usr_lang_del_all_language.Location = new System.Drawing.Point(1087, 710);
            this.usr_lang_del_all_language.Name = "usr_lang_del_all_language";
            this.usr_lang_del_all_language.Size = new System.Drawing.Size(118, 45);
            this.usr_lang_del_all_language.TabIndex = 56;
            this.usr_lang_del_all_language.Text = "Cerrar";
            this.usr_lang_del_all_language.UseVisualStyleBackColor = false;
            this.usr_lang_del_all_language.Click += new System.EventHandler(this.Usr_lang_del_all_language_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.tree_family_list);
            this.panel1.Location = new System.Drawing.Point(23, 178);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1182, 64);
            this.panel1.TabIndex = 57;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightGreen;
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(1063, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 33);
            this.button3.TabIndex = 61;
            this.button3.Text = "Guardar";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Info;
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(832, 14);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(101, 33);
            this.button5.TabIndex = 60;
            this.button5.Text = "+ Familia";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Info;
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(949, 14);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 33);
            this.button4.TabIndex = 59;
            this.button4.Text = "+ Patente";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // tree_family_list
            // 
            this.tree_family_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tree_family_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tree_family_list.FormattingEnabled = true;
            this.tree_family_list.Location = new System.Drawing.Point(14, 14);
            this.tree_family_list.Name = "tree_family_list";
            this.tree_family_list.Size = new System.Drawing.Size(333, 33);
            this.tree_family_list.TabIndex = 0;
            this.tree_family_list.SelectedIndexChanged += new System.EventHandler(this.Tree_family_list_SelectedIndexChanged);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(362, 14);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(61, 33);
            this.button6.TabIndex = 62;
            this.button6.Text = "Ver";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // TreeEditorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 776);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.usr_lang_del_all_language);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.permission_label);
            this.Controls.Add(this.permission_title);
            this.Controls.Add(this.permission_tree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TreeEditorFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TreeEditorFrm";
            this.Load += new System.EventHandler(this.TreeEditorFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label permission_label;
        private System.Windows.Forms.Label permission_title;
        private System.Windows.Forms.TreeView permission_tree;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button usr_lang_del_all_language;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox tree_family_list;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
    }
}