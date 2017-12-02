using AdventOfCode.AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2017
{
    [TestClass]
    public class Day2Test
    {
        [TestMethod]
        public void First1() =>
            Assert.AreEqual(18, Day2.First("5 1 9 5\n7 5 3\n2 4 6 8"));

        [TestMethod]
        public void Second1() =>
            Assert.AreEqual(9, Day2.Second("5 9 2 8\n9 4 7 3\n3 8 6 5"));
    }
}
