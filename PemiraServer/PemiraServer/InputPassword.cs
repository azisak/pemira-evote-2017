using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemiraServer
{
    public partial class InputPassword : Form
    {
        private int iPassword;
        private dbKunciPasswordsController dbPassword = new dbKunciPasswordsController();

        public InputPassword(int _iPassword)
        {
            this.ControlBox = false;
            InitializeComponent();
            iPassword = _iPassword;
            passwordLabel.Text += iPassword + ": ";
            this.Text += " #" + iPassword;
        }

        private void InputPassword_Load(object sender, EventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (passwordTB.Text == confirmTB.Text)
            {
                if (passwordTB.Text.Length == 0)
                {
                    MessageBox.Show("Password can't be empty");
                }
                else
                {
                    dbPassword.addPassword(passwordTB.Text);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Password and Confirm Password doesn't match!");
                passwordTB.Text = "";
                confirmTB.Text = "";
                this.ActiveControl = passwordTB;
            }
        }

        private void passwordTB_Enter(object sender, EventArgs e)
        {
            AcceptButton = okButton;
        }
    }
}
