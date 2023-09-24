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
        public FormPvC(bool playerFirst) : base()
        {
            botIsX = !playerFirst;
            botImg = botIsX ? imgX : imgO;
        }
        protected override void Form1_Load(object sender, EventArgs e)
        {
            base.Form1_Load(sender, e);
            player2.Name = "Computer";
            player2.UpdateName();
            if (botIsX)
            {
                base.changeFirstPlayerToolStripMenuItem_Click(null, null);
                // bot goes in middle
                BotFirstMove();
            }
        }
        protected override void changeFirstPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.changeFirstPlayerToolStripMenuItem_Click(sender, e);
            botIsX = !botIsX;
            botImg = botIsX ? imgX : imgO;
            if (botIsX)
            {
                BotFirstMove();
            }
        }
        protected override void ResetGame()
        {
            base.ResetGame();
            if (botIsX)
            {
                BotFirstMove();
            }
        }
        #region AI
        private int maxRow = 0;
        private int minRow = int.MaxValue;
        private int maxCol = 0;
        private int minCol = int.MaxValue;
        private void BotFirstMove()
        {
              // bot goes in middle
            int x = matrixButton.GetLength(1) / 2 - 1;
            int y = matrixButton.GetLength(0) / 2 - 1;
            matrixButton[y, x].PerformClick();
        }
        protected override void MatrixButton_Click(object sender, EventArgs e)
        {
            base.MatrixButton_Click(sender, e);
            Point point = GetPoint((Button)sender);
            UpdateMinMaxColRow(point);

            this.Refresh();
            if (isXturn == botIsX)
            {
                Button btn = CalculateNexMove();
                btn.PerformClick();
            }
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
        Button CalculateNexMove()
        {
            int h = matrixButton.GetLength(0);
            int w = matrixButton.GetLength(1);
            int bestScore = int.MinValue;
            Button bestMove = null;
            List<Button> allPossibleMoves = GetAllPossibleMoves(matrixButton);
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
                    int val = EvaluateMove.NewGetScore(matrixButton, point.Y, point.X, botIsX);
                    btn.BackgroundImage = null;

                    if (val > bestScore)
                    {
                        bestScore = val;
                        bestMove = btn;
                    }
                }
            }
            return bestMove;
        }
        List<Button> GetAllPossibleMoves(Button[,] matrixButton)
        {
            List<Button> list = new List<Button>();
            int h = matrixButton.GetLength(0);
            int w = matrixButton.GetLength(1);
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w ; j++)
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
