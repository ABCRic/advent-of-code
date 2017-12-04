using System;
using System.Linq;

namespace AdventOfCode.AdventOfCode2017
{
    public class Day4
    {
        public static int First(string input)
        {
            return input
                .Split(new [] {'\n'}, StringSplitOptions.RemoveEmptyEntries) // for each line
                .Select(phrase => phrase.Split(new char[0], StringSplitOptions.RemoveEmptyEntries)) // split words
                .Count(phraseWords => !phraseWords.GroupBy(word => word).Any(group => group.Count() > 1)); // count those with no words with more than 1 occurrence
        }

        public static int Second(string input)
        {
            return input
                .Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries) // for each line
                .Select(phrase => phrase.Split(new char[0], StringSplitOptions.RemoveEmptyEntries) // split words
                    .Select(word => new string(word.OrderBy(c => c).ToArray()))) // order each word's letters
                .Count(phraseWords => !phraseWords.GroupBy(word => word).Any(group => group.Count() > 1)); // count those with no "words" (words with reordered letters) with more than 1 occurrence)
        }
    }
}