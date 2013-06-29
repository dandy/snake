
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Scoreboard
    {
        public int CurrentScore { get; set; }

        public void Score()
        {
            CurrentScore = 0;
        }

        public void AddScore()
        {
            CurrentScore = CurrentScore + 10;
        }

    }
}
