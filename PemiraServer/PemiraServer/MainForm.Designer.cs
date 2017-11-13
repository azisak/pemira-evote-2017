using System.Windows.Forms;

namespace PemiraServer
{
    partial class MainForm
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
            this.labelNIM = new System.Windows.Forms.Label();
            this.textBoxNIM = new System.Windows.Forms.TextBox();
            this.buttonSubmitNIM = new System.Windows.Forms.Button();
            this.buttonGrant1 = new System.Windows.Forms.Button();
            this.buttonGrant2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listViewBilik1 = new System.Windows.Forms.ListView();
            this.labelTimerBilik1 = new System.Windows.Forms.Label();
            this.labelBilikNIM2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listViewBilik2 = new System.Windows.Forms.ListView();
            this.labelTimerBilik2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listViewWaiting = new System.Windows.Forms.ListView();
            this.importButton = new System.Windows.Forms.Button();
            this.import = new System.Windows.Forms.Label();
            this.importStatusLabel = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.exportDpButton = new System.Windows.Forms.Button();
            this.exportDptButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNIM
            // 
            this.labelNIM.AutoSize = true;
            this.labelNIM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNIM.Location = new System.Drawing.Point(159, 85);
            this.labelNIM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNIM.Name = "labelNIM";
            this.labelNIM.Size = new System.Drawing.Size(89, 39);
            this.labelNIM.TabIndex = 0;
            this.labelNIM.Text = "NIM:";
            // 
            // textBoxNIM
            // 
            this.textBoxNIM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNIM.Location = new System.Drawing.Point(263, 81);
            this.textBoxNIM.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNIM.Name = "textBoxNIM";
            this.textBoxNIM.Size = new System.Drawing.Size(393, 45);
            this.textBoxNIM.TabIndex = 1;
            this.textBoxNIM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_pressed);
            // 
            // buttonSubmitNIM
            // 
            this.buttonSubmitNIM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmitNIM.Location = new System.Drawing.Point(665, 81);
            this.buttonSubmitNIM.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSubmitNIM.Name = "buttonSubmitNIM";
            this.buttonSubmitNIM.Size = new System.Drawing.Size(148, 47);
            this.buttonSubmitNIM.TabIndex = 2;
            this.buttonSubmitNIM.Text = "Submit";
            this.buttonSubmitNIM.UseVisualStyleBackColor = true;
            this.buttonSubmitNIM.Click += new System.EventHandler(this.buttonSubmitNIM_Click);
            // 
            // buttonGrant1
            // 
            this.buttonGrant1.Location = new System.Drawing.Point(173, -1);
            this.buttonGrant1.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGrant1.Name = "buttonGrant1";
            this.buttonGrant1.Size = new System.Drawing.Size(135, 37);
            this.buttonGrant1.TabIndex = 4;
            this.buttonGrant1.Text = "Grant Access";
            this.buttonGrant1.UseVisualStyleBackColor = true;
            this.buttonGrant1.Click += new System.EventHandler(this.buttonGrant_Click);
            // 
            // buttonGrant2
            // 
            this.buttonGrant2.Location = new System.Drawing.Point(173, -1);
            this.buttonGrant2.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGrant2.Name = "buttonGrant2";
            this.buttonGrant2.Size = new System.Drawing.Size(135, 37);
            this.buttonGrant2.TabIndex = 5;
            this.buttonGrant2.Text = "Grant Access";
            this.buttonGrant2.UseVisualStyleBackColor = true;
            this.buttonGrant2.Click += new System.EventHandler(this.buttonGrant_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "Bilik 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(117, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Bilik 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "Waiting List";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.listViewBilik1);
            this.panel1.Controls.Add(this.labelTimerBilik1);
            this.panel1.Controls.Add(this.labelBilikNIM2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonGrant1);
            this.panel1.Location = new System.Drawing.Point(348, 207);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 311);
            this.panel1.TabIndex = 9;
            // 
            // listViewBilik1
            // 
            this.listViewBilik1.BackColor = System.Drawing.SystemColors.Control;
            this.listViewBilik1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewBilik1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewBilik1.Location = new System.Drawing.Point(39, 112);
            this.listViewBilik1.Margin = new System.Windows.Forms.Padding(4);
            this.listViewBilik1.Name = "listViewBilik1";
            this.listViewBilik1.Size = new System.Drawing.Size(168, 111);
            this.listViewBilik1.TabIndex = 12;
            this.listViewBilik1.UseCompatibleStateImageBehavior = false;
            this.listViewBilik1.View = System.Windows.Forms.View.Details;
            // 
            // labelTimerBilik1
            // 
            this.labelTimerBilik1.AutoSize = true;
            this.labelTimerBilik1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimerBilik1.Location = new System.Drawing.Point(243, 112);
            this.labelTimerBilik1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTimerBilik1.Name = "labelTimerBilik1";
            this.labelTimerBilik1.Size = new System.Drawing.Size(34, 25);
            this.labelTimerBilik1.TabIndex = 9;
            this.labelTimerBilik1.Text = TimerCountdown.MAXCOUNT.ToString();
            // 
            // labelBilikNIM2
            // 
            this.labelBilikNIM2.AutoSize = true;
            this.labelBilikNIM2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBilikNIM2.Location = new System.Drawing.Point(33, 151);
            this.labelBilikNIM2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBilikNIM2.Name = "labelBilikNIM2";
            this.labelBilikNIM2.Size = new System.Drawing.Size(64, 25);
            this.labelBilikNIM2.TabIndex = 8;
            this.labelBilikNIM2.Text = "NIM 2";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.listViewBilik2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.labelTimerBilik2);
            this.panel2.Controls.Add(this.buttonGrant2);
            this.panel2.Location = new System.Drawing.Point(665, 207);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(309, 311);
            this.panel2.TabIndex = 10;
            // 
            // listViewBilik2
            // 
            this.listViewBilik2.BackColor = System.Drawing.SystemColors.Control;
            this.listViewBilik2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewBilik2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewBilik2.Location = new System.Drawing.Point(36, 112);
            this.listViewBilik2.Margin = new System.Windows.Forms.Padding(4);
            this.listViewBilik2.Name = "listViewBilik2";
            this.listViewBilik2.Size = new System.Drawing.Size(168, 111);
            this.listViewBilik2.TabIndex = 13;
            this.listViewBilik2.UseCompatibleStateImageBehavior = false;
            this.listViewBilik2.View = System.Windows.Forms.View.Details;
            // 
            // labelTimerBilik2
            // 
            this.labelTimerBilik2.AutoSize = true;
            this.labelTimerBilik2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimerBilik2.Location = new System.Drawing.Point(239, 112);
            this.labelTimerBilik2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTimerBilik2.Name = "labelTimerBilik2";
            this.labelTimerBilik2.Size = new System.Drawing.Size(34, 25);
            this.labelTimerBilik2.TabIndex = 13;
            this.labelTimerBilik2.Text = TimerCountdown.MAXCOUNT.ToString();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.listViewWaiting);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(31, 207);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(309, 311);
            this.panel3.TabIndex = 10;
            // 
            // listViewWaiting
            // 
            this.listViewWaiting.BackColor = System.Drawing.SystemColors.Control;
            this.listViewWaiting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewWaiting.Location = new System.Drawing.Point(23, 57);
            this.listViewWaiting.Margin = new System.Windows.Forms.Padding(4);
            this.listViewWaiting.Name = "listViewWaiting";
            this.listViewWaiting.Size = new System.Drawing.Size(260, 233);
            this.listViewWaiting.TabIndex = 11;
            this.listViewWaiting.UseCompatibleStateImageBehavior = false;
            this.listViewWaiting.View = System.Windows.Forms.View.Details;
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(31, 592);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(125, 93);
            this.importButton.TabIndex = 11;
            this.importButton.Text = "Import Database (.csv)";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // import
            // 
            this.import.AutoSize = true;
            this.import.ForeColor = System.Drawing.Color.Black;
            this.import.Location = new System.Drawing.Point(162, 592);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(149, 17);
            this.import.TabIndex = 12;
            this.import.Text = "DPT Database Status:";
            // 
            // importStatusLabel
            // 
            this.importStatusLabel.AutoSize = true;
            this.importStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.importStatusLabel.Location = new System.Drawing.Point(162, 609);
            this.importStatusLabel.Name = "importStatusLabel";
            this.importStatusLabel.Size = new System.Drawing.Size(240, 20);
            this.importStatusLabel.TabIndex = 13;
            this.importStatusLabel.Text = "No DPT Database imported";
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(31, 525);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(125, 61);
            this.exportButton.TabIndex = 14;
            this.exportButton.Text = "Export Semua Pilihan";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PemiraServer.Properties.Resources.Logo_Pemira_KM_ITB1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(887, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 113);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // exportDpButton
            // 
            this.exportDpButton.Location = new System.Drawing.Point(162, 525);
            this.exportDpButton.Name = "exportDpButton";
            this.exportDpButton.Size = new System.Drawing.Size(125, 61);
            this.exportDpButton.TabIndex = 15;
            this.exportDpButton.Text = "Export DP\r\nstatus";
            this.exportDpButton.UseVisualStyleBackColor = true;
            this.exportDpButton.Click += new System.EventHandler(this.exportDpButton_Click);
            // 
            // exportDptButton
            // 
            this.exportDptButton.Location = new System.Drawing.Point(293, 525);
            this.exportDptButton.Name = "exportDptButton";
            this.exportDptButton.Size = new System.Drawing.Size(125, 61);
            this.exportDptButton.TabIndex = 16;
            this.exportDptButton.Text = "Export DPT status";
            this.exportDptButton.UseVisualStyleBackColor = true;
            this.exportDptButton.Click += new System.EventHandler(this.exportDptButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 703);
            this.Controls.Add(this.exportDptButton);
            this.Controls.Add(this.exportDpButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.importStatusLabel);
            this.Controls.Add(this.import);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonSubmitNIM);
            this.Controls.Add(this.textBoxNIM);
            this.Controls.Add(this.labelNIM);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void InitializeListView() {
            ColumnHeader header = new ColumnHeader();
            header.Text = "";
            header.Name = "dummy";
            header.Width = listViewWaiting.Width - 25;

            listViewWaiting.Columns.Add(header);

            ColumnHeader headerBilik = header.Clone() as ColumnHeader;
            headerBilik.Width = listViewBilik1.Width - 25;
            listViewBilik1.Columns.Add(headerBilik);
            listViewBilik2.Columns.Add(headerBilik.Clone() as ColumnHeader);

            listViewWaiting.HeaderStyle = ColumnHeaderStyle.None;
            listViewBilik1.HeaderStyle = ColumnHeaderStyle.None;
            listViewBilik2.HeaderStyle = ColumnHeaderStyle.None;
        }


        private System.Windows.Forms.Label labelNIM;
        private System.Windows.Forms.TextBox textBoxNIM;
        private System.Windows.Forms.Button buttonSubmitNIM;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonGrant1;
        private System.Windows.Forms.Button buttonGrant2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelTimerBilik1;
        private System.Windows.Forms.Label labelBilikNIM2;
        private System.Windows.Forms.Label labelTimerBilik2;
        private System.Windows.Forms.ListView listViewWaiting;
        private System.Windows.Forms.ListView listViewBilik1;
        private System.Windows.Forms.ListView listViewBilik2;
        private Button importButton;
        private Label import;
        private Label importStatusLabel;
        private Button exportButton;
        private Button exportDpButton;
        private Button exportDptButton;
    }
}

