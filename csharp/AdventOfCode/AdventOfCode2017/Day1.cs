namespace AdventOfCode.AdventOfCode2017
{
    public class Day1
    {
        public static int First(string input)
        {
            int acc = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == input[(i + 1) % input.Length])
                    acc += int.Parse(input[i].ToString());
            }
            return acc;
        }

        public static int Second(string input)
        {
            int acc = 0;
            int halfLength = input.Length / 2;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == input[(i + halfLength) % input.Length])
                    acc += int.Parse(input[i].ToString());
            }
            return acc;
        }
    }
}