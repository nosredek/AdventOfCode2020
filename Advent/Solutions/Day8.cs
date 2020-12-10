using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent.Solutions
{
    public class Day8 : AdventDay
    {
        public Day8() : base(8)
        {
        }

        public override string SolvePartOne()
        {
            var commands = Input.Trim().Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim().Split(' ')).Select(i => (i[0], int.Parse(i[1]))).ToList();
            var acc = 0;
            var set = new HashSet<int>();
            var commandLine = 0;
            while (!set.Contains(commandLine))
            {
                set.Add(commandLine);
                (var command, var argument) = commands[commandLine];
                switch (command)
                {
                    case "nop":
                        break;

                    case "acc":
                        acc += argument;
                        break;

                    case "jmp":
                        commandLine += argument;
                        continue;
                }
                commandLine++;
            }
            return acc.ToString();
        }

        public override string SolvePartTwo()
        {
            var commands = Input.Trim().Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim().Split(' ')).Select((item, index) => (index, line: (command: item[0], argument: int.Parse(item[1]))))
                .ToDictionary(i => i.index, i =>
                {
                    return i.line.command switch
                    {
                        "jmp" => new int[] { i.index + i.line.argument, i.index + 1 },
                        "nop" => new int[] { i.index + 1, i.index + i.line.argument },
                        _ => new int[] { i.index + 1 },
                    };
                });

            var linesToFinish = new HashSet<int> { commands.Count - 1 };
            var lines = commands.Where(i => i.Value.First() == commands.Count - 1).Select(i => i.Key);
            while (lines.Any())
            {
                linesToFinish.UnionWith(lines);
                lines = commands.Where(i => lines.Contains(i.Value.First())).Select(i => i.Key).ToList();
            }

            var commandLines = Input.Trim().Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim().Split(' ')).Select(i => (i[0], int.Parse(i[1]))).ToList();

            var acc = 0;
            var set = new HashSet<int>();
            var commandLine = 0;
            var changed = false;
            while (!set.Contains(commandLine))
            {
                if (commandLine >= commands.Count)
                    return acc.ToString();
                set.Add(commandLine);
                (var command, var argument) = commandLines[commandLine];
                if (linesToFinish.Contains(commands[commandLine].Last()) && !changed)
                {
                    changed = true;
                    switch (command)
                    {
                        case "nop":
                            commandLine += argument;
                            continue;
                        case "jmp":
                            break;
                    }
                }
                else
                {
                    switch (command)
                    {
                        case "nop":
                            break;

                        case "acc":
                            acc += argument;
                            break;

                        case "jmp":
                            commandLine += argument;
                            continue;
                    }
                }
                commandLine++;
            }

            return null;
        }
    }
}