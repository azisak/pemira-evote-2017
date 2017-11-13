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

    public partial class BukaKunci : Form
    {
        private dbKunciPasswordsController dbPasswords = new dbKunciPasswordsController();
        private int iPassword;
        private bool isCancel = false;
        private bool isPasswordTrue = false;

        public BukaKunci(int _iPassword)
        {
            this.ControlBox = false;
            iPassword = _iPassword;
            InitializeComponent();
        }

        private void BukaKunci_Load(object sender, EventArgs e)
        {
            this.ActiveControl = passwordTB;
            this.Text += iPassword;
            label1.Text += " #" + iPassword + ": ";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {
                
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }

        public bool getIsCancel()
        {
            return isCancel;
        }

        public bool getIsPasswordTrue()
        {
            return isPasswordTrue;
        }

        private void okButton_Click_1(object sender, EventArgs e)
        {
            if (passwordTB.Text == dbPasswords.getPassword(iPassword))
            {
                isPasswordTrue = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong Password");
                passwordTB.Text = "";
            }
        }

        private void cancelButton_Click_2(object sender, EventArgs e)
        {
            isCancel = true;
            this.Close();
        }
    }
}
