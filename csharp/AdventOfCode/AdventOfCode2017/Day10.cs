using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.AdventOfCode2017
{
    public class Day10
    {
        public static int First(string input, int listLength = 256)
        {
            var list = Enumerable.Range(0, listLength).ToArray();
            int currentPosition = 0;
            int skipSize = 0;
            var lengths = input.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

            // circular iterator over the list
            IEnumerable<int> Circular(int startAt)
            {
                while (true)
                    yield return list[startAt++ % list.Length];
            }

            foreach (var length in lengths)
            {
                // reverse subset of this length, wrapping around
                using (var iter = Circular(currentPosition).Take(length).Reverse().GetEnumerator())
                {
                    iter.MoveNext();
                    for (int i = currentPosition; i < currentPosition + length; i++, iter.MoveNext())
                        list[i % list.Length] = iter.Current;
                }

                // advance cursor
                currentPosition = (currentPosition + length + skipSize) % list.Length;

                skipSize++;
            }

            return list[0] * list[1];
        }

        public static string Second(string input, int listLength = 256)
        {
            var lengths = input.Select(Convert.ToInt32).Concat(new[] {17, 31, 73, 47, 23}).ToArray();
            var list = Enumerable.Range(0, listLength).ToArray();
            int currentPosition = 0;
            int skipSize = 0;

            // circular iterator over the list
            IEnumerable<int> Circular(int startAt)
            {
                while (true)
                    yield return list[startAt++ % list.Length];
            }

            // 64 rounds of the previous algo
            for (int round = 0; round < 64; round++)
            {
                foreach (var length in lengths)
                {
                    // reverse subset of this length, wrapping around
                    using (var iter = Circular(currentPosition).Take(length).Reverse().GetEnumerator())
                    {
                        iter.MoveNext();
                        for (int i = currentPosition; i < currentPosition + length; i++, iter.MoveNext())
                            list[i % list.Length] = iter.Current;
                    }

                    // advance cursor
                    currentPosition = (currentPosition + length + skipSize) % list.Length;

                    skipSize++;
                }
            }

            // XOR-hash list items in blocks of 16
            var hash = new int[listLength / 16];
            for (int block = 0; block < hash.Length; block++)
            {
                var blockhash = list[block * 16];
                for (int i = block * 16 + 1; i < block * 16 + 16; i++)
                    blockhash ^= list[i];
                hash[block] = blockhash;
            }

            // return hex representation, 2 digits per list item
            return string.Join("", hash.Select(i => i.ToString("x2")));
        }
    }
}