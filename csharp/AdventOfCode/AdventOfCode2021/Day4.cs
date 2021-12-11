using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.AdventOfCode2021
{
    public static class Day4
    {
        public record Board((int Number, bool Found)[][] Numbers)
        {
            const int BoardSize = 5;

            public bool Put(int number)
            {
                for(int y = 0; y < BoardSize; y++)
                {
                    for(int x = 0; x < BoardSize; x++)
                    {
                        if(Numbers[y][x].Number == number)
                        {
                            Numbers[y][x].Found = true;

                            // check if all found in row
                            if (Enumerable.Range(0, BoardSize).Select(checkX => Numbers[y][checkX]).All(n => n.Found))
                                return true;
                            // check if all found in column
                            if (Enumerable.Range(0, BoardSize).Select(checkY => Numbers[checkY][x]).All(n => n.Found))
                                return true;
                        }
                    }
                }
                return false;
            }
        }

        public static long First(string input)
        {
            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(l => l.Trim()).ToArray();

            // load numbers
            var numbers = lines[0].Split(',').Select(int.Parse).ToArray();

            // load boards
            var boards = new List<Board>();
            for(int i = 1; i < lines.Length; i += 6)
            {
                // line 1: blank
                // lines 2-6: bingo board
                boards.Add(new Board(
                    new[]
                    {
                        lines[i + 1].Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(n => (int.Parse(n), false)).ToArray(),
                        lines[i + 2].Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(n => (int.Parse(n), false)).ToArray(),
                        lines[i + 3].Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(n => (int.Parse(n), false)).ToArray(),
                        lines[i + 4].Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(n => (int.Parse(n), false)).ToArray(),
                        lines[i + 5].Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(n => (int.Parse(n), false)).ToArray(),
                    }
                    ));
            }

            // run bingo until first board wins
            foreach(var number in numbers)
            {
                foreach(var board in boards)
                {
                    if(board.Put(number))
                    {
                        return board.Numbers.SelectMany(row => row).Where(n => !n.Found).Sum(n => n.Number) * number;
                    }
                }
            }
            throw new ArgumentException("No solution");
        }

        record BoardWithDone((int Number, bool Found)[][] Numbers) : Board(Numbers)
        {
            public bool Done { get; set; } = false;
        }

        public static long Second(string input)
        {
            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(l => l.Trim()).ToArray();

            // load numbers
            var numbers = lines[0].Split(',').Select(int.Parse).ToArray();

            // load boards
            var boards = new List<BoardWithDone>();
            for (int i = 1; i < lines.Length; i += 6)
            {
                // line 1: blank
                // lines 2-6: bingo board
                boards.Add(new BoardWithDone(
                    new[]
                    {
                        lines[i + 1].Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(n => (int.Parse(n), false)).ToArray(),
                        lines[i + 2].Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(n => (int.Parse(n), false)).ToArray(),
                        lines[i + 3].Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(n => (int.Parse(n), false)).ToArray(),
                        lines[i + 4].Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(n => (int.Parse(n), false)).ToArray(),
                        lines[i + 5].Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(n => (int.Parse(n), false)).ToArray(),
                    }
                    ));
            }

            // run bingo until last board wins
            int boardsLeft = boards.Count;
            foreach (var number in numbers)
            {
                foreach (var board in boards.Where(b => !b.Done))
                {
                    if (board.Put(number))
                    {
                        if(boardsLeft == 1)
                        {
                            return board.Numbers.SelectMany(row => row).Where(n => !n.Found).Sum(n => n.Number) * number;
                        }

                        boardsLeft--;
                        board.Done = true;
                    }
                }
            }
            throw new ArgumentException("No solution");
        }
    }
}