using AdventOfCode.Day11;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeTests
{
    [TestFixture]
    public class Day11Tests
    {
        [TestCase("hijklmmn", false)]
        [TestCase("abbceffg", false)]
        [TestCase("abbcegjk", false)]
        public void DoesPasswordMeetsRequirement(string password, bool expectedResult)
        {

        }

        //[TestCase("a", "aabcc")]
        [TestCase("abcdefgh", "abcdffaa")]
        [TestCase("ghjaabcb", "ghjaabcc")]
        [TestCase("ghijklmn", "ghjaabcc")]
        public void GenerateNext(string current, string expectedNext)
        {
            var gen = new PasswordGenerator(current);
            gen.GenerateNext();
            Assert.That(gen.CurrentPassword, Is.EqualTo(expectedNext));
        }
    }
}
