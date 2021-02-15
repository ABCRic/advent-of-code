using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.AdventOfCode2020
{
    public static class Day2
    {
        public static long First(string input)
        {
            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            int valid = 0;
            foreach(var line in lines)
            {
                var parts = Regex.Match(line, @"(?<min>\d+)-(?<max>\d+) (?<character>.): (?<pass>.*)");
                var letterCount = parts.Groups["pass"].Value.Count(c => c == parts.Groups["character"].Value.First());
                if (letterCount >= int.Parse(parts.Groups["min"].Value) &&
                    letterCount <= int.Parse(parts.Groups["max"].Value))
                {
                    valid++;
                }
            }
            return valid;
        }

        public static long Second(string input)
        {
            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            int valid = 0;
            foreach (var line in lines)
            {
                var parts = Regex.Match(line, @"(?<pos1>\d+)-(?<pos2>\d+) (?<character>.): (?<pass>.*)");
                var pass = parts.Groups["pass"].Value;
                var character = parts.Groups["character"].Value.First();
                if (pass[int.Parse(parts.Groups["pos1"].Value) - 1] == character ^
                    pass[int.Parse(parts.Groups["pos2"].Value) - 1] == character)
                {
                    valid++;
                }
            }
            return valid;
        }
    }
}