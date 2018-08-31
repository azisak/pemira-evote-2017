using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemiraClient
{
    public partial class MainForm : Form
    {
        private static State state;
        private ConnectionManager connectionManager;

        private string IP_ADDRESS;
        private int PORT_NUMBER;

        private Point topCenter = new Point(603, 181);
        private Point rightBottom = new Point(1153, 442);

        public MainForm()
        {
            InitializeComponent();

            portfom pf = new portfom();
            pf.ShowDialog();
            IP_ADDRESS = pf.IpAddr;
            PORT_NUMBER = pf.Port;

            StartPosition = FormStartPosition.CenterScreen;

            label_timer_overview.Visible = false;
            label_timer_options_1.Visible = false;
            label_timer_options_2.Visible = false;

            state = new State(BackgroundContainer);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule;
            objKeyboardProcess = new LowLevelKeyboardProc(captureKey);
            ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0);

            killExplorer();

            new Thread(proccessState).Start();
        }

        private void proccessState()
        {
            Action<Label, bool> showLabel = _showLabel;
            Action<Point> setTimerLocation = _setTimerLocation;
            Action<Label, string> setLabelText = _setLabelText;

            //connectionManager = new ConnectionManager(IP_ADDRESS, PORT_NUMBER);
            while (true)
            {
                state.switchState(State.WELCOME);
                int prevState = State.WELCOME;

                Invoke(showLabel, hub_operator, true);

                //ReceiveResponse response = new ReceiveResponse(false, "");
                //while (!response.status)
                //{
                //    response = connectionManager.recv();
                //}

                Invoke(showLabel, hub_operator, false);

                //Invoke(setLabelText, label_NIM, response.value);
                Invoke(setLabelText, label_NIM, "13515000");
                Invoke(showLabel, label_NIM, true);

                bool sessionExpired = false;
                while (!sessionExpired)
                {
                    state.updateState();
                    int currentState = state.getStateCode();
                    if (prevState != currentState)
                    {
                        switch(state.getStateCode())
                        {
                            case State.INSTRUCTION:
                                Invoke(showLabel, label_NIM, false);
                                break;
                            case State.FIRST_PREF_OPTIONS:
                                new Thread(triggerTimerInOptions).Start();
                                Invoke(showLabel, label_timer_options_1, true);
                                Invoke(showLabel, label_timer_options_2, false);
                                Invoke(showLabel, label_timer_overview, false);
                                break;
                            case State.SECOND_PREF_1_CHOSEN:
                                new Thread(triggerTimerInOptions2).Start();
                                Invoke(showLabel, label_timer_options_1, false);
                                Invoke(showLabel, label_timer_options_2, true);
                                break;
                            case State.SECOND_PREF_2_CHOSEN: 
                                new Thread(triggerTimerInOptions2).Start();
                                Invoke(showLabel, label_timer_options_1, false);
                                Invoke(showLabel, label_timer_options_2, true);
                                break;
                            case State.CONFIRMATION_1_OVER_2:
                                new Thread(triggerTimerInOverview).Start();
                                Invoke(showLabel, label_timer_options_1, false);
                                Invoke(showLabel, label_timer_options_2, false);
                                Invoke(setTimerLocation, rightBottom);
                                Invoke(showLabel, label_timer_overview, true);
                                break;
                            case State.CONFIRMATION_2_OVER_1:
                                new Thread(triggerTimerInOverview).Start();
                                Invoke(showLabel, label_timer_options_1, false);
                                Invoke(showLabel, label_timer_options_2, false);
                                Invoke(setTimerLocation, rightBottom);
                                Invoke(showLabel, label_timer_overview, true);
                                break;
                            case State.CONFIRMATION_1_ONLY:
                                new Thread(triggerTimerInOverview).Start();
                                Invoke(showLabel, label_timer_options_2, false);
                                Invoke(setTimerLocation, rightBottom);
                                Invoke(showLabel, label_timer_overview, true);
                                break;
                            case State.CONFIRMATION_2_ONLY:
                                new Thread(triggerTimerInOverview).Start();
                                Invoke(showLabel, label_timer_options_2, false);
                                Invoke(setTimerLocation, rightBottom);
                                Invoke(showLabel, label_timer_overview, true);
                                break;
                            case State.CONFIRMATION_ABSTAIN:
                                new Thread(triggerTimerInOverview).Start();
                                Invoke(showLabel, label_timer_options_1, false);
                                Invoke(showLabel, label_timer_options_2, false);
                                Invoke(setTimerLocation, topCenter);
                                Invoke(showLabel, label_timer_overview, true);
                                break;
                            case State.THANKYOU:
                                Invoke(showLabel, label_timer_overview, false);
                                Invoke(showLabel, label_timer_options_2, false);
                                Invoke(showLabel, label_timer_options_1, false);
                                bool sent = connectionManager.send(state.getDecision(0) + "," + state.getDecision(1));
                                while (!sent)
                                {
                                    sent = connectionManager.send(state.getDecision(0) + "," + state.getDecision(1));
                                }
                                Console.WriteLine("Final decision : " + state.getDecision(0) + "," + state.getDecision(1));
                                Thread.Sleep(2000);
                                sessionExpired = true;
                                state.updateKeypress(-1);
                                state.invalidate();
                                break;
                        }
                    }
                    prevState = currentState;
                }
            }
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            state.updateKeypress(e.KeyChar);
        }

        private void triggerTimerInOptions()
        {
            Action<Label, string> UpdateTimer = _setLabelText;
            Action<string> ShowWarningDialog = _showWarningDialog;

            bool isAbstain = true;
            
            
            for (int i = 60; i >= 0; i--)
            {
                if (i == 30)
                {
                    Invoke(ShowWarningDialog, "Pilih dong, plisss :'");
                }   
                else if (i == 10)
                {
                    Invoke(ShowWarningDialog, "Ayo dong, plisss :'");
                }
                Invoke(UpdateTimer, label_timer_options_1, i.ToString());
                Thread.Sleep(1000);
                isAbstain = label_timer_options_1.Visible;
                if (!isAbstain) break;
            }

            if (isAbstain) state.switchState(State.CONFIRMATION_ABSTAIN);
        }

        private void _showWarningDialog(string warningMessage)
        {
            WarningDialog warningDialog = new WarningDialog();
            warningDialog.setLabelText(warningMessage);
            warningDialog.ShowDialog();
        }

        private void triggerTimerInOptions2()
        {
            Action<Label, string> UpdateTimer = _setLabelText;

            bool isAbstain = true;

            for (int i = 20; i >= 0; i--)
            {
                Invoke(UpdateTimer, label_timer_options_2, i.ToString());
                Thread.Sleep(1000);
                isAbstain = label_timer_options_2.Visible;
                if (!isAbstain) break;
            }

            if (isAbstain && state.getDecision(0).Equals('1')) state.switchState(State.CONFIRMATION_1_ONLY);
            else if (isAbstain && state.getDecision(0).Equals('2')) state.switchState(State.CONFIRMATION_2_ONLY);
        }

        private void triggerTimerInOverview()
        {
            Action<Label, string> UpdateTimer = _setLabelText;
            Action<Label, bool> showLabel = _showLabel;

            bool sure = true;

            for (int i = 10; i >= 0; i--)
            {
                Invoke(UpdateTimer, label_timer_overview, i.ToString());
                Thread.Sleep(1000);
                sure = label_timer_overview.Visible;
                if (!sure) break;
            }

            if (sure) state.switchState(State.THANKYOU);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt & e.Shift & e.KeyCode == Keys.P)
            {
                PasswordDialog dialog = new PasswordDialog();
                dialog.Show();
            }
        }

        private void _showLabel(Label label, bool isShown)
        {
            label.Visible = isShown;
        }

        private void _setTimerLocation(Point point)
        {
            label_timer_overview.Location = point;
        }

        private void _setLabelText(Label label, string text)
        {
            label.Text = text;
        }

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
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(int hWnd, uint Msg, int wParam, int lParam);
        //Declaring Global objects     
        private IntPtr ptrHook;
        private LowLevelKeyboardProc objKeyboardProcess;

        private IntPtr captureKey(int nCode, IntPtr wp, IntPtr lp)
        {
            if (nCode >= 0)
            {
                KBDLLHOOKSTRUCT objKeyInfo = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lp, typeof(KBDLLHOOKSTRUCT));

                bool inactivateKey = objKeyInfo.key == Keys.RWin || objKeyInfo.key == Keys.LWin;
                inactivateKey = inactivateKey || objKeyInfo.key == Keys.Tab && HasAltModifier(objKeyInfo.flags);
                inactivateKey = inactivateKey || objKeyInfo.key == Keys.Escape && (ModifierKeys & Keys.Control) == Keys.Control;
                inactivateKey = inactivateKey || objKeyInfo.key == Keys.Escape && HasAltModifier(objKeyInfo.flags);
                inactivateKey = inactivateKey || objKeyInfo.key == Keys.F4 && HasAltModifier(objKeyInfo.flags);

                if (inactivateKey)
                {
                    return (IntPtr)1; 
                }
            }
            return CallNextHookEx(ptrHook, nCode, wp, lp);
        }

        bool HasAltModifier(int flags)
        {
            return (flags & 0x20) == 0x20;
        }

        private void killExplorer()
        {
            int hwnd;
            hwnd = FindWindow("Progman", null);
            PostMessage(hwnd, /*WM_QUIT*/ 0x12, 0, 0);
            return;
        }

        public static void ShowRedoWarning()
        {
            RedoWarning dialog = new RedoWarning();
            dialog.Show();
        }
    }
}
