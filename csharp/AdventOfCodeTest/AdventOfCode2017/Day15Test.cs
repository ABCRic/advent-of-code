using AdventOfCode.AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2017
{
    [TestClass]
    public class Day15Test
    {
        [TestMethod]
        public void First1() =>
            Assert.AreEqual(588, Day15.First(@"Generator A starts with 65
Generator B starts with 8921
"));

        [TestMethod]
        public void Second1() =>
            Assert.AreEqual(309, Day15.Second(@"Generator A starts with 65
Generator B starts with 8921
"));
    }
}
