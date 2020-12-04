using System;
using System.Linq;

namespace Advent.Solutions
{
    public class Day1 : AdventDay
    {
        private int[] _input => Input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray();

        public Day1() : base(1)
        {
        }

        public override string SolvePartOne()
        {
            foreach (var x in _input)
            {
                foreach (var y in _input)
                {
                    if (x + y == 2020)
                        return (x * y).ToString();
                }
            }
            return null;
        }

        public override string SolvePartTwo()
        {
            foreach (var x in _input)
            {
                foreach (var y in _input)
                {
                    foreach (var z in _input)
                    {
                        if (x + y + z == 2020)
                            return (x * y * z).ToString();
                    }
                }
            }
            return null;
        }
    }
}