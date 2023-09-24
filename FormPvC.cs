using CaroLAN.AIHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroLAN
{
    internal class FormPvC : Form1
    {
        Bitmap botImg = imgO;
        bool botIsX = false;
        public FormPvC() : base()
        {
            //player2.Name = "Computer";
        }

        #region AI
        private int maxRow = 0;
        private int minRow = int.MaxValue;
        private int maxCol = 0;
        private int minCol = int.MaxValue;
        protected override void MatrixButton_Click(object sender, EventArgs e)
        {
            base.MatrixButton_Click(sender, e);
            Point point = GetPoint((Button)sender);
            UpdateMinMaxColRow(point);

            this.Refresh();
            if (isXturn == botIsX)
            {
                //Point point = CalculateNextMove(2);
                //matrixButton[point.Y, point.X].PerformClick();
                Button btn = CalculateNexMove(2);
                btn.PerformClick();
            }
            //Console.WriteLine(EvaluatedMove.GetScore(matrixButton, !isXturn, !isXturn));
        }

        private void UpdateMinMaxColRow(Point point)
        {
            int offset = 1;
            if (point.X < minCol)
                minCol = point.X;
            minCol = (minCol - offset < 0 ? 0 : minCol - offset);

            if (point.X > maxCol)
                maxCol = point.X;
            maxCol = (maxCol + offset > matrixButton.GetLength(1) - 1 ? matrixButton.GetLength(1) - 1 : maxCol + offset);

            if (point.Y < minRow)
                minRow = point.Y;
            minRow = (minRow - offset < 0 ? 0 : minRow - offset);

            if (point.Y > maxRow)
                maxRow = point.Y;
            maxRow = (maxRow + offset > matrixButton.GetLength(0) - 1 ? matrixButton.GetLength(0) - 1 : maxRow + offset);
        }

        private const int WIN_SCORE = 100_000_000;
        
        Button CalculateNexMove(int depth)
        {
            int h = matrixButton.GetLength(0);
            int w = matrixButton.GetLength(1);
            int bestScore = int.MinValue;
            Button bestMove = null;
            List<Button> allPossibleMoves = GetAllPossibleMoves(matrixButton, minCol, maxCol, minRow, maxRow);
            if (allPossibleMoves.Count == 0)
            {
                return null;
            }
            foreach (Button btn in allPossibleMoves)
            {
                if (btn.BackgroundImage == null)
                {
                    Point point = GetPoint(btn);
                    btn.BackgroundImage = botImg;
                    int val = MinimaxAB(matrixButton, depth, false, point.Y, point.X, int.MinValue, int.MaxValue, minCol, maxCol, minRow, maxRow);
                    //int val = EvaluatedMove.NewGetScore(matrixButton, point.Y, point.X, botIsX);
                    btn.BackgroundImage = null;

                    if (val > bestScore)
                    {
                        bestScore = val;
                        bestMove = btn;
                    }
                }
            }
            Console.WriteLine(bestScore);
            return bestMove;
        }
        
        int MinimaxAB(Button[,] matrixButton, int depth, bool isMaximizing, int row, int col, int alpha, int beta, int minCol, int maxCol, int minRow, int maxRow)
        {
            if (depth == 0)
            {
                //double botScore = EvaluatedMove.GetScore(matrixButton, botIsX, isMaximizing);
                //double playerScore = EvaluatedMove.GetScore(matrixButton, !botIsX, isMaximizing);
                //Console.WriteLine(botScore.ToString() + " " + playerScore.ToString());
                //return (int)botScore - (int)playerScore;
                return EvaluatedMove.NewGetScore(matrixButton, row, col, botIsX);
            }
            if (IsEndGame(matrixButton, new Point(col, row)))
            {
                return isMaximizing ? -WIN_SCORE : WIN_SCORE;
            }
            List<Button> allPossibleMoves = GetAllPossibleMoves(matrixButton, minCol, maxCol, minRow, maxRow);
            if (allPossibleMoves.Count == 0)
            {
                return 0;
            }
            int bestScore = 0;
            if (isMaximizing)
            {
                bestScore = int.MinValue;
                foreach (Button btn in allPossibleMoves)
                {
                    btn.BackgroundImage = botImg;
                    Point point = GetPoint(btn);
                    int val = MinimaxAB(matrixButton, depth - 1, false, point.Y, point.X, alpha, beta, minCol, maxCol, minRow, maxRow);
                    btn.BackgroundImage = null;

                    bestScore = Math.Max(bestScore, val);
                    alpha = Math.Max(alpha, bestScore);
                    if (beta <= alpha)
                    {
                        break;
                    }
                }
            }
            else
            {
                bestScore = int.MaxValue;
                foreach (Button btn in allPossibleMoves)
                {
                    btn.BackgroundImage = imgX;
                    Point point = GetPoint(btn);
                    int val = MinimaxAB(matrixButton, depth - 1, true, point.Y, point.X, alpha, beta, minCol, maxCol, minRow, maxRow);
                    btn.BackgroundImage = null;
                    bestScore = Math.Min(bestScore, val);
                    beta = Math.Min(beta, bestScore);
                    if (beta <= alpha)
                    {
                        break;
                    }
                }
            }
            return bestScore;
        }
        
        
        /*
        Point CalculateNextMove(int depth)
        {
            Point point = new Point();

            Point? bestMove = SearchForInstantWin(matrixButton);
            if (bestMove != null)
            {
                point = (Point)bestMove;
                return point;
            }
            EvaluatedMove temp = MinimaxAB(matrixButton, depth, true, int.MinValue, int.MaxValue, minCol, maxCol, minRow, maxRow);
            bestMove = temp.Point;
            Console.WriteLine(temp.Score);
            point = (Point)bestMove;
            //Console.WriteLine(point.X.ToString() + " " + point.Y.ToString());
            return point;
        }
        //private EvaluatedMove MinimaxAB(Button[,] matrixButton, int depth, bool isMaximizing, double alpha, double beta)
        //{
        //    if (depth == 0)
        //    {
        //        return EvaluatedMove.Evaluate(matrixButton, isMaximizing == botIsX, isXturn);
        //        //return new EvaluatedMove(null, EvaluatedMove.GetScore(matrixButton, isMaximizing == botIsX, isXturn));
        //    }

        //    List<Button> allPossibleMoves = GetAllPossibleMoves(matrixButton);
        //    if (allPossibleMoves.Count == 0)
        //    {
        //        return new EvaluatedMove(null, 0);
        //    }
        //    EvaluatedMove bestMove = new EvaluatedMove();
        //    if (isMaximizing)
        //    {
        //        bestMove.Score = int.MinValue;
        //        foreach (Button btn in allPossibleMoves)
        //        {
        //            btn.SuspendLayout();
        //            btn.BackgroundImage = botImg;
        //            isXturn = !isXturn;
        //            Point point = GetPoint(btn);
        //            if (IsEndGame(matrixButton, point))
        //            {
        //                btn.BackgroundImage = null;
        //                isXturn = !isXturn;
        //                btn.ResumeLayout();
        //                return new EvaluatedMove(point, WIN_SCORE);
        //            }
        //            else
        //            {
        //                EvaluatedMove move = MinimaxAB(matrixButton, depth - 1, false, alpha, beta);
        //                if (move.Score > bestMove.Score)
        //                {
        //                    bestMove.Score = move.Score;
        //                    bestMove.Point = point;
        //                }
        //                btn.BackgroundImage = null;
        //                isXturn = !isXturn;
        //                btn.ResumeLayout();
        //                if (bestMove.Score >= beta)
        //                {
        //                    return bestMove;
        //                }
        //                alpha = Math.Max(alpha, bestMove.Score);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        bestMove.Score = int.MaxValue;
        //        foreach (Button btn in allPossibleMoves)
        //        {
        //            btn.SuspendLayout();
        //            btn.BackgroundImage = imgX;
        //            isXturn = !isXturn;
        //            Point point = GetPoint(btn);
        //            if (IsEndGame(matrixButton, point))
        //            {
        //                btn.BackgroundImage = null;
        //                isXturn = !isXturn;
        //                btn.ResumeLayout();
        //                return new EvaluatedMove(point, -WIN_SCORE);
        //            }
        //            else
        //            {
        //                EvaluatedMove move = MinimaxAB(matrixButton, depth - 1, true, alpha, beta);
        //                if (move.Score < bestMove.Score)
        //                {
        //                    bestMove.Score = move.Score;
        //                    bestMove.Point = point;
        //                }
        //                btn.BackgroundImage = null;
        //                isXturn = !isXturn;
        //                btn.ResumeLayout();
        //                if (bestMove.Score <= alpha)
        //                {
        //                    return bestMove;
        //                }
        //                beta = Math.Min(beta, bestMove.Score);
        //            }
        //        }
        //    }   
        //    return bestMove;
        //}
        private EvaluatedMove MinimaxAB(Button[,] matrixButton, int depth, bool isMaximizing, double alpha, double beta, int minCol, int maxCol, int minRow, int maxRow)
        {
            if (depth == 0)
            {
                //return EvaluatedMove.Evaluate(matrixButton, isMaximizing == botIsX, isXturn);
                return new EvaluatedMove(null, EvaluatedMove.GetScore(matrixButton, isMaximizing == botIsX, isXturn));
            }
            if (IsEndGame(matrixButton, new Point()))
            {
                return new EvaluatedMove(null, isMaximizing ? -WIN_SCORE : WIN_SCORE);
            }
            List<Button> allPossibleMoves = GetAllPossibleMoves(matrixButton, minCol, maxCol, minRow, maxRow);
            if (allPossibleMoves.Count == 0)
            {
                return new EvaluatedMove(null, 0);
            }
            EvaluatedMove bestMove = new EvaluatedMove();
            if (isMaximizing)
            {
                bestMove.Score = int.MinValue;
                foreach (Button btn in allPossibleMoves)
                {
                    Point point = GetPoint(btn);
                    btn.BackgroundImage = botImg;
                    EvaluatedMove move = MinimaxAB(matrixButton, depth - 1, false, alpha, beta, minCol, maxCol, minRow, maxRow);
                    btn.BackgroundImage = null;
                    if (move.Score > bestMove.Score)
                    {
                        bestMove.Score = move.Score;
                        bestMove.Point = point;
                    }
                    if (bestMove.Score >= beta)
                    {
                        return bestMove;
                    }
                    alpha = Math.Max(alpha, bestMove.Score);
                }
            }
            else
            {
                bestMove.Score = int.MaxValue;
                foreach (Button btn in allPossibleMoves)
                {
                    Point point = GetPoint(btn);
                    btn.BackgroundImage = imgX;
                    EvaluatedMove move = MinimaxAB(matrixButton, depth - 1, true, alpha, beta, minCol, maxCol, minRow, maxRow);
                    btn.BackgroundImage = null;
                    if (move.Score < bestMove.Score)
                    {
                        bestMove.Score = move.Score;
                        bestMove.Point = point;
                    }
                    if (bestMove.Score <= alpha)
                    {
                        return bestMove;
                    }
                    beta = Math.Min(beta, bestMove.Score);
                }
            }
            return bestMove;
        }
        //private Point? SearchForInstantWin(Button[,] matrixButton)
        //{
        //    List<Button> allPossibleMoves = GetAllPossibleMoves(matrixButton);
        //    foreach (Button btn in allPossibleMoves)
        //    {
        //        btn.SuspendLayout();
        //        btn.BackgroundImage = botImg;
        //        Point point = GetPoint(btn);
        //        if (IsEndGame(matrixButton, point))
        //        {
        //            btn.BackgroundImage = null;
        //            btn.ResumeLayout();
        //            return point;
        //        }
        //        else
        //        {
        //            btn.BackgroundImage = null;
        //            btn.ResumeLayout();
        //        }
        //    }
        //    return null;
        //}
        */
        List<Button> GetAllPossibleMoves(Button[,] matrixButton, int minCol, int maxCol, int minRow, int maxRow)
        {
            List<Button> list = new List<Button>();
            for (int i = minRow; i <= maxRow; i++)
            {
                for (int j = minCol; j <= maxCol ; j++)
                {
                    if (matrixButton[i, j].BackgroundImage == null)
                    {
                        list.Add(matrixButton[i, j]);
                    }
                }
            }
            return list;
        }
        #endregion
    }
}
