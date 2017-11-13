namespace PemiraServer
{
    partial class InputPassword
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
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.confirmTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(44, 41);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(63, 13);
            this.passwordLabel.TabIndex = 0;
            this.passwordLabel.Text = "Password #";
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(122, 38);
            this.passwordTB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(120, 20);
            this.passwordTB.TabIndex = 1;
            this.passwordTB.UseSystemPasswordChar = true;
            this.passwordTB.Enter += new System.EventHandler(this.passwordTB_Enter);
            // 
            // confirmTB
            // 
            this.confirmTB.Location = new System.Drawing.Point(122, 61);
            this.confirmTB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.confirmTB.Name = "confirmTB";
            this.confirmTB.Size = new System.Drawing.Size(120, 20);
            this.confirmTB.TabIndex = 2;
            this.confirmTB.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Confirm Password:";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(115, 104);
            this.okButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(56, 19);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // InputPassword
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 154);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confirmTB);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.passwordLabel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "InputPassword";
            this.Text = "Masukkan Password Kunci";
            this.Load += new System.EventHandler(this.InputPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.TextBox confirmTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okButton;
    }
}