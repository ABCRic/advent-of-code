using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.AdventOfCode2017
{
    public class Day12
    {
        public static int First(string input)
        {
            var edges = new List<(int, int)>();

            // parse edge list
            foreach (var line in input.Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries))
            {
                var parts = line.Split(new []{"<->"}, StringSplitOptions.RemoveEmptyEntries);
                var leftNode = int.Parse(parts[0].Trim());
                var rightNodes = parts[1].Split(',').Select(p => int.Parse(p.Trim()));

                foreach (var rightNode in rightNodes)
                {
                    edges.Add((leftNode, rightNode));
                }
            }


            /* perform BFS starting at 0 to find all reachable nodes. since all edges are bidirectional,
             * all reachable nodes are part of 0's group */
            Queue<int> bfsQueue = new Queue<int>(new[] {0});
            List<int> visitedNodes = new List<int>();

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

            while (bfsQueue.Any())
            {
                var node = bfsQueue.Dequeue();
                if (visitedNodes.Contains(node))
                    continue;
                foreach (var connected in ConnectedTo(node))
                    bfsQueue.Enqueue(connected);
                visitedNodes.Add(node);
            }

            return visitedNodes.Count;
        }

        public static int Second(string input)
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
            for(int node = 0; node <= lastNode; node++)
            {
                if (!nodePreviouslyVisited[node])
                {
                    TraverseGroup(node);
                    groupCount++;
                }
            }

            return groupCount;
        }
    }
}