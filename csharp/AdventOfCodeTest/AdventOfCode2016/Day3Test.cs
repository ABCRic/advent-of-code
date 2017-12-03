using AdventOfCode.AdventOfCode2016;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2016
{
    [TestClass]
    public class Day3Test
    {
        [TestMethod]
        public void First1() =>
            Assert.AreEqual(0, Day3.First("5 10 25"));

        [TestMethod]
        public void First2() =>
            Assert.AreEqual(1, Day3.First("10 20 25"));

        [TestMethod]
        public void First3() =>
            Assert.AreEqual(3, Day3.First("10 20 25\n1 2 5\n2 2 2\n4\t  5  \t 6"));

        [TestMethod]
        public void Second1() =>
            Assert.AreEqual(1, Day3.Second("10 20 25\n10 20 25\n10 300 300"));
    }
}
