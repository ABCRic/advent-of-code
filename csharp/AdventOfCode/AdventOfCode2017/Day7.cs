using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.AdventOfCode2017
{
    public class Day7
    {
        public static string First(string input)
        {
            // parse per line
            var lines = input.Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);
            var edges = new List<(string From, string To)>();

            foreach (var line in lines)
            {
                // only care about edges
                if (line.Contains("->"))
                {
                    var lineParts = line.Split(new[] {"->"},StringSplitOptions.RemoveEmptyEntries);
                    var head = Regex.Match(lineParts[0], @"\w+").Value;
                    var children = lineParts[1].Split(',').Select(c => c.Trim());
                    foreach (var child in children)
                    {
                        edges.Add((head, child));
                    }
                }
            }

            // walk backwards from first node
            string current = edges[0].From;
            while (true)
            {
                var edgeToCurrent = edges.FirstOrDefault(e => e.To == current);

                // if no edges point at current, we're at the root
                if (edgeToCurrent.Equals((null, null)))
                    break;

                current = edgeToCurrent.From;
            }

            return current;
        }

        class Node
        {
            public int Value;
            public List<string> Children = new List<string>();
        }

        public static int Second(string input)
        {
            // parse per line
            var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var nodes = new Dictionary<string, Node>();

            foreach (var line in lines)
            {
                var lineParts = line.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                var head = Regex.Match(lineParts[0], @"(\w+) \((\d+)\)");
                var nodeName = head.Groups[1].Value;
                var nodeValue = int.Parse(head.Groups[2].Value);
                var children = new List<string>();

                // if this is a -> line, parse list of children
                if(lineParts.Length > 1)
                    children = lineParts[1].Split(',').Select(c => c.Trim()).ToList();

                nodes[nodeName] = new Node
                {
                    Value = nodeValue,
                    Children = children
                };
            }

            /* recursively checks whether the weights of the children of a node are equal.
             * return value is a tuple of <boolean indicating the result,
             * the self value for the node, total value of node and children> */
            (bool good, int value, int total) CheckWeight(string nodeName)
            {
                var node = nodes[nodeName];
                // recurse down the tree
                var childWeights = node.Children.Select(CheckWeight).ToArray();

                // early return if a bad node has been found
                if (childWeights.Any(w => !w.good))
                    return childWeights.First(w => !w.good);

                // leaf node
                if (childWeights.Length == 0)
                    return (true, node.Value, node.Value);

                // group child nodes by their total values
                var groups = childWeights.GroupBy(w => w.total).ToArray();
                if (groups.Length > 1)
                {
                    // more than one group: the one node that has a wrong value is here

                    // calculate how much we need to adjust it e.g. (251, 243, 243) -> -8
                    var delta = groups.First(g => g.Count() != 1).Key - groups.First(g => g.Count() == 1).Key;
                    // total is not used, so just return 0
                    return (false, childWeights.First(w => w.total == groups.First(g => g.Count() == 1).Key).value + delta, 0);
                }
                else
                    // non-terminal node
                    return (true, node.Value, node.Value + childWeights.Sum(w => w.total));
            }

            // check weights starting at the tree root
            return CheckWeight(First(input)).value;
        }
    }
}