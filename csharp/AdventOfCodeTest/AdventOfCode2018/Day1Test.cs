using AdventOfCode.AdventOfCode2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2018
{
    [TestClass]
    public class Day1Test
    {
        [DataTestMethod]
        [DataRow("+1, +1, +1", 3)]
        [DataRow("+1, +1, -2", 0)]
        [DataRow("-1, -2, -3", -6)]
        public void First(string input, int output)
        {
            Assert.AreEqual(output, Day1.First(input));
        }

        [DataTestMethod]
        [DataRow("+1, -1", 0)]
        [DataRow("+3, +3, +4, -2, -4", 10)]
        [DataRow("-6, +3, +8, +5, -6", 5)]
        [DataRow("+7, +7, -2, -7, -4", 14)]
        public void Second(string input, int output)
        {
            Assert.AreEqual(output, Day1.Second(input));
        }
    }
}
