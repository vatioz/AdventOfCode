using AdventOfCode.Day10;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    [TestFixture]
    public class Day10Tests
    {
        [TestFixtureSetUp]
        public void SetUp()
        {

        }

        [TestCase("1", 1, "11")]
        [TestCase("1", 2, "21")]
        [TestCase("1", 3, "1211")]
        [TestCase("1", 4, "111221")]
        [TestCase("1", 5, "312211")]
        [TestCase("3", 6, "311311222113")]
        public void Test(string startingSeq, int iterations, string expectedResultSeq)
        {
            Day10 d = new Day10();
            var result = d.RepeatedLookAndSay(startingSeq, iterations);
            Assert.That(result, Is.EqualTo(expectedResultSeq));
        }
    }
}
