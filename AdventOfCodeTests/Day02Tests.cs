using AdventOfCode.Day02;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    [TestFixture]
    class Day02Tests
    {
        [Test]
        public void SumsTwoLines()
        {
            var d02 = new Day02();
            var wholeArea = d02.CountAllAreas(
                @"5x5x5
5x5x5");

            Assert.That(wholeArea, Is.EqualTo(350));
        }

        [TestCase("2x3x4", 58)]
        [TestCase("1x1x10", 43)]
        public void SumsTwoLines(string line, int expectedArea)
        {
            var d02 = new Day02();
            var wholeArea = d02.CountAllAreas(line);

            Assert.That(wholeArea, Is.EqualTo(expectedArea));
        }

        [TestCase("2x3x4", 34)]
        [TestCase("1x1x10", 14)]
        public void RibbonLength(string line, int expectedLength)
        {
            var d02 = new Day02();
            var length = d02.CountAllRibbons(line);
            Assert.That(length, Is.EqualTo(expectedLength));

        }
    }
}
