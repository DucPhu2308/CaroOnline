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
        protected Player player1;
        protected Player player2;
        protected void Form1_Load(object sender, EventArgs e)
        {
            player1 = new Player(Properties.Settings.Default.PlayerName, lbTimer1, lbName1);
            player2 = new Player(Properties.Settings.Default.PlayerName2, lbTimer2, lbName2);
            lbName1.Text = player1.Name;
            lbName2.Text = player2.Name;
            BoardInit(panelBoard);
        }

        //Gameplay
        int HEIGHT;
        int WIDTH;
        int btnWidth = 30;
        int btnHeight = 30;
        protected Button[,] matrixButton;
        protected bool isXturn = true;
        protected Bitmap imgX = Properties.Resources.x;
        protected Bitmap imgO = Properties.Resources.o;

        public void BoardInit(Panel panelBoard)
        {
            WIDTH = panelBoard.Width / btnWidth;
            HEIGHT = panelBoard.Height / btnHeight;
            matrixButton = new Button[HEIGHT, WIDTH];
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    matrixButton[i, j] = new Button()
                    {
                        Width = btnWidth,
                        Height = btnHeight,
                        Location = new Point(j * btnHeight, i * btnWidth),
                        Tag = i.ToString() + " " + j.ToString(),
                        BackgroundImageLayout = ImageLayout.Zoom,
                    };
                    matrixButton[i, j].Click += MatrixButton_Click;
                    panelBoard.Controls.Add(matrixButton[i, j]);
                }
            }
        }
        protected void ChangeTurn()
        {
            if (isXturn) // change to O turn
            {
                pbTurn.BackgroundImage = imgO;
                HighlightPanel(panelPlayer2);
                player2.StartCountDown();
                player1.StopCountDown();
                UnhighlightPanel(panelPlayer1);
            }
            else
            {
                pbTurn.BackgroundImage = imgX;
                player1.StartCountDown();
                HighlightPanel(panelPlayer1);
                player2.StopCountDown();
                UnhighlightPanel(panelPlayer2);
            }
            isXturn = !isXturn;
        }
        public void HighlightPanel(Panel PanelPlayer)
        {
            PanelPlayer.BackColor = Color.YellowGreen;
        }
        public void UnhighlightPanel(Panel PanelPlayer)
        {
            PanelPlayer.BackColor = Color.Transparent;
        }
        protected virtual void MatrixButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackgroundImage != null)
                return;

            Point point = GetPoint(btn);
            if (isXturn)
                btn.BackgroundImage = imgX;
            else
                btn.BackgroundImage = imgO;
            if (Gameplay.IsEndGame(matrixButton, point))
                EndGame();
            else
                ChangeTurn();
        }
        public void EndGame()
        {
            player1.StopCountDown();
            player2.StopCountDown();
            if (isXturn)
            {
                MessageBox.Show(player1.Name + " thắng");
                player1.Score++;
            }
            else
            {
                MessageBox.Show(player2.Name + " thắng");
                player2.Score++;
            }

        }
        Point GetPoint(Button btn)
        {
            string[] xy = btn.Tag.ToString().Split(' ');
            int y = Convert.ToInt32(xy[0]);
            int x = Convert.ToInt32(xy[1]);
            return new Point(x, y);
        }
    }
}
