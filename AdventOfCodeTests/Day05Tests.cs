using AdventOfCode.Day05;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    [TestFixture]
    public class Day05Tests
    {

        [TestCase("ugknbfddgicrmopn", true)]
        [TestCase("aaa", true)]
        [TestCase("jchzalrnumimnmhp", false)]
        [TestCase("haegwjzuvuyypxyu", false)]
        [TestCase("dvszwmarrgswjxmb", false)]
        public void TestDay05a(string word, bool isNiceExpected)
        {
            var d = new Day05();
            var isNice = d.IsWordNice(word);
            Assert.That(isNice, Is.EqualTo(isNiceExpected));
        }

        [TestCase("qjhvhtzxzqqjkmpb", true)]
        [TestCase("xxyxx", true)]
        [TestCase("uurcxstgmygtbstg", false)]
        [TestCase("ieodomkazucvgmuy", false)]
        public void TestDay05b(string word, bool isNiceExpected)
        {
            var d = new Day05();
            var isNice = d.IsWordReallyNice(word);
            Assert.That(isNice, Is.EqualTo(isNiceExpected));
        }

    }
}
