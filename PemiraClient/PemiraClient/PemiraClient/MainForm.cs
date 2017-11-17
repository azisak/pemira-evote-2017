using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Diagnostics;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;
using Microsoft.VisualBasic;

namespace PemiraClient
{
    public partial class MainForm : Form
    {
        private const int WELCOME = 0;
        private const int INSTRUCTION_MWA = 1;
        private const int INSTRUCTION_K3M = 2;
        private const int FIRST_PREFERRENCE_OPTIONS = 3;
        private const int SECOND_PREFERRENCE_OPTIONS_CHOOSEN_2 = 4;
        private const int SECOND_PREFERRENCE_OPTIONS_CHOOSEN_1 = 5;
        private const int CLARIFICATION_1_OVER_2 = 6;
        private const int CLARIFICATION_2_OVER_1 = 7;
        private const int CLARIFICATION_2_ONLY = 8;
        private const int CLARIFICATION_1_ONLY = 9;
        private const int CLARIFICATION_ABSTAIN = 10;
        private const int THANKYOU = 11;

        private const int SENTINEL_KEY = -9999;

        private const int ENTER_KEY = 13;
        private const int BACKSPACE_KEY = 8;

        private int state;
        private int numberOfLooping = 1;
        
        private char[] finalDecision = new char[2];

        private bool hookKeyboard = false;

        /***===========================DISABLE KEY==============================***/
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(int hWnd, uint Msg, int wParam, int lParam);
        /* Code to Disable WinKey, Alt+Tab, Ctrl+Esc Starts Here */

        // Structure contain information about low-level keyboard input event 
        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public Keys key;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr extra;
        }
        //System level functions to be used for hook and unhook keyboard input  
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int id, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hook, int nCode, IntPtr wp, IntPtr lp);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string name);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern short GetAsyncKeyState(Keys key);
        //Declaring Global objects     
        private IntPtr ptrHook;
        private LowLevelKeyboardProc objKeyboardProcess;

        private IntPtr captureKey(int nCode, IntPtr wp, IntPtr lp)
        {
            if (nCode >= 0)
            {
                KBDLLHOOKSTRUCT objKeyInfo = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lp, typeof(KBDLLHOOKSTRUCT));

                // Disabling Windows keys 

                if (objKeyInfo.key == Keys.RWin || objKeyInfo.key == Keys.LWin || objKeyInfo.key == Keys.Tab && HasAltModifier(objKeyInfo.flags) || objKeyInfo.key == Keys.F4 && HasAltModifier(objKeyInfo.flags) || objKeyInfo.key == Keys.Escape && HasAltModifier(objKeyInfo.flags) || objKeyInfo.key == Keys.Escape && (ModifierKeys & Keys.Control) == Keys.Control)
                {
                    return (IntPtr)1; // if 0 is returned then All the above keys will be enabled
                }
            }
            return CallNextHookEx(ptrHook, nCode, wp, lp);
        }

        bool HasAltModifier(int flags)
        {
            return (flags & 0x20) == 0x20;
        }
        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AllocConsole();
        Thread ThreadingServer;

        private void MainForm_Load(object sender, EventArgs e)
        {
            //killExplorer(); //GALAU MAU PAKE ATAU ENGGA

            label_timer_options.Visible = false;
            label_timer_options_2.Visible = false;
            label_timer_overview.Visible = false;

            KeyPreview = true;
            ControlBox = false;
            MinimizeBox = false;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            ThreadingServer = new Thread(StartServer);
            ThreadingServer.IsBackground = true;
            ThreadingServer.Start();
            //AllocConsole();
            ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule;
            objKeyboardProcess = new LowLevelKeyboardProc(captureKey);

            ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0);
        }
        /* Code to Disable WinKey, Alt+Tab, Ctrl+Esc Ends Here */
        /***==============================================================================***/
        /***===================================KILLEXPLORER===============================***/
        private void killExplorer()
        {
            int hwnd;
            hwnd = FindWindow("Progman", null);
            PostMessage(hwnd, /*WM_QUIT*/ 0x12, 0, 0);
            return;
        }
        /***===============================================================================***/
        /***=====================================DISABLE ALT + F4==========================***/
        private bool _altF4Pressed;
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                _altF4Pressed = true;
            }
            else if ((e.Alt && e.Shift && e.KeyCode == Keys.P))
            {
                DialogPassword password = new DialogPassword();
                password.StartPosition = FormStartPosition.CenterScreen;
                password.ShowDialog();
                if (password.inputPassword != "ajdlfjghjashdkjfdfkjlsgajsd")
                {
                    if (password.inputPassword == "inipassword")
                    {
                        foreach (Process p in Process.GetProcesses())
                        {
                            // In case we get Access Denied
                            try
                            {
                                if (p.MainModule.FileName.ToLower().EndsWith(":\\windows\\explorer.exe"))
                                {
                                    p.Kill();
                                    break;
                                }
                            }
                            catch
                            { }
                        }
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Password salah !");
                    }
                }
                password.Dispose();
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_altF4Pressed)
            {
                e.Cancel = true;
                _altF4Pressed = false;
            }
        }

        //Declare and Initialize the IP Adress
        //static IPAddress ipAd = IPAddress.Parse("192.168.43.90");
        static IPAddress ipAd = IPAddress.Parse("127.0.0.1");
        //static IPAddress ipAd = IPAddress.Parse("167.205.66.210");
        //Declare and Initilize the Port Number;
        static int PortNumber = 13514;

        /* Initializes the Listener */
        TcpListener ServerListener = new TcpListener(IPAddress.Any, PortNumber);
        TcpClient clientSocket = default(TcpClient);
        private void THREAD_MOD(string teste, Label x)
        {
            x.Text = teste;
        }

        private void _changeGB(int code)
        {
            Thread OptionsTimerThread = new Thread(triggerTimerInOptions);
            Thread OverviewTimerThread = new Thread(triggerTimeInOverview);
            Thread Options2TimerThread = new Thread(triggerTimerInOptions2);
            switch (code)
            {
                case WELCOME:
                    BackgroundContainer.BackgroundImage = Properties.Resources.welcome;
                    break;
                case INSTRUCTION_K3M:
                    label_NIM_container.Visible = false;
                    BackgroundContainer.BackgroundImage = Properties.Resources.instruction_k3m;
                    break;
                case FIRST_PREFERRENCE_OPTIONS:
                    switchTimer(label_timer_overview, label_timer_options);
                    OptionsTimerThread.Start();
                    BackgroundContainer.BackgroundImage = Properties.Resources.options;
                    break;
                case SECOND_PREFERRENCE_OPTIONS_CHOOSEN_2:
                    finalDecision[0] = '2';
                    switchTimer(label_timer_options, label_timer_options_2);
                    Options2TimerThread.Start();
                    BackgroundContainer.BackgroundImage = Properties.Resources.choose_2;
                    break;
                case SECOND_PREFERRENCE_OPTIONS_CHOOSEN_1:
                    finalDecision[0] = '1';
                    switchTimer(label_timer_options, label_timer_options_2);
                    Options2TimerThread.Start();
                    BackgroundContainer.BackgroundImage = Properties.Resources.choose_1;
                    break;
                case CLARIFICATION_1_ONLY:
                    switchTimer(label_timer_options_2, label_timer_overview);
                    OverviewTimerThread.Start();
                    BackgroundContainer.BackgroundImage = Properties.Resources.clarification_1;
                    numberOfLooping++;
                    break;
                case CLARIFICATION_2_ONLY:
                    switchTimer(label_timer_options_2, label_timer_overview);
                    label_timer_overview.Visible = true;
                    OverviewTimerThread.Start();
                    BackgroundContainer.BackgroundImage = Properties.Resources.clarification_2;
                    numberOfLooping++;
                    break;
                case CLARIFICATION_2_OVER_1:
                    switchTimer(label_timer_options_2, label_timer_overview);
                    OverviewTimerThread.Start();
                    BackgroundContainer.BackgroundImage = Properties.Resources.clarification_2_1;
                    numberOfLooping++;
                    break;
                case CLARIFICATION_1_OVER_2:
                    switchTimer(label_timer_options_2, label_timer_overview);
                    OverviewTimerThread.Start();
                    BackgroundContainer.BackgroundImage = Properties.Resources.clarification_1_2;
                    numberOfLooping++;
                    break;
                case CLARIFICATION_ABSTAIN:
                    switchTimer(label_timer_options, label_timer_overview);
                    OverviewTimerThread.Start();
                    BackgroundContainer.BackgroundImage = Properties.Resources.clarification_abstain;
                    numberOfLooping++;
                    break;
                case THANKYOU:
                    label_timer_overview.Visible = false;
                    BackgroundContainer.BackgroundImage = Properties.Resources.thankyou;
                    Debug.WriteLine("Final Decision = { " + finalDecision[0] + ", " + finalDecision[1] + " }");
                    break;
            }
            state = code;
        }

        private void StartServer()
        {
            Action<string, Label> DelegateTeste_ModifyText = THREAD_MOD;
            Action<int> changeGB = _changeGB;
            Action clarifyDecision = _clarifyDecision;

            Invoke(changeGB, WELCOME);
            //ServerListener.Start();
       
            Debug.WriteLine("Connecting to server ...");
            //clientSocket = ServerListener.AcceptTcpClient();
            Debug.WriteLine("Connected to server.");
            //Debug.WriteLine("Received message = " + clientSocket.GetStream().ToString());

            //NetworkStream networkStream1 = clientSocket.GetStream();
            //byte[] bytesFromawal = new byte[20];
            //int j = networkStream1.Read(bytesFromawal, 0, 20);
            //string[] firstRead = System.Text.Encoding.ASCII.GetString(bytesFromawal,0,j).Split(',');
            string[] firstRead = { "13515108", "y" };
            Debug.WriteLine(firstRead[0]);
            Debug.WriteLine(firstRead[1]);
            Invoke(DelegateTeste_ModifyText, firstRead[0], label_NIM);

            hookKeyboard = true;
            Thread.Sleep(3000);
            hookKeyboard = false;

            Invoke(changeGB, INSTRUCTION_K3M);

            while (nPress != ENTER_KEY) ;

            Invoke(changeGB, FIRST_PREFERRENCE_OPTIONS);

            while (true)
            {
                //try
                //{
                //    NetworkStream networkStream = clientSocket.GetStream();
                //    byte[] bytesFrom = new byte[20];
                //    int i = networkStream.Read(bytesFrom, 0, 20);
                //    string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom,0,i);
                //    Debug.WriteLine(dataFromClient);
                //    if (GBPilihMWA.Visible)
                //    {
                //        Invoke(DelegateTeste_ModifyText, dataFromClient, labelTimer);
                //    }
                //    else if (GBPilihKetuaKM.Visible)
                //    {
                //        Invoke(DelegateTeste_ModifyText, dataFromClient, labelTimer2);
                //    }
                //    string serverResponse = "OK";
                //    if (nPress >= '0' && nPress <= '9')
                //    {
                //        if (GBPilihMWA.Visible == true)
                //        {
                //            serverResponse = ("MWA," + (nPress - '0').ToString() + "," + firstRead[0]);
                //        }
                //        else if (GBPilihKetuaKM.Visible == true)
                //        {
                //            serverResponse = ("K3M," + (nPress - '0').ToString() + "," + firstRead[0]);
                //        }
                //        nPress = -1;
                //    }
                //    Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                //    networkStream.Write(sendBytes, 0, sendBytes.Length);
                //    networkStream.Flush();
                //    if (dataFromClient == "({timeout})")
                //    {
                //        if (GBPilihMWA.Visible)
                //        {
                //            if (firstRead[1] == "y")
                //            {
                //                MessageBox.Show("Pemilu akan dilanjutkan dengan pemilihan Ketua Kabinet KM ITB");
                //                serverResponse = "ready";
                //                sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                //                networkStream.Write(sendBytes, 0, sendBytes.Length);
                //                networkStream.Flush();
                //                Invoke(changeGB, GBPilihKetuaKM);
                //            }
                //            else if (firstRead[1] == "n")
                //            {
                //                Invoke(changeGB, GBTerimaKasih);
                //                System.Threading.Thread.Sleep(1000);
                //                sendBytes = Encoding.ASCII.GetBytes("DONE");
                //                networkStream.Write(sendBytes, 0, sendBytes.Length);
                //                networkStream.Flush();
                //            }
                //        }
                //        else if (GBPilihKetuaKM.Visible)
                //        {
                //            Invoke(changeGB, GBTerimaKasih);
                //            System.Threading.Thread.Sleep(1000);
                //            sendBytes = Encoding.ASCII.GetBytes("DONE");
                //            networkStream.Write(sendBytes, 0, sendBytes.Length);
                //            networkStream.Flush();
                //        }
                //    }
                //    else
                //    {
                //        if (serverResponse != "OK")
                //        {
                //            if (GBPilihMWA.Visible)
                //            {
                //                if (firstRead[1] == "y")
                //                {
                //                    MessageBox.Show("Pemilu akan dilanjutkan dengan pemilihan Ketua Kabinet KM ITB");
                //                    serverResponse = "ready";
                //                    sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                //                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                //                    networkStream.Flush();
                //                    Invoke(changeGB, GBPilihKetuaKM);
                //                }
                //                else if (firstRead[1] == "n")
                //                {
                //                    Invoke(changeGB, GBTerimaKasih);
                //                    System.Threading.Thread.Sleep(1000);
                //                    sendBytes = Encoding.ASCII.GetBytes("DONE");
                //                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                //                    networkStream.Flush();
                //                }
                //            }
                //            else if (GBPilihKetuaKM.Visible)
                //            {
                //                Invoke(changeGB, GBTerimaKasih);
                //                System.Threading.Thread.Sleep(1000);
                //                sendBytes = Encoding.ASCII.GetBytes("DONE");
                //                networkStream.Write(sendBytes, 0, sendBytes.Length);
                //                networkStream.Flush();
                //            }
                //        }
                //    }
                //}
                //catch
                //{
                //    ServerListener.Stop();
                //    Invoke(changeGB, GBWelcomeScreen);
                //    ServerListener.Start();
                //    Invoke(DelegateTeste_ModifyText, "Hubungi operator untuk memilih", labelNIM);
                //    Invoke(DelegateTeste_ModifyText, "", labelTimer);
                //    Invoke(DelegateTeste_ModifyText, "", labelTimer2);
                //    clientSocket = ServerListener.AcceptTcpClient();
                //    networkStream1 = clientSocket.GetStream();
                //    byte[] bytesFromawalx = new byte[20];
                //    j = networkStream1.Read(bytesFromawalx, 0, 20);
                //    firstRead = System.Text.Encoding.ASCII.GetString(bytesFromawalx,0,j).Split(',');
                //    Debug.WriteLine(firstRead[0]);
                //    Debug.WriteLine(firstRead[1]);
                //    Invoke(DelegateTeste_ModifyText, firstRead[0],labelNIM);
                //    System.Threading.Thread.Sleep(500);
                //    Invoke(changeGB, GBPilihMWA);
                //}

                if (nPress != SENTINEL_KEY)
                {
                    switch (state)
                    {
                        case FIRST_PREFERRENCE_OPTIONS:
                            if (nPress == '1') Invoke(changeGB, SECOND_PREFERRENCE_OPTIONS_CHOOSEN_1);
                            else if (nPress == '2') Invoke(changeGB, SECOND_PREFERRENCE_OPTIONS_CHOOSEN_2);
                            break;
                        case SECOND_PREFERRENCE_OPTIONS_CHOOSEN_1:
                            if (nPress == '1') Invoke(changeGB, CLARIFICATION_1_ONLY);
                            else if (nPress == '2') Invoke(changeGB, CLARIFICATION_1_OVER_2);
                            break;
                        case SECOND_PREFERRENCE_OPTIONS_CHOOSEN_2:
                            if (nPress == '2') Invoke(changeGB, CLARIFICATION_2_ONLY);
                            else if (nPress == '1') Invoke(changeGB, CLARIFICATION_2_OVER_1);
                            break;
                        case CLARIFICATION_1_ONLY:
                        case CLARIFICATION_2_ONLY:
                            finalDecision[1] = 'X';
                            Invoke(clarifyDecision);
                            break;
                        case CLARIFICATION_2_OVER_1:
                            finalDecision[1] = '1';
                            Invoke(clarifyDecision);
                            break;
                        case CLARIFICATION_1_OVER_2:
                            finalDecision[1] = '2';
                            Invoke(clarifyDecision);
                            break;
                        case CLARIFICATION_ABSTAIN:
                            finalDecision[0] = 'X';
                            finalDecision[1] = 'X';
                            Invoke(clarifyDecision);
                            break;
                    }
                    nPress = SENTINEL_KEY;
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private int nPress = SENTINEL_KEY;
        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (hookKeyboard) return;
            nPress = e.KeyChar == '1' || e.KeyChar == '2' || e.KeyChar == ENTER_KEY || e.KeyChar == BACKSPACE_KEY ? nPress = e.KeyChar : SENTINEL_KEY;
        }

        private void switchTimer(Label hide, Label show)
        {
            hide.Visible = false;
            show.Visible = true;
        }

        private void _clarifyDecision()
        {
            if (nPress == BACKSPACE_KEY)
            {
                if (numberOfLooping > 2)
                {
                    InvalidRequest form = new InvalidRequest();
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.ShowDialog();
                }
                else _changeGB(FIRST_PREFERRENCE_OPTIONS);
            }
            else if (nPress == ENTER_KEY) _changeGB(THANKYOU);
        }

        private void updateTimer(int time, Label label)
        {
            label.Text = time.ToString();
        }

        private void triggerTimerInOptions()
        {
            Action<int, Label> UpdateTimer = updateTimer;
            Action<int> changeGB = _changeGB;

            bool isAbstain = true;

            for (int i = 20; i >= 0; i--)
            {
                Invoke(UpdateTimer, i, label_timer_options);
                Thread.Sleep(1000);
                isAbstain = label_timer_options.Visible;
                if (!isAbstain) break;
            }

            if (isAbstain) Invoke(changeGB, CLARIFICATION_ABSTAIN);
        }

        private void triggerTimerInOptions2()
        {
            Action<int, Label> UpdateTimer = updateTimer;
            Action<int> changeGB = _changeGB;

            bool isAbstain = true;

            for (int i = 20; i >= 0; i--)
            {
                Invoke(UpdateTimer, i, label_timer_options_2);
                Thread.Sleep(1000);
                isAbstain = label_timer_options_2.Visible;
                if (!isAbstain) break;
            }

            if (isAbstain && finalDecision[0].Equals('1')) Invoke(changeGB, CLARIFICATION_1_ONLY);
            else if (isAbstain && finalDecision[0].Equals('2')) Invoke(changeGB, CLARIFICATION_2_ONLY);
        }

        private void triggerTimeInOverview()
        {
            Action<int, Label> UpdateTimer = updateTimer;
            Action<int> changeGB = _changeGB;

            bool sure = true;

            for (int i = 10; i >= 0; i--)
            {
                Invoke(UpdateTimer, i, label_timer_overview);
                Thread.Sleep(1000);
                sure = label_timer_overview.Visible;
                if (!sure) break;
            }

            if (sure) Invoke(changeGB, THANKYOU);
        }
    }
}
