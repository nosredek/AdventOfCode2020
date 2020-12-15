using Advent.Solutions;
using NUnit.Framework;

namespace Advent.Test
{
    public class Day14Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day14
            {
                DebugInput = @"mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
mem[8] = 11
mem[7] = 101
mem[8] = 0".Replace("\r", "")
            };
        }

        [Test]
        public void Part1()
        {
            Assert.AreEqual("165", _day.SolvePartOne());
        }

        [Test]
        public void Part2()
        {
            _day.DebugInput = @"mask = 000000000000000000000000000000X1001X
mem[42] = 100
mask = 00000000000000000000000000000000X0XX
mem[26] = 1".Replace("\r", "");
            Assert.AreEqual("208", _day.SolvePartTwo());
        }
    }
}