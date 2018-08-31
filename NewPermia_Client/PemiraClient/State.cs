using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemiraClient
{
    class State
    {
        public const int WELCOME = 0;
        public const int INSTRUCTION = 1;
        public const int FIRST_PREF_OPTIONS = 2;
        public const int SECOND_PREF_1_CHOSEN = 3;
        public const int SECOND_PREF_2_CHOSEN = 4;
        public const int CONFIRMATION_1_OVER_2 = 5;
        public const int CONFIRMATION_2_OVER_1 = 6;
        public const int CONFIRMATION_1_ONLY = 7;
        public const int CONFIRMATION_2_ONLY = 8;
        public const int CONFIRMATION_ABSTAIN = 9;
        public const int THANKYOU = 10;

        public const int DEFAULT_KEY = -9999;

        private const int ENTER_KEY = 13;
        private const int BACKSPACE_KEY = 8;

        private const int MAX_ITERATION = 1;

        private const char KEY_1 = 'f';
        private const char KEY_2 = 'j';

        private const char VAL_1 = '1';
        private const char VAL_2 = '2';

        private int keypress;
        private int state;
        private int iteration;

        private PictureBox pictureBox;

        private Point topCenter = new Point(603, 181);
        private Point rightBottom = new Point(1153, 442);

        private char[] decision = new char[2];

        public State(PictureBox pb)
        {
            state = WELCOME;
            pictureBox = pb;
            iteration = 0;

            decision[0] = 'X';
            decision[1] = 'X';
        }

        public int getStateCode()
        {
            return state;
        }

        public void updateState()
        {
            if (keypress != DEFAULT_KEY)
            {
                keypress = Char.ToLower((char)keypress);
                switch (state)
                {
                    case WELCOME:
                        Thread.Sleep(2000);
                        switchState(INSTRUCTION);
                        break;
                    case INSTRUCTION:
                        if (keypress == ENTER_KEY) switchState(FIRST_PREF_OPTIONS);
                        break;
                    case FIRST_PREF_OPTIONS:
                        if (keypress == KEY_1)
                        {
                            decision[0] = VAL_1;
                            switchState(SECOND_PREF_1_CHOSEN);
                        }
                        else if (keypress == KEY_2)
                        {
                            decision[0] = VAL_2;
                            switchState(SECOND_PREF_2_CHOSEN);
                        }
                        break;
                    case SECOND_PREF_1_CHOSEN:
                        switchState(CONFIRMATION_1_OVER_2);
                        break;
                    case SECOND_PREF_2_CHOSEN:
                        switchState(CONFIRMATION_2_OVER_1);
          					    break;
        				    case CONFIRMATION_1_ONLY:
                    case CONFIRMATION_1_OVER_2:
                    case CONFIRMATION_2_ONLY:
                    case CONFIRMATION_2_OVER_1:
                    case CONFIRMATION_ABSTAIN:
                        clarifyDecision(keypress);
					              break;
                    case THANKYOU:
                        switchState(THANKYOU);
                        break;
                }
  			    keypress = DEFAULT_KEY;
            }
        }

        public char getDecision(int idx)
        {
            return decision[idx];
        }

        public void updateKeypress(int val)
        {
            keypress = val;
        }

        private void clarifyDecision(int keypress)
        {
            iteration++;
            if (keypress == BACKSPACE_KEY)
            {
                if (iteration > MAX_ITERATION)
                {
                    var th = new Thread(() =>
                    {
                        var form = new RedoWarning();
                        form.FormClosing += (s, e) => Application.ExitThread();
                        form.Show();
                        Application.Run();
                    });
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
                else switchState(FIRST_PREF_OPTIONS);
            }
            else if (keypress == ENTER_KEY)
            {
                switchState(THANKYOU);
            }
        }

        public int getIteration()
        {
            return iteration;
        }

        public int getMaxIteration()
        {
            return MAX_ITERATION;
        }

        public void switchState(int stateCode)
        {
            changeBg(stateCode);
            state = stateCode;
        }

        public void invalidate()
        {
            iteration = 0;

            decision[0] = 'X';
            decision[1] = 'X';
        }

        private void changeBg(int stateCode)
        {
            switch(stateCode)
            {
                case WELCOME:
                    pictureBox.BackgroundImage = Properties.Resources.referendum_welcome;
                    break;
                case INSTRUCTION:
                    pictureBox.BackgroundImage = Properties.Resources.screen_instructions;
                    break;
                case FIRST_PREF_OPTIONS:
                    pictureBox.BackgroundImage = Properties.Resources.screen_first_pref_options;
                    break;
                case SECOND_PREF_1_CHOSEN:
                    pictureBox.BackgroundImage = Properties.Resources.screen_second_pref_1_chosen;
                    break;
                case SECOND_PREF_2_CHOSEN:
                    pictureBox.BackgroundImage = Properties.Resources.screen_second_pref_2_chosen;
                    break;
                case CONFIRMATION_1_OVER_2:
                    pictureBox.BackgroundImage = Properties.Resources.screen_confirmation_1_over_2;
                    break;
                case CONFIRMATION_2_OVER_1:
                    pictureBox.BackgroundImage = Properties.Resources.screen_confirmation_2_over_1;
                    break;
                case CONFIRMATION_1_ONLY:
                    pictureBox.BackgroundImage = Properties.Resources.screen_confirmation_1_only;
                    break;
                case CONFIRMATION_2_ONLY:
                    pictureBox.BackgroundImage = Properties.Resources.screen_confirmation_2_only;
                    break;
                case CONFIRMATION_ABSTAIN:
                    pictureBox.BackgroundImage = Properties.Resources.screen_confirmation_abstain;
                    break;
                case THANKYOU:
                    pictureBox.BackgroundImage = Properties.Resources.screen_thankyou;
                    break;
            }
        }
    }
}
