using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.AdventOfCode2020
{
    public static class Day5
    {
        public static long First(string input)
        {
            return input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(ParseSeat)
                .Max(seat => SeatID(seat.row, seat.column));
        }

        public static long SeatID(uint row, uint column) => row * 8 + column;

        public static (uint row, uint column) ParseSeat(string seat)
        {
            var row = Convert.ToUInt32(new string(seat.Take(7).ToArray()).Replace('F', '0').Replace('B', '1'), 2);
            var column = Convert.ToUInt32(new string(seat.Skip(7).Take(3).ToArray()).Replace('L', '0').Replace('R', '1'), 2);
            return (row, column);
        }

        public static long Second(string input)
        {
            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(l => l.Trim()).ToArray();
            var seatIDs = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(ParseSeat).Select(seat => SeatID(seat.row, seat.column)).ToHashSet();

            for(long i = seatIDs.Min(); i < seatIDs.Max(); i++)
            {
                if (!seatIDs.Contains(i))
                    return i;
            }
            throw new ArgumentException();
        }
    }
}