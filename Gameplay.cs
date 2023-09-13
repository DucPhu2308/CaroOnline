using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroLAN
{
    internal class Gameplay
    {
        const char NONE = ' ';
        const char PLAYER = 'x';
        const char COMPUTER = 'o';

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
            //WIDTH = panelBoard.Width / btnWidth;
            //HEIGHT = panelBoard.Height / btnHeight;
            WIDTH = 6;
            HEIGHT = 6;
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
            else
            {
                btn.BackgroundImage = Properties.Resources.o;
                matrixValue[point.Y, point.X] = 'o';
                pbTurn.BackgroundImage = Properties.Resources.x;
            }
            isXturn = !isXturn;

            if (IsEndGame(point))
            {
                MessageBox.Show("End Game");
                return;
            }
            else if (gameMode == GameMode.PvC && isXturn == false)
                ComputerTurn();
        }
        bool isFull()
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    if (matrixValue[i, j] == NONE) 
                        return false;
                }
            }
            return true;
        }
        private void ComputerTurn()
        {
            Point bestMove = new Point(0,0);
            int bestVal = -CONS.INFINITY;
            for (int i=0; i<HEIGHT; i++)
            {
                for (int j=0; j<WIDTH; j++)
                {
                    if (matrixValue[i, j] == NONE)
                    {
                        matrixValue[i, j] = COMPUTER;
                        int val = minimax(i, j, -CONS.INFINITY, CONS.INFINITY,0, false);
                        matrixValue[i, j] = NONE;
                        Console.WriteLine("{0}, {1}: {2}",i,j,val);
                        if (val > bestVal)
                        {
                            bestVal = val;
                            bestMove = new Point(j, i);
                        }
                    }
                }
            }
            Console.WriteLine("-----------------------------");
            MatrixButton_Click((object)matrixButton[bestMove.Y, bestMove.X], null);
        }
        private int heuristicEvaluation(char turn)
        {
            int score = 0;
            for (int i =0; i<HEIGHT; i++)
            {
                for (int j=0; j<WIDTH; j++)
                {
                    if ((matrixValue[i, j]) == turn)
                    {
                        score += 1;
                    }
                    else if (matrixValue[i, j] == NONE)
                    {
                        score += 0;
                    }
                    else
                    {
                        score -= 1;
                    }
                }
            }
            return score;
        }
        private int minimax(int I, int J, int alpha, int beta, int depth, bool isMaximizing)
        {
            if (IsEndGame(new Point(J, I)))
            {
                if (isMaximizing)
                    return CONS.DEPTH - depth;
                else
                    return depth - CONS.DEPTH;
            }
            char turn = isMaximizing ? COMPUTER : PLAYER;
            if (depth == CONS.DEPTH)
                return heuristicEvaluation(turn);
            if (isFull())
                return 0;
            int bestVal = isMaximizing ? -CONS.INFINITY : CONS.INFINITY;
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    if (matrixValue[i, j] == ' ')
                    {
                        
                        matrixValue[i, j] = turn;
                        int val = minimax(i, j, alpha, beta, depth + 1, !isMaximizing);
                        matrixValue[i, j] = NONE;
                        if (isMaximizing)
                        {
                            bestVal = Math.Max(val, bestVal);
                            alpha = Math.Max(bestVal, alpha);
                        }
                        else
                        {
                            bestVal = Math.Min(val, bestVal);
                            beta = Math.Min(bestVal, beta);
                        }
                        if (alpha >= beta)
                            break;
                    }
                            
                } 
            } 
            return bestVal;
            
            /*
            if (isMaximizing)
            {
                if (IsEndGame(new Point(J, I)))
                    return depth - CONS.DEPTH;
                int bestVal = -CONS.INFINITY;
                for (int i = 0; i < HEIGHT; i++)
                {
                    for (int j = 0; j < WIDTH; j++)
                    {
                        if (matrixValue[i,j] == ' ')
                        {

                            matrixValue[i, j] = COMPUTER;
                            int val = minimax(i, j, alpha, beta, depth + 1, false);
                            matrixValue[i, j] = NONE;
                            bestVal = Math.Max(val, bestVal);

                            //alpha beta prunning
                            alpha = Math.Max(bestVal, alpha);
                            if (alpha >= beta) 
                                break;
                        }
                    }
                }
                //Console.WriteLine(bestVal);
                return bestVal;
            }
            else
            {
                if (IsEndGame(new Point(J, I)))
                    return CONS.DEPTH - depth;
                int bestVal = CONS.INFINITY;
                for (int i = 0; i < HEIGHT; i++)
                {
                    for (int j = 0; j < WIDTH; j++)
                    {
                        if (matrixValue[i, j] == NONE)
                        {

                            matrixValue[i, j] = PLAYER;
                            int val = minimax(i, j, alpha, beta, depth + 1, true);
                            matrixValue[i, j] = NONE;
                            bestVal = Math.Min(val, bestVal);

                            //alpha beta prunning
                            beta = Math.Min(bestVal, beta);
                            if (alpha >= beta) 
                                break;
                        }
                    }
                }
                //Console.WriteLine(bestVal);
                return bestVal;
            }
            */
        }

        #region Check Win
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
        #endregion
    }
    public enum GameMode
    {
        PvP,
        PvC
    }
}
