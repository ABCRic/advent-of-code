using AdventOfCode.AdventOfCode2020;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest.AdventOfCode2020
{
    [TestClass]
    public class Day5Test
    {
        [TestMethod]
        public void ParseSeat()
        {
            Assert.AreEqual((44u, 5u), Day5.ParseSeat("FBFBBFFRLR"));
        }

        [DataTestMethod]
        [DataRow(44u, 5u, 357)]
        public void SeatID(uint row, uint column, long seatID)
        {
            Assert.AreEqual(seatID, Day5.SeatID(row, column));
        }
    }
}
