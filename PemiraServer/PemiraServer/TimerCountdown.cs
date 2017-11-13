using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemiraServer
{
    class TimerCountdown : Timer
    {
        private int jarak = 1000;
        public static int MAXCOUNT = 20;
        public int counter;

        public TimerCountdown(string s)
        {
            this.Tag = s;
            this.Interval = jarak;
            counter = MAXCOUNT;
        }

        public void reset() {
            counter = MAXCOUNT;
        }
    }
}
