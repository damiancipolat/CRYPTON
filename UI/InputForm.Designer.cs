namespace UI
{
    partial class InputForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.prompt_description = new System.Windows.Forms.Label();
            this.prompt_input = new System.Windows.Forms.Label();
            this.frm_input = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGreen;
            this.button1.Location = new System.Drawing.Point(318, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightCoral;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(482, 166);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 45);
            this.button2.TabIndex = 25;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // prompt_description
            // 
            this.prompt_description.AutoSize = true;
            this.prompt_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prompt_description.Location = new System.Drawing.Point(23, 66);
            this.prompt_description.Name = "prompt_description";
            this.prompt_description.Size = new System.Drawing.Size(202, 20);
            this.prompt_description.TabIndex = 26;
            this.prompt_description.Text = "PROMPT_DESCRIPTION";
            this.prompt_description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // prompt_input
            // 
            this.prompt_input.AutoSize = true;
            this.prompt_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prompt_input.Location = new System.Drawing.Point(21, 19);
            this.prompt_input.Name = "prompt_input";
            this.prompt_input.Size = new System.Drawing.Size(233, 32);
            this.prompt_input.TabIndex = 27;
            this.prompt_input.Text = "PROMPT_INPUT";
            // 
            // frm_input
            // 
            this.frm_input.AcceptsReturn = true;
            this.frm_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frm_input.Location = new System.Drawing.Point(27, 104);
            this.frm_input.Name = "frm_input";
            this.frm_input.Size = new System.Drawing.Size(604, 38);
            this.frm_input.TabIndex = 28;
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 248);
            this.Controls.Add(this.frm_input);
            this.Controls.Add(this.prompt_input);
            this.Controls.Add(this.prompt_description);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Titulo";
            this.Load += new System.EventHandler(this.InputForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label prompt_description;
        private System.Windows.Forms.Label prompt_input;
        private System.Windows.Forms.TextBox frm_input;
    }
}