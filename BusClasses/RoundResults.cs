using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusClasses
{
    public class RoundResults
    {
        public Dictionary<int, TakeRoundResult> Games;
        public List<int> GamesTakenToFinish;
        public List<int> DrinksTakenInRound;

        public RoundResults()
        {
            DrinksTakenInRound = new List<int>();
            Games = new Dictionary<int, TakeRoundResult>();
            GamesTakenToFinish = new List<int>();
        }
    }
}
