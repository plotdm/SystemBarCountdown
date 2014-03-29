using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemBarCountdown
{
    public partial class TimerDisplay : Form
    {
        public DateTime finishAt;
        private TimeSpan timeLeft;

        public TimerDisplay()
        {
            InitializeComponent();

            finishAt = DateTime.Now;
            UpdateDisplay();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timeLeft = finishAt - DateTime.Now;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            hoursLabel.Text = Convert.ToString(timeLeft.Hours);
            minutesLabel.Text = Convert.ToString(timeLeft.Minutes);
            secondsLabel.Text = Convert.ToString(timeLeft.Seconds);
        }
    }
}
