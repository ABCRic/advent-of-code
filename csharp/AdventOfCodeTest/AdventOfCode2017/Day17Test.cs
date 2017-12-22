using AdventOfCode.AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2017
{
    [TestClass]
    public class Day17Test
    {
        [TestMethod]
        public void First1() =>
            Assert.AreEqual(638, Day17.First("3"));

        [TestMethod]
        public void Second1() =>
            Assert.AreEqual(28954211, Day17.Second("380"));
    }
}
