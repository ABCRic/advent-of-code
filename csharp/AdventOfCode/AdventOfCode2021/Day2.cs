using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.AdventOfCode2021
{
    public static class Day2
    {
        public static long First(string input)
        {
            var commands = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToArray();

            int horizontalPosition = 0;
            int depth = 0;
            foreach(var command in commands)
            {
                var parts = command.Split(' ');
                switch(parts[0])
                {
                    case "forward":
                        horizontalPosition += int.Parse(parts[1]);
                        break;
                    case "down":
                        depth += int.Parse(parts[1]);
                        break;
                    case "up":
                        depth -= int.Parse(parts[1]);
                        break;
                }
            }
            return horizontalPosition * depth;
        }

        public static long Second(string input)
        {
            var commands = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToArray();

            int horizontalPosition = 0;
            int depth = 0;
            int aim = 0;
            foreach (var command in commands)
            {
                var parts = command.Split(' ');
                switch (parts[0])
                {
                    case "forward":
                        int arg = int.Parse(parts[1]);
                        horizontalPosition += arg;
                        depth += aim * arg;
                        break;
                    case "down":
                        aim += int.Parse(parts[1]);
                        break;
                    case "up":
                        aim -= int.Parse(parts[1]);
                        break;
                }
            }
            return horizontalPosition * depth;
        }
    }
}