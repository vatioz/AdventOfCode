using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day14
{
    public class Track
    {
        private List<Reindeer> Reindeers { get; set; }

        public Track()
        {
            Reindeers = new List<Reindeer>();
        }

        public void Commit(Reindeer reindeer)
        {
            Reindeers.Add(reindeer);
        }

        public void LetThemRunFor(int seconds)
        {
            foreach (var reindeer in Reindeers)
            {
                reindeer.RunFor(seconds);
            }
        }

        public void AdvanceAllBySecond()
        {
            foreach (var reindeer in Reindeers)
            {
                reindeer.AdvanceBySecond();
            }
        }

        public IEnumerable<Reindeer> GetLeadersByTraveledDistance()
        {
            var max = Reindeers.Max(r => r.TraveledDistance);
            return Reindeers.Where(r => r.TraveledDistance == max);
        }

        public Reindeer GetWinnerByScore()
        {
            var max = Reindeers.Max(r => r.Score);
            return Reindeers.First(r => r.Score == max);
        }
    }
}
