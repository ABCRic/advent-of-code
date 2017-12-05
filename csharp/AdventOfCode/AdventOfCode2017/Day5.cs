using System;
using System.Linq;

namespace AdventOfCode.AdventOfCode2017
{
    public class Day5
    {
        public static int First(string input)
        {
            var instructions = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int steps = 0;
            // iterate until program counter is outside array
            for (int programCounter = 0; programCounter >= 0 && programCounter < instructions.Length; steps++)
            {
                programCounter += instructions[programCounter]++;
            }
            return steps;
        }

        public static int Second(string input)
        {
            var instructions = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int steps = 0;
            // iterate until program counter is outside array
            for (int programCounter = 0; programCounter >= 0 && programCounter < instructions.Length; steps++)
            {
                var jump = instructions[programCounter];
                if (jump >= 3)
                    instructions[programCounter]--;
                else
                    instructions[programCounter]++;
                programCounter += jump;
            }
            return steps;
        }
    }
}