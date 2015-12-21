using System;
using AdventOfCode.Shared;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day09
{
    public class Day09 : IAdventDay
    {
        private List<Direction> directions = new List<Direction>(); 

        public IEnumerable<string> GetLines()
        {
            return FileLineParser.GetAllLines(@"Day09\Day09Input.txt");
        }

        public void LoadTheMap()
        {
            var lines = GetLines();
            foreach (var line in lines)
            {
                var direction = Direction.Parse(line);
                directions.Add(direction);
            }
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
        public static Regex navigRE = new Regex(@"(?<placeA>\w+) to (?<placeB>\w+) = (?<distance>\d+)", RegexOptions.Compiled);

        public Direction(string placeA, string placeB, int distance)
        {
            PlaceA = placeA;
            PlaceB = placeB;
            Distance = distance;
        }

        public string PlaceA { get; set; }
        public string PlaceB { get; set; }

        public int Distance { get; set; }

        public static Direction Parse(string line)
        {
            var match = navigRE.Match(line);
            if(!match.Success)
                throw new ArgumentException($"Bad direction {line}");

            var placeA = match.Groups["placeA"].Value;
            var placeB = match.Groups["placeB"].Value;
            var rawDistance = match.Groups["distance"].Value;
            var distance = int.Parse(rawDistance);
            return new Direction(placeA, placeB, distance);
        }
    }

    public class Place
    {
        public string Name { get; set; }

        public Dictionary<Place, int> NearbyPlaces { get; set; }
    }
}
