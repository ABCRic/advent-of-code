using AdventOfCode.AdventOfCode2021;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2021
{
    [TestClass]
    public class Day3Test
    {
        [DataTestMethod]
        [DataRow(@"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010", 198UL)]
        public void First(string input, ulong output)
        {
            Assert.AreEqual(output, Day3.First(input));
        }

        [DataTestMethod]
        [DataRow(@"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010", 230UL)]
        public void Second(string input, ulong output)
        {
            Assert.AreEqual(output, Day3.Second(input));
        }
    }
}
