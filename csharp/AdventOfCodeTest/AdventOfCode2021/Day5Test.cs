using AdventOfCode.AdventOfCode2021;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2021
{
    [TestClass]
    public class Day5Test
    {
        [DataTestMethod]
        [DataRow(@"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2", 5)]
        public void First(string input, long output)
        {
            Assert.AreEqual(output, Day5.First(input));
        }

        [DataTestMethod]
        [DataRow(@"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2", 12)]
        public void Second(string input, long output)
        {
            Assert.AreEqual(output, Day5.Second(input));
        }
    }
}
