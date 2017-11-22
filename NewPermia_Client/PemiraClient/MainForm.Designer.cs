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
            this.label_timer_overview = new System.Windows.Forms.Label();
            this.label_NIM = new System.Windows.Forms.Label();
            this.label_timer_options_1 = new System.Windows.Forms.Label();
            this.BackgroundContainer = new System.Windows.Forms.PictureBox();
            this.label_timer_options_2 = new System.Windows.Forms.Label();
            this.hub_operator = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // label_timer_overview
            // 
            this.label_timer_overview.BackColor = System.Drawing.Color.Brown;
            this.label_timer_overview.Font = new System.Drawing.Font("Elephant", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_timer_overview.ForeColor = System.Drawing.Color.White;
            this.label_timer_overview.Location = new System.Drawing.Point(1136, 485);
            this.label_timer_overview.Name = "label_timer_overview";
            this.label_timer_overview.Size = new System.Drawing.Size(100, 55);
            this.label_timer_overview.TabIndex = 10;
            this.label_timer_overview.Text = "20";
            this.label_timer_overview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_NIM
            // 
            this.label_NIM.BackColor = System.Drawing.Color.Brown;
            this.label_NIM.Font = new System.Drawing.Font("Elephant", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NIM.ForeColor = System.Drawing.Color.White;
            this.label_NIM.Location = new System.Drawing.Point(438, 406);
            this.label_NIM.Name = "label_NIM";
            this.label_NIM.Size = new System.Drawing.Size(425, 49);
            this.label_NIM.TabIndex = 8;
            this.label_NIM.Text = "13515999";
            this.label_NIM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_timer_options_1
            // 
            this.label_timer_options_1.BackColor = System.Drawing.Color.Brown;
            this.label_timer_options_1.Font = new System.Drawing.Font("Elephant", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_timer_options_1.ForeColor = System.Drawing.Color.White;
            this.label_timer_options_1.Location = new System.Drawing.Point(609, 338);
            this.label_timer_options_1.Name = "label_timer_options_1";
            this.label_timer_options_1.Size = new System.Drawing.Size(100, 55);
            this.label_timer_options_1.TabIndex = 9;
            this.label_timer_options_1.Text = "20";
            this.label_timer_options_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackgroundContainer
            // 
            this.BackgroundContainer.BackgroundImage = global::PemiraClient.Properties.Resources.screen_welcome;
            this.BackgroundContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundContainer.Location = new System.Drawing.Point(0, 0);
            this.BackgroundContainer.Name = "BackgroundContainer";
            this.BackgroundContainer.Size = new System.Drawing.Size(1300, 700);
            this.BackgroundContainer.TabIndex = 11;
            this.BackgroundContainer.TabStop = false;
            // 
            // label_timer_options_2
            // 
            this.label_timer_options_2.BackColor = System.Drawing.Color.Brown;
            this.label_timer_options_2.Font = new System.Drawing.Font("Elephant", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_timer_options_2.ForeColor = System.Drawing.Color.White;
            this.label_timer_options_2.Location = new System.Drawing.Point(609, 338);
            this.label_timer_options_2.Name = "label_timer_options_2";
            this.label_timer_options_2.Size = new System.Drawing.Size(100, 55);
            this.label_timer_options_2.TabIndex = 12;
            this.label_timer_options_2.Text = "20";
            this.label_timer_options_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hub_operator
            // 
            this.hub_operator.BackColor = System.Drawing.Color.White;
            this.hub_operator.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.hub_operator.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hub_operator.Location = new System.Drawing.Point(433, 406);
            this.hub_operator.Name = "hub_operator";
            this.hub_operator.Size = new System.Drawing.Size(430, 49);
            this.hub_operator.TabIndex = 13;
            this.hub_operator.Text = "HUBUNGI OPERATOR";
            this.hub_operator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(1300, 700);
            this.ControlBox = false;
            this.Controls.Add(this.hub_operator);
            this.Controls.Add(this.label_timer_options_2);
            this.Controls.Add(this.label_timer_overview);
            this.Controls.Add(this.label_NIM);
            this.Controls.Add(this.label_timer_options_1);
            this.Controls.Add(this.BackgroundContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundContainer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_timer_overview;
        private System.Windows.Forms.Label label_NIM;
        private System.Windows.Forms.Label label_timer_options_1;
        private System.Windows.Forms.PictureBox BackgroundContainer;
        private System.Windows.Forms.Label label_timer_options_2;
        private System.Windows.Forms.Label hub_operator;
    }
}

