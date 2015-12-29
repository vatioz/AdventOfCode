using AdventOfCode.Day12;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
