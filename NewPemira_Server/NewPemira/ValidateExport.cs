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
    public partial class ValidateExport : Form
    {
        private List<string> password;
        private bool cancel = false;

        public ValidateExport()
        {
            password = new List<string>();
            InitializeComponent();
        }

        public List<string> getPassword()
        {
            return password;
        }

        public bool getCancel()
        {
            return cancel;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            cancel = true;
            this.Close();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            string errormsg = "";
            //Check Password Input
            if (textBox1.Text == "")
            {
                errormsg += "Password 1 Tidak Boleh Kosong\n";
            }
            if (textBox2.Text == "")
            {
                errormsg += "Password 2 Tidak Boleh Kosong\n";
            }
            if (textBox3.Text == "")
            {
                errormsg += "Password 3 Tidak Boleh Kosong\n";
            }
            if (textBox4.Text == "")
            {
                errormsg += "Password 4 Tidak Boleh Kosong\n";
            }
            if (textBox5.Text == "")
            {
                errormsg += "Password 5 Tidak Boleh Kosong\n";
            }

            if (errormsg != "")
            {
                MessageBox.Show(errormsg);
            } else
            {
                password.Add(textBox1.Text);
                password.Add(textBox2.Text);
                password.Add(textBox3.Text);
                password.Add(textBox4.Text);
                password.Add(textBox5.Text);
                this.Close();
            }
        }
    }
}
