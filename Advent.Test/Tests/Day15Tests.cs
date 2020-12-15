using Advent.Solutions;
using NUnit.Framework;

namespace Advent.Test
{
    public class Day15Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day15();
        }

        [TestCase("0,3,6", ExpectedResult = "436")]
        [TestCase("1,3,2", ExpectedResult = "1")]
        [TestCase("2,1,3", ExpectedResult = "10")]
        [TestCase("1,2,3", ExpectedResult = "27")]
        [TestCase("2,3,1", ExpectedResult = "78")]
        [TestCase("3,2,1", ExpectedResult = "438")]
        [TestCase("3,1,2", ExpectedResult = "1836")]
        public string Part1(string input)
        {
            _day.DebugInput = input;
            return _day.SolvePartOne();
        }

        [TestCase("0,3,6", ExpectedResult = "175594")]
        [TestCase("1,3,2", ExpectedResult = "2578")]
        [TestCase("2,1,3", ExpectedResult = "3544142")]
        [TestCase("1,2,3", ExpectedResult = "261214")]
        [TestCase("2,3,1", ExpectedResult = "6895259")]
        [TestCase("3,2,1", ExpectedResult = "18")]
        [TestCase("3,1,2", ExpectedResult = "362")]
        public string Part2(string input)
        {
            _day.DebugInput = input;
            return _day.SolvePartTwo();
        }
    }
}