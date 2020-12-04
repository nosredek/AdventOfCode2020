using Advent.Solutions;
using NUnit.Framework;

namespace Advent.Test
{
    public class Day2Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day2
            {
                DebugInput = @"1-3 a: abcde
1-3 b: cdefg
2-9 c: ccccccccc".Replace("\r", "")
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
            Assert.AreEqual("1", _day.SolvePartTwo());
        }
    }
}