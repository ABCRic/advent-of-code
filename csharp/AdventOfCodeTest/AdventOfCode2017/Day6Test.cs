using AdventOfCode.AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2017
{
    [TestClass]
    public class Day6Test
    {
        [TestMethod]
        public void First1() =>
            Assert.AreEqual(5, Day6.First("0 2 7 0"));

        [TestMethod]
        public void Second1() =>
            Assert.AreEqual(4, Day6.Second("0 2 7 0"));
    }
}
