using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.AdventOfCode2019
{
    public static class Day4
    {
        static bool ValidatePassword(int password)
        {
            var digits = password.ToString().Select(c => int.Parse(c.ToString())).ToArray();
            bool hasAdjacentDuplicates = false;
            for (int i = 1; i < digits.Length; i++)
            {
                if (digits[i - 1] == digits[i])
                    hasAdjacentDuplicates = true;

                if (digits[i] < digits[i - 1])
                    return false;
            }
            return hasAdjacentDuplicates;
        }

        static bool ValidatePassword2(int password)
        {
            var digits = password.ToString().Select(c => int.Parse(c.ToString())).ToArray();
            for (int i = 1; i < digits.Length; i++)
            {
                if (digits[i] < digits[i - 1])
                    return false;
            }
            return Regex.IsMatch(password.ToString(), "(?<!\\1)(.)(\\1)(?!\\1)");
        }

        public static int First(string input)
        {
            var min = int.Parse(input.Substring(0, 6));
            var max = int.Parse(input.Substring(7, 6));
            return Enumerable.Range(min, max - min).Count(ValidatePassword);
        }

        public static int Second(string input)
        {
            var min = int.Parse(input.Substring(0, 6));
            var max = int.Parse(input.Substring(7, 6));
            return Enumerable.Range(min, max - min).Count(ValidatePassword2);
        }
    }
}