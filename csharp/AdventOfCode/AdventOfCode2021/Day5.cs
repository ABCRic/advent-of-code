using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.AdventOfCode2021
{
    public static class Day5
    {
        readonly record struct Point(int X, int Y)
        {
            public static Point FromString(string str) {
                var parts = str.Split(",");
                return new Point(int.Parse(parts[0]), int.Parse(parts[1])); 
            }
        };

        public static long First(string input)
        {
            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(l => l.Trim()).ToArray();

            var linesPerPoint = new Dictionary<Point, int>();

            foreach (var line in lines)
            {
                var points = line.Split(" -> ");

                var from = Point.FromString(points[0]);
                var to = Point.FromString(points[1]);

                void Mark(Point point)
                {
                    linesPerPoint.TryGetValue(point, out var count);
                    linesPerPoint[point] = count + 1;
                }

                // horizontal
                if (from.X == to.X)
                {
                    for (int y = Math.Min(from.Y, to.Y); y <= Math.Max(from.Y, to.Y); y++)
                        Mark(new Point(from.X, y));
                }

                // vertical
                if (from.Y == to.Y)
                {
                    for (int x = Math.Min(from.X, to.X); x <= Math.Max(from.X, to.X); x++)
                        Mark(new Point(x, from.Y));
                }
            }

            return linesPerPoint.Count(pair => pair.Value > 1);
        }

        public static long Second(string input)
        {
            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(l => l.Trim()).ToArray();

            var linesPerPoint = new Dictionary<Point, int>();

            foreach (var line in lines)
            {
                var points = line.Split(" -> ");

                var from = Point.FromString(points[0]);
                var to = Point.FromString(points[1]);

                void Mark(Point point)
                {
                    linesPerPoint.TryGetValue(point, out var count);
                    linesPerPoint[point] = count + 1;
                }

                var leftmost = new[] { from, to }.MinBy(p => p.X);
                var rightmost = leftmost == from ? to : from;

                // vertical
                if (from.X == to.X)
                {
                    for (int y = Math.Min(from.Y, to.Y); y <= Math.Max(from.Y, to.Y); y++)
                        Mark(new Point(from.X, y));
                }
                else if (from.Y == to.Y) // horizontal
                {
                    for (int x = Math.Min(from.X, to.X); x <= Math.Max(from.X, to.X); x++)
                        Mark(new Point(x, from.Y));
                }
                else if (leftmost.Y <= rightmost.Y) // down-right diagonal
                {
                    for (int x = leftmost.X, y = leftmost.Y; x <= rightmost.X && y <= rightmost.Y; x++, y++)
                    {
                        Mark(new Point(x, y));
                    }
                }
                else // down-left diagonal
                {
                    for (int x = leftmost.X, y = leftmost.Y; x <= rightmost.X && y >= rightmost.Y; x++, y--)
                    {
                        Mark(new Point(x, y));
                    }
                }
            }

            return linesPerPoint.Count(pair => pair.Value > 1);
        }
    }
}