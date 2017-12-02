using AdventOfCode.AdventOfCode2015;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2015
{
    [TestClass]
    public class Day1Test
    {
        [TestMethod]
        public void First1()
        {
            Assert.AreEqual(0, Day1.First("(())"));
            Assert.AreEqual(0, Day1.First("()()"));
        }

        [TestMethod]
        public void First2()
        {
            Assert.AreEqual(3, Day1.First("((("));
            Assert.AreEqual(3, Day1.First("(()(()("));
        }

        [TestMethod]
        public void First3()
        {
            Assert.AreEqual(3, Day1.First("))((((("));
        }

        [TestMethod]
        public void First4()
        {
            Assert.AreEqual(-1, Day1.First("())"));
            Assert.AreEqual(-1, Day1.First("))("));
        }

        [TestMethod]
        public void First5()
        {
            Assert.AreEqual(-3, Day1.First(")))"));
            Assert.AreEqual(-3, Day1.First(")())())"));
        }

        [TestMethod]
        public void Second1() =>
            Assert.AreEqual(1, Day1.Second(")"));

        [TestMethod]
        public void Second2() =>
            Assert.AreEqual(5, Day1.Second("()())"));
    }
}
