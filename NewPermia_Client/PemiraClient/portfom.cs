﻿using System;
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
    public partial class portfom : Form
    {
        private int port;
        private string ipAddr;
        public portfom()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
        }
        
        public string IpAddr
        {
            get { return ipAddr; }
            set { ipAddr = value; }
        }


        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txbIP.Text == "" || txbIP.Text == "")
            {
                MessageBox.Show("TIDAK BOLEH KOSONG!");
            } else
            {
                ipAddr = txbIP.Text;
                try
                {
                    port = Convert.ToInt32(txbPORT.Text);
                } catch(FormatException exp)
                {
                    Console.WriteLine(exp.StackTrace);
                    MessageBox.Show("Port tidak valid!");
                    return;
                }
                this.Close();
            }
        }
    }
}
