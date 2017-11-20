using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
            new Thread(proccessState).Start();
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

        private void proccessState()
        {
            
            Action<Label, bool> showLabel = _showLabel;
            Action<Point> setTimerLocation = _setTimerLocation;
            Action<Label, string> setLabelText = _setLabelText;

            connectionManager = new ConnectionManager(IP_ADDRESS, PORT_NUMBER);
            while (true)
            {
                state.switchState(State.WELCOME);
                int prevState = State.WELCOME;

                Invoke(showLabel, hub_operator, true);

                string nim = connectionManager.recv();

                Invoke(showLabel, hub_operator, false);

                Invoke(setLabelText, label_NIM, nim);
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
                                Invoke(showLabel, label_timer_options_2, false);
                                Invoke(setTimerLocation, rightBottom);
                                Invoke(showLabel, label_timer_overview, true);
                                break;
                            case State.CONFIRMATION_2_OVER_1:
                                new Thread(triggerTimerInOverview).Start();
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
                                connectionManager.send(state.getDecision(0) + "," + state.getDecision(1));
                                Console.WriteLine(">>>>>>>> " + state.getDecision(0) + "," + state.getDecision(1));
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

        private void updateTimer(int time, Label label)
        {
            label.Text = time.ToString();
        }

        private void triggerTimerInOptions()
        {
            Action<int, Label> UpdateTimer = updateTimer;

            bool isAbstain = true;

            for (int i = 20; i >= 0; i--)
            {
                Invoke(UpdateTimer, i, label_timer_options_1);
                Thread.Sleep(1000);
                isAbstain = label_timer_options_1.Visible;
                if (!isAbstain) break;
            }

            if (isAbstain) state.switchState(State.CONFIRMATION_ABSTAIN);
        }

        private void triggerTimerInOptions2()
        {
            Action<int, Label> UpdateTimer = updateTimer;

            bool isAbstain = true;

            for (int i = 20; i >= 0; i--)
            {
                Invoke(UpdateTimer, i, label_timer_options_2);
                Thread.Sleep(1000);
                isAbstain = label_timer_options_2.Visible;
                if (!isAbstain) break;
            }

            if (isAbstain && state.getDecision(0).Equals('1')) state.switchState(State.CONFIRMATION_1_ONLY);
            else if (isAbstain && state.getDecision(0).Equals('2')) state.switchState(State.CONFIRMATION_2_ONLY);
        }

        private void triggerTimerInOverview()
        {
            Action<int, Label> UpdateTimer = updateTimer;
            Action<Label, bool> showLabel = _showLabel;

            bool sure = true;

            for (int i = 10; i >= 0; i--)
            {
                Invoke(UpdateTimer, i, label_timer_overview);
                Thread.Sleep(1000);
                sure = label_timer_overview.Visible;
                if (!sure) break;
            }

            if (sure) state.switchState(State.THANKYOU);
        }
    }
}
