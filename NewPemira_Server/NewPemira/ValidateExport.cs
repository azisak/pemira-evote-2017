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

            if (errormsg != "")
            {
                MessageBox.Show(errormsg);
            } else
            {
                password.Add(textBox1.Text);
                this.Close();
            }
        }

        private void ValidateExport_Load(object sender, EventArgs e)
        {

        }
    }
}
