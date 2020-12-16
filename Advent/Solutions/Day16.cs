using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent.Solutions
{
    public class Day16 : AdventDay
    {
        public Day16() : base(16)
        {
        }

        public override string SolvePartOne()
        {
            var input = Input.Split("\n\n", System.StringSplitOptions.RemoveEmptyEntries);
            var rules = input[0].Split('\n').Select(i => i.Split(": ")[1].Split(" or ")).Select(i =>
              {
                  return (Func<int, bool>)delegate (int value)
                  {
                      var range1 = i[0].Split('-').Select(int.Parse).ToArray();
                      var range2 = i[1].Split('-').Select(int.Parse).ToArray();
                      return (value >= range1[0] && value <= range1[1]) || (value >= range2[0] && value <= range2[1]);
                  };
              }).ToArray();
            var nearbyTickets = input[2].Split('\n', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            var sum = 0;
            foreach (var ticket in nearbyTickets)
            {
                var values = ticket.Split(',').Select(int.Parse);
                sum += values.Where(i => !rules.Any(j => j(i))).Sum();
            }
            return sum.ToString();
        }

        public override string SolvePartTwo()
        {
            var input = Input.Split("\n\n", System.StringSplitOptions.RemoveEmptyEntries);
            //create dictionary that contains rule name and a delegate that checks for it
            var rules = input[0].Split('\n').Select(i => (i.Split(":")[0], i.Split(": ")[1].Split(" or "))).Select(i =>
             {
                 return (i.Item1, (Func<int, bool>)delegate (int value)
                 {
                     var range1 = i.Item2[0].Split('-').Select(int.Parse).ToArray();
                     var range2 = i.Item2[1].Split('-').Select(int.Parse).ToArray();
                     return (value >= range1[0] && value <= range1[1]) || (value >= range2[0] && value <= range2[1]);
                 }
                 );
             }).ToDictionary(i => i.Item1, i => i.Item2);

            var nearbyTickets = input[2].Split('\n', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();

            //get only tickets where each value has at least one valid rule
            var validTickets = nearbyTickets.Select(i => i.Split(',')
                                                          .Select(int.Parse)
                                                          .ToArray()).Where(i => i.All(j => rules.Values.Any(rule => rule(j)))).ToArray();

            //an array that contains list of possible rules and the original index in the ticket
            var possibleSolutions = new (List<string>, int)[validTickets[0].Length];
            //for each index check which rules could be possible
            for (int i = 0; i < validTickets[0].Length; i++)
            {
                var possibleRules = rules.Where(rule => validTickets.All(ticket => rule.Value(ticket[i])))
                                         .Select(i => i.Key)
                                         .ToList();
                possibleSolutions[i] = (possibleRules, i);
            }

            //order it by amount of possible rules and then from all indexes remove extra rules that are a sole rule on another index
            var ordered = possibleSolutions.OrderBy(i => i.Item1.Count).ToList();
            for (int i = 0; i < ordered.Count - 1; i++)
            {
                var val = ordered[i].Item1.First();
                foreach (var possible in ordered.Skip(i + 1))
                {
                    possible.Item1.Remove(val);
                }
            }

            //order it back by original index so it can be used easily by my ticket
            ordered = ordered.OrderBy(i => i.Item2).ToList();
            var myTicket = input[1].Split('\n')[1]
                                   .Split(',')
                                   .Select(long.Parse)
                                   .Where((i, j) => ordered[j].Item1.First().StartsWith("departure"))
                                   .Aggregate((i, j) => i * j);

            return myTicket.ToString();
        }
    }
}