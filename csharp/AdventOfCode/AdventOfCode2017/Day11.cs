using System;

namespace AdventOfCode.AdventOfCode2017
{
    public class Day11
    {
        public static int First(string input)
        {
            var steps = input.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

            /* use cube coordinates for the hex grid, with the x axis pointing right,
             * the y axis pointing up-left, and the z axis pointing down-left.
             * see https://www.redblobgames.com/grids/hexagons/ */
            int x = 0, y = 0, z = 0;

            foreach (var step in steps)
            {
                switch (step)
                {
                    case "n":
                        y++;
                        z--;
                        break;
                    case "s":
                        y--;
                        z++;
                        break;
                    case "ne":
                        x++;
                        z--;
                        break;
                    case "sw":
                        x--;
                        z++;
                        break;
                    case "nw":
                        y++;
                        x--;
                        break;
                    case "se":
                        y--;
                        x++;
                        break;
                }
            }

            // adjacent hexes are 2 manhattan distance apart. Calc distance then divide by 2
            return (Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2;
        }

        public static int Second(string input)
        {
            var steps = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            /* use cube coordinates for the hex grid, with the x axis pointing right,
             * the y axis pointing up-left, and the z axis pointing down-left.
             * see https://www.redblobgames.com/grids/hexagons/ */
            int x = 0, y = 0, z = 0;
            int maxDistance = 0;

            foreach (var step in steps)
            {
                switch (step)
                {
                    case "n":
                        y++;
                        z--;
                        break;
                    case "s":
                        y--;
                        z++;
                        break;
                    case "ne":
                        x++;
                        z--;
                        break;
                    case "sw":
                        x--;
                        z++;
                        break;
                    case "nw":
                        y++;
                        x--;
                        break;
                    case "se":
                        y--;
                        x++;
                        break;
                }
                maxDistance = Math.Max((Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2, maxDistance);
            }

            // adjacent hexes are 2 manhattan distance apart. Calc distance then divide by 2
            return maxDistance;
        }
    }
}