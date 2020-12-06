using System;
using System.Linq;

namespace Advent.Solutions
{
    public class Day6 : AdventDay
    {
        public Day6() : base(6)
        {
        }

        public override string SolvePartOne()
        {
            return Input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
                        .Select(i => i.Replace("\n", "").Distinct().Count())
                        .Sum()
                        .ToString();
        }

        public override string SolvePartTwo()
        {
            return Input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
                        .Select(i => new {  chars = i.Split('\n')
                                                    .Select(i => i.Distinct())
                                                    .SelectMany(i => i),
                                            numLines = i.Split('\n', StringSplitOptions.RemoveEmptyEntries).Length })
                        .Select(i => i.chars.GroupBy(c => c).Where(j => j.Count() == i.numLines).Count())
                        .Sum()
                        .ToString();
        }
    }
}