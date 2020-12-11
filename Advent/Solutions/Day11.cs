using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent.Solutions
{
    public class Day11 : AdventDay
    {
        public Day11() : base(11)
        {
        }

        public override string SolvePartOne()
        {
            var seats = Input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(i => i.Prepend('x').Append('x').ToList()).ToList();
            seats = seats.Append(seats[0].Select(i => 'x').ToList()).Prepend(seats[0].Select(i => 'x').ToList()).ToList();

            var changed = true;
            while (changed)
            {
                changed = false;
                var set = new HashSet<(int i, int j, char a)>();
                for (int i = 1; i < seats.Count - 1; i++)
                {
                    for (int j = 1; j < seats[0].Count - 1; j++)
                    {
                        var element = seats[i][j];
                        if (element != '#' && element != 'L')
                        {
                            continue;
                        }

                        var elements = new[]
                        {
                        seats[i-1][j],
                        seats[i+1][j],
                        seats[i][j-1],
                        seats[i][j+1],
                        seats[i-1][j-1],
                        seats[i-1][j+1],
                        seats[i+1][j-1],
                        seats[i+1][j+1],
                    };

                        if (element == 'L' && !elements.Any(item => item == '#'))
                        {
                            set.Add((i, j, '#'));
                        }
                        else if (element == '#' && elements.Count(item => item == '#') >= 4)
                        {
                            set.Add((i, j, 'L'));
                        }
                        else
                        {
                            continue;
                        }
                        changed = true;
                    }
                }
                foreach (var a in set)
                {
                    seats[a.i][a.j] = a.a;
                }
            }
            return seats.SelectMany(i => i).Count(i => i == '#').ToString();
        }

        public override string SolvePartTwo()
        {
            var seats = Input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(i => i.Prepend('x').Append('x').ToList()).ToList();
            seats = seats.Append(seats[0].Select(i => 'x').ToList()).Prepend(seats[0].Select(i => 'x').ToList()).ToList();

            var changed = true;
            while (changed)
            {
                changed = false;
                var set = new HashSet<(int i, int j, char a)>();
                for (int i = 1; i < seats.Count - 1; i++)
                {
                    for (int j = 1; j < seats[0].Count - 1; j++)
                    {
                        var element = seats[i][j];
                        if (element != '#' && element != 'L')
                        {
                            continue;
                        }

                        var directions = new[] { (0, 1), (1, 0), (1, 1), (0, -1), (-1, 0), (-1, -1), (1, -1), (-1, 1) };

                        var elements = new List<char>();

                        foreach (var (x,y) in directions)
                        {
                            var (a, b) = (x, y);
                            while(i+a >0 && j+b > 0 && i+a<seats.Count && b+j<seats[0].Count)
                            {
                                if (seats[i+a][j+b] == '#' || seats[i + a][j + b] == 'L')
                                {
                                    elements.Add(seats[i + a][j + b]);
                                    break;
                                }
                                a += x;
                                b += y;
                            }
                        }
                        

                        if (element == 'L' && !elements.Any(item => item == '#'))
                        {
                            set.Add((i, j, '#'));
                        }
                        else if (element == '#' && elements.Count(item => item == '#') >= 5)
                        {
                            set.Add((i, j, 'L'));
                        }
                        else
                        {
                            continue;
                        }
                        changed = true;
                    }
                }
                foreach (var a in set)
                {
                    seats[a.i][a.j] = a.a;
                }
            }
            return seats.SelectMany(i => i).Count(i => i == '#').ToString();
        }
    }
}