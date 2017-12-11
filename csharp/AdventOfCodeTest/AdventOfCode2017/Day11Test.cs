using AdventOfCode.AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2017
{
    [TestClass]
    public class Day11Test
    {
        [TestMethod]
        public void First1() =>
            Assert.AreEqual(3, Day11.First("ne,ne,ne"));

        [TestMethod]
        public void First2() =>
            Assert.AreEqual(0, Day11.First("ne,ne,sw,sw"));

        [TestMethod]
        public void First3() =>
            Assert.AreEqual(2, Day11.First("ne,ne,s,s"));

        [TestMethod]
        public void First4() =>
            Assert.AreEqual(3, Day11.First("se,sw,se,sw,sw"));

        [TestMethod]
        public void First5() =>
            Assert.AreEqual(0, Day11.First("n,nw,s,se"));

        [TestMethod]
        public void Second1() =>
            Assert.AreEqual(3, Day11.Second("ne,ne,ne"));

        [TestMethod]
        public void Second2() =>
            Assert.AreEqual(2, Day11.Second("ne,ne,sw,sw"));

        [TestMethod]
        public void Second3() =>
            Assert.AreEqual(1, Day11.Second("n,se,s,sw,nw,n,ne"));
    }
}
