using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent.Solutions
{
    public class Day9 : AdventDay
    {
        private int _preambleSize;
        public Day9(int preambleSize) : base(9)
        {
            _preambleSize = preambleSize;
        }

        public override string SolvePartOne()
        {
            var longInput = Input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray() ;


            for (int i = _preambleSize; i < longInput.Length; i++)
            {
                var preamble = longInput[(i - _preambleSize)..i];
                if (preamble.Any(item => (preamble.Contains(longInput[i] - item) && (longInput[i] - item) != item)))
                    continue;
                return longInput[i].ToString();
            }
            return null;
        }

        public override string SolvePartTwo()
        {
            var longInput = Input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

            long targetNum = 0;
            for (int i = _preambleSize; i < longInput.Length; i++)
            {
                var preamble = longInput[(i - _preambleSize)..i];
                if (preamble.Any(item => (preamble.Contains(longInput[i] - item) && (longInput[i] - item) != item)))
                    continue;

                targetNum =  longInput[i];
                break;
            }

            foreach(var i in Enumerable.Range(0, longInput.Length))
            {
                foreach(var j in Enumerable.Range(i + 2, longInput.Length-i))
                {
                    var range = longInput[i..j];
                    var sum = range.Sum();
                    if (sum == targetNum) return (range.Min() + range.Max()).ToString();
                    else if(sum> targetNum)
                    {
                        break;
                    }
                }
            }
            return null;
        }
    }
}