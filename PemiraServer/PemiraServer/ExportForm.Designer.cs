namespace PemiraServer
{
    partial class ExportForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.password1TB = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.password2TB = new System.Windows.Forms.TextBox();
            this.password3TB = new System.Windows.Forms.TextBox();
            this.password4TB = new System.Windows.Forms.TextBox();
            this.password5TB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password #1:";
            // 
            // password1TB
            // 
            this.password1TB.Location = new System.Drawing.Point(112, 10);
            this.password1TB.Name = "password1TB";
            this.password1TB.Size = new System.Drawing.Size(178, 22);
            this.password1TB.TabIndex = 5;
            this.password1TB.UseSystemPasswordChar = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(83, 170);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.AccessibleName = "";
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(164, 170);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password #2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password #3:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password #4:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password #5:";
            // 
            // password2TB
            // 
            this.password2TB.Location = new System.Drawing.Point(112, 38);
            this.password2TB.Name = "password2TB";
            this.password2TB.Size = new System.Drawing.Size(178, 22);
            this.password2TB.TabIndex = 6;
            this.password2TB.UseSystemPasswordChar = true;
            // 
            // password3TB
            // 
            this.password3TB.Location = new System.Drawing.Point(112, 66);
            this.password3TB.Name = "password3TB";
            this.password3TB.Size = new System.Drawing.Size(178, 22);
            this.password3TB.TabIndex = 7;
            this.password3TB.UseSystemPasswordChar = true;
            // 
            // password4TB
            // 
            this.password4TB.Location = new System.Drawing.Point(112, 94);
            this.password4TB.Name = "password4TB";
            this.password4TB.Size = new System.Drawing.Size(178, 22);
            this.password4TB.TabIndex = 8;
            this.password4TB.UseSystemPasswordChar = true;
            // 
            // password5TB
            // 
            this.password5TB.Location = new System.Drawing.Point(112, 122);
            this.password5TB.Name = "password5TB";
            this.password5TB.Size = new System.Drawing.Size(178, 22);
            this.password5TB.TabIndex = 9;
            this.password5TB.UseSystemPasswordChar = true;
            // 
            // ExportForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(314, 213);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.password5TB);
            this.Controls.Add(this.password4TB);
            this.Controls.Add(this.password3TB);
            this.Controls.Add(this.password2TB);
            this.Controls.Add(this.password1TB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ExportForm";
            this.Text = "Insert Export Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox password1TB;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox password2TB;
        private System.Windows.Forms.TextBox password3TB;
        private System.Windows.Forms.TextBox password4TB;
        private System.Windows.Forms.TextBox password5TB;
    }
}