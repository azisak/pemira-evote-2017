using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemiraClient
{
    public partial class DialogPassword : Form
    {
        public string inputPassword = null;
        public DialogPassword()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inputPassword = textBox1.Text;
            this.Close();
        }

        private void DialogPassword_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            AcceptButton = button1;
        }
    }
}
