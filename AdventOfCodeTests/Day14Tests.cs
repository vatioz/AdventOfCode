using System.Linq;
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

            var track = new Track();
            track.Commit(r1);
            track.Commit(r2);

            track.LetThemRunFor(1000);
            var leaders = track.GetLeadersByTraveledDistance();

            
            Assert.That(r1.Name, Is.EqualTo("Comet"));
            Assert.That(r2.Name, Is.EqualTo("Dancer"));

            Assert.That(leaders.Single().TraveledDistance, Is.EqualTo(1120));

        }

        [Test]
        public void LetReindeersRunWithAlteredScoring()
        {
            var line1 = "Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.";
            var line2 = "Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.";

            var r1 = ReindeerParser.ParseReindeer(line1);
            var r2 = ReindeerParser.ParseReindeer(line2);

            var track = new Track();
            track.Commit(r1);
            track.Commit(r2);

            for (int i = 0; i < 1000; i++)
            {
                track.AdvanceAllBySecond();
                var temporaryLeaders = track.GetLeadersByTraveledDistance();
                foreach (var leader in temporaryLeaders)
                {
                    leader.AwardByPoints(1);
                }
            }

            var winner = track.GetWinnerByScore();

            Assert.That(r1.Name, Is.EqualTo("Comet"));
            Assert.That(r2.Name, Is.EqualTo("Dancer"));

            Assert.That(winner.Name, Is.EqualTo("Dancer"));
            Assert.That(winner.Score, Is.EqualTo(689));

        }
    }
}
