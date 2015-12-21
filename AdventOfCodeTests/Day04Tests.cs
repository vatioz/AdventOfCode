using AdventOfCode.Day04;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    [TestFixture]
    public class Day04Tests
    {
        [Explicit("Slow test")]
        [TestCase("abcdef", "609043")]
        [TestCase("pqrstuv", "1048970")]
        public void TestDay04(string secretKey, string answer)
        {
            var d = new Day04();
            var number = d.FindNumberProducingHashWithLeadingZeroes(secretKey);
            Assert.That(number, Is.EqualTo(answer));
        }

    }
}
