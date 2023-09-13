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
        char[,] matrixValue;
        bool isXturn = true;

        PictureBox pbTurn;
        Panel panelBoard;
        GameMode gameMode;
        public Gameplay(Panel panelBoard, PictureBox pbTurn, GameMode gameMode)
        {
            this.panelBoard = panelBoard;
            this.pbTurn = pbTurn;
            this.gameMode = gameMode;
        }
        public void BoardInit()
        {
            WIDTH = panelBoard.Width / btnWidth;
            HEIGHT = panelBoard.Height / btnHeight;
            matrixButton = new Button[HEIGHT, WIDTH];
            matrixValue = new char[HEIGHT, WIDTH];
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
                    matrixValue[i, j] = ' ';
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
            {
                btn.BackgroundImage = Properties.Resources.x;
                matrixValue[point.Y, point.X] = 'x';
                pbTurn.BackgroundImage = Properties.Resources.o;
            }
            else if (gameMode == GameMode.PvP)
            {
                btn.BackgroundImage = Properties.Resources.o;
                matrixValue[point.Y, point.X] = 'o';
                pbTurn.BackgroundImage = Properties.Resources.x;
            }
            isXturn = !isXturn;
            if (gameMode == GameMode.PvC)
                ComputerTurn();
            if (IsEndGame(point))
            {
                MessageBox.Show("End Game");
                return;
            }
        }

        private void ComputerTurn()
        {

        }

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
                if (matrixValue[point.Y, i] == matrixValue[point.Y, point.X])
                    countLeft++;
                else
                    break;
            }
            for (int i = point.X + 1; i < WIDTH; i++)
            {
                if (matrixValue[point.Y, i] == matrixValue[point.Y, point.X])
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
                if (matrixValue[i, point.X] == matrixValue[point.Y, point.X])
                    countTop++;
                else
                    break;
            }
            for (int i = point.Y + 1; i < HEIGHT; i++)
            {
                if (matrixValue[i, point.X] == matrixValue[point.Y, point.X])
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
                if (matrixValue[point.Y - i, point.X - i] == matrixValue[point.Y, point.X])
                    countTop++;
                else
                    break;
            }
            for (int i = 1; i < WIDTH - point.X; i++)
            {
                if (point.X + i >= WIDTH || point.Y + i >= HEIGHT)
                    break;
                if (matrixValue[point.Y + i, point.X + i] == matrixValue[point.Y, point.X])
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
                if (matrixValue[point.Y + i, point.X - i] == matrixValue[point.Y, point.X])
                    countTop++;
                else
                    break;
            }
            for (int i = 1; i < WIDTH - point.X; i++)
            {
                if (point.X + i >= WIDTH || point.Y - i < 0)
                    break;
                if (matrixValue[point.Y - i, point.X + i] == matrixValue[point.Y, point.X])
                    countBottom++;
                else
                    break;
            }
            return countTop + countBottom >= 5;
        }
    }
    public enum GameMode
    {
        PvP,
        PvC
    }
}
