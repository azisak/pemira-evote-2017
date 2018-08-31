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
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.belumImportLbl = new System.Windows.Forms.Label();
            this.sudahImportLbl = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.label1.Location = new System.Drawing.Point(225, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "NIM :";
            // 
            // txtNIM
            // 
            this.txtNIM.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNIM.Location = new System.Drawing.Point(339, 59);
            this.txtNIM.Margin = new System.Windows.Forms.Padding(4);
            this.txtNIM.Name = "txtNIM";
            this.txtNIM.Size = new System.Drawing.Size(380, 40);
            this.txtNIM.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(739, 58);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(131, 41);
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
            this.panel1.Location = new System.Drawing.Point(16, 161);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 382);
            this.panel1.TabIndex = 3;
            // 
            // btnClearWL
            // 
            this.btnClearWL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearWL.Location = new System.Drawing.Point(53, 337);
            this.btnClearWL.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearWL.Name = "btnClearWL";
            this.btnClearWL.Size = new System.Drawing.Size(100, 28);
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
            this.listViewWL.Location = new System.Drawing.Point(87, 57);
            this.listViewWL.Margin = new System.Windows.Forms.Padding(4);
            this.listViewWL.Name = "listViewWL";
            this.listViewWL.Size = new System.Drawing.Size(167, 273);
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
            this.label4.Location = new System.Drawing.Point(4, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 26);
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
            this.panel2.Location = new System.Drawing.Point(368, 161);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(343, 382);
            this.panel2.TabIndex = 4;
            // 
            // btnGrantAccBlk1
            // 
            this.btnGrantAccBlk1.Location = new System.Drawing.Point(237, 71);
            this.btnGrantAccBlk1.Margin = new System.Windows.Forms.Padding(4);
            this.btnGrantAccBlk1.Name = "btnGrantAccBlk1";
            this.btnGrantAccBlk1.Size = new System.Drawing.Size(100, 44);
            this.btnGrantAccBlk1.TabIndex = 17;
            this.btnGrantAccBlk1.Text = "Grant Access";
            this.btnGrantAccBlk1.UseVisualStyleBackColor = true;
            this.btnGrantAccBlk1.Click += new System.EventHandler(this.btnGrantAccBlk1_Click);
            // 
            // btnClearBlk1
            // 
            this.btnClearBlk1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearBlk1.Location = new System.Drawing.Point(48, 165);
            this.btnClearBlk1.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearBlk1.Name = "btnClearBlk1";
            this.btnClearBlk1.Size = new System.Drawing.Size(100, 28);
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
            this.listViewBlk1.Location = new System.Drawing.Point(48, 57);
            this.listViewBlk1.Margin = new System.Windows.Forms.Padding(4);
            this.listViewBlk1.Name = "listViewBlk1";
            this.listViewBlk1.Size = new System.Drawing.Size(181, 101);
            this.listViewBlk1.TabIndex = 16;
            this.listViewBlk1.UseCompatibleStateImageBehavior = false;
            this.listViewBlk1.View = System.Windows.Forms.View.SmallIcon;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(128, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 26);
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
            this.panel3.Location = new System.Drawing.Point(720, 161);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(343, 382);
            this.panel3.TabIndex = 5;
            // 
            // btnGrantAccBlk2
            // 
            this.btnGrantAccBlk2.Location = new System.Drawing.Point(237, 71);
            this.btnGrantAccBlk2.Margin = new System.Windows.Forms.Padding(4);
            this.btnGrantAccBlk2.Name = "btnGrantAccBlk2";
            this.btnGrantAccBlk2.Size = new System.Drawing.Size(100, 44);
            this.btnGrantAccBlk2.TabIndex = 18;
            this.btnGrantAccBlk2.Text = "Grant Access";
            this.btnGrantAccBlk2.UseVisualStyleBackColor = true;
            this.btnGrantAccBlk2.Click += new System.EventHandler(this.btnGrantAccBlk2_Click);
            // 
            // btnClearBlk2
            // 
            this.btnClearBlk2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearBlk2.Location = new System.Drawing.Point(49, 165);
            this.btnClearBlk2.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearBlk2.Name = "btnClearBlk2";
            this.btnClearBlk2.Size = new System.Drawing.Size(100, 28);
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
            this.listViewBlk2.Location = new System.Drawing.Point(49, 57);
            this.listViewBlk2.Margin = new System.Windows.Forms.Padding(4);
            this.listViewBlk2.Name = "listViewBlk2";
            this.listViewBlk2.Size = new System.Drawing.Size(184, 101);
            this.listViewBlk2.TabIndex = 17;
            this.listViewBlk2.UseCompatibleStateImageBehavior = false;
            this.listViewBlk2.View = System.Windows.Forms.View.SmallIcon;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(125, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 26);
            this.label6.TabIndex = 15;
            this.label6.Text = "Bilik 2";
            // 
            // btnImportDP
            // 
            this.btnImportDP.Location = new System.Drawing.Point(4, 48);
            this.btnImportDP.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportDP.Name = "btnImportDP";
            this.btnImportDP.Size = new System.Drawing.Size(151, 64);
            this.btnImportDP.TabIndex = 6;
            this.btnImportDP.Text = "Import DP";
            this.btnImportDP.UseVisualStyleBackColor = true;
            this.btnImportDP.Click += new System.EventHandler(this.btnImportDP_Click);
            // 
            // expKotakSuara
            // 
            this.expKotakSuara.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expKotakSuara.Location = new System.Drawing.Point(9, 46);
            this.expKotakSuara.Margin = new System.Windows.Forms.Padding(4);
            this.expKotakSuara.Name = "expKotakSuara";
            this.expKotakSuara.Size = new System.Drawing.Size(151, 64);
            this.expKotakSuara.TabIndex = 7;
            this.expKotakSuara.Text = "Export Hasil Referendum";
            this.expKotakSuara.UseVisualStyleBackColor = true;
            this.expKotakSuara.Click += new System.EventHandler(this.expKotakSuara_Click);
            // 
            // btnExportDP
            // 
            this.btnExportDP.Location = new System.Drawing.Point(448, 46);
            this.btnExportDP.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportDP.Name = "btnExportDP";
            this.btnExportDP.Size = new System.Drawing.Size(151, 64);
            this.btnExportDP.TabIndex = 8;
            this.btnExportDP.Text = "Export DP";
            this.btnExportDP.UseVisualStyleBackColor = true;
            this.btnExportDP.Click += new System.EventHandler(this.btnExportDP_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.btnExportDP);
            this.panel4.Controls.Add(this.expKotakSuara);
            this.panel4.Location = new System.Drawing.Point(460, 554);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(608, 117);
            this.panel4.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Perpetua Titling MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(244, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "EXPORT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Perpetua Titling MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 1);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 29);
            this.label3.TabIndex = 11;
            this.label3.Text = "IMPORT";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.belumImportLbl);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.btnImportDP);
            this.panel5.Controls.Add(this.sudahImportLbl);
            this.panel5.Location = new System.Drawing.Point(16, 554);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(425, 117);
            this.panel5.TabIndex = 12;
            // 
            // belumImportLbl
            // 
            this.belumImportLbl.AutoSize = true;
            this.belumImportLbl.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.belumImportLbl.Cursor = System.Windows.Forms.Cursors.Default;
            this.belumImportLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.belumImportLbl.ForeColor = System.Drawing.Color.Red;
            this.belumImportLbl.Location = new System.Drawing.Point(169, 71);
            this.belumImportLbl.Name = "belumImportLbl";
            this.belumImportLbl.Size = new System.Drawing.Size(219, 18);
            this.belumImportLbl.TabIndex = 12;
            this.belumImportLbl.Text = "Belum Import Daftar Pemilih";
            // 
            // sudahImportLbl
            // 
            this.sudahImportLbl.AutoSize = true;
            this.sudahImportLbl.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.sudahImportLbl.Cursor = System.Windows.Forms.Cursors.Default;
            this.sudahImportLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sudahImportLbl.ForeColor = System.Drawing.Color.Lime;
            this.sudahImportLbl.Location = new System.Drawing.Point(169, 71);
            this.sudahImportLbl.Name = "sudahImportLbl";
            this.sudahImportLbl.Size = new System.Drawing.Size(219, 18);
            this.sudahImportLbl.TabIndex = 13;
            this.sudahImportLbl.Text = "Sudah Import Daftar Pemilih";
            this.sudahImportLbl.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnExit.FlatAppearance.BorderSize = 5;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(996, 4);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 43);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NewPemira.Properties.Resources.KongresLogo;
            this.pictureBox1.Location = new System.Drawing.Point(16, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 684);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtNIM);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
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
        private System.Windows.Forms.Label sudahImportLbl;
        private System.Windows.Forms.Label belumImportLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

