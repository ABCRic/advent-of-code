using AdventOfCode.AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2017
{
    [TestClass]
    public class Day4Test
    {
        [TestMethod]
        public void First1() =>
            Assert.AreEqual(2,
                Day4.First("aa bb cc dd ee\n" +
                           "aa bb cc dd aa\n" +
                           "aa bb cc dd aaa"));

        [TestMethod]
        public void Second1() =>
            Assert.AreEqual(3,
                Day4.Second("abcde fghij\n" +
                           "abcde xyz ecdab\n" +
                           "a ab abc abd abf abj\n" +
                           "iiii oiii ooii oooi oooo\n" +
                           "oiii ioii iioi iiio"));
    }
}
