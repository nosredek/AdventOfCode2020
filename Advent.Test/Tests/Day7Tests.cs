using Advent.Solutions;
using NUnit.Framework;

namespace Advent.Test
{
    public class Day7Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day7
            {
                DebugInput = @"shiny gold bags contain 2 dark red bags.
dark red bags contain 2 dark orange bags.
dark orange bags contain 2 dark yellow bags.
dark yellow bags contain 2 dark green bags.
dark green bags contain 2 dark blue bags.
dark blue bags contain 2 dark violet bags.
dark violet bags contain no other bags.".Replace("\r", "")
            };
        }

        [Test]
        public void Part1()
        {
            Assert.AreEqual("4", _day.SolvePartOne());
        }

        [Test]
        public void Part2()
        {
            Assert.AreEqual("126", _day.SolvePartTwo());
        }
    }
}