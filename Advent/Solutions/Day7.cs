using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent.Solutions
{
    public class Day7 : AdventDay
    {
        public Day7() : base(7)
        {
        }

        public override string SolvePartOne()
        {
            var input = Input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                            .Select(i => i.Replace("bags", "bag").Replace(".", "").Split("contain"));
            Dictionary<string, List<string>> dict = new();
            foreach (var item in input)
            {
                var element = item[0].Trim();
                var keys = item[1].Split(", ").Select(i => i.Substring(2).Trim());
                foreach (var key in keys)
                {
                    if (dict.ContainsKey(key))
                    {
                        dict[key].Add(element);
                    }
                    else
                    {
                        dict[key] = new List<string> { element };
                    }
                }
            }

            var bagKeys = new List<string> { "shiny gold bag" };
            var distinctBags = new HashSet<string>();
            while (bagKeys.Count != 0)
            {
                bagKeys = dict.Where(i => bagKeys.Contains(i.Key)).SelectMany(i => i.Value).ToList();
                distinctBags.UnionWith(bagKeys);
            }

            return distinctBags.Count.ToString();
        }

        public override string SolvePartTwo()
        {
            var input = Input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                            .Select(i => i.Replace("bags", "bag").Replace(".", "").Split("contain"));
            Dictionary<string, List<(int, string)>> dict = new();

            foreach (var item in input)
            {
                var key = item[0].Trim();
                var bags = item[1].Split(", ").Select(i => i.Trim());
                foreach (var bag in bags)
                {
                    if (bag == "no other bag")
                        continue;
                    var num = bag[0] - '0';
                    if (dict.ContainsKey(key))
                    {
                        dict[key].Add((num, bag.Substring(2)));
                    }
                    else
                    {
                        dict[key] = new List<(int, string)> { (num, bag.Substring(2)) };
                    }
                }
            }
            return (CountBags(dict, "shiny gold bag") - 1).ToString();
        }

        private int CountBags(Dictionary<string, List<(int, string)>> dict, string bagKey)
        {
            return !dict.ContainsKey(bagKey) ? 1 : 1 + dict[bagKey].Select(i => i.Item1 * CountBags(dict, i.Item2)).Sum();
        }
    }
}