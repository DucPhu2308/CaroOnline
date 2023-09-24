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
            player1 = new Player(Properties.Settings.Default.PlayerName, panelPlayer1);
            player2 = new Player(Properties.Settings.Default.PlayerName2, panelPlayer2);
            player1.TimeOut += Player_TimeOut;
            player2.TimeOut += Player_TimeOut;

            lbName1.Text = player1.Name;
            lbName2.Text = player2.Name;
            BoardInit(panelBoard);
        }

        //Gameplay
        int HEIGHT;
        int WIDTH;
        int btnWidth = 30;
        int btnHeight = 30;
        protected Button[,] matrixButton = null;
        protected bool isXturn = true;
        public static Bitmap imgX = Properties.Resources.x;
        public static Bitmap imgO = Properties.Resources.o;
        List<Button> winningButtons = new List<Button>();
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
            // unable to change first player after first move
            changeFirstPlayerToolStripMenuItem.Enabled = false;
            Button btn = sender as Button;
            btn.Focus();
            if (btn.BackgroundImage != null)
                return;

            Point point = GetPoint(btn);
            if (isXturn)
                btn.BackgroundImage = imgX;
            else
                btn.BackgroundImage = imgO;
            if (IsEndGame(matrixButton, point))
            {
                Player winner = isXturn ? player1 : player2;
                Console.WriteLine(winner.Name);
                EndGame(winner);
            }
            else
                ChangeTurn();
        }
        protected virtual void EndGame(Player winner)
        {
            // enable change first player after game ends
            changeFirstPlayerToolStripMenuItem.Enabled = true;
            winner.Score++;
            winner.UpdateScore();
            PauseGame();
            HighlightWinningButtons();
            DialogResult dr = MessageBox.Show(winner.Name + " thắng! Bắt đầu lại?", "Trò chơi kết thúc", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                ResetGame();
            }
        }
        protected void HighlightWinningButtons()
        {
            foreach (Button btn in winningButtons)
            {
                btn.BackColor = Color.Lime;
            }
        }
        protected void Player_TimeOut()
        {
            Player winner = isXturn ? player2 : player1;
            EndGame(winner);
        }
        protected void PauseGame()
        {
            player1.StopCountDown();
            player2.StopCountDown();
            panelBoard.Enabled = false;
        }
        protected virtual void ResetGame()
        {
            panelBoard.Controls.Clear();
            BoardInit(panelBoard);
            panelBoard.Enabled = true;
            player1.ResetTimer();
            player2.ResetTimer();
            UnhighlightPanel(panelPlayer1);
            UnhighlightPanel(panelPlayer2);
            isXturn = true;
            pbTurn.BackgroundImage = imgX;
        }

        protected Point GetPoint(Button btn)
        {
            string[] xy = btn.Tag.ToString().Split(' ');
            int y = Convert.ToInt32(xy[0]);
            int x = Convert.ToInt32(xy[1]);
            return new Point(x, y);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Bạn muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
                Dispose();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn muốn bắt đầu lại?", "Bắt đầu lại", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                ResetGame();
        }

        private void exitToMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exitToDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }
        protected virtual void changeFirstPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player.ChangeFirstPlayer(ref player1, ref player2);
        }

        #region endgame check
        public bool IsEndGame(Button[,] matrixButton, Point point)
        {
            return IsEndGameHorizontal(matrixButton, point) || IsEndGameVertical(matrixButton, point) || IsEndGamePrimaryDiagonal(matrixButton, point) || IsEndGameSubDiagonal(matrixButton, point);
        }
        bool IsEndGameHorizontal(Button[,] matrixButton, Point point)
        {
            int countLeft = 0;
            int countRight = 0;
            winningButtons.Add(matrixButton[point.Y, point.X]);
            int w = matrixButton.GetLength(1);
            for (int i = point.X; i >= 0; i--)
            {
                if (matrixButton[point.Y, i].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                {
                    countLeft++;
                    winningButtons.Add(matrixButton[point.Y, i]);
                }
                else
                    break;
            }
            for (int i = point.X + 1; i < w; i++)
            {
                if (matrixButton[point.Y, i].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                {
                    countRight++;
                    winningButtons.Add(matrixButton[point.Y, i]);
                }
                else
                    break;
            }
            if (countLeft + countRight >= 5)
            {
                return true;
            }
            else
            {
                winningButtons.Clear();
                return false;
            }
        }
        bool IsEndGameVertical(Button[,] matrixButton, Point point)
        {
            int countTop = 0;
            int countBottom = 0;
            int h = matrixButton.GetLength(0);
            winningButtons.Add(matrixButton[point.Y, point.X]);
            for (int i = point.Y; i >= 0; i--)
            {
                if (matrixButton[i, point.X].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                {
                    countTop++;
                    winningButtons.Add(matrixButton[i, point.X]);
                }
                else
                    break;
            }
            for (int i = point.Y + 1; i < h; i++)
            {
                if (matrixButton[i, point.X].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                {
                    countBottom++;
                    winningButtons.Add(matrixButton[i, point.X]);
                }
                else
                    break;
            }
            if (countTop + countBottom >= 5)
            {
                return true;
            }
            else
            {
                winningButtons.Clear();
                return false;
            }
        }
        bool IsEndGamePrimaryDiagonal(Button[,] matrixButton, Point point)
        {
            int countTop = 0;
            int countBottom = 0;
            int h = matrixButton.GetLength(0);
            int w = matrixButton.GetLength(1);
            winningButtons.Add(matrixButton[point.Y, point.X]);
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0)
                    break;
                if (matrixButton[point.Y - i, point.X - i].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                {
                    countTop++;
                    winningButtons.Add(matrixButton[point.Y - i, point.X - i]);
                }
                else
                    break;
            }
            for (int i = 1; i < w - point.X; i++)
            {
                if (point.X + i >= w || point.Y + i >= h)
                    break;
                if (matrixButton[point.Y + i, point.X + i].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                {
                    countBottom++;
                    winningButtons.Add(matrixButton[point.Y + i, point.X + i]);
                }
                else
                    break;
            }
            if (countTop + countBottom >= 5)
            {
                return true;
            }
            else
            {
                winningButtons.Clear();
                return false;
            }
        }
        bool IsEndGameSubDiagonal(Button[,] matrixButton, Point point)
        {
            int countTop = 0;
            int countBottom = 0;
            int h = matrixButton.GetLength(0);
            int w = matrixButton.GetLength(1);
            winningButtons.Add(matrixButton[point.Y, point.X]);
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y + i >= h)
                    break;
                if (matrixButton[point.Y + i, point.X - i].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                {
                    countTop++;
                    winningButtons.Add(matrixButton[point.Y + i, point.X - i]);
                }
                else
                    break;
            }
            for (int i = 1; i < w - point.X; i++)
            {
                if (point.X + i >= w || point.Y - i < 0)
                    break;
                if (matrixButton[point.Y - i, point.X + i].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                {
                    countBottom++;
                    winningButtons.Add(matrixButton[point.Y - i, point.X + i]);
                }
                else
                    break;
            }
            if (countTop + countBottom >= 5)
            {
                return true;
            }
            else
            {
                winningButtons.Clear();
                return false;
            }
        }
        #endregion
    }
}
