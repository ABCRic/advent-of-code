using System;
using System.Linq;

namespace AdventOfCode.AdventOfCode2016
{
    public class Day3
    {
        public static int First(string input)
        {
            bool ValidTriangle(int a, int b, int c) =>
                a + b > c &&
                a + c > b &&
                b + c > a;

            input = input.Trim();

            return input
                .Split('\n') // for each line
                .Select(l => l
                    .Split(new char[0], StringSplitOptions.RemoveEmptyEntries) // split the numbers
                    .Select(int.Parse) // parse them to ints
                    .ToArray()) // convert to array for indexing
                .Count(t => ValidTriangle(t[0], t[1], t[2])); // count those that are valid triangles
        }

        public static int Second(string input)
        {
            var flat = input
                .Split('\n') // for each line
                .Select(l => l
                    .Split(new char[0], StringSplitOptions.RemoveEmptyEntries) // split the numbers
                    .Select(int.Parse) // parse them to ints
                    .ToArray()) // convert to array for indexing
                .SelectMany(n => n) // flatten
                .ToArray();

            // iterate through input in three interleaved slices
            // e.g. [a, b, c, d, e, f, g, h, i] becomes
            // [a, d, g, b, e, h, c, f, i]
            // and assemble a string matching the format for the first half of the puzzle
            string subInput = "";
            for (int b = 0; b < 3; b++)
            {
                for (int i = 0; i < flat.Length / 3; i += 3)
                {
                    subInput += flat[b + i * 3] + " " + flat[b + (i + 1) * 3] + " " + flat[b + (i + 2) * 3] + "\n";
                }
            }

            // we've converted this into the first problem. delegate
            return First(subInput);
        }
    }
}