using System.Linq;

namespace AdventOfCode.AdventOfCode2017
{
    public class Day2
    {
        public static int First(string input)
        {
            input = input.Trim();

            return
                input.Split('\n') // split into lines
                    .Select(l => l.Split('\t', ' ').Select(int.Parse).ToArray()) // split each line into arrays of its numbers
                    .Select(l => l.Max() - l.Min()) // sum the difference of the max and min of each line
                    .Sum(); // sum over every line
        }

        public static int Second(string input)
        {
            input = input.Trim();

            // split into array of ints for each line
            var lines = input.Split('\n').Select(l => l.Split('\t', ' ').Select(int.Parse).ToArray());
            var sum = 0;
            
            foreach (var line in lines)
            {
                // iterate over line
                for (int i = 0; i < line.Length; i++)
                {
                    // iterate over other numbers down the line
                    for (int j = i + 1; j < line.Length; j++)
                    {
                        // check divisibility both ways. If either verify, add to sum and jump to next line
                        if (line[i] % line[j] == 0)
                        {
                            sum += line[i] / line[j];
                            goto nextline;
                        }
                        else if (line[j] % line[i] == 0)
                        {
                            sum += line[j] / line[i];
                            goto nextline;
                        }
                    }
                }
                nextline: {}
            }
            return sum;
        }
    }
}