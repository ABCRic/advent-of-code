using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.AdventOfCode2017
{
    public class Day16
    {
        public static string First(string input)
        {
            // keep track of a virtual head instead of spinning the proper contents
            int virtualHead = 0;
            char[] programs = "abcdefghijklmnop".ToCharArray();

            foreach (var instruction in input.Split(','))
            {
                switch (instruction[0])
                {
                    case 's':
                        // swapping is just moving where the head points to
                        virtualHead = (virtualHead - int.Parse(instruction.Substring(1))) % programs.Length;
                        if (virtualHead < 0)
                            virtualHead = programs.Length + virtualHead;
                        break;
                    case 'x':
                        var parameters = instruction.Substring(1).Split('/');
                        // calculate the indexes relative to the head
                        var virtualLeftPos = (int.Parse(parameters[0]) + virtualHead) % programs.Length;
                        var virtualRightPos = (int.Parse(parameters[1]) + virtualHead) % programs.Length;
                        (programs[virtualLeftPos], programs[virtualRightPos]) =
                            (programs[virtualRightPos], programs[virtualLeftPos]);
                        break;
                    case 'p':
                        var leftProg = instruction[1];
                        var rightProg = instruction[3];
                        // find where the programs are and swap them
                        var leftIndex = Array.IndexOf(programs, leftProg);
                        var rightIndex = Array.IndexOf(programs, rightProg);
                        (programs[leftIndex], programs[rightIndex]) =
                            (programs[rightIndex], programs[leftIndex]);
                        break;
                }
            }

            return new string(Enumerable.Concat(programs.Skip(virtualHead), programs.Take(virtualHead)).ToArray());
        }
        
        public static string Second(string input)
        {
            // keep track of a virtual head instead of spinning the proper contents
            int virtualHead = 0;
            char[] programs = "abcdefghijklmnop".ToCharArray();
            // store configurations we've seen for cycle detection
            var seenConfigs = new Dictionary<string, int>
            {
                [new string(Enumerable.Concat(programs.Skip(virtualHead), programs.Take(virtualHead)).ToArray())] = 0
            };

            int i = 1;
            for (; i <= 1_000_000_00; i++)
            {
                foreach (var instruction in input.Split(','))
                {
                    switch (instruction[0])
                    {
                        case 's':
                            // swapping is just moving where the head points to
                            virtualHead = (virtualHead - int.Parse(instruction.Substring(1))) % programs.Length;
                            if (virtualHead < 0)
                                virtualHead = programs.Length + virtualHead;
                            break;
                        case 'x':
                            var parameters = instruction.Substring(1).Split('/');
                            // calculate the indexes relative to the head
                            var virtualLeftPos = (int.Parse(parameters[0]) + virtualHead) % programs.Length;
                            var virtualRightPos = (int.Parse(parameters[1]) + virtualHead) % programs.Length;
                            (programs[virtualLeftPos], programs[virtualRightPos]) =
                                (programs[virtualRightPos], programs[virtualLeftPos]);
                            break;
                        case 'p':
                            var leftProg = instruction[1];
                            var rightProg = instruction[3];
                            // find where the programs are and swap them
                            var leftIndex = Array.IndexOf(programs, leftProg);
                            var rightIndex = Array.IndexOf(programs, rightProg);
                            (programs[leftIndex], programs[rightIndex]) =
                                (programs[rightIndex], programs[leftIndex]);
                            break;
                    }
                }

                if (seenConfigs.TryGetValue(
                    new string(Enumerable.Concat(programs.Skip(virtualHead), programs.Take(virtualHead)).ToArray()),
                    out var seenAt))
                {
                    // cycle found. save the real iteration number sans the cyclical parts
                    int cycleSize = i - seenAt;
                    i = 1_000_000_000 % cycleSize;
                    break;
                }
                else
                {
                    seenConfigs.Add(
                        new string(Enumerable.Concat(programs.Skip(virtualHead), programs.Take(virtualHead)).ToArray()), i);
                }
            }

            // retrieve solution
            return seenConfigs.First(pair => pair.Value == i).Key;
        }
    }
}