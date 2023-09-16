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
        #region endgame check
        public static bool IsEndGame(Button[,] matrixButton, Point point)
        {
            return IsEndGameHorizontal(matrixButton, point) || IsEndGameVertical(matrixButton, point) || IsEndGamePrimaryDiagonal(matrixButton, point) || IsEndGameSubDiagonal(matrixButton, point);
        }
        static bool IsEndGameHorizontal(Button[,] matrixButton, Point point)
        {
            int countLeft = 0;
            int countRight = 0;

            int w = matrixButton.GetLength(1);
            for (int i = point.X; i >= 0; i--)
            {
                if (matrixButton[point.Y, i].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                {
                    countLeft++;
                }
                else
                    break;
            }
            for (int i = point.X + 1; i < w; i++)
            {
                if (matrixButton[point.Y, i].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                    countRight++;
                else
                    break;
            }
            return countLeft + countRight >= 5;
        }
        static bool IsEndGameVertical(Button[,] matrixButton, Point point)
        {
            int countTop = 0;
            int countBottom = 0;
            int h = matrixButton.GetLength(0);
            for (int i = point.Y; i >= 0; i--)
            {
                if (matrixButton[i, point.X].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                    countTop++;
                else
                    break;
            }
            for (int i = point.Y + 1; i < h; i++)
            {
                if (matrixButton[i, point.X].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                    countBottom++;
                else
                    break;
            }
            return countTop + countBottom >= 5;
        }
        static bool IsEndGamePrimaryDiagonal(Button[,] matrixButton, Point point)
        {
            int countTop = 0;
            int countBottom = 0;
            int h = matrixButton.GetLength(0);
            int w = matrixButton.GetLength(1);
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0)
                    break;
                if (matrixButton[point.Y - i, point.X - i].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                    countTop++;
                else
                    break;
            }
            for (int i = 1; i < w - point.X; i++)
            {
                if (point.X + i >= w || point.Y + i >= h)
                    break;
                if (matrixButton[point.Y + i, point.X + i].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                    countBottom++;
                else
                    break;
            }
            return countTop + countBottom >= 5;
        }
        static bool IsEndGameSubDiagonal(Button[,] matrixButton, Point point)
        {
            int countTop = 0;
            int countBottom = 0;
            int h = matrixButton.GetLength(0);
            int w = matrixButton.GetLength(1);
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y + i >= h)
                    break;
                if (matrixButton[point.Y + i, point.X - i].BackgroundImage == matrixButton[point.Y, point.X].BackgroundImage)
                    countTop++;
                else
                    break;
            }
            for (int i = 1; i < w - point.X; i++)
            {
                if (point.X + i >= w || point.Y - i < 0)
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
        PvPLocal,
        PvC
    }
}
