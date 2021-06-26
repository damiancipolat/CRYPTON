namespace UI
{
    partial class PermisosFrm
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
            this.permission_tree = new System.Windows.Forms.TreeView();
            this.permission_title = new System.Windows.Forms.Label();
            this.permission_label = new System.Windows.Forms.Label();
            this.btn_del_permission = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_close_permission = new System.Windows.Forms.Button();
            this.list_perm = new System.Windows.Forms.ListBox();
            this.permission_abm = new System.Windows.Forms.Label();
            this.btn_compound_permission = new System.Windows.Forms.Button();
            this.btn_update_permission = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // permission_tree
            // 
            this.permission_tree.Location = new System.Drawing.Point(405, 155);
            this.permission_tree.Name = "permission_tree";
            this.permission_tree.Size = new System.Drawing.Size(704, 336);
            this.permission_tree.TabIndex = 21;
            this.permission_tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Permission_tree_AfterSelect);
            // 
            // permission_title
            // 
            this.permission_title.AutoSize = true;
            this.permission_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.permission_title.Location = new System.Drawing.Point(34, 18);
            this.permission_title.Name = "permission_title";
            this.permission_title.Size = new System.Drawing.Size(154, 38);
            this.permission_title.TabIndex = 22;
            this.permission_title.Text = "Permisos";
            this.permission_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // permission_label
            // 
            this.permission_label.AutoSize = true;
            this.permission_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.permission_label.Location = new System.Drawing.Point(37, 68);
            this.permission_label.Name = "permission_label";
            this.permission_label.Size = new System.Drawing.Size(500, 20);
            this.permission_label.TabIndex = 23;
            this.permission_label.Text = "En esta sección se puede agregar o quitar permisos a un usuario.";
            this.permission_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_del_permission
            // 
            this.btn_del_permission.BackColor = System.Drawing.Color.Coral;
            this.btn_del_permission.ForeColor = System.Drawing.Color.Transparent;
            this.btn_del_permission.Location = new System.Drawing.Point(960, 92);
            this.btn_del_permission.Name = "btn_del_permission";
            this.btn_del_permission.Size = new System.Drawing.Size(149, 45);
            this.btn_del_permission.TabIndex = 24;
            this.btn_del_permission.Text = "Borrar permiso";
            this.btn_del_permission.UseVisualStyleBackColor = false;
            this.btn_del_permission.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(333, 304);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 45);
            this.button2.TabIndex = 25;
            this.button2.Text = ">>";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // btn_close_permission
            // 
            this.btn_close_permission.Location = new System.Drawing.Point(960, 516);
            this.btn_close_permission.Name = "btn_close_permission";
            this.btn_close_permission.Size = new System.Drawing.Size(149, 45);
            this.btn_close_permission.TabIndex = 26;
            this.btn_close_permission.Text = "Cerrar";
            this.btn_close_permission.UseVisualStyleBackColor = true;
            this.btn_close_permission.Click += new System.EventHandler(this.Button3_Click);
            // 
            // list_perm
            // 
            this.list_perm.FormattingEnabled = true;
            this.list_perm.ItemHeight = 16;
            this.list_perm.Location = new System.Drawing.Point(41, 219);
            this.list_perm.Name = "list_perm";
            this.list_perm.Size = new System.Drawing.Size(277, 276);
            this.list_perm.TabIndex = 27;
            // 
            // permission_abm
            // 
            this.permission_abm.AutoSize = true;
            this.permission_abm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.permission_abm.Location = new System.Drawing.Point(40, 126);
            this.permission_abm.Name = "permission_abm";
            this.permission_abm.Size = new System.Drawing.Size(176, 20);
            this.permission_abm.TabIndex = 29;
            this.permission_abm.Text = "Permisos atomicos:";
            // 
            // btn_compound_permission
            // 
            this.btn_compound_permission.Location = new System.Drawing.Point(43, 161);
            this.btn_compound_permission.Name = "btn_compound_permission";
            this.btn_compound_permission.Size = new System.Drawing.Size(147, 45);
            this.btn_compound_permission.TabIndex = 32;
            this.btn_compound_permission.Text = "Agregar compuesto";
            this.btn_compound_permission.UseVisualStyleBackColor = true;
            this.btn_compound_permission.Click += new System.EventHandler(this.Button4_Click);
            // 
            // btn_update_permission
            // 
            this.btn_update_permission.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_update_permission.Location = new System.Drawing.Point(205, 161);
            this.btn_update_permission.Name = "btn_update_permission";
            this.btn_update_permission.Size = new System.Drawing.Size(113, 45);
            this.btn_update_permission.TabIndex = 33;
            this.btn_update_permission.Text = "Actualizar";
            this.btn_update_permission.UseVisualStyleBackColor = false;
            this.btn_update_permission.Click += new System.EventHandler(this.Button5_Click);
            // 
            // PermisosFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 581);
            this.Controls.Add(this.btn_update_permission);
            this.Controls.Add(this.btn_compound_permission);
            this.Controls.Add(this.permission_abm);
            this.Controls.Add(this.list_perm);
            this.Controls.Add(this.btn_close_permission);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_del_permission);
            this.Controls.Add(this.permission_label);
            this.Controls.Add(this.permission_title);
            this.Controls.Add(this.permission_tree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PermisosFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permisos";
            this.Load += new System.EventHandler(this.Permisos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView permission_tree;
        private System.Windows.Forms.Label permission_title;
        private System.Windows.Forms.Label permission_label;
        private System.Windows.Forms.Button btn_del_permission;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_close_permission;
        private System.Windows.Forms.ListBox list_perm;
        private System.Windows.Forms.Label permission_abm;
        private System.Windows.Forms.Button btn_compound_permission;
        private System.Windows.Forms.Button btn_update_permission;
    }
}