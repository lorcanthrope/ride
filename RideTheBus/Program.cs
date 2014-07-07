using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using BusClasses;

namespace RideTheBus
{
    class Program
    {
        static void Main(string[] args)
        {
            List<RoundResults> results = new List<RoundResults>();
            int numberOfRoundsToSample = 100000;


            if(args.Length == 1)
            {
                int.TryParse(args[0], out numberOfRoundsToSample);
            }

            for(int i = 0; i < numberOfRoundsToSample; i++)
            {
                results.Add(DrawRound());
            }

            Console.WriteLine("# of rounds sampled: {0}", numberOfRoundsToSample);

            int maximumNumberOfDrinksTaken = results.Select(a => a.DrinksTakenInRound.Any() ? a.DrinksTakenInRound.Max() : 0).Max();
            Console.WriteLine("Maximum # of drinks taken: {0}", maximumNumberOfDrinksTaken);
            int maximumNumberOfGamesPlayed = results.Select(a => a.GamesTakenToFinish.Any() ? a.GamesTakenToFinish.Max() : 0).Max();
            Console.WriteLine("Maximum # of games played: {0}", maximumNumberOfGamesPlayed);

            int minimumNumberOfGamesPlayed = results.Select(a => a.GamesTakenToFinish.Any() ?  a.GamesTakenToFinish.Min() : 1).Min();
            Console.WriteLine("Minimum # of games played: {0}", minimumNumberOfGamesPlayed);
            
            double averageNumberOfGamesPlayed = results.SelectMany(a => a.GamesTakenToFinish).Average();
            Console.WriteLine("Average # of games played: {0:F4}", averageNumberOfGamesPlayed);

            double averageNumberOfDrinksTaken = results.SelectMany(a => a.DrinksTakenInRound).Average();
            Console.WriteLine("Average # of drinks taken: {0:F4}", averageNumberOfDrinksTaken);

            Console.Read();
        }

        static RoundResults DrawRound()
        {
            RoundResults results = new RoundResults();

            Round round = new Round();

            int i = 0;

            int roundsTaken = 1;

            int drinksTaken = 0;

            while (!round.RoundFinished)
            {
                TakeRoundResult takeRoundResult = round.TakeRound();
                results.Games[i++] = takeRoundResult;
                if(takeRoundResult.Finished)
                {
                    results.DrinksTakenInRound.Add(drinksTaken);
                    results.GamesTakenToFinish.Add(roundsTaken);
                    roundsTaken = 1;
                    drinksTaken = 0;
                }
                else
                {
                    roundsTaken++;
                    drinksTaken += takeRoundResult.Choices.Count;
                }
            }

            if(drinksTaken > 0)
            {
                results.DrinksTakenInRound.Add(drinksTaken);
            }

            return results;
        }

        static void PrintTakeRoundResult(TakeRoundResult  takeRoundResult)
        {
            Console.WriteLine("----------------------------");
            foreach (KeyValuePair<int, Choice> choice in takeRoundResult.Choices)
            {
                Console.WriteLine("# {0} => {1} => {2}", choice.Key, choice.Value.Route.ToString(), choice.Value.Card.ToShortString());
            }
            Console.WriteLine("Finished => {0}", takeRoundResult.Finished);
            Console.WriteLine("----------------------------");
        }

        static void PrintRound(Round round)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("1.          " + round.First.Contents[RouteValue.Centre].ToShortString());
            Console.WriteLine();
            Console.WriteLine("2.      " + round.Second.Contents[RouteValue.Left].ToShortString() + "       " + round.Second.Contents[RouteValue.Right].ToShortString());
            Console.WriteLine();
            Console.WriteLine("3. " + round.Third.Contents[RouteValue.Left].ToShortString() + "        " + round.Third.Contents[RouteValue.Centre].ToShortString() + "         " + round.Third.Contents[RouteValue.Right].ToShortString());
            Console.WriteLine();
            Console.WriteLine("4.      " + round.Fourth.Contents[RouteValue.Left].ToShortString() + "       " + round.Fourth.Contents[RouteValue.Right].ToShortString());
            Console.WriteLine();
            Console.WriteLine("5.          " + round.Fifth.Contents[RouteValue.Centre].ToShortString());
            Console.WriteLine();
            Console.WriteLine("----------------------------");
        }
    }
}
