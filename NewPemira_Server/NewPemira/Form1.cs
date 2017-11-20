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

        const int MAX_QUEUE_BILIK_1 = 2;
        const int MAX_QUEUE_BILIK_2 = 2;
        const int N_PASSWORD = 5;
        List<string> password = new List<string>();

        const string myIp = "169.254.1.2";
        const int port1 = 13514;
        const int port2 = 13515;
        MyListener list1;
        MyListener list2;

        public Form1()
        {
            InitializeComponent();
            updateBtnStats();
            /*
            // Check if password already inputted
            // For testing, assumed password not implemented
            for (int i = 1; i <= N_PASSWORD; i++)
            {
                InputPassword ip = new InputPassword(i);
                ip.ShowDialog();
                password.Add(ip.Pass);
            }

            // Print to console the password inputted
            int idx = 1;
            foreach (var password in password)
            {
                Console.WriteLine("Input pwd "+ idx++ +": " + password);
            }*/

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

        private bool isNIMValid(string nim)
        {
            const string errNIMLEN = "PANJANG NIM HARUS 8 !";
            const string errNIMNotNumber = "NIM HARUS BERISI BILANGAN !";
            const string errNIMNotFound = "NIM TIDAK TERDAFTAR PADA TPS INI !";
            const string errNIMAlreadyVoted = "NIM SUDAH MELAKUKAN VOTING !";

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
            }/*
            // Validate NIM must found in DP
            else if (!FoundAtDP(nim))
            {
                MessageBox.Show(errNIMNotFound);
                return false;
            }
            // Validate NIM must not voted 
            else if (!AlreadyVoted(nim) {
                MessageBox.Show(errNIMAlreadyVoted);
                return false;
            }*/
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

        private void btnClearBlk1_Click(object sender, EventArgs e)
        {
            listViewBlk1.Items.Clear();

            updateBtnStats();
        }

        private void btnClearBlk2_Click(object sender, EventArgs e)
        {
            listViewBlk2.Items.Clear();

            updateBtnStats();
        }

        private void btnClearWL_Click(object sender, EventArgs e)
        {
            listViewWL.Items.Clear();

            updateBtnStats();
        }

        private void btnAddRemaining_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (listViewWL.Items.Count > 0 && (listViewBlk1.Items.Count < MAX_QUEUE_BILIK_1 || listViewBlk2.Items.Count < MAX_QUEUE_BILIK_2) )
            {
                ListViewItem item = new ListViewItem(listViewWL.Items[i].Text);
                listViewWL.Items.RemoveAt(i);
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
            }

            updateBtnStats();
        }

        // Updates the buttons status 
        private void updateBtnStats()
        {
            if (listViewWL.Items.Count == 0)
            {
                btnClearWL.Enabled = false;
                btnAddRemaining.Enabled = false;
            } else
            {
                btnClearWL.Enabled = true;
                if (listViewBlk1.Items.Count < MAX_QUEUE_BILIK_1 || listViewBlk2.Items.Count < MAX_QUEUE_BILIK_2)
                {
                    btnAddRemaining.Enabled = true;
                }
                else
                {
                    btnAddRemaining.Enabled = false;
                }
            }
            if (listViewBlk1.Items.Count == 0)
            {
                btnClearBlk1.Enabled = false;
            } else
            {
                btnClearBlk1.Enabled = true;
            }
            if (listViewBlk2.Items.Count == 0)
            {
                btnClearBlk2.Enabled = false;
            } else
            {
                btnClearBlk2.Enabled = true;
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
            } else // id == 2
            {
                listViewBlk2.Items[0].Remove();
            }
        }

        private void processNIMBilik_1(Object _nim)
        {
            Action<int> disableGrant = disableGrantBilik;
            Action<int> enableGrant = enableGrantBilik;
            Action<int> remTop = removeTopList;
            Action updBtn = updateBtnStats;
            Invoke(disableGrant, 1);
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
                String[] tokens = msg.Split(',');
                Console.WriteLine("Pref1 : " + tokens[0] + " Pref2 : " + tokens[1]);
                Invoke(remTop, 1);
            } catch (Exception ex)
            {
                MessageBox.Show("Coba lagi");
                Console.WriteLine("Error : " + ex.StackTrace);
            } finally
            {
                Invoke(enableGrant, 1);
                Invoke(updBtn);
            }
                
        }

        private void processNIMBilik_2(Object _nim)
        {
            Action<int> disableGrant = disableGrantBilik;
            Action<int> enableGrant = enableGrantBilik;
            Action<int> remTop = removeTopList;
            Action updBtn = updateBtnStats;
            Invoke(disableGrant, 2);
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
                String[] tokens = msg.Split(',');
                Console.WriteLine("Pref1 : " + tokens[0] + " Pref2 : " + tokens[1]);
                Invoke(remTop, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Coba lagi");
                Console.WriteLine("Error : " + ex.StackTrace);
            }
            finally
            {
                Invoke(enableGrant, 2);
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


    }
}
