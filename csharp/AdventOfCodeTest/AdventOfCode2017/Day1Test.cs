using AdventOfCode.AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2017
{
    [TestClass]
    public class Day1Test
    {
        [TestMethod]
        public void First1() =>
            Assert.AreEqual(3, Day1.First("1122"));

        [TestMethod]
        public void First2() =>
            Assert.AreEqual(4, Day1.First("1111"));

        [TestMethod]
        public void First3() =>
            Assert.AreEqual(0, Day1.First("1234"));

        [TestMethod]
        public void First4() =>
            Assert.AreEqual(9, Day1.First("91212129"));

        [TestMethod]
        public void Second1() =>
            Assert.AreEqual(6, Day1.Second("1212"));

        [TestMethod]
        public void Second2() =>
            Assert.AreEqual(0, Day1.Second("1221"));

        [TestMethod]
        public void Second3() =>
            Assert.AreEqual(4, Day1.Second("123425"));

        [TestMethod]
        public void Second4() =>
            Assert.AreEqual(12, Day1.Second("123123"));

        [TestMethod]
        public void Second5() =>
            Assert.AreEqual(4, Day1.Second("12131415"));
    }
}
