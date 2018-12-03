using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

namespace AdventOfCode.AdventOfCode2018
{
    public class Day3
    {
        class Claim
        {
            public int Id { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }

        static IEnumerable<Claim> ParseClaims(string input)
        {
            var lineRegex = new Regex(@"#(?<id>\d+) @ (?<x>\d+),(?<y>\d+): (?<width>\d+)x(?<height>\d+)");
            var claimStrings = input.Split(new[] {"\r\n", "\n"}, StringSplitOptions.RemoveEmptyEntries);
            var claims = claimStrings.Select(
                line =>
                {
                    var match = lineRegex.Match(line);
                    return new Claim
                    {
                        Id = Convert.ToInt32(match.Groups["id"].Value),
                        X = Convert.ToInt32(match.Groups["x"].Value),
                        Y = Convert.ToInt32(match.Groups["y"].Value),
                        Width = Convert.ToInt32(match.Groups["width"].Value),
                        Height = Convert.ToInt32(match.Groups["height"].Value)
                    };
                });
            return claims;
        }

        public static int First(string input)
        {
            var claims = ParseClaims(input);
            Dictionary<(int x, int y), int> positionClaimCounts = new Dictionary<(int x, int y), int>();
            foreach (var claim in claims)
            {
                for (int x = claim.X; x < claim.X + claim.Width; x++)
                for (int y = claim.Y; y < claim.Y + claim.Height; y++)
                {
                    positionClaimCounts[(x, y)] = positionClaimCounts.TryGetValue((x, y), out var val) ? val + 1 : 1;
                }
            }

            return positionClaimCounts.Values.Count(v => v > 1);
        }

        static bool Intersects(Claim a, Claim b) => (b.X < a.X + a.Width && a.X < b.X + b.Width) &&
                                                    (b.Y < a.Y + a.Height && a.Y < b.Y + b.Height);

        public static int Second(string input)
        {
            // list claims and whether they overlap
            var claims = ParseClaims(input).ToArray();

            // for each claim check collision with other claims
            for (int a = 0; a < claims.Length; a++)
            {
                for (int b = 0; b < claims.Length; b++)
                {
                    // ignore self
                    if (a == b) continue;

                    // early exit when we find an overlap
                    if (Intersects(claims[a], claims[b]))
                        goto nextClaim;
                }
                // if we didn't jump, we have no collisions therefore this is our overlapless claim
                return claims[a].Id;
                nextClaim: ;
            }
            
            throw new ArgumentException();
        }
    }
}