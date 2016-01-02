using AdventOfCode.Shared;
using System;

namespace AdventOfCode.Day14
{
    public class Day14 : IAdventDay
    {
        public string SolvePartOne()
        {
            int max = 0;
            var lines = InputLineParser.GetAllLines(Day14Input.REINDEERS);
            foreach (var line in lines)
            {
                var reindeer = ReindeerParser.ParseReindeer(line);
                reindeer.AdvanceBy(2503);
                var traveled = reindeer.TraveledDistance;
                max = Math.Max(traveled, max);
            }

            return max.ToString();
        }

        public string SolvePartTwo()
        {
            return "Not yet";
        }

        public string PuzzleName => "Reindeer Olympics";
    }
}
