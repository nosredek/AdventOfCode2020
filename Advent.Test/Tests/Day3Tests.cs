using Advent.Solutions;
using NUnit.Framework;

namespace Advent.Test
{
    public class Day3Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day3
            {
                DebugInput = @"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#".Replace("\r", "")
            };
        }

        [Test]
        public void Part1()
        {
            Assert.AreEqual("7", _day.SolvePartOne());
        }

        [Test]
        public void Part2()
        {
            Assert.AreEqual("336", _day.SolvePartTwo());
        }
    }
}