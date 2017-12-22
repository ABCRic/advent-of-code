using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.AdventOfCode2017
{
    public class Day15
    {
        class Generator
        {
            public long Seed { get; }
            public long Last { private set; get; }
            public long Current { private set; get; }
            public long Multiplier { get; }
            public long Divider { get; }

            public Generator(long seed, long multiplier, long divider)
            {
                Current = seed;
                Seed = seed;
                Multiplier = multiplier;
                Divider = divider;
            }

            public virtual long Next()
            {
                Last = Current;
                return Current = (Last * Multiplier) % Divider;
            }
        }

        public static int First(string input)
        {
            var inputLines = input.Split('\n');
            Generator genA = new Generator(long.Parse(new string(inputLines[0].Skip("Generator A starts with ".Length).ToArray())), 16807L, 2147483647L);
            Generator genB = new Generator(long.Parse(new string(inputLines[1].Skip("Generator B starts with ".Length).ToArray())), 48271L, 2147483647L);

            var tally = 0;
            for (int rounds = 0; rounds < 40_000_000; rounds++)
            {
                if ((genA.Next() & 0xFFFF) == (genB.Next() & 0xFFFF))
                    tally++;
            }
            return tally;
        }

        class PickyGenerator : Generator
        {
            public long CriteriaDivisor { get; }

            public PickyGenerator(long seed, long multiplier, long divider, long criteriaDivisor) : base(seed, multiplier, divider)
            {
                CriteriaDivisor = criteriaDivisor;
            }

            public override long Next()
            {
                while (true)
                {
                    var candidate = base.Next();
                    if (candidate % CriteriaDivisor == 0)
                        return candidate;
                }
            }
        }

        public static int Second(string input)
        {
            var inputLines = input.Split('\n');
            Generator genA = new PickyGenerator(long.Parse(new string(inputLines[0].Skip("Generator A starts with ".Length).ToArray())), 16807L, 2147483647L, 4L);
            Generator genB = new PickyGenerator(long.Parse(new string(inputLines[1].Skip("Generator B starts with ".Length).ToArray())), 48271L, 2147483647L, 8L);

            var tally = 0;
            for (int rounds = 0; rounds < 5_000_000; rounds++)
            {
                if ((genA.Next() & 0xFFFF) == (genB.Next() & 0xFFFF))
                    tally++;
            }
            return tally;
        }
    }
}