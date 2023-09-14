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
    internal class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public double TimeLeft { get; set; }
        public Timer Timer { get; set; }
        public Label TxtTime { get; set; }
        public Panel PanelPlayer { get; set; }
        public Player(string name, Timer timer, Label txtTime, Panel panelPlayer)
        {
            Name = name;
            Score = 0;
            TimeLeft = 5*60;
            Timer = timer;
            Timer.Tick += Timer_Tick;
            TxtTime = txtTime;
            TxtTime.Text = GetTimeLeft();
            PanelPlayer = panelPlayer;
        }
        public void HighlightPanel()
        {
            PanelPlayer.BackColor = System.Drawing.Color.YellowGreen;
        }
        public void UnhighlightPanel()
        {
            PanelPlayer.BackColor = System.Drawing.Color.Transparent;
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
            TxtTime.Text = GetTimeLeft();
            if (TimeLeft == 0)
            {
                Timer.Stop();
                MessageBox.Show(Name + " hết giờ");
            }
        }
    }
}
