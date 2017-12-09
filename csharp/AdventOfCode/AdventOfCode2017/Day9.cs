namespace AdventOfCode.AdventOfCode2017
{
    public class Day9
    {
        public static int First(string input)
        {
            int cursor = 0;
            int CalculateScore(string substr, int depth = 0)
            {
                int score = depth;
                bool inGarbage = false;
                while (cursor < input.Length)
                {
                    switch (substr[cursor])
                    {
                        case '{' when !inGarbage:
                            cursor++;
                            score += CalculateScore(substr, depth + 1);
                            break;
                        case '}' when !inGarbage:
                            cursor++;
                            return score;
                        case '!':
                            cursor += 2;
                            break;
                        case '<' when !inGarbage:
                            inGarbage = true;
                            cursor++;
                            break;
                        case '>':
                            inGarbage = false;
                            cursor++;
                            break;
                        default:
                            cursor++;
                            break;
                    }
                }
                return score;
            }

            return CalculateScore(input);
        }

        public static int Second(string input)
        {
            int garbageRemoved = 0;
            int cursor = 0;
            void Parse(string substr)
            {
                bool inGarbage = false;
                while (cursor < input.Length)
                {
                    switch (substr[cursor])
                    {
                        case '{' when !inGarbage:
                            cursor++;
                            Parse(substr);
                            break;
                        case '}' when !inGarbage:
                            cursor++;
                            return;
                        case '!':
                            cursor += 2;
                            break;
                        case '<' when !inGarbage:
                            inGarbage = true;
                            cursor++;
                            break;
                        case '>':
                            inGarbage = false;
                            cursor++;
                            break;
                        default:
                            if (inGarbage)
                                garbageRemoved++;
                            cursor++;
                            break;
                    }
                }
            }

            Parse(input);
            return garbageRemoved;
        }
    }
}