using AdventOfCode.AdventOfCode2019;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2019
{
    [TestClass]
    public class Day1Test
    {
        [DataTestMethod]
        [DataRow("12", 2)]
        [DataRow("14", 2)]
        [DataRow("1969", 654)]
        [DataRow("100756", 33583)]
        [DataRow("12\n14\n1969\n100756", 2+2+654+33583)]
        public void First(string input, int output)
        {
            Assert.AreEqual(output, Day1.First(input));
        }

        [DataTestMethod]
        [DataRow("14", 2)]
        [DataRow("1969", 966)]
        [DataRow("100756", 50346)]
        [DataRow("14\n1969\n100756", 2 + 966 + 50346)]
        public void Second(string input, int output)
        {
            Assert.AreEqual(output, Day1.Second(input));
        }
    }
}
