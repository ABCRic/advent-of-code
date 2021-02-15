using AdventOfCode.AdventOfCode2020;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2020
{
    [TestClass]
    public class Day2Test
    {
        [DataTestMethod]
        [DataRow(@"1-3 a: abcde
1-3 b: cdefg
2-9 c: ccccccccc", 2)]
        public void First(string input, int output)
        {
            Assert.AreEqual(output, Day2.First(input));
        }

        [DataTestMethod]
        [DataRow(@"1-3 a: abcde
1-3 b: cdefg
2-9 c: ccccccccc", 1)]
        public void Second(string input, int output)
        {
            Assert.AreEqual(output, Day2.Second(input));
        }
    }
}
