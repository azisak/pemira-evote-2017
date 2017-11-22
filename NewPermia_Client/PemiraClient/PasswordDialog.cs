using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemiraClient
{
    public partial class PasswordDialog : Form
    {
        private const string TEXT_PASSWORD = "Qzwxecrvtbynumi,o.p?";

        public PasswordDialog()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void submit_button_onclick(object sender, EventArgs e)
        {
            if (input_password.Text.ToString() == "")
                return;
            else if (!input_password.Text.ToString().Equals(TEXT_PASSWORD))
                MessageBox.Show("Invalid password!");
            else
            {
                RestartExplorer();
                Environment.Exit(0);
            }        
        }

        private void cancel_button_onclick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void input_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            const int ENTER_ASCII = 13;
            if (e.KeyChar == ENTER_ASCII)
                submit_button_onclick(sender, e);
        }

        private void RestartExplorer()
        {
            Process.Start(Path.Combine(Environment.GetEnvironmentVariable("windir"), "explorer.exe"));
        }
    }
}
