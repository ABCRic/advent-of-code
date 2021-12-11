using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.AdventOfCode2021
{
    public static class Day1
    {
        public static long First(string input)
        {
            var numbers = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var increases = 0;
            for(int i = 1; i < numbers.Length; i++)
            {
                if(numbers[i] > numbers[i - 1])
                    increases++;
            }
            return increases;
        }

        public static long Second(string input)
        {
            var numbers = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var increases = 0;
            for (int i = 3; i < numbers.Length; i++)
            {
                if (numbers[i] + numbers[i - 1] + numbers[i - 2] >
                    numbers[i - 1] + numbers[i - 2] + numbers[i - 3])
                {
                    increases++;
                }
            }
            return increases;
        }
    }
}