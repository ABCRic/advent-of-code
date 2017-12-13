using AdventOfCode.AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2017
{
    [TestClass]
    public class Day12Test
    {
        [TestMethod]
        public void First1() =>
            Assert.AreEqual(6, Day12.First(@"0 <-> 2
1 <-> 1
2 <-> 0, 3, 4
3 <-> 2, 4
4 <-> 2, 3, 6
5 <-> 6
6 <-> 4, 5"));

        [TestMethod]
        public void Second1() =>
            Assert.AreEqual(2, Day12.Second(@"0 <-> 2
1 <-> 1
2 <-> 0, 3, 4
3 <-> 2, 4
4 <-> 2, 3, 6
5 <-> 6
6 <-> 4, 5"));
    }
}
