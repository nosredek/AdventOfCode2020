using System;

namespace Advent.Solutions
{
    public class Day3 : AdventDay
    {
        private string[] _input;

        public Day3() : base(3)
        {
            _input = Input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        }

        protected override string SolvePartOne()
        {
            return SlopeCount(3, 1).ToString();
        }

        protected override string SolvePartTwo()
        {
            return (SlopeCount(1, 1) * SlopeCount(3, 1) * SlopeCount(5, 1) * SlopeCount(7, 1) * SlopeCount(1, 2)).ToString();
        }

        private int SlopeCount(int right, int down)
        {
            var x = right;
            var count = 0;
            var len = _input[0].Length;
            for (int i = down; i < _input.Length; i += down)
            {
                if (_input[i][(x) % len] == '#')
                    count++;
                x += right;
            }
            return count;
        }
    }
}