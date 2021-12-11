using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.AdventOfCode2017
{
    public class Day6
    {
        class IntArrayEqualityComparer : IEqualityComparer<int[]>
        {
            public bool Equals(int[]? x, int[]? y)
            {
                return x == y ||
                    (x != null && y != null && x.SequenceEqual(y));
            }

            public int GetHashCode(int[] arr)
            {
                int hash = arr.Length;
                for (int i = 0; i < arr.Length;i ++)
                {
                    hash += hash * 17 + arr[i];
                }
                return hash;
            }
        }

        public static int First(string input)
        {
            // parse into array of ints
            var buckets = input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            // use a set for storing configurations for quick checking if we already found one
            HashSet<int[]> configurations = new HashSet<int[]>(new IntArrayEqualityComparer());

            // loop until adding config fails (already in set)
            int cycles;
            for(cycles = 0; configurations.Add((int[])buckets.Clone()); cycles++)
            {
                // find max index
                var maxAt = 0;
                int maxVal = 0;
                for (int i = 0; i < buckets.Length; i++)
                {
                    if (buckets[i] > maxVal)
                    {
                        maxAt = i;
                        maxVal = buckets[i];
                    }
                }

                // distribute memory banks
                var toDistribute = maxVal;
                buckets[maxAt] = 0;
                for (int i = (maxAt+1)%buckets.Length; toDistribute > 0; i = (i + 1) % buckets.Length, toDistribute--)
                {
                    buckets[i]++;
                }
            }

            return cycles;
        }

        public static int Second(string input)
        {
            // parse into array of ints
            var buckets = input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            // use a set for storing configurations for quick checking if we already found one
            HashSet<int[]> configurations = new HashSet<int[]>(new IntArrayEqualityComparer());
            // also store (references to) each config and which cycle it was generated in
            List<(int[], int)> configurationStarts = new List<(int[], int)>();

            int cycles;
            for (cycles = 0; ; cycles++)
            {
                var currentConfig = (int[]) buckets.Clone();
                if (!configurations.Add(currentConfig))
                    break;
                configurationStarts.Add((currentConfig, cycles));

                // find max index
                var maxAt = 0;
                int maxVal = 0;
                for (int i = 0; i < buckets.Length; i++)
                {
                    if (buckets[i] > maxVal)
                    {
                        maxAt = i;
                        maxVal = buckets[i];
                    }
                }

                // distribute memory banks
                var toDistribute = maxVal;
                buckets[maxAt] = 0;
                for (int i = (maxAt + 1) % buckets.Length; toDistribute > 0; i = (i + 1) % buckets.Length, toDistribute--)
                {
                    buckets[i]++;
                }
            }

            // return cycles since this config was first found
            return cycles - configurationStarts.First(o => buckets.SequenceEqual(o.Item1)).Item2;
        }
    }
}