using AdventOfCode.AdventOfCode2021;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2021
{
    [TestClass]
    public class Day2Test
    {
        [DataTestMethod]
        [DataRow(@"forward 5
down 5
forward 8
up 3
down 8
forward 2", 150)]
        public void First(string input, int output)
        {
            Assert.AreEqual(output, Day2.First(input));
        }

        [DataTestMethod]
        [DataRow(@"forward 5
down 5
forward 8
up 3
down 8
forward 2", 900)]
        public void Second(string input, int output)
        {
            Assert.AreEqual(output, Day2.Second(input));
        }
    }
}
