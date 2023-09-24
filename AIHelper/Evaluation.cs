using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroLAN.AIHelper
{
    public class Evaluation
    {
        public int ConsecutiveCount { get; set; }
        public int BlockCount { get; set; }
        public int Score { get; set; }
        public Evaluation(int consecutiveCount, int blockedCount, int score)
        {
            ConsecutiveCount = consecutiveCount;
            BlockCount = blockedCount;
            Score = score;
        }
    }
}
