using Advent.Solutions;
using NUnit.Framework;

namespace Advent.Test
{
    public class Day10Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day10
            {
                DebugInput = @"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3".Replace("\r", "")
            };
        }

        [Test]
        public void Part1()
        {
            Assert.AreEqual("220", _day.SolvePartOne());
        }

        [Test]
        public void Part2()
        {
            Assert.AreEqual("19208", _day.SolvePartTwo());
        }
    }
}