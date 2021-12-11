using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.AdventOfCode2021
{
    public static class Day3
    {
        public static ulong First(string input)
        {
            var numbers = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(l => l.Trim()).ToArray();

            // peek at length of numbers
            var numberLength = numbers[0].Length;

            // find most common digit per place by computing running balance (positive = more 1s, negative = more 0s)
            var balancePerDigitPlace = new int[numberLength];
            foreach(var number in numbers)
            {
                for(int i = 0; i < numberLength; i++)
                {
                    if(number[i] == '1')
                        balancePerDigitPlace[i]++;
                    else
                        balancePerDigitPlace[i]--;
                }
            }

            // add up binary digits
            ulong gammaRate = 0;
            ulong epsilonRate = 0;
            for(int i = 0; i < numberLength; i++)
            {
                if (balancePerDigitPlace[i] > 0)
                    gammaRate |= 1UL << (numberLength - i - 1);
                if (balancePerDigitPlace[i] < 0)
                    epsilonRate |= 1UL << (numberLength - i - 1);
            }
            return gammaRate * epsilonRate;
        }

        public static ulong Second(string input)
        {
            var numbers = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(l => l.Trim()).ToArray();

            var numberLength = numbers[0].Length;

            static char findMostCommon(string[] liveNumbers, int index, bool invert)
            {
                // find most common digit per place by computing running balance (positive = more 1s, negative = more 0s)
                int balance = 0;
                foreach (var number in liveNumbers)
                {
                    if (number[index] == '1')
                        balance++;
                    else
                        balance--;
                }
                return balance >= 0 ^ invert ? '1' : '0';
            }

            int i = 0;
            var oxygenNumbers = (string[])numbers.Clone();
            while (oxygenNumbers.Length > 1)
            {
                var mostCommon = findMostCommon(oxygenNumbers, i, false);
                oxygenNumbers = oxygenNumbers.Where(n => n[i] == mostCommon).ToArray();
                i++;
            }

            i = 0;
            var co2Numbers = (string[])numbers.Clone();
            while (co2Numbers.Length > 1)
            {
                var leastCommon = findMostCommon(co2Numbers, i, true);
                co2Numbers = co2Numbers.Where(n => n[i] == leastCommon).ToArray();
                i++;
            }

            // add up binary digits
            ulong oxygen = 0;
            ulong co2 = 0;
            for (int j = 0; j < numberLength; j++)
            {
                if (oxygenNumbers[0][j] == '1')
                    oxygen |= 1UL << (numberLength - j - 1);
                if (co2Numbers[0][j] == '1')
                    co2 |= 1UL << (numberLength - j - 1);
            }
            return oxygen * co2;
        }
    }
}