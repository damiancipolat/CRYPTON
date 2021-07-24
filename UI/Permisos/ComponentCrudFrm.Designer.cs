namespace UI.Permisos
{
    partial class ComponentCrudFrm
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
            this.comp_crud_title = new System.Windows.Forms.Label();
            this.comp_crud_description = new System.Windows.Forms.Label();
            this.comp_crud_list = new System.Windows.Forms.ListBox();
            this.comp_crud_delete = new System.Windows.Forms.Button();
            this.comp_crud_add = new System.Windows.Forms.Button();
            this.comp_crud_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comp_crud_title
            // 
            this.comp_crud_title.AutoSize = true;
            this.comp_crud_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comp_crud_title.Location = new System.Drawing.Point(19, 19);
            this.comp_crud_title.Name = "comp_crud_title";
            this.comp_crud_title.Size = new System.Drawing.Size(215, 32);
            this.comp_crud_title.TabIndex = 34;
            this.comp_crud_title.Text = "comp_crud_title";
            // 
            // comp_crud_description
            // 
            this.comp_crud_description.AutoSize = true;
            this.comp_crud_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comp_crud_description.Location = new System.Drawing.Point(21, 69);
            this.comp_crud_description.Name = "comp_crud_description";
            this.comp_crud_description.Size = new System.Drawing.Size(183, 20);
            this.comp_crud_description.TabIndex = 33;
            this.comp_crud_description.Text = "comp_crud_description";
            this.comp_crud_description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comp_crud_list
            // 
            this.comp_crud_list.FormattingEnabled = true;
            this.comp_crud_list.ItemHeight = 16;
            this.comp_crud_list.Location = new System.Drawing.Point(25, 180);
            this.comp_crud_list.Name = "comp_crud_list";
            this.comp_crud_list.Size = new System.Drawing.Size(523, 500);
            this.comp_crud_list.TabIndex = 35;
            // 
            // comp_crud_delete
            // 
            this.comp_crud_delete.BackColor = System.Drawing.Color.DarkOrange;
            this.comp_crud_delete.ForeColor = System.Drawing.Color.Transparent;
            this.comp_crud_delete.Location = new System.Drawing.Point(390, 114);
            this.comp_crud_delete.Name = "comp_crud_delete";
            this.comp_crud_delete.Size = new System.Drawing.Size(158, 45);
            this.comp_crud_delete.TabIndex = 37;
            this.comp_crud_delete.Text = "comp_crud_delete";
            this.comp_crud_delete.UseVisualStyleBackColor = false;
            this.comp_crud_delete.Click += new System.EventHandler(this.Comp_crud_delete_Click);
            // 
            // comp_crud_add
            // 
            this.comp_crud_add.BackColor = System.Drawing.Color.PaleGreen;
            this.comp_crud_add.Location = new System.Drawing.Point(220, 114);
            this.comp_crud_add.Name = "comp_crud_add";
            this.comp_crud_add.Size = new System.Drawing.Size(154, 42);
            this.comp_crud_add.TabIndex = 36;
            this.comp_crud_add.Text = "comp_crud_add";
            this.comp_crud_add.UseVisualStyleBackColor = false;
            this.comp_crud_add.Click += new System.EventHandler(this.Comp_crud_add_Click);
            // 
            // comp_crud_close
            // 
            this.comp_crud_close.BackColor = System.Drawing.Color.LightCoral;
            this.comp_crud_close.ForeColor = System.Drawing.Color.Transparent;
            this.comp_crud_close.Location = new System.Drawing.Point(390, 703);
            this.comp_crud_close.Name = "comp_crud_close";
            this.comp_crud_close.Size = new System.Drawing.Size(158, 45);
            this.comp_crud_close.TabIndex = 38;
            this.comp_crud_close.Text = "comp_crud_close";
            this.comp_crud_close.UseVisualStyleBackColor = false;
            this.comp_crud_close.Click += new System.EventHandler(this.Button3_Click);
            // 
            // ComponentCrudFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 765);
            this.Controls.Add(this.comp_crud_close);
            this.Controls.Add(this.comp_crud_delete);
            this.Controls.Add(this.comp_crud_add);
            this.Controls.Add(this.comp_crud_list);
            this.Controls.Add(this.comp_crud_title);
            this.Controls.Add(this.comp_crud_description);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComponentCrudFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ComponentCrudFrm";
            this.Load += new System.EventHandler(this.ComponentCrudFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label comp_crud_title;
        private System.Windows.Forms.Label comp_crud_description;
        private System.Windows.Forms.ListBox comp_crud_list;
        private System.Windows.Forms.Button comp_crud_delete;
        private System.Windows.Forms.Button comp_crud_add;
        private System.Windows.Forms.Button comp_crud_close;
    }
}