using AdventOfCode.AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2017
{
    [TestClass]
    public class Day10Test
    {
        [TestMethod]
        public void First1() =>
            Assert.AreEqual(12, Day10.First("3,4,1,5", 5));

        [TestMethod]
        public void Second1() =>
            Assert.AreEqual("a2582a3a0e66e6e86e3812dcb672a272", Day10.Second(""));

        [TestMethod]
        public void Second2() =>
            Assert.AreEqual("33efeb34ea91902bb2f59c9920caa6cd", Day10.Second("AoC 2017"));

        [TestMethod]
        public void Second3() =>
            Assert.AreEqual("3efbe78a8d82f29979031a4aa0b16a9d", Day10.Second("1,2,3"));

        [TestMethod]
        public void Second4() =>
            Assert.AreEqual("63960835bcdc130f0b66d7ff4f6a5a8e", Day10.Second("1,2,4"));
    }
}
