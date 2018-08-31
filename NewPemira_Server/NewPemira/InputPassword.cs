using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPemira
{
    public partial class InputPassword : Form
    {
        string pass;
        public InputPassword(int i)
        {
            InitializeComponent();
        }

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const string errPassEmpty = "Harap isikan Password!";
            const string errConfirmPassEmpty = "Harap isikan Confirm Password!";
            const string errNotMatch = "Password dan Confirm Pass tidak sama!";
            if (txbPass.Text == "")
            {
                MessageBox.Show(errPassEmpty);
            } else if (txbConfirmPass.Text == "")
            {
                MessageBox.Show(errConfirmPassEmpty);
            } else if (txbPass.Text != txbConfirmPass.Text)
            {
                MessageBox.Show(errNotMatch);
            } else
            {
                // EVERYTHING OK
                pass = txbPass.Text;
                this.Close();
            }
        }
    }
}
