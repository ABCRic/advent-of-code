using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.AdventOfCode2019
{
    public static class Day2
    {
        public static int RunIntcode(int[] memory)
        {
            int pc = 0;
            while (true)
            {
                switch (memory[pc])
                {
                    case 1:
                        memory[memory[pc + 3]] = memory[memory[pc + 2]] + memory[memory[pc + 1]];
                        break;
                    case 2:
                        memory[memory[pc + 3]] = memory[memory[pc + 2]] * memory[memory[pc + 1]];
                        break;
                    case 99:
                        goto end;
                    default:
                        throw new InvalidOperationException("bad opcode");
                }
                pc += 4;
            }
            end:
            return memory[0];
        }

        public static int First(string input)
        {
            var tape = input.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            // restore pre-fire state
            tape[1] = 12;
            tape[2] = 2;

            return RunIntcode(tape);
        }

        public static int Second(string input)
        {
            var tape = input.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            // test all combinations
            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    var newTape = (int[])tape.Clone();
                    newTape[1] = noun;
                    newTape[2] = verb;
                    try
                    {
                        if (RunIntcode(newTape) == 19690720)
                            return 100 * noun + verb;
                    } catch(InvalidOperationException) { }
                }
            }
            throw new ArgumentException("no solution");
        }
    }
}