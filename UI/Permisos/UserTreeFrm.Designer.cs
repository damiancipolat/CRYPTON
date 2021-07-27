namespace UI.Permisos
{
    partial class UserTreeFrm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.user_tree_crud_delete = new System.Windows.Forms.Button();
            this.user_tree_crud_save = new System.Windows.Forms.Button();
            this.user_tree_crud_add_family = new System.Windows.Forms.Button();
            this.user_tree_crud_add_patent = new System.Windows.Forms.Button();
            this.user_tree_family_list = new System.Windows.Forms.ComboBox();
            this.user_tree_crud_close = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.user_tree_descrip_editor = new System.Windows.Forms.Label();
            this.user_tree_title_editor = new System.Windows.Forms.Label();
            this.user_permission_tree = new System.Windows.Forms.TreeView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.user_tree_crud_delete);
            this.panel1.Controls.Add(this.user_tree_crud_save);
            this.panel1.Controls.Add(this.user_tree_crud_add_family);
            this.panel1.Controls.Add(this.user_tree_crud_add_patent);
            this.panel1.Controls.Add(this.user_tree_family_list);
            this.panel1.Location = new System.Drawing.Point(21, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1182, 64);
            this.panel1.TabIndex = 68;
            // 
            // user_tree_crud_delete
            // 
            this.user_tree_crud_delete.BackColor = System.Drawing.Color.DarkSalmon;
            this.user_tree_crud_delete.ForeColor = System.Drawing.Color.White;
            this.user_tree_crud_delete.Location = new System.Drawing.Point(725, 15);
            this.user_tree_crud_delete.Name = "user_tree_crud_delete";
            this.user_tree_crud_delete.Size = new System.Drawing.Size(101, 31);
            this.user_tree_crud_delete.TabIndex = 58;
            this.user_tree_crud_delete.Text = "tree_crud_delete";
            this.user_tree_crud_delete.UseVisualStyleBackColor = false;
            this.user_tree_crud_delete.Click += new System.EventHandler(this.User_tree_crud_delete_Click);
            // 
            // user_tree_crud_save
            // 
            this.user_tree_crud_save.BackColor = System.Drawing.Color.LightGreen;
            this.user_tree_crud_save.ForeColor = System.Drawing.Color.Black;
            this.user_tree_crud_save.Location = new System.Drawing.Point(1063, 14);
            this.user_tree_crud_save.Name = "user_tree_crud_save";
            this.user_tree_crud_save.Size = new System.Drawing.Size(101, 33);
            this.user_tree_crud_save.TabIndex = 61;
            this.user_tree_crud_save.Text = "tree_crud_save";
            this.user_tree_crud_save.UseVisualStyleBackColor = false;
            this.user_tree_crud_save.Click += new System.EventHandler(this.User_tree_crud_save_Click);
            // 
            // user_tree_crud_add_family
            // 
            this.user_tree_crud_add_family.BackColor = System.Drawing.SystemColors.Info;
            this.user_tree_crud_add_family.ForeColor = System.Drawing.Color.Black;
            this.user_tree_crud_add_family.Location = new System.Drawing.Point(838, 13);
            this.user_tree_crud_add_family.Name = "user_tree_crud_add_family";
            this.user_tree_crud_add_family.Size = new System.Drawing.Size(101, 33);
            this.user_tree_crud_add_family.TabIndex = 60;
            this.user_tree_crud_add_family.Text = "tree_crud_add_family";
            this.user_tree_crud_add_family.UseVisualStyleBackColor = false;
            this.user_tree_crud_add_family.Click += new System.EventHandler(this.User_tree_crud_add_family_Click);
            // 
            // user_tree_crud_add_patent
            // 
            this.user_tree_crud_add_patent.BackColor = System.Drawing.SystemColors.Info;
            this.user_tree_crud_add_patent.ForeColor = System.Drawing.Color.Black;
            this.user_tree_crud_add_patent.Location = new System.Drawing.Point(950, 13);
            this.user_tree_crud_add_patent.Name = "user_tree_crud_add_patent";
            this.user_tree_crud_add_patent.Size = new System.Drawing.Size(101, 33);
            this.user_tree_crud_add_patent.TabIndex = 59;
            this.user_tree_crud_add_patent.Text = "tree_crud_add_patent";
            this.user_tree_crud_add_patent.UseVisualStyleBackColor = false;
            this.user_tree_crud_add_patent.Click += new System.EventHandler(this.User_tree_crud_add_patent_Click);
            // 
            // user_tree_family_list
            // 
            this.user_tree_family_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.user_tree_family_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_tree_family_list.FormattingEnabled = true;
            this.user_tree_family_list.Location = new System.Drawing.Point(14, 14);
            this.user_tree_family_list.Name = "user_tree_family_list";
            this.user_tree_family_list.Size = new System.Drawing.Size(333, 33);
            this.user_tree_family_list.TabIndex = 0;
            this.user_tree_family_list.SelectedIndexChanged += new System.EventHandler(this.Tree_family_list_SelectedIndexChanged);
            // 
            // user_tree_crud_close
            // 
            this.user_tree_crud_close.BackColor = System.Drawing.Color.LightCoral;
            this.user_tree_crud_close.ForeColor = System.Drawing.Color.White;
            this.user_tree_crud_close.Location = new System.Drawing.Point(1085, 647);
            this.user_tree_crud_close.Name = "user_tree_crud_close";
            this.user_tree_crud_close.Size = new System.Drawing.Size(118, 45);
            this.user_tree_crud_close.TabIndex = 67;
            this.user_tree_crud_close.Text = "tree_crud_close";
            this.user_tree_crud_close.UseVisualStyleBackColor = false;
            this.user_tree_crud_close.Click += new System.EventHandler(this.User_tree_crud_close_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.permiso;
            this.pictureBox1.Location = new System.Drawing.Point(21, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 64;
            this.pictureBox1.TabStop = false;
            // 
            // user_tree_descrip_editor
            // 
            this.user_tree_descrip_editor.AutoSize = true;
            this.user_tree_descrip_editor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_tree_descrip_editor.Location = new System.Drawing.Point(112, 66);
            this.user_tree_descrip_editor.Name = "user_tree_descrip_editor";
            this.user_tree_descrip_editor.Size = new System.Drawing.Size(195, 20);
            this.user_tree_descrip_editor.TabIndex = 63;
            this.user_tree_descrip_editor.Text = "user_tree_descrip_editor";
            this.user_tree_descrip_editor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // user_tree_title_editor
            // 
            this.user_tree_title_editor.AutoSize = true;
            this.user_tree_title_editor.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_tree_title_editor.Location = new System.Drawing.Point(108, 19);
            this.user_tree_title_editor.Name = "user_tree_title_editor";
            this.user_tree_title_editor.Size = new System.Drawing.Size(322, 38);
            this.user_tree_title_editor.TabIndex = 62;
            this.user_tree_title_editor.Text = "user_tree_title_editor";
            this.user_tree_title_editor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // user_permission_tree
            // 
            this.user_permission_tree.Location = new System.Drawing.Point(21, 200);
            this.user_permission_tree.Name = "user_permission_tree";
            this.user_permission_tree.Size = new System.Drawing.Size(1182, 426);
            this.user_permission_tree.TabIndex = 61;
            // 
            // UserTreeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 712);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.user_tree_crud_close);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.user_tree_descrip_editor);
            this.Controls.Add(this.user_tree_title_editor);
            this.Controls.Add(this.user_permission_tree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserTreeFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserTreeFrm";
            this.Load += new System.EventHandler(this.UserTreeFrm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button user_tree_crud_delete;
        private System.Windows.Forms.Button user_tree_crud_save;
        private System.Windows.Forms.Button user_tree_crud_add_family;
        private System.Windows.Forms.Button user_tree_crud_add_patent;
        private System.Windows.Forms.ComboBox user_tree_family_list;
        private System.Windows.Forms.Button user_tree_crud_close;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label user_tree_descrip_editor;
        private System.Windows.Forms.Label user_tree_title_editor;
        private System.Windows.Forms.TreeView user_permission_tree;
    }
}