using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace PemiraServer
{
    public partial class MainForm : Form
    {
        private ServerSocket[] sock;
        private TimerCountdown[] time;
        private string[] tag = { "1" , "2" };
        private bool[] isTwice;
        private bool[] isS1;
        private const int MAXWAITING = 2;
        private string[] host = { "169.254.1.2", "169.254.1.3" };
        //private string[] host = { "127.0.0.1", "127.0.0.1" };
        private int nPasswords = 5;

        private int port = 13514;
        private dbDPTController dbDpt = new dbDPTController();
        private dbQBilik1Controller dbQBilik1 = new dbQBilik1Controller();
        private dbQBilik2Controller dbQBilik2 = new dbQBilik2Controller();
        private dbWaitingListController dbWaitingList = new dbWaitingListController();
        private dbImportStatusController dbImport = new dbImportStatusController();
        private dbKunciPasswordsController dbPasswords = new dbKunciPasswordsController();

        /*
            Constructors
        */
        public MainForm()
        {
            //Minta Password
            if (dbPasswords.getDataCount() == 0)
            {
                for (int i = 1; i <= nPasswords; i++)
                {
                    InputPassword ip = new InputPassword(i);
                    ip.ShowDialog();
                }
            }

            InitializeComponent();
            InitializeListView();
            InitializeVariable();
            InitializeQueue();
            //dbDpt.importCSV("E:/Contoh File DPT.csv");
            //dbDpt.printDB();
            //dbDpt.exportCSVmwawm("E:/MWA.csv");
            //dbDpt.exportCSVkm("E:/K3M.csv");
            //dbQBilik1.printDB();
            //dbQBilik2.printDB();
            //dbWaitingList.printDB();
        }

        /*
            Initialize all data members in this class
        */
        private void InitializeVariable() {
            isTwice = new bool[MAXWAITING];
            isS1 = new bool[MAXWAITING];
            time = new TimerCountdown[MAXWAITING];
            sock = new ServerSocket[MAXWAITING];

            for (int i = 0; i < MAXWAITING; i++) {
                tag[i] = (i + 1).ToString();
                time[i] = new TimerCountdown(tag[i]);
                time[i].Tick += new EventHandler(time_Tick);
                sock[i] = new ServerSocket(host[i], port);
            }
            dbImport.setImportStatusLabel(importStatusLabel);
            dbImport.updateImportStatusLabel();
        }

        private void InitializeQueue() {
            loadQueueFromDB();
            string s;
            if (listViewWaiting.Items.Count > 0)
            {
                while (listViewBilik1.Items.Count < 2)
                {
                    s = listViewWaiting.Items[0].Text;
                    listViewBilik1.Items.Add(s);
                    listViewWaiting.Items.RemoveAt(0);
                }
            }
            if (listViewWaiting.Items.Count > 0)
            {
                while (listViewBilik2.Items.Count < 2)
                {
                    s = listViewWaiting.Items[0].Text;
                    listViewBilik2.Items.Add(s);
                    listViewWaiting.Items.RemoveAt(0);
                }
            }
        }

        private void loadQueueFromDB() {
            DataRowCollection dr = dbWaitingList.getAllRows();
            string NIM;

            foreach (DataRow r in dr) {
                NIM = r["nim"].ToString();
                listViewWaiting.Items.Add(NIM);
            }

            dr = dbQBilik1.getAllRows();
            foreach (DataRow r in dr) {
                NIM = r["nim"].ToString();
                listViewBilik1.Items.Add(NIM);
            }

            dr = dbQBilik2.getAllRows();
            foreach (DataRow r in dr) {
                NIM = r["nim"].ToString();
                listViewBilik2.Items.Add(NIM);
            }
        }

        /*
            Function to add the content of textBoxNIM to waiting list
        */
        private void addToWaiting()
        {
            string s = textBoxNIM.Text;

            if (s != "") {
                int countBilik1 = listViewBilik1.Items.Count;
                int countBilik2 = listViewBilik2.Items.Count;
                if (countBilik2 < MAXWAITING) {
                    //DITAMBAHIN ALSON, semua addNimnya
                    if (countBilik1 == 0) {
                        dbQBilik1.addNim(s);
                        listViewBilik1.Items.Add(s);
                    } else {
                        dbQBilik2.addNim(s);
                        listViewBilik2.Items.Add(s);
                    }
                } else if (countBilik1 < MAXWAITING) {
                    if (countBilik2 == 0) {
                        dbQBilik2.addNim(s);
                        listViewBilik2.Items.Add(s);
                    } else {
                        dbQBilik1.addNim(s);
                        listViewBilik1.Items.Add(s);
                    }
                } else {
                    dbWaitingList.addNim(s);
                    listViewWaiting.Items.Add(s);
                }
            }
            textBoxNIM.Text = "";
        }

        private void STOP_VOTE(ListView listNIM, Button bGrant, TimerCountdown t, Label lTimer) {

            //hapus dari db Queue
            if (bGrant.Name == "buttonGrant1") {
                dbQBilik1.delNim(listNIM.Items[0].Text);
            } else {
                dbQBilik2.delNim(listNIM.Items[0].Text);
            }

            listNIM.Items.RemoveAt(0);

            // Add from listWaiting to bilik
            if (listViewWaiting.Items.Count > 0) {

                string s = listViewWaiting.Items[0].Text;
                listNIM.Items.Add(s);
                //DITAMBAHIN ALSON
                dbWaitingList.delNim(listViewWaiting.Items[0].Text);
                listViewWaiting.Items.RemoveAt(0);
            }
            //sleep selama sekian detik
            Thread.Sleep(3000);
            bGrant.Enabled = true;
            t.Stop();
            t.reset();

            lTimer.Text = TimerCountdown.MAXCOUNT.ToString();

        }

        private void ACCEPT_VOTE(string[] args, int i) {
            //masukin pilihan ke database, masukin juga bahwa NIM x udah milih
            if (args[0] == "K3M") {
                dbDpt.setChoiceKM(args[2], args[1]);
            } else if (args[0] == "MWA") {
                dbDpt.setSudahPilih(args[2], true);
                dbDpt.setChoiceMWAWM(args[2], args[1]);
            }

            //ubah label waktu
            ListView listNIM;
            Button bGrant;
            Label lTimer;
            if (i == 0) {
                bGrant = buttonGrant1;
                lTimer = labelTimerBilik1;
                listNIM = listViewBilik1;
                labelTimerBilik1.Text = TimerCountdown.MAXCOUNT.ToString();
            } else {
                bGrant = buttonGrant2;
                lTimer = labelTimerBilik2;
                listNIM = listViewBilik2;
                labelTimerBilik2.Text = TimerCountdown.MAXCOUNT.ToString();
            }


            if(!isTwice[i]) { //stop proses buat NIM x
                sock[i].disconnect();
                STOP_VOTE(listNIM, bGrant, time[i], lTimer);
            } else {
                //stop timer
                time[i].Stop();
                time[i].reset();
            }
        }

        private void START_VOTE(int i) {
            //start timer
            time[i].Start();
            isTwice[i] = false;
        }

        private void TIME_START(int i) {
            time[i].Start();
        }

        private void TCPrecv(Object i) {
            int idx = (int) i ;
            Action<string[], int> Delegate_AcceptVote = ACCEPT_VOTE;
            Action<int> Delegate_StartVote = START_VOTE;
            Action<int> Delegate_TimeStart = TIME_START;

            string s = "aa";
            while (s != "") {
                try {
                    s = sock[idx].recv();
                    //Debug.WriteLine("recieved" + s);
                    string[] listArg = s.Split(',');
                    if (listArg[0] == "K3M" || listArg[0] == "MWA") {
                        Invoke(Delegate_AcceptVote, listArg, idx);
                    } else if (listArg[0] == "ready") {
                        //Debug.WriteLine("READY");
                        Invoke(Delegate_StartVote, idx);
                    } else if (listArg[0] == "manualMWA") {
                        Invoke(Delegate_TimeStart, idx);
                    }
                } catch (IOException e) {
                    s = "";
                }
            }
        }

        /*
            Event handler when button submit clicked
        */
        private void buttonSubmitNIM_Click(object sender, EventArgs e)
        {
            validasiNIM();
        }

        private void validasiNIM() {
            //DITAMBAHIN ALSON, tapi entah kenapa ga ngecek
            if (dbDpt.isExistInDB(textBoxNIM.Text)) {
                if (!dbDpt.getSudahPilih(textBoxNIM.Text)) {
                    if (!dbQBilik1.isExistInDB(textBoxNIM.Text)) {
                        if (!dbQBilik2.isExistInDB(textBoxNIM.Text)) {
                            if (!dbWaitingList.isExistInDB(textBoxNIM.Text)) {
                                addToWaiting();
                            } else {
                                MessageBox.Show("Nim " + textBoxNIM.Text + " Sudah Ada di Waiting List!");
                            }
                        } else {
                            MessageBox.Show("Nim " + textBoxNIM.Text + " Sudah Ada di Bilik 2!");
                        }
                    } else {
                        MessageBox.Show("Nim " + textBoxNIM.Text + " Sudah Ada di Bilik 1!");
                    }
                } else {
                    MessageBox.Show("Nim " + textBoxNIM.Text + " Sudah Pernah Memilih!");
                }
            } else {
                MessageBox.Show("Nim " + textBoxNIM.Text + " Tidak Terdaftar di DPT maupun DP!");
            }
        }

        /*
            Event handler when enter pressed while typing textBoxNIM
        */
        private void enter_pressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validasiNIM();
            }
        }

        /*
            Event handler when a buttonGrant is clicked
        */
        private void buttonGrant_Click(object sender, EventArgs e)
        {
            Button source = sender as Button;
            ListView listNIM;

            int idx;
            if (source.Name == "buttonGrant1") {
                listNIM = listViewBilik1;
                idx = 0;
            } else {
                listNIM = listViewBilik2;
                idx = 1;
            }

            if (listNIM.Items.Count > 0) { //sukses
                isTwice[idx] = listNIM.Items[0].Text[0] == '1';
                isS1[idx] = isTwice[idx];
                if (!isTwice[idx])
                {
                    dbDpt.setChoiceKM(listNIM.Items[0].Text, "999");
                }

                source.Enabled = false;
                try {
                    sock[idx].connect();
                    Thread trd = new Thread(TCPrecv);
                    trd.Start(idx);
                    string NIM = listNIM.Items[0].Text;
                    string data = "";
                    if (isTwice[idx]) {
                        data = NIM + ",y";
                    } else {
                        data = NIM + ",n";
                    }
                    sock[idx].send(data);
                } catch (Exception excp) {
                    source.Enabled = true;
                    MessageBox.Show("Client is not connected!");
                }
            } else { //gagal
                MessageBox.Show("Tidak ada NIM pada antrian!");
            }

        }

        /*
           Event handler for when a timer ticks
       */
        private void time_Tick(object sender, EventArgs e) {
            TimerCountdown t = sender as TimerCountdown;
            Label lTimer;
            Button bGrant;
            ListView listNIM;
            int idx;
            string data;

            if (t.Tag.ToString() == tag[0]) {
                lTimer = labelTimerBilik1;
                idx = 0;
                bGrant = buttonGrant1;
                listNIM = listViewBilik1;
            } else {
                idx = 1;
                bGrant = buttonGrant1;
                lTimer = labelTimerBilik2;
                listNIM = listViewBilik2;
            }


            t.counter--;
            int count = t.counter;
            lTimer.Text = count.ToString();

            // Check if should choose K3M


            // Timer's empty, stop
            if (count <= 0) {
                try {
                    sock[idx].send("({timeout})");
                    //add to DB
                } catch (IOException excpt) {
                    MessageBox.Show("Client disconnected!");
                }

                if (isTwice[idx]) {
                    t.counter = TimerCountdown.MAXCOUNT;

                    count = t.counter;
                    isTwice[idx] = false;
                    t.Stop();
                    t.reset();
                    dbDpt.setChoiceMWAWM(listNIM.Items[0].Text, "A");
                } else {
                    sock[idx].disconnect();
                    //tandain NIM x udah vote di database
                    dbDpt.setSudahPilih(listNIM.Items[0].Text, true);
                    if (isS1[idx])
                    {
                        dbDpt.setChoiceKM(listNIM.Items[0].Text, "A");
                    }
                    else
                    {
                        dbDpt.setChoiceMWAWM(listNIM.Items[0].Text, "A");
                    }
                    STOP_VOTE(listNIM, bGrant, t, lTimer);
                }
            } else {
                try {
                    data = count.ToString();
                    sock[idx].send(data);
                } catch (IOException excp) {
                    t.Stop();
                    t.reset();
                    bGrant.Enabled = true;
                    MessageBox.Show("Client disconnected!");
                }
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            var fd = new System.Windows.Forms.OpenFileDialog();
            fd.Filter = "CSV files (*.csv)|*.csv";
            fd.InitialDirectory = System.Environment.CurrentDirectory;
            fd.Title = "Please select file to import.";
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = fd.FileName;
                if (dbDpt.importCSV(fileToOpen))
                {
                    dbImport.addNewImportStatus(fileToOpen, System.Environment.MachineName);
                };
                //importStatusLabel.Text = fileToOpen + "\n" + System.Environment.MachineName;
                //importStatusLabel.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= nPasswords; i++)
            {
                BukaKunci bk = new BukaKunci(i);
                bk.ShowDialog();
                if (bk.getIsCancel())
                {
                    break;
                }
                else if (i == nPasswords && bk.getIsPasswordTrue())
                {
                    var fd = new FolderBrowserDialog();
                    //fd.InitialDirectory = System.Environment.CurrentDirectory;
                    //fd.Title = "Please select file to import.";
                    if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string selectedPath = fd.SelectedPath;

                        string exportKMname = "KMresults.csv";
                        string exportMWAWMname = "MWAWMresults.csv";

                        bool isSuccessful = true;
                        string msg = "";
                        dbDPTController dbDpt = new dbDPTController();
                        string pathKM = selectedPath + @"\" + exportKMname;
                        //Cek apakah berhasil export km
                        isSuccessful &= dbDpt.exportCSVkm(pathKM);
                        string pathMWAWM = selectedPath + @"\" + exportMWAWMname;
                        //Cek apakah berhasil export mwawm
                        isSuccessful &= dbDpt.exportCSVmwawm(pathMWAWM);
                        if (isSuccessful)
                        {
                            msg += "Export Successful!\n";
                            msg += "File Exported to: " + selectedPath + "\n";
                            msg += "File names: " + exportKMname + " and " + exportMWAWMname;
                        }

                        MessageBox.Show(msg);
                        //this.Close();
                    }
                }
            }
        }

        private void exportDpButton_Click(object sender, EventArgs e)
        {
            var fd = new FolderBrowserDialog();
            //fd.InitialDirectory = System.Environment.CurrentDirectory;
            //fd.Title = "Please select file to import.";
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string exportDPname = "DPstatus.csv";

                string selectedPath = fd.SelectedPath;
                bool isSuccessful = true;
                string msg = "";
                dbDPTController dbDpt = new dbDPTController();
                string pathDp = selectedPath + @"\" + exportDPname;
                //Cek apakah berhasil export mwawm
                isSuccessful &= dbDpt.exportCSVdp(pathDp);
                if (isSuccessful)
                {
                    msg += "Export Successful!\n";
                    msg += "File Exported to: " + selectedPath + "\n";
                    msg += "File name: " + exportDPname;
                }

                MessageBox.Show(msg);
            }
        }

        private void exportDptButton_Click(object sender, EventArgs e)
        {
            var fd = new FolderBrowserDialog();
            //fd.InitialDirectory = System.Environment.CurrentDirectory;
            //fd.Title = "Please select file to import.";
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string exportDPTname = "DPTstatus.csv";

                string selectedPath = fd.SelectedPath;
                bool isSuccessful = true;
                string msg = "";
                dbDPTController dbDpt = new dbDPTController();
                string pathDpt = selectedPath + @"\" + exportDPTname;
                //Cek apakah berhasil export mwawm
                isSuccessful &= dbDpt.exportCSVdpt(pathDpt);
                if (isSuccessful)
                {
                    msg += "Export Successful!\n";
                    msg += "File Exported to: " + selectedPath + "\n";
                    msg += "File name: " + exportDPTname;
                }

                MessageBox.Show(msg);
            }
        }
    }
}
