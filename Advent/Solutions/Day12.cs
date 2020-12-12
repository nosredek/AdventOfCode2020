using System;
using System.Linq;

namespace Advent.Solutions
{
    public class Day12 : AdventDay
    {
        public Day12() : base(12)
        {
        }

        public override string SolvePartOne()
        {
            var instructions = Input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(i => (i[0], int.Parse(i[1..]))).ToList();
            var (x, y) = (0, 0);
            var possibleDirections = new[] { (1, 0), (0, -1), (-1, 0), (0, 1) };
            var facingDirection = 0;
            foreach (var (direction, amount) in instructions)
            {
                switch (direction)
                {
                    case 'N':
                        y += amount;
                        break;

                    case 'S':
                        y -= amount;
                        break;

                    case 'E':
                        x += amount;
                        break;

                    case 'W':
                        x -= amount;
                        break;

                    case 'L':
                        var num = facingDirection - (amount / 90);
                        facingDirection = num < 0 ? possibleDirections.Length + num : num;
                        break;

                    case 'R':
                        facingDirection = (facingDirection + (amount / 90)) % 4;
                        break;

                    case 'F':
                        (x, y) = (x + (amount * possibleDirections[facingDirection].Item1), y + (amount * possibleDirections[facingDirection].Item2));
                        break;
                }
            }
            return (Math.Abs(x) + Math.Abs(y)).ToString();
        }

        public override string SolvePartTwo()
        {
            var instructions = Input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(i => (i[0], int.Parse(i[1..]))).ToList();
            var (boatX, boatY) = (0, 0);
            var (wayX, wayY) = (10, 1);
            foreach (var (direction, amount) in instructions)
            {
                switch (direction)
                {
                    case 'N':
                        wayY += amount;
                        break;

                    case 'S':
                        wayY -= amount;
                        break;

                    case 'E':
                        wayX += amount;
                        break;

                    case 'W':
                        wayX -= amount;
                        break;

                    case 'L':
                        var num = 4 - (amount / 90);
                        switch (num)
                        {
                            case 1:
                                (wayX, wayY) = (wayY, -wayX);
                                break;

                            case 2:
                                (wayX, wayY) = (-wayX, -wayY);
                                break;

                            case 3:
                                (wayX, wayY) = (-wayY, wayX);
                                break;
                        }
                        break;

                    case 'R':
                        num = amount / 90;
                        switch (num)
                        {
                            case 1:
                                (wayX, wayY) = (wayY, -wayX);
                                break;

                            case 2:
                                (wayX, wayY) = (-wayX, -wayY);
                                break;

                            case 3:
                                (wayX, wayY) = (-wayY, wayX);
                                break;
                        }
                        break;

                    case 'F':
                        (boatX, boatY) = (boatX + wayX * amount, boatY + wayY * amount);
                        break;
                }
            }
            return (Math.Abs(boatX) + Math.Abs(boatY)).ToString();
        }
    }
}