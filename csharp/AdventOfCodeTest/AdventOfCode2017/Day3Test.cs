using AdventOfCode.AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2017
{
    [TestClass]
    public class Day3Test
    {
        [TestMethod]
        public void First1() =>
            Assert.AreEqual(0, Day3.First(1));

        [TestMethod]
        public void First2() =>
            Assert.AreEqual(3, Day3.First(12));

        [TestMethod]
        public void First3() =>
            Assert.AreEqual(2, Day3.First(23));

        [TestMethod]
        public void First4() =>
            Assert.AreEqual(31, Day3.First(1024));

        [TestMethod]
        public void Second1() =>
            Assert.AreEqual(10, Day3.Second(9));

        [TestMethod]
        public void Second2() =>
            Assert.AreEqual(23, Day3.Second(20));

        [TestMethod]
        public void Second3() =>
            Assert.AreEqual(54, Day3.Second(50));

        [TestMethod]
        public void Second4() =>
            Assert.AreEqual(304, Day3.Second(148));
    }
}
