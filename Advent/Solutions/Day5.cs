using System;
using System.Linq;

namespace Advent.Solutions
{
    public class Day5 : AdventDay
    {
        public Day5() : base(5)
        {
        }

        public override string SolvePartOne()
        {
            return Input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Max(i => SeatId(i)).ToString();
        }

        public override string SolvePartTwo()
        {
            var seats = Input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(i => SeatId(i));
            return Enumerable.Range(seats.Min(), seats.Count()).First(i => !seats.Contains(i)).ToString();
        }

        private int SeatId(string input)
        {
            return Convert.ToInt32(input.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1'), 2);
        }
    }
}