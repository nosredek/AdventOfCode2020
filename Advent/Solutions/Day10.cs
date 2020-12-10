using System;
using System.Linq;

namespace Advent.Solutions
{
    public class Day10 : AdventDay
    {
        public Day10() : base(10)
        {
        }

        public override string SolvePartOne()
        {
            var adapters = Input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).Append(0).OrderBy(i => i).ToList();
            var sol = adapters.Zip(adapters.Skip(1)).Select(i => i.Second - i.First).GroupBy(i => i).ToDictionary(i => i.Key, i => i.Count());
            return ((sol[1]) * (sol[3] + 1)).ToString();
        }

        public override string SolvePartTwo()
        {
            var adapters = Input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).Append(0).OrderBy(i => i).ToList();
            var steps = new long[adapters.Count];
            steps[0] = 1;
            for (int i = 1; i < adapters.Count; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    if (i >= j && (adapters[i] - adapters[i - j]) <= 3)
                        steps[i] += steps[i - j];
                }
            }

            return steps[^1].ToString();
        }
    }
}