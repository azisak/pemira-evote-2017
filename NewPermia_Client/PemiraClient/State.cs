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

        private int keypress;
        private int state;
        private int iteration;

        private PictureBox pictureBox;
        private Label nim;
        private Label timerOptions1;
        private Label timerOptions2;
        private Label timerOverview;

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
                        if (keypress == '1') switchState(SECOND_PREF_1_CHOSEN);
                        else if (keypress == '2') switchState(SECOND_PREF_2_CHOSEN);
                        break;
                    case SECOND_PREF_1_CHOSEN:
                        decision[0] = '1';
                        if (iteration >= MAX_ITERATION && keypress == '2' || keypress == '1')
                        {
                            if (keypress == '2') decision[1] = '2';
                            switchState(THANKYOU);
                        }
                        else if (keypress == '1')
                            switchState(CONFIRMATION_1_ONLY);
                        else if (keypress == '2')
                            switchState(CONFIRMATION_1_OVER_2);
                        break;
                    case SECOND_PREF_2_CHOSEN:
                        decision[0] = '2';
                        if (iteration >= MAX_ITERATION && keypress == '2' || keypress == '1')
                        {
                            if (keypress == '1') decision[1] = '1';
                            switchState(THANKYOU);
                        }
                        else if (keypress == '1')
                            switchState(CONFIRMATION_2_OVER_1);
					    else if (keypress == '2')
                            switchState(CONFIRMATION_2_ONLY);
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
            if (keypress == BACKSPACE_KEY) switchState(FIRST_PREF_OPTIONS);
            else if (keypress == ENTER_KEY) switchState(THANKYOU);
        }

        public void switchState(int stateCode)
        {
            changeBg(stateCode);
            state = stateCode;
        }

        private void changeBg(int stateCode)
        {
            switch(stateCode)
            {
                case WELCOME:
                    pictureBox.BackgroundImage = Properties.Resources.screen_welcome;
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
