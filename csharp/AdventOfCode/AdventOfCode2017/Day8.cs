using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.AdventOfCode2017
{
    public class Day8
    {
        class Instruction
        {
            public string Register;
            public bool Increment;
            public int Amount;
            public string ConditionRegister;
            public string ConditionOp;
            public int ConditionAmount;
        }

        private static Dictionary<string, Func<int, int, bool>> ops = new Dictionary<string, Func<int, int, bool>>
        {
            [">"] = (a, b) => a > b,
            [">="] = (a, b) => a >= b,
            ["<"] = (a, b) => a < b,
            ["<="] = (a, b) => a <= b,
            ["=="] = (a, b) => a == b,
            ["!="] = (a, b) => a != b
        };

        public static int First(string input)
        {
            // parse
            List<Instruction> instructions = new List<Instruction>();
            foreach (var line in input.Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries))
            {
                var parts = line.Split();
                instructions.Add(new Instruction
                {
                    Register = parts[0],
                    Increment = parts[1] == "inc",
                    Amount = int.Parse(parts[2]),
                    ConditionRegister = parts[4],
                    ConditionOp = parts[5],
                    ConditionAmount = int.Parse(parts[6])
                });
            }

            // execute
            var registers = new Dictionary<string, int>();
            foreach (var instr in instructions)
            {
                // check condition
                var fetch = registers.ContainsKey(instr.ConditionRegister) ? registers[instr.ConditionRegister] : 0;
                if (ops[instr.ConditionOp](fetch, instr.ConditionAmount))
                {
                    var value = registers.ContainsKey(instr.Register) ? registers[instr.Register] : 0;
                    if (instr.Increment)
                        value += instr.Amount;
                    else
                        value -= instr.Amount;
                    registers[instr.Register] = value;
                }
            }

            return registers.Max(pair => pair.Value);
        }

        public static int Second(string input)
        {
            // parse
            List<Instruction> instructions = new List<Instruction>();
            foreach (var line in input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var parts = line.Split();
                instructions.Add(new Instruction
                {
                    Register = parts[0],
                    Increment = parts[1] == "inc",
                    Amount = int.Parse(parts[2]),
                    ConditionRegister = parts[4],
                    ConditionOp = parts[5],
                    ConditionAmount = int.Parse(parts[6])
                });
            }

            // execute
            var registers = new Dictionary<string, int>();
            int max = 0;
            foreach (var instr in instructions)
            {
                // check condition
                var fetch = registers.ContainsKey(instr.ConditionRegister) ? registers[instr.ConditionRegister] : 0;
                if (ops[instr.ConditionOp](fetch, instr.ConditionAmount))
                {
                    var value = registers.ContainsKey(instr.Register) ? registers[instr.Register] : 0;
                    if (instr.Increment)
                        value += instr.Amount;
                    else
                        value -= instr.Amount;
                    registers[instr.Register] = value;

                    max = Math.Max(max, value);
                }
            }

            return max;
        }
    }
}