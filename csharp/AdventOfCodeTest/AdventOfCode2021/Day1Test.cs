using AdventOfCode.AdventOfCode2021;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2021
{
    [TestClass]
    public class Day1Test
    {
        [DataTestMethod]
        [DataRow(@"199
200
208
210
200
207
240
269
260
263", 7)]
        public void First(string input, int output)
        {
            Assert.AreEqual(output, Day1.First(input));
        }

        [DataTestMethod]
        [DataRow(@"199
200
208
210
200
207
240
269
260
263", 5)]
        public void Second(string input, int output)
        {
            Assert.AreEqual(output, Day1.Second(input));
        }
    }
}
