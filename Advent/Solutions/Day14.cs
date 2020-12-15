using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent.Solutions
{
    public class Day14 : AdventDay
    {
        public Day14() : base(14)
        {
        }

        public override string SolvePartOne()
        {
            var lines = Input.Trim().Split('\n').ToList();
            Dictionary<string, long> mem = new();
            string mask = "";
            foreach (var line in lines)
            {
                if (line.StartsWith("mask"))
                {
                    mask = line.Split('=')[1].Trim();
                }
                else
                {
                    var temp = line.Split('=');
                    var key = temp[0];
                    var bits = Convert.ToString(long.Parse(temp[1]), 2).PadLeft(36, '0').ToArray();
                    for (int i = 0; i < mask.Length; i++)
                    {
                        bits[i] = (mask[i]) switch
                        {
                            '1' => '1',
                            '0' => '0',
                            _ => bits[i],
                        };
                    }
                    mem[key] = Convert.ToInt64(new string(bits), 2);
                }
            }
            return mem.Values.Sum().ToString();
        }

        public override string SolvePartTwo()
        {
            var lines = Input.Trim().Split('\n').ToList();
            Dictionary<long, long> mem = new();
            string mask = "";
            foreach (var line in lines)
            {
                if (line.StartsWith("mask"))
                {
                    mask = line.Split('=')[1].Trim();
                }
                else
                {
                    var temp = line.Split('=');
                    var key = temp[0][4..^2];
                    var value = long.Parse(temp[1]);
                    var keyBits = Convert.ToString(long.Parse(key), 2).PadLeft(36, '0');
                    var newKeys = new List<string>();
                    for (int i = 0; i < mask.Length; i++)
                    {
                        if (mask[i] == 'X')
                        {
                            if (!newKeys.Any())
                            {
                                var key0 = keyBits.Remove(i, 1).Insert(i, "0");
                                var key1 = keyBits.Remove(i, 1).Insert(i, "1");
                                newKeys.Add(key0);
                                newKeys.Add(key1);
                            }
                            else
                            {
                                var cnt = newKeys.Count;
                                for (int j = 0; j < cnt; j++)
                                {
                                    newKeys[j] = newKeys[j].Remove(i, 1).Insert(i, "0");
                                    newKeys.Add(newKeys[j].Remove(i, 1).Insert(i, "1"));
                                }
                            }
                        }
                        else if (mask[i] == '1')
                        {
                            keyBits = keyBits.Remove(i, 1).Insert(i, "1");
                            for (int j = 0; j < newKeys.Count; j++)
                            {
                                newKeys[j] = newKeys[j].Remove(i, 1).Insert(i, "1");
                            }
                        }
                    }
                    foreach (var keyToAdd in newKeys)
                    {
                        mem[Convert.ToInt64(keyToAdd, 2)] = value;
                    }
                }
            }
            return mem.Values.Sum().ToString();
        }
    }
}