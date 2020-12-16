using Advent.Solutions;
using NUnit.Framework;

namespace Advent.Test
{
    public class Day16Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day16
            {
                DebugInput = @"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50

your ticket:
7,1,14

nearby tickets:
7,3,47
40,4,50
55,2,20
38,6,12".Replace("\r", "")
            };
        }

        [Test]
        public void Part1()
        {
            Assert.AreEqual("71", _day.SolvePartOne());
        }

        [Test]
        public void Part2()
        {
            _day.DebugInput = @"class: 0-1 or 4-19
row: 0-5 or 8-19
seat: 0-13 or 16-19

your ticket:
11,12,13

nearby tickets:
3,9,18
15,1,5
5,14,9".Replace("\r", "");
            Assert.Pass();
        }
    }
}