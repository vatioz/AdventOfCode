using System.Linq;
using System.Runtime.InteropServices;
using AdventOfCode.Day08;
using AdventOfCode.Day09;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    /// <summary>
    /// Summary description for Day09Tests
    /// </summary>
    [TestFixture]
    public class Day09Tests
    {

        private Day09 d;

        [TestFixtureSetUp]
        public void SetUp()
        {
            d = new Day09(@"Day09\Day09TestInput.txt");
        }

        [Test]
        public void FindShortestWithTestData()
        {
            var min = d.FindShortestConnection();
            Assert.That(min, Is.EqualTo(605));
        }

        [Test]
        public void FindLongestWithTestData()
        {
            var min = d.FindLongestConnection();
            Assert.That(min, Is.EqualTo(982));
        }

    }
}
