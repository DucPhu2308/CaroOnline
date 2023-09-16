using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace CaroLAN
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public double TimeLeft { get; set; }
        public Timer Timer { get; set; }
        public Label LabelTime { get; set; }
        public Label LabelName { get; set; }
        public Player(string name, Label txtTime, Label labelName)
        {
            Name = name;
            Score = 0;
            TimeLeft = 5 * 60;

            Timer = new Timer();
            Timer.Interval = 100;
            Timer.Tick += Timer_Tick;

            LabelTime = txtTime;
            LabelTime.Text = GetTimeLeft();
            LabelName = labelName;
        }
        public string GetTimeLeft()
        {
            int timeLeft = (int)TimeLeft;
            int minutes = timeLeft / 60;
            int seconds = timeLeft % 60;
            string minutesStr = minutes.ToString();
            string secondsStr = seconds.ToString();
            if (minutes < 10)
            {
                minutesStr = "0" + minutesStr;
            }
            if (seconds < 10)
            {
                secondsStr = "0" + secondsStr;
            }

            return minutesStr + ":" + secondsStr;
        }
        public void UpdateName(string name)
        {
            Name = name;
            LabelName.Text = name;
        }
        public void StartCountDown()
        {
            Timer.Start();
        }
        public void StopCountDown()
        {
            Timer.Stop();
        }
        public void Timer_Tick(object sender, EventArgs e)
        {
            TimeLeft -= (double) Timer.Interval/1000;
            LabelTime.Text = GetTimeLeft();
            if (TimeLeft == 0)
            {
                Timer.Stop();
                MessageBox.Show(Name + " hết giờ");
            }
        }
    }
}
