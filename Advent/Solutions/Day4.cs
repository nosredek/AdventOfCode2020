using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent.Solutions
{
    public class Day4 : AdventDay
    {
        public Day4() : base(4)
        {
        }

        public override string SolvePartOne()
        {
            var valid = Input.Split("\n\n")
                .Select(i => i.Replace("\n", " ").Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .Count(i => i.Where(j => !j.StartsWith("cid")).Count() == 7);
            return valid.ToString();
        }

        public override string SolvePartTwo()
        {
            var valid = Input.Split("\n\n")
                .Select(i => i.Replace("\n", " ").Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .Where(i => i.Where(j => !j.StartsWith("cid")).Count() == 7)
                .Count(i => Validate(i));
            return valid.ToString();
        }

        private bool Validate(IEnumerable<string> values)
        {
            foreach (var item in values)
            {
                var pair = item.Split(':');
                switch (pair[0])
                {
                    case "byr":
                        var byr = int.Parse(pair[1]);
                        if (byr < 1920 || byr > 2002)
                            return false;
                        break;

                    case "iyr":
                        var iyr = int.Parse(pair[1]);
                        if (iyr < 2010 || iyr > 2020)
                            return false;
                        break;

                    case "eyr":
                        var eyr = int.Parse(pair[1]);
                        if (eyr < 2020 || eyr > 2030)
                            return false;
                        break;

                    case "hgt":
                        if (pair[1].EndsWith("in"))
                        {
                            var hgt = int.Parse(pair[1].Replace("in", ""));
                            if (hgt < 59 || hgt > 76)
                                return false;
                        }
                        else if (pair[1].EndsWith("cm"))
                        {
                            var hgt = int.Parse(pair[1].Replace("cm", ""));
                            if (hgt < 150 || hgt > 193)
                                return false;
                        }
                        else
                        {
                            return false;
                        }
                        break;

                    case "hcl":
                        if (pair[1].Length != 7 || pair[1][0] != '#' || pair[1][1..].Any(i => !"abcdef0123456789".Contains(i)))
                            return false;
                        break;

                    case "ecl":
                        if (!(new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }).Contains(pair[1]))
                            return false;
                        break;

                    case "pid":
                        if (pair[1].Any(i => !char.IsDigit(i)) || pair[1].Length != 9)
                            return false;
                        break;
                }
            }
            return true;
        }
    }
}