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
    public partial class ExportForm : Form
    {
        private string[] passwords = new string[5];

        public ExportForm()
        {
            InitializeComponent();
            //InitializePassword();
        }

        private void InitializePassword()
        {
            passwords[0] = "alson";
            passwords[1] = "reza";
            passwords[2] = "kristi";
            passwords[3] = "tepi";
            passwords[4] = "pemira";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            string errMsg = "Wrong Passwords:\n";
            if(password1TB.Text != passwords[0])
            {
                isValid = false;
                errMsg += "password 1\n";
            }
            if (password2TB.Text != passwords[1])
            {
                isValid = false;
                errMsg += "password 2\n";
            }
            if (password3TB.Text != passwords[2])
            {
                isValid = false;
                errMsg += "password 3\n";
            }
            if (password4TB.Text != passwords[3])
            {
                isValid = false;
                errMsg += "password 4\n";
            }
            if (password5TB.Text != passwords[4])
            {
                isValid = false;
                errMsg += "password 5\n";
            }

            if (isValid)
            {
                var fd = new FolderBrowserDialog();
                //fd.InitialDirectory = System.Environment.CurrentDirectory;
                //fd.Title = "Please select file to import.";
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string selectedPath = fd.SelectedPath;

                    bool isSuccessful = true;
                    string msg = "";
                    dbDPTController dbDpt = new dbDPTController();
                    string pathKM = selectedPath + @"\exportKM.csv";
                    //Cek apakah berhasil export km
                    isSuccessful &= dbDpt.exportCSVkm(pathKM);
                    string pathMWAWM = selectedPath + @"\exportMWAWM.csv";
                    //Cek apakah berhasil export mwawm
                    isSuccessful &= dbDpt.exportCSVmwawm(pathMWAWM);
                    if (isSuccessful)
                    {
                        msg += "Export Successful!\n";
                        msg += "File Exported to: " + selectedPath + "\n";
                        msg += "File names: exportKM.csv and exportMWAWM.csv";
                    }

                    MessageBox.Show(msg);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(errMsg);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
