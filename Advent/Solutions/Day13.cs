using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent.Solutions
{
    public class Day13 : AdventDay
    {
        public Day13() : base(13)
        {
        }

        public override string SolvePartOne()
        {
            var timestampAndIds = Input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var timestamp = long.Parse(timestampAndIds[0]);
            var earliestId = timestampAndIds[1].Split(',').Where(i => i != "x").Select(int.Parse).OrderBy(i => i - (timestamp % i)).First();
            return (earliestId * (earliestId - (timestamp % earliestId))).ToString();
        }

        public override string SolvePartTwo()
        {
            var ids = Input.Split('\n', StringSplitOptions.RemoveEmptyEntries)[1]
                .Split(',')
                .Select((i, index) => (i, index))
                .Where(i => i.i != "x")
                .Select(i => (id: int.Parse(i.i), index: i.index % int.Parse(i.i)))
                .OrderByDescending(i => i.id)
                .ToList();

            long step = ids[0].id;
            long searchTimestamp = ids[0].id-ids[0].index;
            var correct = 1;
            while (correct < ids.Count)
            {
                searchTimestamp += step;
                foreach (var (id, index) in ids.Skip(correct))
                {
                    var temp = searchTimestamp % id;
                    temp = temp > 0 ? id - temp : temp;
                    if (temp == index)
                    {
                        step *= id;
                        correct++;
                    }
                    else { break; }
                }

            }
            return searchTimestamp.ToString();
        }
    }
}