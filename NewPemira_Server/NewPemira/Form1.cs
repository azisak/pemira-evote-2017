using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPemira
{
    public partial class Form1 : Form
    {
        DBDPTController dbDPT = new DBDPTController();
        DBPasswordController dbPass = new DBPasswordController();
        DBPilihanController dbPilihan = new DBPilihanController();
        const int MAX_QUEUE_BILIK_1 = 2;
        const int MAX_QUEUE_BILIK_2 = 2;
        const int N_PASSWORD = 1;
        List<string> password = new List<string>();

        string myIp = "169.254.1.1";
        int port1 = 13514;
        int port2 = 13515;
        MyListener list1;
        MyListener list2;

        public Form1()
        {
            InitializeComponent();
            updateBtnStats();
            
            // Check if password already inputted
            // For testing, assumed password not implemented
            if (dbPass.isTableEmpty())
            {
                for (int i = 1; i <= N_PASSWORD; i++)
                {
                    InputPassword ip = new InputPassword(i);
                    ip.ShowDialog();
                    password.Add(ip.Pass);
                }
                if (!dbPass.addPassword(password))
                {
                    MessageBox.Show("Add Password Gagal");
                    Environment.Exit(0);
                }
            }

            if (!dbDPT.isEmptyDPT())
            {
                belumImportLbl.Visible = false;
                sudahImportLbl.Visible = true;
            }

            foreach (var pass in password)
            {
                Console.WriteLine(pass);
            }

            BasicSetting bsc = new BasicSetting();
            bsc.ShowDialog();
            myIp = bsc.IpServer;
            port1 = bsc.PortBilik1;
            port2 = bsc.PortBilik2;
            
            list1 = new MyListener(myIp, port1);
            list2 = new MyListener(myIp, port2);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            //Application.Exit();
        }

        // ===== NIM VALIDATION SECTION =====
        bool isAllNumber(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                {
                    return false;
                }
            }
            return true;
        }

        private bool isNIMAlreadyInside(string nim)
        {
            // search in WL
            foreach (ListViewItem item in listViewWL.Items)
            {
                if (nim == item.Text)
                    return true;
            }
            //Search in bilik 1
            foreach (ListViewItem item in listViewBlk1.Items)
            {
                if (nim == item.Text)
                    return true;
            }
            //Search in bilik 2
            foreach (ListViewItem item in listViewBlk2.Items)
            {
                if (nim == item.Text)
                    return true;
            }
            return false;
        }

        private bool isNIMValid(string nim)
        {
            const string errNIMLEN = "PANJANG NIM HARUS 8 !";
            const string errNIMNotNumber = "NIM HARUS BERISI BILANGAN !";
            const string errNIMNotFound = "NIM TIDAK TERDAFTAR PADA TPS INI !";
            const string errNIMAlreadyVoted = "NIM SUDAH MELAKUKAN VOTING !";
            const string errNIMAlreadyInside = "NIM SUDAH DI DALAM ANTRIAN !";

            // Validate NIM LENGTH ( MUST equals to 8 )
            if (nim.Length != 8)
            {
                MessageBox.Show(errNIMLEN);
                return false;
            }
            // Validate NIM must contain number
            else if (!isAllNumber(nim))
            {
                MessageBox.Show(errNIMNotNumber);
                return false;
            }
            else if (isNIMAlreadyInside(nim))
            {
                MessageBox.Show(errNIMAlreadyInside);
                return false;
            }
            // Validate NIM must found in DP
            else if (!dbDPT.getDPT(nim))
            {
                MessageBox.Show(errNIMNotFound);
                return false;
            }
            // Validate NIM must not voted 
            else if (!dbDPT.checkBelumPilih(nim))
            {
                MessageBox.Show(errNIMAlreadyVoted);
                return false;
            }
            else
            {
                return true;
            }
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string nim = txtNIM.Text;
            // Free from error :)
            if (isNIMValid(nim))
            {

                ListViewItem item = new ListViewItem(nim);
                // Put into bilik 1 if empty
                if (listViewBlk1.Items.Count == 0)
                {
                    listViewBlk1.Items.Add(item);
                }
                // else put into bilik 2 if empty
                else if (listViewBlk2.Items.Count == 0)
                {
                    listViewBlk2.Items.Add(item);
                }
                // else put into bilik 1 if still capable
                else if (listViewBlk1.Items.Count < MAX_QUEUE_BILIK_1)
                {
                    listViewBlk1.Items.Add(item);
                }
                // else put into bilik 2 if still capable
                else if (listViewBlk2.Items.Count < MAX_QUEUE_BILIK_2)
                {
                    listViewBlk2.Items.Add(item);
                }
                    // else put into waiting list
                else 
                {

                    listViewWL.Items.Add(item);
                }
                txtNIM.Clear();
            }
           updateBtnStats();
        } 

        private void clearListView(int id)
        {
            removeTopList(id);
            if (id != 3) AddRemainingWLTo(id);
            updateBtnStats();
        }

        private void btnClearBlk1_Click(object sender, EventArgs e)
        {
            clearListView(1);
        }

        private void btnClearBlk2_Click(object sender, EventArgs e)
        {
            clearListView(2);
        }

        private void btnClearWL_Click(object sender, EventArgs e)
        {
            clearListView(3);
        }
        
        // Updates the buttons status 
        private void updateBtnStats()
        {
            btnClearWL.Enabled = (listViewWL.Items.Count > 0);
            if (btnGrantAccBlk1.Enabled == true)
            {
                btnClearBlk1.Enabled = (listViewBlk1.Items.Count > 0);
            }
            if (btnGrantAccBlk2.Enabled == true)
            {
                btnClearBlk2.Enabled = (listViewBlk2.Items.Count > 0);
            }
        }

        private void enableClearBilik(int id)
        {
            if (id == 1)
            {
                btnClearBlk1.Enabled = true;
            }
            else // id == 2
            {
                btnClearBlk2.Enabled = true;
            }
        }

        private void disableClearBilik(int id)
        {
            if (id == 1)
            {
                btnClearBlk1.Enabled = false;
            }
            else // id == 2
            {
                btnClearBlk2.Enabled = false;
            }
        }

        private void enableGrantBilik(int id)
        {
            if (id == 1)
            {
                btnGrantAccBlk1.Enabled = true;
            } else // id == 2
            {
                btnGrantAccBlk2.Enabled = true;
            }
        }
        private void disableGrantBilik(int id)
        {
            if (id == 1)
            {
                btnGrantAccBlk1.Enabled = false;
            }
            else // id == 2
            {
                btnGrantAccBlk2.Enabled = false;
            }
        }

        private void removeTopList(int id)
        {
            if (id == 1)
            {
                listViewBlk1.Items[0].Remove();
            } else if (id == 2)// Bilik 2
            {
                listViewBlk2.Items[0].Remove();
            } else if (id == 3) // Waiting List
            {
                listViewWL.Items[0].Remove();
            }
            updateBtnStats();
        }

        private void setSudahPilih(string nim)
        {
            dbDPT.setSudahPilih(nim);
        }

        private void acceptVote(string prodi, string pilihan)
        {
            dbPilihan.tambahPilihanKM(prodi, pilihan);
        }

        private void AddRemainingWLTo(int id)
        {
            if (listViewWL.Items.Count > 0)
            {
                if (id == 1)
                {
                    string nimToMove = listViewWL.Items[0].Text;
                    Console.WriteLine("Nim to move : " + nimToMove);
                    ListViewItem item = new ListViewItem(nimToMove);
                    listViewBlk1.Items.Add(item);
                }
                else
                {
                    string nimToMove = listViewWL.Items[0].Text;
                    Console.WriteLine("Nim to move : " + nimToMove);
                    ListViewItem item = new ListViewItem(nimToMove);
                    listViewBlk2.Items.Add(item);
                }
                removeTopList(3);
            }
        }

        private void processNIMBilik_1(Object _nim)
        {
            Action<int> disableClear = disableClearBilik;
            Action<int> enableClear = enableClearBilik;
            Action<int> disableGrant = disableGrantBilik;
            Action<int> enableGrant = enableGrantBilik;
            Action<int> remTop = removeTopList;
            Action<int> addremwlto = AddRemainingWLTo;
            Action<int> clearlistview = clearListView;
            Action<string> setPilih = setSudahPilih;
            Action<string, string> tambahPilihan = acceptVote;
            Action updBtn = updateBtnStats;

            Invoke(disableGrant, 1);
            Invoke(disableClear, 1);
            string nim = (string)_nim;
            string msg;

            if (!list1.checkOK())
            {
                list1.startServer();
            }
            try
            {
                list1.sendMsg(nim);
                Thread.Sleep(500);
                msg = list1.getMsg();
                Console.WriteLine("Message received : " + msg);
                // TODO update database 
                // kemungkinan 1,2 / 1,2
                if (!msg.Equals("ERROR"))
                {
                    String[] tokens = msg.Split(',');
                    string prodi = nim.Substring(0, 3);
                    Invoke(tambahPilihan, prodi, tokens[0]);
                    Console.WriteLine("Pref1 : " + tokens[0] + " Pref2 : " + tokens[1]);
                    Invoke(setPilih, nim);
                }
                Invoke(clearlistview, 1);
            } catch (Exception ex)
            {
                MessageBox.Show("Coba lagi");
                Console.WriteLine("Error : " + ex.StackTrace);
            } finally
            {
                Invoke(enableGrant, 1);
                Invoke(enableClear, 1);
                Invoke(updBtn);
            }        
        }

        private void processNIMBilik_2(Object _nim)
        {
            Action<int> disableClear = disableClearBilik;
            Action<int> enableClear = enableClearBilik;
            Action<int> disableGrant = disableGrantBilik;
            Action<int> enableGrant = enableGrantBilik;
            Action<int> remTop = removeTopList;
            Action<int> addremwlto = AddRemainingWLTo;
            Action<int> clearlistview = clearListView;
            Action<string> setPilih = setSudahPilih;
            Action<string, string> tambahPilihan = acceptVote;
            Action updBtn = updateBtnStats;

            Invoke(disableGrant, 2);
            Invoke(disableClear, 2);
            string nim = (string)_nim;
            string msg;

            if (!list2.checkOK())
            {
                list2.startServer();
            }
            try
            {
                list2.sendMsg(nim);
                Thread.Sleep(500);
                msg = list2.getMsg();
                Console.WriteLine("Message received : " + msg);
                // TODO update database 
                // kemungkinan 1,2 / 1,x / dst
                if (!msg.Equals("ERROR"))
                {
                    String[] tokens = msg.Split(',');
                    string prodi = nim.Substring(0, 3);
                    Invoke(tambahPilihan, prodi, tokens[0]);
                    Console.WriteLine("Pref1 : " + tokens[0] + " Pref2 : " + tokens[1]);
                    Invoke(setPilih, nim);
                }
                Invoke(clearlistview, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Coba lagi");
                Console.WriteLine("Error : " + ex.StackTrace);
            }
            finally
            {
                Invoke(enableGrant, 2);
                Invoke(enableClear, 2);
                Invoke(updBtn);
            }
        }

        private void btnGrantAccBlk1_Click(object sender, EventArgs e)
        {
            const string errQueueEmpty = "MAAF TIDAK BISA DIPROSES KARENA ANTRIAN KOSONG :(";
            const string errCannotConnect = "TERDAPAT MASALAH SAAT TERHUBUNG DENGAN BILIK 1 :(";
            // Check wheter bilik is empty or not
            if (listViewBlk1.Items.Count == 0)
            {
                    MessageBox.Show(errQueueEmpty);
            } else
            {
                try
                {
                    Thread trd = new Thread(processNIMBilik_1);
                    trd.Start(listViewBlk1.Items[0].Text);
                } catch(Exception ex)
                {
                    MessageBox.Show(errCannotConnect);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        private void btnGrantAccBlk2_Click(object sender, EventArgs e)
        {
            const string errQueueEmpty = "MAAF TIDAK BISA DIPROSES KARENA ANTRIAN KOSONG :(";
            const string errCannotConnect = "TERDAPAT MASALAH SAAT TERHUBUNG DENGAN BILIK 2 :(";
            // Check wheter bilik is empty or not
            if (listViewBlk2.Items.Count == 0)
            {
                MessageBox.Show(errQueueEmpty);
            }
            else
            {
                try
                {
                    Thread trd = new Thread(processNIMBilik_2);
                    trd.Start(listViewBlk2.Items[0].Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(errCannotConnect);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        // === END NIM VALIDATION SECTION ====

        // === IMPORT AND EXPORT DATABASE === //
        private void btnImportDP_Click(object sender, EventArgs e)
        {
            var fd = new System.Windows.Forms.OpenFileDialog();
            fd.Filter = "CSV files (*.csv)|*.csv";
            fd.InitialDirectory = System.Environment.CurrentDirectory;
            fd.Title = "Please select file to import.";
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = fd.FileName;
                if (dbDPT.importCSV(fileToOpen))
                {
                    belumImportLbl.Visible = false;
                    sudahImportLbl.Visible = true;
                }
            }
        }

        private void expKotakSuara_Click(object sender, EventArgs e)
        {
            ValidateExport validate = new ValidateExport();
            validate.ShowDialog();
            bool check = false;
            if (!validate.getCancel())
            {
                check = dbPass.checkPassword(validate.getPassword());
                if (check)
                {
                    var folder = new FolderBrowserDialog();
                    if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string exportname = "HasilReferendumK3M2018.csv";

                        string selectedPath = folder.SelectedPath;
                        string msg = "";
                        string pathDp = selectedPath + @"\" + exportname;
                        if (dbPilihan.exportCSVPilihanKM(pathDp))
                        {
                            msg += "Export Successful!\n";
                            msg += "File Exported to: " + selectedPath + "\n";
                            msg += "File name: " + exportname;
                        }
                        MessageBox.Show(msg);
                    }
                }
                else
                {
                    MessageBox.Show("Password yang Anda Masukan Salah");
                }
            }
        }

        private void btnExportDP_Click(object sender, EventArgs e)
        {
            var fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string exportDPname = "DPstatus.csv";

                string selectedPath = fd.SelectedPath;
                string msg = "";
                string pathDp = selectedPath + @"\" + exportDPname;
                if (dbDPT.exportCSVDP(pathDp))
                {
                    msg += "Export Successful!\n";
                    msg += "File Exported to: " + selectedPath + "\n";
                    msg += "File name: " + exportDPname;
                }
                MessageBox.Show(msg);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
        // === IMPORT AND EXPORT DATABASE === //
}
