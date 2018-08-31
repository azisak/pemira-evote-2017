namespace PemiraClient
{
    partial class PasswordDialog
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
            this.input_password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_submit = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // input_password
            // 
            this.input_password.BackColor = System.Drawing.Color.Linen;
            this.input_password.Location = new System.Drawing.Point(81, 70);
            this.input_password.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.input_password.Name = "input_password";
            this.input_password.Size = new System.Drawing.Size(207, 22);
            this.input_password.TabIndex = 0;
            this.input_password.UseSystemPasswordChar = true;
            this.input_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.input_password_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(77, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password untuk menutup:";
            // 
            // button_submit
            // 
            this.button_submit.BackColor = System.Drawing.Color.Lavender;
            this.button_submit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_submit.Location = new System.Drawing.Point(81, 106);
            this.button_submit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(100, 28);
            this.button_submit.TabIndex = 3;
            this.button_submit.Text = "OK";
            this.button_submit.UseVisualStyleBackColor = false;
            this.button_submit.Click += new System.EventHandler(this.submit_button_onclick);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(189, 106);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(100, 28);
            this.button_cancel.TabIndex = 4;
            this.button_cancel.Text = "Batal";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.cancel_button_onclick);
            // 
            // PasswordDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(363, 182);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_submit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.input_password);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PasswordDialog";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input_password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.Button button_cancel;
    }
}