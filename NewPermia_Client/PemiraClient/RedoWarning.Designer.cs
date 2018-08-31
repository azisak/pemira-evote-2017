namespace PemiraClient
{
    partial class RedoWarning
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
            this.label_redo_warning = new System.Windows.Forms.Label();
            this.button_ok_redo_warning = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_redo_warning
            // 
            this.label_redo_warning.AutoSize = true;
            this.label_redo_warning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_redo_warning.ForeColor = System.Drawing.Color.White;
            this.label_redo_warning.Location = new System.Drawing.Point(40, 30);
            this.label_redo_warning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_redo_warning.Name = "label_redo_warning";
            this.label_redo_warning.Size = new System.Drawing.Size(558, 25);
            this.label_redo_warning.TabIndex = 0;
            this.label_redo_warning.Text = "Anda hanya dapat melakukan pemilihan ulang sebanyak 2 kali.";
            // 
            // button_ok_redo_warning
            // 
            this.button_ok_redo_warning.Location = new System.Drawing.Point(293, 82);
            this.button_ok_redo_warning.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_ok_redo_warning.Name = "button_ok_redo_warning";
            this.button_ok_redo_warning.Size = new System.Drawing.Size(100, 28);
            this.button_ok_redo_warning.TabIndex = 1;
            this.button_ok_redo_warning.Text = "OK";
            this.button_ok_redo_warning.UseVisualStyleBackColor = true;
            this.button_ok_redo_warning.Click += new System.EventHandler(this.button_ok_redo_warning_Click);
            // 
            // RedoWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(679, 148);
            this.Controls.Add(this.button_ok_redo_warning);
            this.Controls.Add(this.label_redo_warning);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RedoWarning";
            this.Text = "RedoWarning";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_redo_warning;
        private System.Windows.Forms.Button button_ok_redo_warning;
    }
}