using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.AdventOfCode2020
{
    public static class Day1
    {
        public static long First(string input)
        {
            var numbers = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();
            foreach(var num in numbers)
            {
                // check if the complement (vs 2020) exists
                if (numbers.Contains(2020 - num))
                    return num * (2020 - num);
            }
            throw new ArgumentException("No solution.");
        }

        public static long Second(string input)
        {
            var numbers = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();
            // for each first number
            foreach (var num1 in numbers)
            {
                // repeat the same logic as in First() but using the first numbers as anchor
                foreach (var num2 in numbers)
                {
                    if (numbers.Contains(2020 - num1 - num2))
                    {
                        return num1 * num2 * (2020 - num1 - num2);
                    }
                }
            }
            throw new ArgumentException("No solution.");
        }
    }
}