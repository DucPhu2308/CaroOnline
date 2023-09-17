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
        public Panel PanelPlayer { get; set; }
        public event TimeOutHandler TimeOut;
        public delegate void TimeOutHandler();
        public Player(string name, Panel panelPlayer)
        {
            Name = name;
            Score = 0;
            TimeLeft = Properties.Settings.Default.TotalTime;

            Timer = new Timer();
            Timer.Interval = 100;
            Timer.Tick += Timer_Tick;


            PanelPlayer = panelPlayer;
            foreach (Control control in PanelPlayer.Controls)
            {
                if (control.Tag == null)
                    continue;
                if (control.Tag.ToString() == "name")
                {
                    LabelName = control as Label;
                }
                else if (control.Tag.ToString() == "time")
                {
                    LabelTime = control as Label;
                }
            }
            LabelTime.Text = GetTimeLeft();
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
        public void ResetTimer()
        {
            StopCountDown();
            TimeLeft = Properties.Settings.Default.TotalTime;
            LabelTime.Text = GetTimeLeft();
        }
        public void Timer_Tick(object sender, EventArgs e)
        {
            TimeLeft -= (double) Timer.Interval/1000;
            LabelTime.Text = GetTimeLeft();
            if (TimeLeft <= 0)
            {
                Timer.Stop();
                if (TimeOut != null)
                    TimeOut();
            }
        }
    }
}
