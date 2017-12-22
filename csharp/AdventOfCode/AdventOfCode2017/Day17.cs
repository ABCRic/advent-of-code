using System.Collections.Generic;

namespace AdventOfCode.AdventOfCode2017
{
    public class Day17
    {
        public static int First(string input)
        {
            int step = int.Parse(input);

            List<int> buffer = new List<int> {0};
            int position = 0;

            for (int i = 1; i <= 2017; i++)
            {
                position = (position + step) % buffer.Count;
                buffer.Insert(position + 1, i);
                position++;
            }

            return buffer[buffer.IndexOf(2017) + 1];
        }
        
        public static int Second(string input)
        {
            int step = int.Parse(input);
            
            int position = 0;
            int result = 0;

            /* our solution is after 0 which is always at the start of the buffer.
             * don't keep a buffer at all, just keep track of the current length (which the index i also is)
             * and track the numbers that should be inserted after position 0 */
            for (int i = 1; i <= 50000000; i++)
            {
                position = (position + step) % i;
                if (position == 0)
                    result = i;
                position++;
            }

            return result;
        }
    }
}