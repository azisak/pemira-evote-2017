namespace PemiraClient
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
            this.label_NIM = new System.Windows.Forms.Label();
            this.label_NIM_container = new System.Windows.Forms.Panel();
            this.BackgroundContainer = new System.Windows.Forms.PictureBox();
            this.label_timer_options = new System.Windows.Forms.Label();
            this.label_timer_overview = new System.Windows.Forms.Label();
            this.label_timer_options_2 = new System.Windows.Forms.Label();
            this.label_NIM_container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // label_NIM
            // 
            this.label_NIM.Font = new System.Drawing.Font("Elephant", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NIM.ForeColor = System.Drawing.Color.White;
            this.label_NIM.Location = new System.Drawing.Point(3, 4);
            this.label_NIM.Name = "label_NIM";
            this.label_NIM.Size = new System.Drawing.Size(414, 41);
            this.label_NIM.TabIndex = 0;
            this.label_NIM.Text = "13515999";
            this.label_NIM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_NIM_container
            // 
            this.label_NIM_container.BackColor = System.Drawing.Color.Brown;
            this.label_NIM_container.Controls.Add(this.label_NIM);
            this.label_NIM_container.Location = new System.Drawing.Point(440, 405);
            this.label_NIM_container.Name = "label_NIM_container";
            this.label_NIM_container.Size = new System.Drawing.Size(420, 45);
            this.label_NIM_container.TabIndex = 1;
            // 
            // BackgroundContainer
            // 
            this.BackgroundContainer.BackgroundImage = global::PemiraClient.Properties.Resources.clarification_1_2;
            this.BackgroundContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundContainer.Location = new System.Drawing.Point(0, 0);
            this.BackgroundContainer.Name = "BackgroundContainer";
            this.BackgroundContainer.Size = new System.Drawing.Size(1300, 700);
            this.BackgroundContainer.TabIndex = 2;
            this.BackgroundContainer.TabStop = false;
            // 
            // label_timer_options
            // 
            this.label_timer_options.BackColor = System.Drawing.Color.Brown;
            this.label_timer_options.Font = new System.Drawing.Font("Elephant", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_timer_options.ForeColor = System.Drawing.Color.White;
            this.label_timer_options.Location = new System.Drawing.Point(596, 343);
            this.label_timer_options.Name = "label_timer_options";
            this.label_timer_options.Size = new System.Drawing.Size(100, 55);
            this.label_timer_options.TabIndex = 3;
            this.label_timer_options.Text = "20";
            this.label_timer_options.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_timer_overview
            // 
            this.label_timer_overview.BackColor = System.Drawing.Color.Brown;
            this.label_timer_overview.Font = new System.Drawing.Font("Elephant", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_timer_overview.ForeColor = System.Drawing.Color.White;
            this.label_timer_overview.Location = new System.Drawing.Point(1151, 440);
            this.label_timer_overview.Name = "label_timer_overview";
            this.label_timer_overview.Size = new System.Drawing.Size(100, 55);
            this.label_timer_overview.TabIndex = 4;
            this.label_timer_overview.Text = "20";
            this.label_timer_overview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_timer_options_2
            // 
            this.label_timer_options_2.BackColor = System.Drawing.Color.Brown;
            this.label_timer_options_2.Font = new System.Drawing.Font("Elephant", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_timer_options_2.ForeColor = System.Drawing.Color.White;
            this.label_timer_options_2.Location = new System.Drawing.Point(596, 343);
            this.label_timer_options_2.Name = "label_timer_options_2";
            this.label_timer_options_2.Size = new System.Drawing.Size(100, 55);
            this.label_timer_options_2.TabIndex = 5;
            this.label_timer_options_2.Text = "20";
            this.label_timer_options_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1300, 700);
            this.Controls.Add(this.label_timer_overview);
            this.Controls.Add(this.label_timer_options);
            this.Controls.Add(this.label_NIM_container);
            this.Controls.Add(this.label_timer_options_2);
            this.Controls.Add(this.BackgroundContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.label_NIM_container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundContainer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_NIM;
        private System.Windows.Forms.Panel label_NIM_container;
        private System.Windows.Forms.PictureBox BackgroundContainer;
        private System.Windows.Forms.Label label_timer_options;
        private System.Windows.Forms.Label label_timer_overview;
        private System.Windows.Forms.Label label_timer_options_2;
    }
}

