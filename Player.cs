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
        public Label LabelScore { get; set; }
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
            UpdatePanel();
            LabelTime.Text = GetTimeLeft();
        }
        public void UpdateScore()
        {
            LabelScore.Text = "Score: " + Score.ToString();
        }
        void UpdatePanel()
        {
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
                else if (control.Tag.ToString() == "score")
                {
                    LabelScore = control as Label;
                }
            }
        }
        public static void ChangeFirstPlayer(ref Player player1, ref Player player2)
        {
            Player temp = player1;
            player1 = player2;
            player2 = temp;
            // swap panel
            Panel tempPanel = player1.PanelPlayer;
            player1.PanelPlayer = player2.PanelPlayer;
            player2.PanelPlayer = tempPanel;

            player1.UpdatePanel();
            player1.UpdateScore();
            player1.UpdateName();

            player2.UpdatePanel();
            player2.UpdateScore();
            player2.UpdateName();
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
        public void UpdateName()
        {
            LabelName.Text = Name;
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
