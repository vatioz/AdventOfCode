using AdventOfCode.Shared;
using System;
using System.Linq;

namespace AdventOfCode.Day14
{
    public class Day14 : IAdventDay
    {
        public object SolvePartOne()
        {
            var lines = InputLineParser.GetAllLines(Day14Input.REINDEERS);
            var track = new Track();

            foreach (var line in lines)
            {
                var reindeer = ReindeerParser.ParseReindeer(line);
                track.Commit(reindeer);
            }

            track.LetThemRunFor(2503);

            var distance = track.GetLeadersByTraveledDistance().Max(r => r.TraveledDistance);

            return distance;
        }

        public object SolvePartTwo()
        {
            var lines = InputLineParser.GetAllLines(Day14Input.REINDEERS);
            var track = new Track();

            foreach (var line in lines)
            {
                var reindeer = ReindeerParser.ParseReindeer(line);
                track.Commit(reindeer);
            }

            for (int i = 0; i < 2503; i++)
            {
                track.AdvanceAllBySecond();
                var temporaryLeaders = track.GetLeadersByTraveledDistance();
                foreach (var leader in temporaryLeaders)
                {
                    leader.AwardByPoints(1);
                }
            }

            var winner = track.GetWinnerByScore();

            return winner.Score;
        }

        public string PuzzleName => "Reindeer Olympics";
    }
}
