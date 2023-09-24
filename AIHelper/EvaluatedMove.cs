using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroLAN.AIHelper
{
    internal class EvaluatedMove
    {
        public Point? Point;
        public double Score;
        static Bitmap imgX = Form1.imgX;
        static Bitmap imgO = Form1.imgO;
        private const int WIN_SCORE = 100_000_000;
        public EvaluatedMove()
        {
        }
        static int[] attackScale = { 0, 9, 54, 162, 1296, 10368, 118008 };
        static int[] defenseScale = { 0, 3, 27, 99, 792, 6561, 59049 };
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

        public EvaluatedMove(Point? point, double score)
        {
            this.Point = point;
            this.Score = score;
        }
        public static EvaluatedMove Evaluate(Button[,] matrixButton, bool forX, bool isXturn)
        {
            // Get board score of both players.
            double oScore = GetScore(matrixButton, false, isXturn);
            double xScore = GetScore(matrixButton, true, isXturn);

            if (oScore == 0) oScore = 1.0;
            if (xScore == 0) xScore = 1.0;

            if (forX)
            {
                return new EvaluatedMove(null, xScore / oScore);
            }
            else
            {
                return new EvaluatedMove(null, oScore / xScore);
            }
        }
        public static double GetScore(Button[,] matrixButton, bool forX, bool isXturn)
        {
            
            return EvaluateHorizontal(matrixButton, forX, isXturn) +
                   EvaluateVertical(matrixButton, forX, isXturn) +
                   EvaluateDiagonal(matrixButton, forX, isXturn);
        }

        private static int EvaluateDiagonal(Button[,] matrixButton, bool forX, bool isXturn)
        {
            Evaluation evaluations = new Evaluation(0, 2, 0);
            for (int k = 0; k <= 2 * (matrixButton.GetLength(0) - 1); k++)
            {
                int iStart = Math.Max(0, k - matrixButton.GetLength(0) + 1);
                int iEnd = Math.Min(matrixButton.GetLength(0) - 1, k);
                for (int i = iStart; i <= iEnd; ++i)
                {
                    EvaluateDirections(matrixButton, i, k - i, forX, isXturn, ref evaluations);
                }
                EvaluateDirectionsAfterOnePass(ref evaluations, forX, isXturn);
            }
            // From top-left to bottom-right diagonally
            for (int k = 1 - matrixButton.GetLength(0); k < matrixButton.GetLength(0); k++)
            {
                int iStart = Math.Max(0, k);
                int iEnd = Math.Min(matrixButton.GetLength(0) + k - 1, matrixButton.GetLength(0) - 1);
                for (int i = iStart; i <= iEnd; ++i)
                {
                    EvaluateDirections(matrixButton, i, i - k, forX, isXturn, ref evaluations);
                }
                EvaluateDirectionsAfterOnePass(ref evaluations, forX, isXturn);
            }
            return evaluations.Score;
        }

        private static int EvaluateVertical(Button[,] matrixButton, bool forX, bool isXturn)
        {
            Evaluation evaluations = new Evaluation(0, 2, 0);

            for (int j = 0; j < matrixButton.GetLength(1); j++)
            {
                for (int i = 0; i < matrixButton.GetLength(0); i++)
                {
                    EvaluateDirections(matrixButton, i, j, forX, isXturn, ref evaluations);
                }
                EvaluateDirectionsAfterOnePass(ref evaluations, forX, isXturn);

            }
            return evaluations.Score;
        }

        private static int EvaluateHorizontal(Button[,] matrixButton, bool forX, bool isXturn)
        {
            Evaluation evaluations = new Evaluation(0, 2, 0);
            for (int i = 0; i < matrixButton.GetLength(0); i++)
            {
                // Iterate over all cells in a row
                for (int j = 0; j < matrixButton.GetLength(1); j++)
                {
                    // Check if the selected player has a stone in the current cell
                    EvaluateDirections(matrixButton, i, j, forX, isXturn, ref evaluations);
                }
                EvaluateDirectionsAfterOnePass(ref evaluations, forX, isXturn);
            }

            return evaluations.Score;
        }

        private static void EvaluateDirectionsAfterOnePass(ref Evaluation eval, bool forX, bool isXturn)
        {
            // End of row, check if there were any consecutive stones before we reached right border
            if (eval.ConsecutiveCount > 0)
            {
                eval.Score += GetConsecutiveSetScore(eval.ConsecutiveCount, eval.BlockCount, forX == isXturn);
            }
            // Reset consecutive stone and blocks count
            eval.ConsecutiveCount = 0;
            eval.BlockCount = 2;
        }

        private static void EvaluateDirections(Button[,] matrixButton, int i, int j, bool forX, bool isXturn, ref Evaluation eval)
        {
            if (matrixButton[i, j].BackgroundImage == (isXturn ? imgX : imgO))
            {
                eval.ConsecutiveCount++;
            }
            // Check if cell is empty
            else if (matrixButton[i, j].BackgroundImage == null)
            {
                // Check if there were any consecutive stones before this empty cell
                if (eval.ConsecutiveCount > 0)
                {
                    // Consecutive set is not blocked by opponent, decrement block count
                    eval.BlockCount--;
                    // Get consecutive set score
                    eval.Score += GetConsecutiveSetScore(eval.ConsecutiveCount, eval.BlockCount, forX == isXturn);
                    // Reset consecutive stone count
                    eval.ConsecutiveCount = 0;
                    // Current cell is empty, next consecutive set will have at most 1 blocked side.
                }
                // No consecutive stones.
                // Current cell is empty, next consecutive set will have at most 1 blocked side.
                eval.BlockCount = 1;
            }
            // Cell is occupied by opponent
            // Check if there were any consecutive stones before this empty cell
            else if (eval.ConsecutiveCount > 0)
            {
                // Get consecutive set score
                eval.Score += GetConsecutiveSetScore(eval.ConsecutiveCount, eval.BlockCount, forX == isXturn);
                // Reset consecutive stone count
                eval.ConsecutiveCount = 0;
                // Current cell is occupied by opponent, next consecutive set may have 2 blocked sides
                eval.BlockCount = 2;
            }
            else
            {
                // Current cell is occupied by opponent, next consecutive set may have 2 blocked sides
                eval.BlockCount = 2;
            }
        }
        private static int GetConsecutiveSetScore(int count, int blocks, bool currentTurn)
        {
            const int winGuarantee = 1_000_000;
            // If both sides of a set is blocked, this set is worthless return 0 points.
            if (blocks == 2 && count < 5) return 0;

            switch (count)
            {
                case 5:
                    {
                        // 5 consecutive wins the game
                        return WIN_SCORE;
                    }
                case 4:
                    {
                        if (currentTurn)
                        {
                            return winGuarantee;
                        }
                        else
                        {
                            // Opponent's turn
                            // If neither side is blocked, 4 consecutive stones guarantees a win in the next turn.
                            if (blocks == 0) 
                                return winGuarantee / 4;
                            else return 400;
                        }
                    }
                case 3:
                    {
                        // 3 consecutive stones
                        if (blocks == 0)
                        {
                            
                            if (currentTurn) 
                                return 50_000;
                            else 
                                return 200;
                        }
                        else
                        {
                            // One of the sides is blocked.
                            // Playmaker scores
                            if (currentTurn) return 10;
                            else return 5;
                        }
                    }
                case 2:
                    {
                        // 2 consecutive stones
                        // Playmaker scores
                        if (blocks == 0)
                        {
                            if (currentTurn) return 7;
                            else return 5;
                        }
                        else
                        {
                            return 3;
                        }
                    }
                case 1:
                    {
                        return 1;
                    }
            }

            // More than 5 consecutive stones? 
            return WIN_SCORE * 2;
        }
    }
}
