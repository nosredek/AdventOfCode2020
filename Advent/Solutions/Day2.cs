using System;
using System.Linq;

namespace Advent.Solutions
{
    public class Day2 : AdventDay
    {
        private string[] _input => Input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToArray();

        public Day2() : base(2)
        {
        }

        public override string SolvePartOne()
        {
            var valid = 0;
            foreach (var password in _input)
            {
                var a = password.Split(':');
                var condition = a[0].Split(' ');
                var cond = condition[0].Split('-').Select(i => int.Parse(i)).ToArray();

                var letterCount = a[1].Count(i => i == condition[1][0]);
                if (letterCount >= cond[0] && letterCount <= cond[1])
                    valid++;
            }
            return valid.ToString();
        }

        public override string SolvePartTwo()
        {
            var valid = 0;
            foreach (var password in _input)
            {
                var a = password.Split(':');
                var condition = a[0].Split(' ');
                var cond = condition[0].Split('-').Select(i => int.Parse(i)).ToArray();

                if (a[1][cond[0]] == condition[1][0] ^ a[1][cond[1]] == condition[1][0])
                    valid++;
            }
            return valid.ToString();
        }
    }
}