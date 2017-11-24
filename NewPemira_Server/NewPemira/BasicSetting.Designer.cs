namespace NewPemira
{
    partial class BasicSetting
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbIPServer = new System.Windows.Forms.TextBox();
            this.txbPORTBlk1 = new System.Windows.Forms.TextBox();
            this.txbPORTBlk2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP Addr";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Biliik 1 PORT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bilik 2 PORT";
            // 
            // txbIPServer
            // 
            this.txbIPServer.Location = new System.Drawing.Point(143, 34);
            this.txbIPServer.Name = "txbIPServer";
            this.txbIPServer.Size = new System.Drawing.Size(100, 20);
            this.txbIPServer.TabIndex = 3;
            this.txbIPServer.Text = "169.254.1.1";
            // 
            // txbPORTBlk1
            // 
            this.txbPORTBlk1.Location = new System.Drawing.Point(143, 64);
            this.txbPORTBlk1.Name = "txbPORTBlk1";
            this.txbPORTBlk1.Size = new System.Drawing.Size(100, 20);
            this.txbPORTBlk1.TabIndex = 4;
            this.txbPORTBlk1.Text = "13514";
            // 
            // txbPORTBlk2
            // 
            this.txbPORTBlk2.Location = new System.Drawing.Point(143, 92);
            this.txbPORTBlk2.Name = "txbPORTBlk2";
            this.txbPORTBlk2.Size = new System.Drawing.Size(100, 20);
            this.txbPORTBlk2.TabIndex = 5;
            this.txbPORTBlk2.Text = "13515";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BasicSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 169);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txbPORTBlk2);
            this.Controls.Add(this.txbPORTBlk1);
            this.Controls.Add(this.txbIPServer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BasicSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BasicSetting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbIPServer;
        private System.Windows.Forms.TextBox txbPORTBlk1;
        private System.Windows.Forms.TextBox txbPORTBlk2;
        private System.Windows.Forms.Button button1;
    }
}