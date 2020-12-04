using Advent.Solutions;
using NUnit.Framework;

namespace Advent.Test
{
    public class Day5Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day5
            {
                DebugInput = @"".Replace("\r", "")
            };
        }

        [Test]
        public void Part1()
        {
            Assert.AreEqual("2", _day.SolvePartOne());
        }

        [Test]
        public void Part2()
        {
            Assert.AreEqual("2", _day.SolvePartTwo());
        }
    }
}