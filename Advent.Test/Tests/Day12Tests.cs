using Advent.Solutions;
using NUnit.Framework;

namespace Advent.Test
{
    public class Day12Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day12
            {
                DebugInput = @"F10
N3
F7
R90
F11".Replace("\r", "")
            };
        }

        [Test]
        public void Part1()
        {
            Assert.AreEqual("25", _day.SolvePartOne());
        }

        [Test]
        public void Part2()
        {
            Assert.AreEqual("286", _day.SolvePartTwo());
        }
    }
}