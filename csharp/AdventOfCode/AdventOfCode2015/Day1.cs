namespace AdventOfCode.AdventOfCode2015
{
    public class Day1
    {
        public static int First(string input)
        {
            int floor = 0;
            foreach (var i in input)
            {
                if (i == '(')
                    floor++;
                else if (i == ')')
                    floor--;
            }
            return floor;
        }

        public static int Second(string input)
        {
            int floor = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var current = input[i];
                if (current == '(')
                    floor++;
                else if (current == ')')
                    floor--;
                if (floor < 0)
                    return i + 1; // problem requires 1-indexed solution
            }
            return -1;
        }
    }
}