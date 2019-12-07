using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.AdventOfCode2019
{
    public static class Day1
    {
        static long CalculateFuel(long mass) => (long)Math.Floor(mass / 3.0) - 2;

        static long RecursiveCalculateFuel(long mass)
        {
            var fuel = CalculateFuel(mass);
            if (fuel > 0)
                return fuel + RecursiveCalculateFuel(fuel);
            else
                return 0;
        }

        public static long First(string input) =>
            input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                 .Select(long.Parse)
                 .Select(CalculateFuel)
                 .Sum();

        public static long Second(string input)
        {
            return input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                 .Select(long.Parse)
                 .Select(RecursiveCalculateFuel)
                 .Sum();
        }
    }
}