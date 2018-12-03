using AdventOfCode.AdventOfCode2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2018
{
    [TestClass]
    public class Day2Test
    {
        [DataTestMethod]
        [DataRow(@"abcdef
bababc
abbcde
abcccd
aabcdd
abcdee
ababab", 12)]
        public void First(string input, int output)
        {
            Assert.AreEqual(output, Day2.First(input));
        }

        [DataTestMethod]
        [DataRow(@"abcde
fghij
klmno
pqrst
fguij
axcye
wvxyz", "fgij")]
        public void Second(string input, string output)
        {
            Assert.AreEqual(output, Day2.Second(input));
        }
    }
}
