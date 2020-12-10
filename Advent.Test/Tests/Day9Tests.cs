using Advent.Solutions;
using NUnit.Framework;

namespace Advent.Test
{
    public class Day9Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day9(5)
            {
                DebugInput = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576".Replace("\r", "")
            };
        }

        [Test]
        public void Part1()
        {
            Assert.AreEqual("127", _day.SolvePartOne());
        }

        [Test]
        public void Part2()
        {
            Assert.AreEqual("62", _day.SolvePartTwo());
        }
    }
}