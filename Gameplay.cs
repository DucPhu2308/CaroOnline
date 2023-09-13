using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroLAN
{
    internal class Gameplay
    {
        int HEIGHT;
        int WIDTH;
        int btnWidth = 30;
        int btnHeight = 30;
        Button[,] matrixButton;
        bool isXturn = true;
        Bitmap imgX = Properties.Resources.x;
        Bitmap imgO = Properties.Resources.o;

        PictureBox pbTurn;
        Panel panelBoard;
        GameMode gameMode;
        Player player1;
        Player player2;
        public Gameplay(Panel panelBoard, PictureBox pbTurn, GameMode gameMode, Player player1, Player player2)
        {
            this.panelBoard = panelBoard;
            this.pbTurn = pbTurn;
            this.gameMode = gameMode;
            this.player1 = player1;
            this.player2 = player2;
        }
        public void BoardInit()
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
        Point GetPoint(Button btn)
        {
            string[] xy = btn.Tag.ToString().Split(' ');
            int y = Convert.ToInt32(xy[0]);
            int x = Convert.ToInt32(xy[1]);
            return new Point(x, y);
        }
        private void MatrixButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackgroundImage != null)
                return;

            Point point = GetPoint(btn);
            if (isXturn)
                btn.BackgroundImage = imgX;
            else if (gameMode == GameMode.PvP)
                btn.BackgroundImage = imgO;
            if (IsEndGame(point))
                EndGame();
            else
                ChangeTurn();
        }

        private void ChangeTurn()
        {
            if (isXturn) // change to O turn
            {
                pbTurn.BackgroundImage = imgO;
                player2.HighlightPanel();
                player2.StartCountDown();
                player1.StopCountDown();
                player1.UnhighlightPanel();
            }
            else
            {
                pbTurn.BackgroundImage = imgX;
                player1.StartCountDown();
                player1.HighlightPanel();
                player2.StopCountDown();
                player2.UnhighlightPanel();
            }
            isXturn = !isXturn;
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
        #region endgame check
        bool IsEndGame(Point point)
        {
            return IsEndGameHorizontal(point) || IsEndGameVertical(point) || IsEndGamePrimaryDiagonal(point) || IsEndGameSubDiagonal(point);
        }
        bool IsEndGameHorizontal(Point point)
        {
            int countLeft = 0;
            int countRight = 0;
            for (int i = point.X; i >= 0; i--)
            {
                if (matrixButton[point.Y, i].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                {
                    countLeft++;
                    Console.WriteLine(countLeft);
                }
                else
                    break;
            }
            for (int i = point.X + 1; i < WIDTH; i++)
            {
                if (matrixButton[point.Y, i].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                    countRight++;
                else
                    break;
            }
            return countLeft + countRight >= 5;
        }
        bool IsEndGameVertical(Point point)
        {
            int countTop = 0;
            int countBottom = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (matrixButton[i, point.X].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                    countTop++;
                else
                    break;
            }
            for (int i = point.Y + 1; i < HEIGHT; i++)
            {
                if (matrixButton[i, point.X].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                    countBottom++;
                else
                    break;
            }
            return countTop + countBottom >= 5;
        }
        bool IsEndGamePrimaryDiagonal(Point point)
        {
            int countTop = 0;
            int countBottom = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0)
                    break;
                if (matrixButton[point.Y - i, point.X - i].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                    countTop++;
                else
                    break;
            }
            for (int i = 1; i < WIDTH - point.X; i++)
            {
                if (point.X + i >= WIDTH || point.Y + i >= HEIGHT)
                    break;
                if (matrixButton[point.Y + i, point.X + i].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                    countBottom++;
                else
                    break;
            }
            return countTop + countBottom >= 5;
        }
        bool IsEndGameSubDiagonal(Point point)
        {
            int countTop = 0;
            int countBottom = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y + i >= HEIGHT)
                    break;
                if (matrixButton[point.Y + i, point.X - i].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                    countTop++;
                else
                    break;
            }
            for (int i = 1; i < WIDTH - point.X; i++)
            {
                if (point.X + i >= WIDTH || point.Y - i < 0)
                    break;
                if (matrixButton[point.Y - i, point.X + i].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                    countBottom++;
                else
                    break;
            }
            return countTop + countBottom >= 5;
        }
        #endregion
    }
    public enum GameMode
    {
        PvP,
        PvC
    }
}
