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
            this.tree_descrip_editor = new System.Windows.Forms.Label();
            this.tree_title_editor = new System.Windows.Forms.Label();
            this.permission_tree = new System.Windows.Forms.TreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tree_crud_patent = new System.Windows.Forms.Button();
            this.tree_crud_family = new System.Windows.Forms.Button();
            this.tree_crud_close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tree_crud_view = new System.Windows.Forms.Button();
            this.tree_crud_save = new System.Windows.Forms.Button();
            this.tree_crud_add_family = new System.Windows.Forms.Button();
            this.tree_crud_add_patent = new System.Windows.Forms.Button();
            this.tree_family_list = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tree_descrip_editor
            // 
            this.tree_descrip_editor.AutoSize = true;
            this.tree_descrip_editor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tree_descrip_editor.Location = new System.Drawing.Point(114, 67);
            this.tree_descrip_editor.Name = "tree_descrip_editor";
            this.tree_descrip_editor.Size = new System.Drawing.Size(191, 25);
            this.tree_descrip_editor.TabIndex = 37;
            this.tree_descrip_editor.Text = "tree_descrip_editor";
            this.tree_descrip_editor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tree_title_editor
            // 
            this.tree_title_editor.AutoSize = true;
            this.tree_title_editor.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tree_title_editor.Location = new System.Drawing.Point(110, 20);
            this.tree_title_editor.Name = "tree_title_editor";
            this.tree_title_editor.Size = new System.Drawing.Size(240, 38);
            this.tree_title_editor.TabIndex = 36;
            this.tree_title_editor.Text = "tree_title_editor";
            this.tree_title_editor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // tree_crud_patent
            // 
            this.tree_crud_patent.Location = new System.Drawing.Point(187, 115);
            this.tree_crud_patent.Name = "tree_crud_patent";
            this.tree_crud_patent.Size = new System.Drawing.Size(149, 45);
            this.tree_crud_patent.TabIndex = 53;
            this.tree_crud_patent.Text = "tree_crud_patent";
            this.tree_crud_patent.UseVisualStyleBackColor = true;
            this.tree_crud_patent.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tree_crud_family
            // 
            this.tree_crud_family.Location = new System.Drawing.Point(23, 115);
            this.tree_crud_family.Name = "tree_crud_family";
            this.tree_crud_family.Size = new System.Drawing.Size(149, 45);
            this.tree_crud_family.TabIndex = 54;
            this.tree_crud_family.Text = "tree_crud_family";
            this.tree_crud_family.UseVisualStyleBackColor = true;
            this.tree_crud_family.Click += new System.EventHandler(this.Button2_Click);
            // 
            // tree_crud_close
            // 
            this.tree_crud_close.BackColor = System.Drawing.Color.LightCoral;
            this.tree_crud_close.ForeColor = System.Drawing.Color.White;
            this.tree_crud_close.Location = new System.Drawing.Point(1087, 710);
            this.tree_crud_close.Name = "tree_crud_close";
            this.tree_crud_close.Size = new System.Drawing.Size(118, 45);
            this.tree_crud_close.TabIndex = 56;
            this.tree_crud_close.Text = "tree_crud_close";
            this.tree_crud_close.UseVisualStyleBackColor = false;
            this.tree_crud_close.Click += new System.EventHandler(this.Usr_lang_del_all_language_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tree_crud_view);
            this.panel1.Controls.Add(this.tree_crud_save);
            this.panel1.Controls.Add(this.tree_crud_add_family);
            this.panel1.Controls.Add(this.tree_crud_add_patent);
            this.panel1.Controls.Add(this.tree_family_list);
            this.panel1.Location = new System.Drawing.Point(23, 178);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1182, 64);
            this.panel1.TabIndex = 57;
            // 
            // tree_crud_view
            // 
            this.tree_crud_view.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tree_crud_view.ForeColor = System.Drawing.Color.White;
            this.tree_crud_view.Location = new System.Drawing.Point(362, 14);
            this.tree_crud_view.Name = "tree_crud_view";
            this.tree_crud_view.Size = new System.Drawing.Size(70, 33);
            this.tree_crud_view.TabIndex = 62;
            this.tree_crud_view.Text = "tree_crud_view";
            this.tree_crud_view.UseVisualStyleBackColor = false;
            this.tree_crud_view.Click += new System.EventHandler(this.Button6_Click);
            // 
            // tree_crud_save
            // 
            this.tree_crud_save.BackColor = System.Drawing.Color.LightGreen;
            this.tree_crud_save.ForeColor = System.Drawing.Color.Black;
            this.tree_crud_save.Location = new System.Drawing.Point(1063, 14);
            this.tree_crud_save.Name = "tree_crud_save";
            this.tree_crud_save.Size = new System.Drawing.Size(101, 33);
            this.tree_crud_save.TabIndex = 61;
            this.tree_crud_save.Text = "tree_crud_save";
            this.tree_crud_save.UseVisualStyleBackColor = false;
            this.tree_crud_save.Click += new System.EventHandler(this.Button3_Click);
            // 
            // tree_crud_add_family
            // 
            this.tree_crud_add_family.BackColor = System.Drawing.SystemColors.Info;
            this.tree_crud_add_family.ForeColor = System.Drawing.Color.Black;
            this.tree_crud_add_family.Location = new System.Drawing.Point(836, 14);
            this.tree_crud_add_family.Name = "tree_crud_add_family";
            this.tree_crud_add_family.Size = new System.Drawing.Size(101, 33);
            this.tree_crud_add_family.TabIndex = 60;
            this.tree_crud_add_family.Text = "tree_crud_add_family";
            this.tree_crud_add_family.UseVisualStyleBackColor = false;
            this.tree_crud_add_family.Click += new System.EventHandler(this.Button5_Click);
            // 
            // tree_crud_add_patent
            // 
            this.tree_crud_add_patent.BackColor = System.Drawing.SystemColors.Info;
            this.tree_crud_add_patent.ForeColor = System.Drawing.Color.Black;
            this.tree_crud_add_patent.Location = new System.Drawing.Point(950, 14);
            this.tree_crud_add_patent.Name = "tree_crud_add_patent";
            this.tree_crud_add_patent.Size = new System.Drawing.Size(101, 33);
            this.tree_crud_add_patent.TabIndex = 59;
            this.tree_crud_add_patent.Text = "tree_crud_add_patent";
            this.tree_crud_add_patent.UseVisualStyleBackColor = false;
            this.tree_crud_add_patent.Click += new System.EventHandler(this.Button4_Click);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(630, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 58;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // TreeEditorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 776);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tree_crud_close);
            this.Controls.Add(this.tree_crud_family);
            this.Controls.Add(this.tree_crud_patent);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tree_descrip_editor);
            this.Controls.Add(this.tree_title_editor);
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
        private System.Windows.Forms.Label tree_descrip_editor;
        private System.Windows.Forms.Label tree_title_editor;
        private System.Windows.Forms.TreeView permission_tree;
        private System.Windows.Forms.Button tree_crud_patent;
        private System.Windows.Forms.Button tree_crud_family;
        private System.Windows.Forms.Button tree_crud_close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox tree_family_list;
        private System.Windows.Forms.Button tree_crud_add_patent;
        private System.Windows.Forms.Button tree_crud_add_family;
        private System.Windows.Forms.Button tree_crud_save;
        private System.Windows.Forms.Button tree_crud_view;
        private System.Windows.Forms.Button button1;
    }
}