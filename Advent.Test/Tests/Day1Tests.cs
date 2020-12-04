using Advent.Solutions;
using NUnit.Framework;

namespace Advent.Test
{
    public class Day1Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day1
            {
                DebugInput = @"1721
979
366
299
675
1456".Replace("\r", "")
            };
        }

        [Test]
        public void Part1()
        {
            Assert.AreEqual("514579", _day.SolvePartOne());
        }

        [Test]
        public void Part2()
        {
            Assert.AreEqual("241861950", _day.SolvePartTwo());
        }
    }
}