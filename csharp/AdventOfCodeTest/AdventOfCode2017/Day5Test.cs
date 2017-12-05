using AdventOfCode.AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2017
{
    [TestClass]
    public class Day5Test
    {
        [TestMethod]
        public void First1() =>
            Assert.AreEqual(5,
                Day5.First("0\n3\n0\n1\n-3"));

        [TestMethod]
        public void Second1() =>
            Assert.AreEqual(10,
                Day5.Second("0\n3\n0\n1\n-3"));
    }
}
