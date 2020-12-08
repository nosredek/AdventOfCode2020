using Advent.Solutions;
using NUnit.Framework;

namespace Advent.Test
{
    public class Day8Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day8
            {
                DebugInput = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6".Replace("\r", "")
            };
        }

        [Test]
        public void Part1()
        {
            Assert.AreEqual("5", _day.SolvePartOne());
        }

        [Test]
        public void Part2()
        {
            Assert.AreEqual("8", _day.SolvePartTwo());
        }
    }
}