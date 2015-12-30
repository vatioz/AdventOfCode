using AdventOfCode.Day12;
using NUnit.Framework;
using System.Linq;

namespace AdventOfCodeTests
{
    [TestFixture]
    public class Day12Tests
    {
        [Test]
        public void GetAllNumbers_CanGetNumbers()
        {
            var parser = new JSONNumberParser();
            var numbers = parser.GetAllNumbers("0abc-1wer11w400.0");
            var count = numbers.Count();
            Assert.That(count, Is.EqualTo(5));
        }

        [TestCase("[1,2,3]", 6)]
        [TestCase("{'a':2,'b':4}", 6)]
        [TestCase("[[[3]]]", 3)]
        [TestCase("{'a':{'b':4},'c':-1}", 3)]
        [TestCase("{'a':[-1,1]}", 0)]
        [TestCase("[-1,{'a':1}]", 0)]
        [TestCase("[]", 0)]
        [TestCase("{}", 0)]
        public void Day12Test(string json, int expectedSum)
        {
            Day12 d = new Day12();
            var sum = d.GetSum(json);
            Assert.That(sum, Is.EqualTo(expectedSum));
        }
    }
}
