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
    public partial class RedoWarning : Form
    {
        public RedoWarning()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button_ok_redo_warning_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
