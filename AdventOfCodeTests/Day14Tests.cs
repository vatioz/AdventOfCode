using AdventOfCode.Day14;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    [TestFixture]
    public class Day14Tests
    {
        [Test]
        public void LetReindeersRun()
        {
            var line1 = "Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.";
            var line2 = "Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.";

            var r1 = ReindeerParser.ParseReindeer(line1);
            var r2 = ReindeerParser.ParseReindeer(line2);

            r1.AdvanceBy(1000);
            r2.AdvanceBy(1000);

            var rd1 = r1.TraveledDistance;
            var rd2 = r2.TraveledDistance;

            Assert.That(r1.Name, Is.EqualTo("Comet"));
            Assert.That(r2.Name, Is.EqualTo("Dancer"));
            Assert.That(rd1, Is.EqualTo(1120));
            Assert.That(rd2, Is.EqualTo(1056));
        }
    }
}
