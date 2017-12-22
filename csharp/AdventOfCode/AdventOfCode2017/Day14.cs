using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.AdventOfCode2017
{
    public class Day14
    {
        public static int First(string input)
        {
            // lookup table for number of set bits for each hex digit
            Dictionary<char, int> hexBits = new Dictionary<char, int>
            {
                ['0'] = 0,
                ['1'] = 1,
                ['2'] = 1,
                ['3'] = 2,
                ['4'] = 1,
                ['5'] = 2,
                ['6'] = 2,
                ['7'] = 3,
                ['8'] = 1,
                ['9'] = 2,
                ['a'] = 2,
                ['b'] = 3,
                ['c'] = 2,
                ['d'] = 3,
                ['e'] = 3,
                ['f'] = 4,
            };

            var used = 0;
            // over all hashes...
            for (int i = 0; i < 128; i++)
            {
                var hash = Day10.Second($"{input}-{i}");
                // sum the number of set bits.
                foreach (var c in hash)
                {
                    used += hexBits[c];
                }
            }
            return used;
        }

        public static int Second(string input)
        {
            Dictionary<char, string> hexCharBinString = new Dictionary<char, string> {
                ['0'] = "0000",
                ['1'] = "0001",
                ['2'] = "0010",
                ['3'] = "0011",
                ['4'] = "0100",
                ['5'] = "0101",
                ['6'] = "0110",
                ['7'] = "0111",
                ['8'] = "1000",
                ['9'] = "1001",
                ['a'] = "1010",
                ['b'] = "1011",
                ['c'] = "1100",
                ['d'] = "1101",
                ['e'] = "1110",
                ['f'] = "1111",
            };

            bool[,] lines = new bool[128, 128];
            for (int y = 0; y < 128; y++)
            {
                var hash = Day10.Second($"{input}-{y}");
                var bits = string.Join("", hash.Select(c => hexCharBinString[c]));
                for (int x = 0; x < 128; x++)
                {
                    lines[x, y] = bits[x] == '1';
                }
                
            }

            var graphInput = "";
            for (int y = 0; y < 128; y++)
            {
                for (int x = 0; x < 128; x++)
                {
                    if (lines[x, y])
                    {
                        var adjacents = new List<int>();
                        if (y > 0 && lines[x, y - 1])
                            adjacents.Add(x + (y - 1) * 128);
                        if (y < 127 && lines[x, y + 1])
                            adjacents.Add(x + (y + 1) * 128);
                        if (x > 0 && lines[x - 1, y])
                            adjacents.Add((x - 1) + y * 128);
                        if (x < 127 && lines[x + 1, y])
                            adjacents.Add((x + 1) + y * 128);

                        if(adjacents.Any())
                            graphInput += (x + y * 128) + " <-> " + string.Join(", ", adjacents) + '\n';
                    }
                }
            }

            return ConnectedGroups(graphInput, lines);
        }

        // modified version of Day12.Second that doesn't assume all numbers are valid nodes, checks the nodes matrix instead
        private static int ConnectedGroups(string input, bool[,] nodes)
        {
            var edges = new List<(int, int)>();

            // parse edge list
            foreach (var line in input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var parts = line.Split(new[] { "<->" }, StringSplitOptions.RemoveEmptyEntries);
                var leftNode = int.Parse(parts[0].Trim());
                var rightNodes = parts[1].Split(',').Select(p => int.Parse(p.Trim()));

                foreach (var rightNode in rightNodes)
                {
                    edges.Add((leftNode, rightNode));
                }
            }

            // nodes in input are sorted by left side with no gaps
            var lastNode = edges[edges.Count - 1].Item1;

            bool[] nodePreviouslyVisited = new bool[lastNode + 1];

            /* returns all nodes the specified node is connected to
             * we ignore that the input is complete (each line contains all nodes the left is connected to)
             * in favor of a more generic approach */
            IEnumerable<int> ConnectedTo(int from)
            {
                foreach (var edge in edges)
                {
                    if (edge.Item1 == from)
                        yield return edge.Item2;
                    else if (edge.Item2 == from)
                        yield return edge.Item1;
                }
            }

            /* traverses a group starting at a root. marks all traversed nodes as visited */
            void TraverseGroup(int root)
            {
                List<int> visitedNodes = new List<int>();
                Queue<int> bfsQueue = new Queue<int>(new[] { root });
                while (bfsQueue.Any())
                {
                    var node = bfsQueue.Dequeue();
                    if (visitedNodes.Contains(node))
                        continue;
                    //if (nodePreviouslyVisited[node])
                    //    return false;
                    foreach (var connected in ConnectedTo(node))
                        bfsQueue.Enqueue(connected);
                    visitedNodes.Add(node);
                }
                visitedNodes.ForEach(n => nodePreviouslyVisited[n] = true);
            }

            /* iterate over all nodes. don't start traversals on those already reached */
            int groupCount = 0;
            for (int node = 0; node <= lastNode; node++)
            {
                // modified part: node existence check added here
                // the previous code started traversals at every possible node number because they all existed
                if (!nodePreviouslyVisited[node] && nodes[node % 128, node / 128])
                {
                    TraverseGroup(node);
                    groupCount++;
                }
            }

            return groupCount;
        }
    }
}