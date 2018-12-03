using AdventOfCode.AdventOfCode2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2018
{
    [TestClass]
    public class Day3Test
    {
        [DataTestMethod]
        [DataRow(@"#1 @ 1,3: 4x4
#2 @ 3,1: 4x4
#3 @ 5,5: 2x2", 4)]
        public void First(string input, int output)
        {
            Assert.AreEqual(output, Day3.First(input));
        }

        [DataTestMethod]
        [DataRow(@"#1 @ 1,3: 4x4
#2 @ 3,1: 4x4
#3 @ 5,5: 2x2", 3)]
        public void Second(string input, int output)
        {
            Assert.AreEqual(output, Day3.Second(input));
        }
    }
}
