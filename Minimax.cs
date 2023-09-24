//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace CaroLAN
//{
//    internal class Minimax
//    {
//        public int[,] Board = null;
//        public Button[,] matrixButton = null;
//        bool isXturn = true;
//        private const int WIN_SCORE = 100_000_000;

//        // Constructor
//        public Minimax(Button[,] board, ref bool isXturn)
//        {
//            this.matrixButton = board;
//            this.isXturn = isXturn;
//            this.Board = new int[board.GetLength(0), board.GetLength(1)];
//        }

//        // This function is used to get the next intelligent move to make for the AI.
//        public Point? CalculateNextMove(int depth)
//        {
//            Point? move = new Point?();

//            // Check if any available move can finish the game to make sure the AI always
//            // takes the opportunity to finish the game.
//            Point? bestMove = SearchWinningMove(Board).point;

//            if (bestMove != null)
//            {
//                // Finishing move is found.
//                move = (Point)bestMove;

//            }
//            else
//            {
//                // If there is no such move, search the minimax tree with specified depth.

//                bestMove = minimaxSearchAB(depth, Board, true, -1.0, WIN_SCORE).point;
//                if (bestMove == null)
//                {
//                    return null;
//                }
//                else
//                {
//                    move = (Point)bestMove;
//                }
//            }

//            return move;
//        }

//        private Move SearchWinningMove(int[,] board)
//        {
//            throw new NotImplementedException();
//        }

//        public static void PlayPoint(int[,] Board, Point point, bool isXturn)
//        {
//            Board[point.Y, point.X] = isXturn ? 1 : 2;
//        }
//        /*
//         * alpha : Best AI Move (Max)
//         * beta : Best Player Move (Min)
//         * returns: {score, move[0], move[1]}
//         * */
//        private static Move minimaxSearchAB(int depth, int[,] dummyBoard, bool max, double alpha, double beta)
//        {

//            // Last depth (terminal node), evaluate the current board score.
//            if (depth == 0)
//            {
//                Move x = new Move(null, evaluateBoardForX(dummyBoard, !max));
//                return x;
//            }
//            List<Point> allPossibleMoves = GetAllPossibleMove(dummyBoard);

//            // If there is no possible move left, treat this node as a terminal node and return the score.
//            if (allPossibleMoves.Count == 0)
//            {
//                Move x = new Move(null, evaluateBoardForX(dummyBoard, !max));
//                return x;
//            }

//            Move bestMove = new Move();

//            // Generate Minimax Tree and calculate node scores.
//            if (max)
//            {
//                // Initialize the starting best move with -infinity.
//                bestMove.score = -1.0;
//                // Iterate for all possible moves that can be made.
//                foreach (Point move in allPossibleMoves)
//                {

//                    // Play the move on that temporary board without drawing anything

//                    dummyBoard[move.Y, move.X] = 2;

//                    // Call the minimax function for the next depth, to look for a minimum score.
//                    // This function recursively generates new Minimax trees branching from this node 
//                    // (if the depth > 0) and searches for the minimum white score in each of the sub trees.
//                    // We will find the maximum score of this depth, among the minimum scores found in the
//                    // lower depth.
//                    Object[] tempMove = minimaxSearchAB(depth - 1, dummyBoard, false, alpha, beta);

//                    // backtrack and remove
//                    dummyBoard.removeStoneNoGUI(move[1], move[0]);

//                    // Updating alpha (alpha value holds the maximum score)
//                    // When searching for the minimum, if the score of a node is lower than the alpha 
//                    // (max score of uncle nodes from one upper level) the whole subtree originating
//                    // from that node will be discarded, since the maximizing player will choose the 
//                    // alpha node over any node with a score lower than the alpha. 
//                    if ((Double)(tempMove[0]) > alpha)
//                    {
//                        alpha = (Double)(tempMove[0]);
//                    }
//                    // Pruning with beta
//                    // Beta value holds the minimum score among the uncle nodes from one upper level.
//                    // We need to find a score lower than this beta score, because any score higher than
//                    // beta will be eliminated by the minimizing player (upper level). If the score is
//                    // higher than (or equal to) beta, break out of loop discarding any remaining nodes 
//                    // and/or subtrees and return the last move.
//                    if ((Double)(tempMove[0]) >= beta)
//                    {
//                        return tempMove;
//                    }

//                    // Find the move with the maximum score.
//                    if ((Double)tempMove[0] > (Double)bestMove[0])
//                    {
//                        bestMove = tempMove;
//                        bestMove[1] = move[0];
//                        bestMove[2] = move[1];
//                    }
//                }
//            }
//            else
//            {
//                // Initialize the starting best move using the first move in the list and +infinity score.
//                bestMove[0] = 100_000_000.0;
//                bestMove[1] = allPossibleMoves.get(0)[0];
//                bestMove[2] = allPossibleMoves.get(0)[1];

//                // Iterate for all possible moves that can be made.
//                for (int[] move : allPossibleMoves)
//                {
//                    // Create a temporary board that is equivalent to the current board

//                    // Play the move on that temporary board without drawing anything
//                    dummyBoard.addStoneNoGUI(move[1], move[0], true);

//                    // Call the minimax function for the next depth, to look for a maximum score.
//                    // This function recursively generates new Minimax trees branching from this node 
//                    // (if the depth > 0) and searches for the maximum white score in each of the sub trees.
//                    // We will find the minimum score of this depth, among the maximum scores found in the
//                    // lower depth.
//                    Object[] tempMove = minimaxSearchAB(depth - 1, dummyBoard, true, alpha, beta);

//                    dummyBoard.removeStoneNoGUI(move[1], move[0]);

//                    // Updating beta (beta value holds the minimum score)
//                    // When searching for the maximum, if the score of a node is higher than the beta 
//                    // (min score of uncle nodes from one upper level) the whole subtree originating
//                    // from that node will be discarded, since the minimizing player will choose the 
//                    // beta node over any node with a score higher than the beta. 
//                    if (((Double)tempMove[0]) < beta)
//                    {
//                        beta = (Double)(tempMove[0]);
//                    }
//                    // Pruning with alpha
//                    // Alpha value holds the maximum score among the uncle nodes from one upper level.
//                    // We need to find a score higher than this alpha score, because any score lower than
//                    // alpha will be eliminated by the maximizing player (upper level). If the score is
//                    // lower than (or equal to) alpha, break out of loop discarding any remaining nodes 
//                    // and/or subtrees and return the last move.
//                    if ((Double)(tempMove[0]) <= alpha)
//                    {
//                        return tempMove;
//                    }

//                    // Find the move with the minimum score.
//                    if ((Double)tempMove[0] < (Double)bestMove[0])
//                    {
//                        bestMove = tempMove;
//                        bestMove[1] = move[0];
//                        bestMove[2] = move[1];
//                    }
//                }
//            }

//            // Return the best move found in this depth
//            return bestMove;
//        }

//        private static List<Point> GetAllPossibleMove(int[,] board)
//        {
//            List<Point> possibleMoves = new List<Point>();
//            for (int i = 0; i < board.GetLength(0); i++)
//            {
//                // Iterate over all cells in a row
//                for (int j = 0; j < board.GetLength(1); j++)
//                {
//                    // Check if the selected player has a stone in the current cell
//                    if (board[i, j] == 0)
//                    {
//                        possibleMoves.Add(new Point(i, j));
//                    }
//                }
//            }
//            return possibleMoves;
//        }

//        // This function calculates the relative score of the white player against the black.
//        // (i.e. how likely is white player to win the game before the black player)
//        // This value will be used as the score in the Minimax algorithm.
//        public static double evaluateBoardForX(int[,] board, bool oTurn)
//        {

//            // Get board score of both players.
//            double oScore = getScore(board, true, oTurn);
//            double xScore = getScore(board, false, oTurn);

//            if (oScore == 0) oScore = 1.0;

//            // Calculate relative score of white against black
//            return xScore / oScore;
//        }

//        private static double getScore(int[,] board, bool forO, bool oTurn)
//        {
//            // Calculate score for each of the 3 directions
//            return EvaluateHorizontal(board, forO, oTurn) +
//                    EvaluateVertical(board, forO, oTurn) +
//                    EvaluateDiagonal(board, forO, oTurn);
//        }

//        private static int EvaluateDiagonal(int[,] boardMatrix, bool forO, bool playersTurn)
//        {
//            Evaluation evaluations = new Evaluation(0, 2, 0);
//            for (int k = 0; k <= 2 * (boardMatrix.GetLength(0) - 1); k++)
//            {
//                int iStart = Math.Max(0, k - boardMatrix.GetLength(0) + 1);
//                int iEnd = Math.Min(boardMatrix.GetLength(0) - 1, k);
//                for (int i = iStart; i <= iEnd; ++i)
//                {
//                    EvaluateDirections(boardMatrix, i, k - i, forO, playersTurn, evaluations);
//                }
//                EvaluateDirectionsAfterOnePass(evaluations, forO, playersTurn);
//            }
//            // From top-left to bottom-right diagonally
//            for (int k = 1 - boardMatrix.GetLength(0); k < boardMatrix.GetLength(0); k++)
//            {
//                int iStart = Math.Max(0, k);
//                int iEnd = Math.Min(boardMatrix.GetLength(0) + k - 1, boardMatrix.GetLength(0) - 1);
//                for (int i = iStart; i <= iEnd; ++i)
//                {
//                    EvaluateDirections(boardMatrix, i, i - k, forO, playersTurn, evaluations);
//                }
//                EvaluateDirectionsAfterOnePass(evaluations, forO, playersTurn);
//            }
//            return evaluations.Score;
//        }

//        private static int EvaluateVertical(int[,] boardMatrix, bool forO, bool playersTurn)
//        {
//            Evaluation evaluations = new Evaluation(0, 2, 0);

//            for (int j = 0; j < boardMatrix.GetLength(1); j++)
//            {
//                for (int i = 0; i < boardMatrix.GetLength(0); i++)
//                {
//                    EvaluateDirections(boardMatrix, i, j, forO, playersTurn, evaluations);
//                }
//                EvaluateDirectionsAfterOnePass(evaluations, forO, playersTurn);

//            }
//            return evaluations.Score;
//        }

//        private static int EvaluateHorizontal(int[,] board, bool forO, bool playersTurn)
//        {
//            Evaluation evaluations = new Evaluation(0, 2, 0);
//            for (int i = 0; i < board.GetLength(0); i++)
//            {
//                // Iterate over all cells in a row
//                for (int j = 0; j < board.GetLength(1); j++)
//                {
//                    // Check if the selected player has a stone in the current cell
//                    EvaluateDirections(board, i, j, forO, playersTurn, evaluations);
//                }
//                EvaluateDirectionsAfterOnePass(evaluations, forO, playersTurn);
//            }

//            return evaluations.Score;
//        }

//        private static void EvaluateDirectionsAfterOnePass(Evaluation eval, bool isBot, bool playersTurn)
//        {
//            // End of row, check if there were any consecutive stones before we reached right border
//            if (eval.ConsecutiveCount > 0)
//            {
//                eval.Score += GetConsecutiveSetScore(eval.ConsecutiveCount, eval.BlockCount, isBot == playersTurn);
//            }
//            // Reset consecutive stone and blocks count
//            eval.ConsecutiveCount = 0;
//            eval.BlockCount = 2;
//        }

//        private static void EvaluateDirections(int[,] board, int i, int j, bool isBot, bool botsTurn, Evaluation eval)
//        {
//            // Check if the selected player has a stone in the current cell
//            if (board[i, j] == (isBot ? 2 : 1))
//            {
//                // Increment consecutive stones count
//                eval.ConsecutiveCount++;
//            }
//            // Check if cell is empty
//            else if (board[i, j] == 0)
//            {
//                // Check if there were any consecutive stones before this empty cell
//                if (eval.ConsecutiveCount > 0)
//                {
//                    // Consecutive set is not blocked by opponent, decrement block count
//                    eval.BlockCount--;
//                    // Get consecutive set score
//                    eval.Score += GetConsecutiveSetScore(eval.ConsecutiveCount, eval.BlockCount, isBot == botsTurn);
//                    // Reset consecutive stone count
//                    eval.ConsecutiveCount = 0;
//                    // Current cell is empty, next consecutive set will have at most 1 blocked side.
//                }
//                // No consecutive stones.
//                // Current cell is empty, next consecutive set will have at most 1 blocked side.
//                eval.BlockCount = 1;
//            }
//            // Cell is occupied by opponent
//            // Check if there were any consecutive stones before this empty cell
//            else if (eval.ConsecutiveCount > 0)
//            {
//                // Get consecutive set score
//                eval.Score += GetConsecutiveSetScore(eval.ConsecutiveCount, eval.BlockCount, isBot == botsTurn);
//                // Reset consecutive stone count
//                eval.ConsecutiveCount = 0;
//                // Current cell is occupied by opponent, next consecutive set may have 2 blocked sides
//                eval.BlockCount = 2;
//            }
//            else
//            {
//                // Current cell is occupied by opponent, next consecutive set may have 2 blocked sides
//                eval.BlockCount = 2;
//            }
//        }

//        private static int GetConsecutiveSetScore(int count, int blocks, bool currentTurn)
//        {
//            const int winGuarantee = 1000000;
//            // If both sides of a set is blocked, this set is worthless return 0 points.
//            if (blocks == 2 && count < 5) return 0;

//            switch (count)
//            {
//                case 5:
//                    {
//                        // 5 consecutive wins the game
//                        return WIN_SCORE;
//                    }
//                case 4:
//                    {
//                        // 4 consecutive stones in the user's turn guarantees a win.
//                        // (User can win the game by placing the 5th stone after the set)
//                        if (currentTurn) return winGuarantee;
//                        else
//                        {
//                            // Opponent's turn
//                            // If neither side is blocked, 4 consecutive stones guarantees a win in the next turn.
//                            if (blocks == 0) return winGuarantee / 4;
//                            // If only a single side is blocked, 4 consecutive stones limits the opponents move
//                            // (Opponent can only place a stone that will block the remaining side, otherwise the game is lost
//                            // in the next turn). So a relatively high score is given for this set.
//                            else return 200;
//                        }
//                    }
//                case 3:
//                    {
//                        // 3 consecutive stones
//                        if (blocks == 0)
//                        {
//                            // Neither side is blocked.
//                            // If it's the current player's turn, a win is guaranteed in the next 2 turns.
//                            // (User places another stone to make the set 4 consecutive, opponent can only block one side)
//                            // However the opponent may win the game in the next turn therefore this score is lower than win
//                            // guaranteed scores but still a very high score.
//                            if (currentTurn) return 50_000;
//                            // If it's the opponent's turn, this set forces opponent to block one of the sides of the set.
//                            // So a relatively high score is given for this set.
//                            else return 200;
//                        }
//                        else
//                        {
//                            // One of the sides is blocked.
//                            // Playmaker scores
//                            if (currentTurn) return 10;
//                            else return 5;
//                        }
//                    }
//                case 2:
//                    {
//                        // 2 consecutive stones
//                        // Playmaker scores
//                        if (blocks == 0)
//                        {
//                            if (currentTurn) return 7;
//                            else return 5;
//                        }
//                        else
//                        {
//                            return 3;
//                        }
//                    }
//                case 1:
//                    {
//                        return 1;
//                    }
//            }

//            // More than 5 consecutive stones? 
//            return WIN_SCORE * 2;
//        }
//    }
//    public class Move
//    {
//        public Point? point;
//        public double score;

//        public Move()
//        {
//        }

//        public Move(Point? point, double score)
//        {
//            this.point = point;
//            this.score = score;
//        }
//    }
//public class Evaluation
//{
//    public int ConsecutiveCount { get; set; }
//    public int BlockCount { get; set; }
//    public int Score { get; set; }
//    public Evaluation(int consecutiveCount, int blockedCount, int score)
//    {
//        ConsecutiveCount = consecutiveCount;
//        BlockCount = blockedCount;
//        Score = score;
//    }
//}
//}
