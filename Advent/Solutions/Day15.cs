using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Advent.Solutions
{
    public class Day15 : AdventDay
    {
        public Day15() : base(15)
        {
        }

        public override string SolvePartOne()
        {
            var list = new int[2020];
            var input = Input.Split(',').Select((item, index) => (int.Parse(item), (int)index + 1));
            foreach (var (a, i) in input)
            {
                list[a] = i;
            }
            var current = input.Last().Item1;
            var index = input.Last().Item2;
            var nextNumber = 0;
            for (int i = index + 1; i < 2020; i++)
            {
                var temp = list[nextNumber];
                list[nextNumber] = i;
                nextNumber = temp == 0 ? 0 : i - temp;
            }
            return nextNumber.ToString();
        }

        public override string SolvePartTwo()
        {
            var list = new int[30000000];
            var input = Input.Split(',').Select((item, index) => (int.Parse(item), (int)index + 1));
            foreach (var (a,i) in input)
            {
                list[a] = i;
            }
            var current = input.Last().Item1;
            var index = input.Last().Item2;
            var nextNumber = 0;
            for (int i = index + 1; i < 30000000; i++)
            {
                var temp = list[nextNumber];
                list[nextNumber] = i;
                nextNumber = temp == 0 ? 0 : i - temp;
            }
            return nextNumber.ToString();
        }
    }
}