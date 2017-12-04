using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.AdventOfCode2017
{
    public class Day3
    {
        public static int First(int input)
        {
            /* the numbers in the bottom right corner of each ring are the
             * squares of the odd numbers. Find which ring the input is in by
             * walking up to the square bigger than the input */
            int exp = 1, ring = 0;
            for (; exp * exp < input; ring++, exp += 2) { }
            int bottomRight = exp * exp;

            /* the NSWE numbers to the origin are exactly <ring> distance away.
             * compute those numbers for the current ring and find the distance to the
             * closest to the input.
             * The manhattan distance will be the sum of these two distances */
            var distanceClosest =
                new[] {
                    bottomRight - exp / 2,
                    bottomRight - exp / 2 - (exp - 1),
                    bottomRight - exp / 2 - 2 * (exp - 1),
                    bottomRight - exp / 2 - 3 * (exp - 1)
                }
                .Min(d => Math.Abs(input - d));

            return distanceClosest + ring;
        }

        public static int Second(int input)
        {
            int x = 0,
                y = 0,
                dx = 0,
                dy = -1;
            var matrix = new Dictionary<(int, int), int>();

            // generate spiral until first number larger than input
            while (true)
            {
                var acc = 0;
                foreach (var offset in new[]
                    {(-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 0), (0, 1), (1, -1), (1, 0), (1, 1)})
                {
                    if (matrix.TryGetValue((x + offset.Item1, y + offset.Item2), out var sub))
                        acc += sub;
                }
                if (acc > input)
                    return acc;
                if (x == 0 && y == 0)
                    matrix.Add((0, 0), 1);
                else
                    matrix.Add((x, y), acc);
                // rotate if
                if (x == y ||               // top right or bottom left corner
                    (x < 0 && x == -y) ||   // top left
                    (x > 0 && x == -y + 1)) // bottom right + 1 right
                    (dx, dy) = (-dy, dx);
                x += dx;
                y += dy;
            }
        }
    }
}