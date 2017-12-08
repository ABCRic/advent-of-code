using AdventOfCode.AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2017
{
    [TestClass]
    public class Day8Test
    {
        [TestMethod]
        public void First1() =>
            Assert.AreEqual(1, Day8.First(@"b inc 5 if a > 1
a inc 1 if b < 5
c dec -10 if a >= 1
c inc -20 if c == 10"));

        [TestMethod]
        public void Second1() =>
            Assert.AreEqual(10, Day8.Second(@"b inc 5 if a > 1
a inc 1 if b < 5
c dec -10 if a >= 1
c inc -20 if c == 10"));
    }
}
