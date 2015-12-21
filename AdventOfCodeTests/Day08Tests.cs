using AdventOfCode.Shared;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Day08;

namespace AdventOfCodeTests
{
    [TestFixture]
    public class Day08Tests
    {
        private IEnumerable<string> lines;

        [TestFixtureSetUp]
        public void SetUp()
        {
            lines = FileLineParser.GetAllLines(@"Day08\Day08TestInput.txt");
        }
        
        [TestCase(0, 2, 0, Description = "empty line")]
        [TestCase(1, 5, 3, Description = "abc")]
        [TestCase(2, 10, 7, Description = "one quote")]
        [TestCase(3, 6, 1, Description = "\\x escaping")]
        [TestCase(4, 8, 5, Description = "one backslash")]
        [TestCase(5, 10, 6, Description = "quote and backslash")]
        [TestCase(6, 10, 6, Description = "backslash and quote")]
        public void UnescapingTests(int lineNuber, int memoryLength, int strLength)
        {
            var emptyLine = lines.Skip(lineNuber).First();
            Assert.That(emptyLine.Length, Is.EqualTo(memoryLength));
            var unesc = new Unescapeator(emptyLine).Unescape();
            Assert.That(unesc.Length, Is.EqualTo(strLength));
        }


        [TestCase(0, 2, 6, Description = "empty line")]
        [TestCase(1, 5, 9, Description = "abc")]
        [TestCase(2, 10, 16, Description = "one quote")]
        [TestCase(3, 6, 11, Description = "\\x escaping")]
        [TestCase(4, 8, 14, Description = "one backslash")]
        [TestCase(5, 10, 18, Description = "quote and backslash")]
        [TestCase(6, 10, 18, Description = "backslash and quote")]
        public void ReescapingTests(int lineNuber, int strLength, int memoryLength)
        {
            var emptyLine = lines.Skip(lineNuber).First();
            Assert.That(emptyLine.Length, Is.EqualTo(strLength));
            var unesc = new Unescapeator(emptyLine).Reescape();
            Assert.That(unesc.Length, Is.EqualTo(memoryLength));
        }

    }
}
