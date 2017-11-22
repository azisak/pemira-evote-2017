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
    public partial class PilihExport : Form
    {
        int selected;
        public PilihExport()
        {
            InitializeComponent();
            selected = 1;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            selected = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            selected = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int getSelected()
        {
            return selected;
        }
    }
}
