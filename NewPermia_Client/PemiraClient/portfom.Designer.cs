namespace PemiraClient
{
    partial class portfom
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
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbPORT = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(121, 92);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP ADDR";
            // 
            // txbIP
            // 
            this.txbIP.BackColor = System.Drawing.Color.MistyRose;
            this.txbIP.Location = new System.Drawing.Point(99, 25);
            this.txbIP.Name = "txbIP";
            this.txbIP.Size = new System.Drawing.Size(97, 20);
            this.txbIP.TabIndex = 3;
            this.txbIP.Text = "169.254.1.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "PORT";
            // 
            // txbPORT
            // 
            this.txbPORT.BackColor = System.Drawing.Color.MistyRose;
            this.txbPORT.Location = new System.Drawing.Point(99, 57);
            this.txbPORT.Name = "txbPORT";
            this.txbPORT.Size = new System.Drawing.Size(97, 20);
            this.txbPORT.TabIndex = 6;
            // 
            // portfom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Brown;
            this.ClientSize = new System.Drawing.Size(247, 157);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbPORT);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "portfom";
            this.Text = "portfom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbPORT;
    }
}