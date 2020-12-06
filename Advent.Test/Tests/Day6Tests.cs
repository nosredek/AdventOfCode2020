using Advent.Solutions;
using NUnit.Framework;

namespace Advent.Test
{
    public class Day6Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day6
            {
                DebugInput = @"abc

a
b
c

ab
ac

a
a
a
a

b".Replace("\r", "")
            };
        }

        [Test]
        public void Part1()
        {
            Assert.AreEqual("11", _day.SolvePartOne());
        }

        [Test]
        public void Part2()
        {
            Assert.AreEqual("6", _day.SolvePartTwo());
        }
    }
}