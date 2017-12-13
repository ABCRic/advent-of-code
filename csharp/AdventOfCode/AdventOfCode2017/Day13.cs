using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.AdventOfCode2017
{
    public class Day13
    {
        public static int First(string input)
        {
            // parse input into dictionary of depths->ranges
            Dictionary<int, int> ranges = new Dictionary<int, int>();
            foreach (var line in input.Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries))
            {
                var parts = line.Split(new[] {": "}, StringSplitOptions.None);
                var depth = int.Parse(parts[0]);
                var range = int.Parse(parts[1]);
                ranges.Add(depth, range);
            }

            // iterate over every depth
            int lastDepth = ranges.Keys.Max();
            int severity = 0;
            for (int i = 0; i <= lastDepth; i++)
            {
                // if depth has a scanner...
                if (ranges.TryGetValue(i, out int range))
                {
                    /* calculate whether it coincides with our position. i is the tick at which we will be in the layer.
                     * The scanner crosses the entire layer every (range - 1) ticks. Therefore it will be at the top at every
                     * tick that is a multiple of (range - 1) * 2 ticks. Check against i to know if we get caught. */
                    if (i % ((range - 1) * 2) == 0)
                        severity += i * range;
                }
            }
            return severity;
        }

        public static int Second(string input)
        {
            // parse input into dictionary of depths->ranges
            Dictionary<int, int> ranges = new Dictionary<int, int>();
            foreach (var line in input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var parts = line.Split(new[] { ": " }, StringSplitOptions.None);
                var depth = int.Parse(parts[0]);
                var range = int.Parse(parts[1]);
                ranges.Add(depth, range);
            }

            int lastDepth = ranges.Keys.Max();
            int delay = 0;
            while(true)
            {
                var caught = false;
                // iterate over every depth
                for (int i = 0; i <= lastDepth; i++)
                {
                    // if depth has a scanner...
                    if (ranges.TryGetValue(i, out int range))
                    {
                        /* calculate whether it coincides with our position. i + delay is the tick at which we will be in the layer.
                         * The scanner crosses the entire layer every (range - 1) ticks. Therefore it will be at the top at every
                         * tick that is a multiple of (range - 1) * 2 ticks. Check against i + delay to know if we get caught. */
                        if ((i + delay) % ((range - 1) * 2) == 0)
                            caught = true;
                    }
                }
                if (!caught)
                    break;
                delay++;
            }
            return delay;
        }
    }
}