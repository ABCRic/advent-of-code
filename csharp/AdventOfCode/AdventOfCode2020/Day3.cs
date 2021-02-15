using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.AdventOfCode2020
{
    public static class Day3
    {
        public static long First(string input)
        {
            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(l => l.Trim()).ToArray();
            var lineWidth = lines[0].Length;

            var treeHits = 0;
            for(int x = 0, y = 0; y < lines.Length; x += 3, y++)
            {
                if (lines[y][x % lineWidth] == '#')
                    treeHits++;
            }
            return treeHits;
        }

        public static long Second(string input)
        {
            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(l => l.Trim()).ToArray();
            var lineWidth = lines[0].Length;

            long result = 1;
            var slopes = new []{
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2)
            };

            foreach (var (slopeX, slopeY) in slopes)
            {
                var treeHits = 0;
                for (int x = 0, y = 0; y < lines.Length; x += slopeX, y += slopeY)
                {
                    if (lines[y][x % lineWidth] == '#')
                        treeHits++;
                }
                result *= treeHits;
            }
            return result;
        }
    }
}