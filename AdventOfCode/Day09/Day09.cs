using AdventOfCode.Shared;
using System.Collections.Generic;

namespace AdventOfCode.Day09
{
    public class Day09 : IAdventDay
    {

        public IEnumerable<string> GetLines()
        {
            return FileLineParser.GetAllLines(@"Day09\Day09Input.txt");
        }


        public string SolvePartOne()
        {

            return "Not yet";
        }

        public string SolvePartTwo()
        {

            return "Not yet";
        }

        public string PuzzleName { get { return "All in a Single Night"; } }
    }


    public class Direction
    {
        public string PlaceA { get; set; }
        public string PlaceB { get; set; }

        public int Distance { get; set; }
    }

    public class Place
    {
        public string Name { get; set; }

        public Dictionary<Place, int> NearbyPlaces { get; set; }
    }
}
