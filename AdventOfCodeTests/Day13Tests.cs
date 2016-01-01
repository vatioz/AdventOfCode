using AdventOfCode.Day13;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCodeTests
{
    [TestFixture]
    public class Day13Tests
    {
        [Test]
        public void TryAllSeatingPlans_FindsMaxHappiness()
        {
            var host = new Host();
            host.NoticePersonalities(Day13Input.TEST_HAPPINESS);
            var maxHappiness = host.TryAllSeatingPlans();
            Assert.That(maxHappiness, Is.EqualTo(330));
        }

        [Test]
        public void GetPermutations()
        {
            var list = new List<string> { "a", "b", "c", "d", "e" };
            var result = EnumerableHelpers.GetPermutations(list, list.Count);
            foreach (var perm in result)
            {
                var permString = string.Join(", ", perm.ToArray());
                Debug.WriteLine(permString);
            }
        }
    }
}
