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
    public partial class BasicSetting : Form
    {
        private string ipserver;
        private int portblk1;
        private int portblk2;
        public BasicSetting()
        {
            InitializeComponent();
        }

        public string IpServer
        {
            get { return ipserver; }
        }
        public int PortBilik1
        {
            get { return portblk1; }
        }
        public int PortBilik2
        {
            get { return portblk2; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txbIPServer.Text == "" || txbPORTBlk1.Text == "" || txbPORTBlk2.Text == "")
            {
                MessageBox.Show("Data harus terisi semua !");
            } 
            else
            {
                this.Close();
            }
        }
    }
}
