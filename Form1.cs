using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroLAN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Gameplay gameplay;
        Player player1;
        Player player2;
        private void Form1_Load(object sender, EventArgs e)
        {
            player1 = new Player("Phu", timerPlayer1, txtTimer1, panelPlayer1);
            player2 = new Player("Phu2", timerPlayer2, txtTimer2, panelPlayer2);
            txtPlayerName1.Text = player1.Name;
            txtPlayerName2.Text = player2.Name;
            gameplay = new Gameplay(panelBoard, pbTurn, GameMode.PvP, player1, player2);
            gameplay.BoardInit();
        }
    }
}
