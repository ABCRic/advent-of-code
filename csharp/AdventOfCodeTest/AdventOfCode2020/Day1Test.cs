using AdventOfCode.AdventOfCode2020;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2020
{
    [TestClass]
    public class Day1Test
    {
        [DataTestMethod]
        [DataRow(@"1721
979
366
299
675
1456", 514579)]
        public void First(string input, int output)
        {
            Assert.AreEqual(output, Day1.First(input));
        }

        [DataTestMethod]
        [DataRow(@"1721
979
366
299
675
1456", 241861950)]
        public void Second(string input, int output)
        {
            Assert.AreEqual(output, Day1.Second(input));
        }
    }
}
