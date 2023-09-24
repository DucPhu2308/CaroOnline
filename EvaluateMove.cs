using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroLAN.AIHelper
{
    internal class EvaluateMove
    {
        public Point? Point;
        public double Score;
        static Bitmap imgX = Form1.imgX;
        static Bitmap imgO = Form1.imgO;
        public EvaluateMove()
        {
        }
        static int[] defenseScale = { 0, 9, 54, 162, 1296, 10368, 118008 };
        static int[] attackScale = { 0, 3, 27, 99, 792, 6561, 59049 };
        public static int NewGetScore(Button[,] matrixButton, int currRow, int currCol, bool isXturn)
        {
            return Math.Max(GetAttackScore(matrixButton, currRow, currCol, isXturn), GetDefenseScore(matrixButton, currRow, currCol, isXturn));
        }
        private static int GetAttackScore(Button[,] matrixButton, int currRow, int currCol, bool isXturn)
        {
            
            return GetAttackScoreHorizontal(matrixButton, currRow, currCol, isXturn) +
                   GetAttackScoreVertical(matrixButton, currRow, currCol, isXturn) +
                   GetAttackScoreDiagonal_Main(matrixButton, currRow, currCol, isXturn) +
                   GetAttackScoreDiagonal_Secondary(matrixButton, currRow, currCol, isXturn);
        }

        private static int GetAttackScoreDiagonal_Secondary(Button[,] matrixButton, int currRow, int currCol, bool isXturn)
        {
            Bitmap img = isXturn ? imgX : imgO;
            Bitmap imgEnemy = isXturn ? imgO : imgX;
            int score = 0;
            int count = 0;
            int block = 0;
            // to top-right
            for (int i = 0; i <= 5; i++)
            {
                if (currRow - i < 0 ||  currCol + i >= matrixButton.GetLength(1))
                {
                    continue;
                }
                if (matrixButton[currRow - i, currCol + i].BackgroundImage == img)
                {
                    count++;
                }
                else if (matrixButton[currRow - i, currCol + i].BackgroundImage == imgEnemy)
                {
                    block++;
                    break;
                }
                else
                {
                    break;
                }
            }
            // to bottom-left
            for (int i = 1; i <= 5; i++)
            {
                if (currRow + i >= matrixButton.GetLength(0) || currCol - i < 0)
                {
                    continue;
                }
                if (matrixButton[currRow + i, currCol - i].BackgroundImage == img)
                {
                    count++;
                }
                else if (matrixButton[currRow + i, currCol - i].BackgroundImage == imgEnemy)
                {
                    block++;
                    break;
                }
                else
                {
                    break;
                }
            }
            if (block ==2)
                return 0;
            score += attackScale[count];
            score -= defenseScale[block+2];
            return score;
        }

        private static int GetAttackScoreDiagonal_Main(Button[,] matrixButton, int currRow, int currCol, bool isXturn)
        {
            Bitmap img = isXturn ? imgX : imgO;
            Bitmap imgEnemy = isXturn ? imgO : imgX;
            int score = 0;
            int count = 0;
            int block = 0;
            // to top-left
            for (int i = 0; i <= 5; i++)
            {
                if (currRow - i < 0 || currCol - i < 0)
                {
                    continue;
                }
                if (matrixButton[currRow - i, currCol - i].BackgroundImage == img)
                {
                    count++;
                }
                else if (matrixButton[currRow - i, currCol - i].BackgroundImage == imgEnemy)
                {
                    block++;
                    break;
                }
                else
                {
                    break;
                }
            }
            // to bottom-right
            for (int i = 1; i <= 5; i++)
            {
                if (currRow + i >= matrixButton.GetLength(0) || currCol + i >= matrixButton.GetLength(1))
                {
                    continue;
                }
                if (matrixButton[currRow + i, currCol + i].BackgroundImage == img)
                {
                    count++;
                }
                else if (matrixButton[currRow + i, currCol + i].BackgroundImage == imgEnemy)
                {
                    block++;
                    break;
                }
                else
                {
                    break;
                }
            }
            if (block == 2)
                return 0;
            score += attackScale[count];
            score -= defenseScale[block+2];
            return score;
        }

        private static int GetAttackScoreVertical(Button[,] matrixButton, int currRow, int currCol, bool isXturn)
        {
            Bitmap img = isXturn ? imgX : imgO;
            Bitmap imgEnemy = isXturn ? imgO : imgX;
            int score = 0;
            int count = 0;
            int block = 0;
            // to bottom
            for (int i = currRow; i <= currRow + 5; i++)
            {
                if (i < 0 || i >= matrixButton.GetLength(0))
                {
                    continue;
                }
                if (matrixButton[i, currCol].BackgroundImage == img)
                {
                    count++;
                }
                else if (matrixButton[i, currCol].BackgroundImage == imgEnemy)
                {
                    block++;
                    break;
                }
                else
                {
                    break;
                }
            }
            // to top
            for (int i = currRow - 1; i >= currRow - 5; i--)
            {
                if (i < 0 || i >= matrixButton.GetLength(0))
                {
                    continue;
                }
                if (matrixButton[i, currCol].BackgroundImage == img)
                {
                    count++;
                }
                else if (matrixButton[i, currCol].BackgroundImage == imgEnemy)
                {
                    block++;
                    break;
                }
                else
                {
                    break;
                }
            }
            if (block == 2)
                return 0;
            score += attackScale[count];
            score -= defenseScale[block+2];
            return score;
        }

        private static int GetAttackScoreHorizontal(Button[,] matrixButton, int currRow, int currCol, bool isXturn)
        {
            Bitmap img = isXturn ? imgX : imgO;
            Bitmap imgEnemy = isXturn ? imgO : imgX;
            int score = 0;
            int count = 0;
            int block = 0;
            // to right
            for (int i = currCol; i <= currCol + 5; i++)
            {
                if (i < 0 || i >= matrixButton.GetLength(1))
                {
                    continue;
                }
                if (matrixButton[currRow, i].BackgroundImage == img)
                {
                    count++;
                }
                else if (matrixButton[currRow, i].BackgroundImage == imgEnemy)
                {
                    block++;
                    break;
                }
                else
                {
                    break;
                }
            }
            // to left
            for (int i = currCol - 1; i >= currCol - 5; i--)
            {
                if (i < 0 || i >= matrixButton.GetLength(1))
                {
                    continue;
                }
                if (matrixButton[currRow, i].BackgroundImage == img)
                {
                    count++;
                }
                else if (matrixButton[currRow, i].BackgroundImage == imgEnemy)
                {
                    block++;
                    break;
                }
                else
                {
                    break;
                }
            }
            if (block == 2)
                return 0;
            score += attackScale[count];
            score -= defenseScale[block+2];
            return score;
        }

        private static int GetDefenseScore(Button[,] matrixButton, int currRow, int currCol, bool isXturn)
        {
            return GetDefenseScoreHorizontal(matrixButton, currRow, currCol, isXturn) +
                   GetDefenseScoreVertical(matrixButton, currRow, currCol, isXturn) +
                   GetDefenseScoreDiagonal_Main(matrixButton, currRow, currCol, isXturn) +
                   GetDefenseScoreDiagonal_Secondary(matrixButton, currRow, currCol, isXturn);
        }

        private static int GetDefenseScoreDiagonal_Secondary(Button[,] matrixButton, int currRow, int currCol, bool isXturn)
        {
            Bitmap img = isXturn ? imgX : imgO;
            Bitmap imgEnemy = isXturn ? imgO : imgX;
            int score = 0;
            int count = 0;
            int block = 0;
            // to top-right
            for (int i = 1; i <= 5; i++)
            {
                if (currRow - i < 0 || currCol + i >= matrixButton.GetLength(1))
                {
                    block++;
                    break;
                }
                if (matrixButton[currRow - i, currCol + i].BackgroundImage == imgEnemy)
                {
                    count++;
                }
                else if (matrixButton[currRow - i, currCol + i].BackgroundImage == img)
                {
                    block++;
                    break;
                }
                else
                {
                    break;
                }

            }
            score += defenseScale[count];
            count = 0;
            block = 0;

            // to bottom-left
            for (int i = 1; i <= 5; i++)
            {
                if (currRow + i >= matrixButton.GetLength(0) || currCol - i < 0)
                {
                    block++;
                    break;
                }
                if (matrixButton[currRow + i, currCol - i].BackgroundImage == imgEnemy)
                {
                    count++;
                }
                else if (matrixButton[currRow + i, currCol - i].BackgroundImage == img)
                {
                    block++;
                    break;
                }
                else
                {
                    break;
                }
            }
            score += defenseScale[count];
            return score;
        }

        private static int GetDefenseScoreDiagonal_Main(Button[,] matrixButton, int currRow, int currCol, bool isXturn)
        {
            Bitmap img = isXturn ? imgX : imgO;
            Bitmap imgEnemy = isXturn ? imgO : imgX;
            int score = 0;
            int count = 0;
            int block = 0;
            // to top-left
            for (int i = 1; i <= 5; i++)
            {
                if (currRow - i < 0 || currCol - i < 0)
                {
                    block++;
                    break;
                }
                if (matrixButton[currRow - i, currCol - i].BackgroundImage == imgEnemy)
                {
                    count++;
                }
                else if (matrixButton[currRow - i, currCol - i].BackgroundImage == img)
                {
                    block++;
                    break;
                }
                else
                {
                    break;
                }
            }
            score += defenseScale[count];
            count = 0;
            block = 0;

            // to bottom-right
            for (int i = 1; i <= 5; i++)
            {
                if (currRow + i >= matrixButton.GetLength(0) || currCol + i >= matrixButton.GetLength(1))
                {
                    block++;
                    break;
                }
                if (matrixButton[currRow + i, currCol + i].BackgroundImage == imgEnemy)
                {
                    count++;
                }
                else if (matrixButton[currRow + i, currCol + i].BackgroundImage == img)
                {
                    block++;
                    break;
                }
                else
                {
                    break;
                }
            }
            score += defenseScale[count];
            return score;
        }

        private static int GetDefenseScoreVertical(Button[,] matrixButton, int currRow, int currCol, bool isXturn)
        {
            Bitmap img = isXturn ? imgX : imgO;
            Bitmap imgEnemy = isXturn ? imgO : imgX;
            int score = 0;
            int count = 0;
            int block = 0;
            // to bottom
            for (int i = currRow + 1; i <= currRow + 5; i++)
            {
                if (i < 0 || i >= matrixButton.GetLength(0))
                {
                    block++;
                    break;
                }
                if (matrixButton[i, currCol].BackgroundImage == imgEnemy)
                {
                    count++;
                }
                else if (matrixButton[i, currCol].BackgroundImage == img)
                {
                    block++;
                    break;
                }
                else
                {
                    break;
                }
            }
            score += defenseScale[count];
            count = 0;
            block = 0;

            // to top
            for (int i = currRow - 1; i >= currRow - 5; i--)
            {
                if (i < 0 || i >= matrixButton.GetLength(0))
                {
                    block++;
                    break;
                }
                if (matrixButton[i, currCol].BackgroundImage == imgEnemy)
                {
                    count++;
                }
                else if (matrixButton[i, currCol].BackgroundImage == img)
                {
                    block++;
                    break;
                }
                else
                {
                    break;
                }
            }
            score += defenseScale[count];
            return score;
        }

        private static int GetDefenseScoreHorizontal(Button[,] matrixButton, int currRow, int currCol, bool isXturn)
        {
            Bitmap img = isXturn ? imgX : imgO;
            Bitmap imgEnemy = isXturn ? imgO : imgX;
            int score = 0;
            int count = 0;
            int block = 0;
            // to right
            for (int i = currCol + 1; i <= currCol + 5; i++)
            {
                if (i < 0 || i >= matrixButton.GetLength(1))
                {
                    block++;
                    break;
                }
                if (matrixButton[currRow, i].BackgroundImage == imgEnemy)
                {
                    count++;
                }
                else if (matrixButton[currRow, i].BackgroundImage == img)
                {
                    block++;
                    break;
                }
                else
                {
                    break;
                }
            }
            score += defenseScale[count];
            count = 0;
            block = 0;

            // to left
            for (int i = currCol - 1; i >= currCol - 5; i--)
            {
                if (i < 0 || i >= matrixButton.GetLength(1))
                {
                    block++;
                    break;
                }
                if (matrixButton[currRow, i].BackgroundImage == imgEnemy)
                {
                    count++;
                }
                else if (matrixButton[currRow, i].BackgroundImage == img)
                {
                    block++;
                    break;
                }
                else
                {
                    break;
                }
            }
            score += defenseScale[count];
            return score;
        }
    }
}
