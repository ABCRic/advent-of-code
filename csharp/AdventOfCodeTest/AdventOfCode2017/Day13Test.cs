using AdventOfCode.AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2017
{
    [TestClass]
    public class Day13Test
    {
        [TestMethod]
        public void First1() =>
            Assert.AreEqual(24, Day13.First(@"0: 3
1: 2
4: 4
6: 4"));

        [TestMethod]
        public void Second1() =>
            Assert.AreEqual(10, Day13.Second(@"0: 3
1: 2
4: 4
6: 4"));
    }
}
