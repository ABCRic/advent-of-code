using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.AdventOfCode2018
{
    public class Day1
    {
        public static int First(string input) =>
            input.Split(new[] { ", ", "\n" }, StringSplitOptions.RemoveEmptyEntries).Sum(int.Parse);

        public static int Second(string input)
        {
            HashSet<int> seen = new HashSet<int>{0};
            var changes = input.Split(new[] { ", ", "\n" }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var freq = 0;
            for (int i = 0;; i = (i + 1) % changes.Length)
            {
                freq += changes[i];
                if (!seen.Add(freq))
                    return freq;
            }
        }
    }
}