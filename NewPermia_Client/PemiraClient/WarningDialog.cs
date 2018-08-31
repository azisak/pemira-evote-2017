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
    public partial class WarningDialog : Form
    {
        public WarningDialog()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
        }

        public void setLabelText(string str)
        {
            this.warning_label.Text = str;
        }

        private void waring_label_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
