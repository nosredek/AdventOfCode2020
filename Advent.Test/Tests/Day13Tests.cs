using Advent.Solutions;
using NUnit.Framework;

namespace Advent.Test
{
    public class Day13Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day13
            {
                DebugInput = @"939
7,13,x,x,59,x,31,19".Replace("\r", "")
            };
        }

        [Test]
        public void Part1()
        {
            Assert.AreEqual("295", _day.SolvePartOne());
        }

        [Test]
        public void Part2()
        {
            Assert.AreEqual("1068781", _day.SolvePartTwo());
        }
    }
}