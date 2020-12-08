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
            var commands = Input.Trim().Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim().Split(' ')).Select(i => (i[0],int.Parse(i[1]))).ToList();
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
            var commands = Input.Trim().Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim().Split(' ')).Select(i => (i[0], int.Parse(i[1]))).ToList();
            var set = new HashSet<int>();
            var jmpNopSet = new HashSet<int>();
            var commandLine = 0;
            while (!set.Contains(commandLine))
            {
                set.Add(commandLine);
                (var command, var argument) = commands[commandLine];
                switch (command)
                {
                    case "nop":
                        jmpNopSet.Add(commandLine);
                        break;
                    case "acc":
                        break;
                    case "jmp":
                        jmpNopSet.Add(commandLine);
                        commandLine += argument;
                        continue;
                }
                commandLine++;
            }

            foreach(var jmpOrNopLine in jmpNopSet)
            {
                var acc = 0;
                set = new HashSet<int>();
                commandLine = 0;
                while (!set.Contains(commandLine))
                {
                    if (commandLine >= commands.Count)
                        return acc.ToString();
                    set.Add(commandLine);
                    (var command, var argument) = commands[commandLine];
                    if (commandLine == jmpOrNopLine)
                    {
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
            }

            return null;
        }
    }
}