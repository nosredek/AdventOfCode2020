using Advent.Solutions;
using NUnit.Framework;

namespace Advent.Test
{
    public class Day11Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day11
            {
                DebugInput = @"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL".Replace("\r", "")
            };
        }

        [Test]
        public void Part1()
        {
            Assert.AreEqual("37", _day.SolvePartOne());
        }

        [Test]
        public void Part2()
        {
            Assert.AreEqual("26", _day.SolvePartTwo());
        }
    }
}