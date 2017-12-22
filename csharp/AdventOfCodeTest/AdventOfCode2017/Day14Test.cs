using AdventOfCode.AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2017
{
    [TestClass]
    public class Day14Test
    {
        [TestMethod]
        public void First1() =>
            Assert.AreEqual(8108, Day14.First("flqrgnkx"));

        [TestMethod]
        public void Second1() =>
            Assert.AreEqual(1242, Day14.Second("flqrgnkx"));
    }
}
