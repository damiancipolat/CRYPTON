namespace UI
{
    partial class ComponenteSelectorFrm
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
            this.comp_title = new System.Windows.Forms.Label();
            this.comp_description = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comp_list = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // comp_title
            // 
            this.comp_title.AutoSize = true;
            this.comp_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comp_title.Location = new System.Drawing.Point(28, 25);
            this.comp_title.Name = "comp_title";
            this.comp_title.Size = new System.Drawing.Size(145, 32);
            this.comp_title.TabIndex = 32;
            this.comp_title.Text = "comp_title";
            // 
            // comp_description
            // 
            this.comp_description.AutoSize = true;
            this.comp_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comp_description.Location = new System.Drawing.Point(30, 75);
            this.comp_description.Name = "comp_description";
            this.comp_description.Size = new System.Drawing.Size(141, 20);
            this.comp_description.TabIndex = 31;
            this.comp_description.Text = "comp_description";
            this.comp_description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightCoral;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(206, 597);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 45);
            this.button2.TabIndex = 30;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightBlue;
            this.button1.Location = new System.Drawing.Point(34, 597);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 42);
            this.button1.TabIndex = 29;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // comp_list
            // 
            this.comp_list.FormattingEnabled = true;
            this.comp_list.ItemHeight = 16;
            this.comp_list.Location = new System.Drawing.Point(34, 125);
            this.comp_list.Name = "comp_list";
            this.comp_list.Size = new System.Drawing.Size(329, 452);
            this.comp_list.TabIndex = 33;
            this.comp_list.SelectedIndexChanged += new System.EventHandler(this.Comp_list_SelectedIndexChanged);
            // 
            // ComponenteListFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 668);
            this.Controls.Add(this.comp_list);
            this.Controls.Add(this.comp_title);
            this.Controls.Add(this.comp_description);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComponenteListFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ComponenteListFrm";
            this.Load += new System.EventHandler(this.ComponenteListFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label comp_title;
        private System.Windows.Forms.Label comp_description;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox comp_list;
    }
}