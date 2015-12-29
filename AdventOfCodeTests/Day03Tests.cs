using AdventOfCode.Day03;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    [TestFixture]
    public class Day03Tests
    {
        [TestCase(">", 2)]
        [TestCase("^>v<", 4)]
        [TestCase("^v^v^v^v^v", 2)]
        public void WalkThroughHouses(string directions, int expectedHouseCount)
        {
            var d03 = new Day03();
            var houseCount = d03.CountHousesWithPresent(directions, 1);

            Assert.That(houseCount, Is.EqualTo(expectedHouseCount));
        }



        [TestCase("^>", 3)]
        [TestCase("^>v<", 3)]
        [TestCase("^v^v^v^v^v", 11)]
        public void RoboWalkThroughHouses(string directions, int expectedHouseCount)
        {
            var d03 = new Day03();
            var houseCount = d03.CountHousesWithPresent(directions, 2);

            Assert.That(houseCount, Is.EqualTo(expectedHouseCount));
        }





    }
}
