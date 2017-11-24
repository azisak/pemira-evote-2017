namespace NewPemira
{
    partial class Form1
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
            this.txtNIM = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClearWL = new System.Windows.Forms.Button();
            this.listViewWL = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGrantAccBlk1 = new System.Windows.Forms.Button();
            this.btnClearBlk1 = new System.Windows.Forms.Button();
            this.listViewBlk1 = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnGrantAccBlk2 = new System.Windows.Forms.Button();
            this.btnClearBlk2 = new System.Windows.Forms.Button();
            this.listViewBlk2 = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.btnImportDP = new System.Windows.Forms.Button();
            this.expKotakSuara = new System.Windows.Forms.Button();
            this.btnExportDP = new System.Windows.Forms.Button();
            this.btnExpPerProdi = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "NIM :";
            // 
            // txtNIM
            // 
            this.txtNIM.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNIM.Location = new System.Drawing.Point(254, 48);
            this.txtNIM.Name = "txtNIM";
            this.txtNIM.Size = new System.Drawing.Size(286, 33);
            this.txtNIM.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(554, 47);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(98, 33);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "SUBMIT";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnClearWL);
            this.panel1.Controls.Add(this.listViewWL);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 311);
            this.panel1.TabIndex = 3;
            // 
            // btnClearWL
            // 
            this.btnClearWL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearWL.Location = new System.Drawing.Point(40, 274);
            this.btnClearWL.Name = "btnClearWL";
            this.btnClearWL.Size = new System.Drawing.Size(75, 23);
            this.btnClearWL.TabIndex = 15;
            this.btnClearWL.Text = "CLEAR";
            this.btnClearWL.UseVisualStyleBackColor = true;
            this.btnClearWL.Click += new System.EventHandler(this.btnClearWL_Click);
            // 
            // listViewWL
            // 
            this.listViewWL.BackColor = System.Drawing.SystemColors.Menu;
            this.listViewWL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewWL.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewWL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewWL.Location = new System.Drawing.Point(65, 46);
            this.listViewWL.Name = "listViewWL";
            this.listViewWL.Size = new System.Drawing.Size(125, 222);
            this.listViewWL.TabIndex = 14;
            this.listViewWL.UseCompatibleStateImageBehavior = false;
            this.listViewWL.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 120;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 22);
            this.label4.TabIndex = 13;
            this.label4.Text = "Waiting List :";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnGrantAccBlk1);
            this.panel2.Controls.Add(this.btnClearBlk1);
            this.panel2.Controls.Add(this.listViewBlk1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(276, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(258, 311);
            this.panel2.TabIndex = 4;
            // 
            // btnGrantAccBlk1
            // 
            this.btnGrantAccBlk1.Location = new System.Drawing.Point(178, 58);
            this.btnGrantAccBlk1.Name = "btnGrantAccBlk1";
            this.btnGrantAccBlk1.Size = new System.Drawing.Size(75, 36);
            this.btnGrantAccBlk1.TabIndex = 17;
            this.btnGrantAccBlk1.Text = "Grant Access";
            this.btnGrantAccBlk1.UseVisualStyleBackColor = true;
            this.btnGrantAccBlk1.Click += new System.EventHandler(this.btnGrantAccBlk1_Click);
            // 
            // btnClearBlk1
            // 
            this.btnClearBlk1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearBlk1.Location = new System.Drawing.Point(36, 134);
            this.btnClearBlk1.Name = "btnClearBlk1";
            this.btnClearBlk1.Size = new System.Drawing.Size(75, 23);
            this.btnClearBlk1.TabIndex = 16;
            this.btnClearBlk1.Text = "CLEAR";
            this.btnClearBlk1.UseVisualStyleBackColor = true;
            this.btnClearBlk1.Click += new System.EventHandler(this.btnClearBlk1_Click);
            // 
            // listViewBlk1
            // 
            this.listViewBlk1.BackColor = System.Drawing.SystemColors.Menu;
            this.listViewBlk1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewBlk1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewBlk1.Location = new System.Drawing.Point(36, 46);
            this.listViewBlk1.Name = "listViewBlk1";
            this.listViewBlk1.Size = new System.Drawing.Size(136, 82);
            this.listViewBlk1.TabIndex = 16;
            this.listViewBlk1.UseCompatibleStateImageBehavior = false;
            this.listViewBlk1.View = System.Windows.Forms.View.SmallIcon;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(96, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 22);
            this.label5.TabIndex = 14;
            this.label5.Text = "Bilik 1";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnGrantAccBlk2);
            this.panel3.Controls.Add(this.btnClearBlk2);
            this.panel3.Controls.Add(this.listViewBlk2);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(540, 131);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(258, 311);
            this.panel3.TabIndex = 5;
            // 
            // btnGrantAccBlk2
            // 
            this.btnGrantAccBlk2.Location = new System.Drawing.Point(178, 58);
            this.btnGrantAccBlk2.Name = "btnGrantAccBlk2";
            this.btnGrantAccBlk2.Size = new System.Drawing.Size(75, 36);
            this.btnGrantAccBlk2.TabIndex = 18;
            this.btnGrantAccBlk2.Text = "Grant Access";
            this.btnGrantAccBlk2.UseVisualStyleBackColor = true;
            this.btnGrantAccBlk2.Click += new System.EventHandler(this.btnGrantAccBlk2_Click);
            // 
            // btnClearBlk2
            // 
            this.btnClearBlk2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearBlk2.Location = new System.Drawing.Point(37, 134);
            this.btnClearBlk2.Name = "btnClearBlk2";
            this.btnClearBlk2.Size = new System.Drawing.Size(75, 23);
            this.btnClearBlk2.TabIndex = 17;
            this.btnClearBlk2.Text = "CLEAR";
            this.btnClearBlk2.UseVisualStyleBackColor = true;
            this.btnClearBlk2.Click += new System.EventHandler(this.btnClearBlk2_Click);
            // 
            // listViewBlk2
            // 
            this.listViewBlk2.BackColor = System.Drawing.SystemColors.Menu;
            this.listViewBlk2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewBlk2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewBlk2.Location = new System.Drawing.Point(37, 46);
            this.listViewBlk2.Name = "listViewBlk2";
            this.listViewBlk2.Size = new System.Drawing.Size(138, 82);
            this.listViewBlk2.TabIndex = 17;
            this.listViewBlk2.UseCompatibleStateImageBehavior = false;
            this.listViewBlk2.View = System.Windows.Forms.View.SmallIcon;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(94, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 22);
            this.label6.TabIndex = 15;
            this.label6.Text = "Bilik 2";
            // 
            // btnImportDP
            // 
            this.btnImportDP.Location = new System.Drawing.Point(3, 39);
            this.btnImportDP.Name = "btnImportDP";
            this.btnImportDP.Size = new System.Drawing.Size(113, 52);
            this.btnImportDP.TabIndex = 6;
            this.btnImportDP.Text = "Import DP";
            this.btnImportDP.UseVisualStyleBackColor = true;
            this.btnImportDP.Click += new System.EventHandler(this.btnImportDP_Click);
            // 
            // expKotakSuara
            // 
            this.expKotakSuara.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expKotakSuara.Location = new System.Drawing.Point(7, 37);
            this.expKotakSuara.Name = "expKotakSuara";
            this.expKotakSuara.Size = new System.Drawing.Size(113, 52);
            this.expKotakSuara.TabIndex = 7;
            this.expKotakSuara.Text = "Export Kotak Suara";
            this.expKotakSuara.UseVisualStyleBackColor = true;
            this.expKotakSuara.Click += new System.EventHandler(this.expKotakSuara_Click);
            // 
            // btnExportDP
            // 
            this.btnExportDP.Location = new System.Drawing.Point(336, 37);
            this.btnExportDP.Name = "btnExportDP";
            this.btnExportDP.Size = new System.Drawing.Size(113, 52);
            this.btnExportDP.TabIndex = 8;
            this.btnExportDP.Text = "Export DP";
            this.btnExportDP.UseVisualStyleBackColor = true;
            this.btnExportDP.Click += new System.EventHandler(this.btnExportDP_Click);
            // 
            // btnExpPerProdi
            // 
            this.btnExpPerProdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpPerProdi.Location = new System.Drawing.Point(126, 37);
            this.btnExpPerProdi.Name = "btnExpPerProdi";
            this.btnExpPerProdi.Size = new System.Drawing.Size(113, 52);
            this.btnExpPerProdi.TabIndex = 9;
            this.btnExpPerProdi.Text = "Export Kotak Suara Per Prodi";
            this.btnExpPerProdi.UseVisualStyleBackColor = true;
            this.btnExpPerProdi.Click += new System.EventHandler(this.btnExpPerProdi_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.btnExpPerProdi);
            this.panel4.Controls.Add(this.btnExportDP);
            this.panel4.Controls.Add(this.expKotakSuara);
            this.panel4.Location = new System.Drawing.Point(345, 450);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(456, 95);
            this.panel4.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Perpetua Titling MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(119, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "EXPORT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Perpetua Titling MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "IMPORT";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.btnImportDP);
            this.panel5.Location = new System.Drawing.Point(12, 450);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(319, 95);
            this.panel5.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::NewPemira.Properties.Resources.LOGO_PEMIRA4;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(13, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 125);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnExit.FlatAppearance.BorderSize = 5;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(747, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(54, 35);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 556);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtNIM);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNIM;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnImportDP;
        private System.Windows.Forms.Button expKotakSuara;
        private System.Windows.Forms.Button btnExportDP;
        private System.Windows.Forms.Button btnExpPerProdi;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClearWL;
        private System.Windows.Forms.ListView listViewWL;
        private System.Windows.Forms.ListView listViewBlk1;
        private System.Windows.Forms.ListView listViewBlk2;
        private System.Windows.Forms.Button btnGrantAccBlk1;
        private System.Windows.Forms.Button btnClearBlk1;
        private System.Windows.Forms.Button btnGrantAccBlk2;
        private System.Windows.Forms.Button btnClearBlk2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

