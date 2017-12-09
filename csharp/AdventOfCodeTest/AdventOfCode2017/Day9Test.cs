using AdventOfCode.AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2017
{
    [TestClass]
    public class Day9Test
    {
        [TestMethod]
        public void First1() =>
            Assert.AreEqual(1, Day9.First("{}"));

        [TestMethod]
        public void First2() =>
            Assert.AreEqual(6, Day9.First("{{{}}}"));

        [TestMethod]
        public void First3() =>
            Assert.AreEqual(5, Day9.First("{{},{}}"));

        [TestMethod]
        public void First4() =>
            Assert.AreEqual(16, Day9.First("{{{},{},{{}}}}"));

        [TestMethod]
        public void First5() =>
            Assert.AreEqual(1, Day9.First("{<a>,<a>,<a>,<a>}"));

        [TestMethod]
        public void First6() =>
            Assert.AreEqual(9, Day9.First("{{<ab>},{<ab>},{<ab>},{<ab>}}"));

        [TestMethod]
        public void First7() =>
            Assert.AreEqual(9, Day9.First("{{<!!>},{<!!>},{<!!>},{<!!>}}"));

        [TestMethod]
        public void First8() =>
            Assert.AreEqual(3, Day9.First("{{<a!>},{<a!>},{<a!>},{<ab>}}"));

        [TestMethod]
        public void Second1() =>
            Assert.AreEqual(0, Day9.Second("<>"));

        [TestMethod]
        public void Second2() =>
            Assert.AreEqual(17, Day9.Second("<random characters>"));

        [TestMethod]
        public void Second3() =>
            Assert.AreEqual(3, Day9.Second("<<<<>"));

        [TestMethod]
        public void Second4() =>
            Assert.AreEqual(2, Day9.Second("{{<{!>}>}}"));

        [TestMethod]
        public void Second5() =>
            Assert.AreEqual(0, Day9.Second("{{{}, <!!>}}"));

        [TestMethod]
        public void Second6() =>
            Assert.AreEqual(0, Day9.Second("<!!!>>"));

        [TestMethod]
        public void Second7() =>
            Assert.AreEqual(10, Day9.Second("<{o\"i!a,<{i<a>"));
    }
}
