using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.AdventOfCode2018
{
    public class Day2
    {
        public static int First(string input)
        {
            var lines = input.Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);
            var doubles = 0;
            var triples = 0;
            foreach (var line in lines)
            {
                var occurences = new Dictionary<char, int>();
                bool hasDouble = false,
                     hasTriple = false;
                foreach (var ch in line)
                    occurences[ch] = occurences.TryGetValue(ch, out int v) ? v + 1 : 1;

                foreach (var count in occurences.Values)
                {
                    if (count == 2)
                        hasDouble = true;
                    else if (count == 3)
                        hasTriple = true;
                }

                if (hasDouble)
                    doubles++;
                if (hasTriple)
                    triples++;
            }
            return doubles * triples;
        }

        public static string Second(string input)
        {
            var lines = input.Split(new[] {"\r\n", "\n"}, StringSplitOptions.RemoveEmptyEntries);

            for(int i = 0; i < lines.Length; i++)
            {
                for (int j = i + 1; j < lines.Length; j++)
                {
                    int diffCount = 0;
                    int diffPosition = 0;
                    for (int x = 0; x < lines[i].Length; x++)
                    {
                        if (lines[i][x] != lines[j][x])
                        {
                            diffCount++;
                            diffPosition = x;
                        }
                    }

                    if (diffCount == 1)
                    {
                        return lines[i].Substring(0, diffPosition) + (diffPosition < lines[i].Length ? lines[i].Substring(diffPosition + 1) : "");
                    }
                }
            }

            throw new ArgumentException();
        }
    }
}