using AdventOfCode.Shared;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day09
{
    public class Day09 : IAdventDay
    {
        public Day09() : this(@"Day09\Day09Input.txt")
        {
        }

        public Day09(string pathToInputFile)
        {
            LoadTheMap(pathToInputFile);
        }

        private List<Direction> directions = new List<Direction>();
        public Dictionary<string, Place> Places = new Dictionary<string, Place>();

        public IEnumerable<string> GetLines(string path)
        {
            return FileLineParser.GetAllLines(path);
        }

        public void LoadTheMap(string path)
        {
            var lines = GetLines(path);
            foreach (var line in lines)
            {
                var direction = Direction.Parse(line);
                directions.Add(direction);
            }

            foreach (var direction in directions)
            {
                Place placeA;
                Place placeB;
                if (Places.ContainsKey(direction.PlaceA))
                    placeA = Places[direction.PlaceA];
                else
                {
                    placeA = new Place(direction.PlaceA);
                    Places.Add(placeA.Name, placeA);
                }

                if (Places.ContainsKey(direction.PlaceB))
                    placeB = Places[direction.PlaceB];
                else
                {
                    placeB = new Place(direction.PlaceB);
                    Places.Add(placeB.Name, placeB);
                }

                if (!placeA.NearbyPlaces.ContainsKey(placeB))
                    placeA.NearbyPlaces.Add(placeB, direction.Distance);

                if (!placeB.NearbyPlaces.ContainsKey(placeA))
                    placeB.NearbyPlaces.Add(placeA, direction.Distance);

            }
        }

        private Stack<Place> visited = new Stack<Place>();
        private int sum = 0;
        private Dictionary<string, int> distances = new Dictionary<string, int>();

        public int FindShortestConnection()
        {
            FindAllFullConnections();

            var min = distances.Min(kvp => kvp.Value);
            return min;
        }

        public int FindLongestConnection()
        {
            FindAllFullConnections();

            var min = distances.Max(kvp => kvp.Value);
            return min;
        }

        private void FindAllFullConnections()
        {
            distances.Clear();
            foreach (var place in Places.Values)
            {
                visited = new Stack<Place>();
                sum = 0;

                HitTheRoad(place);
            }
        }

        public void HitTheRoad(Place startingPlace)
        {
            visited.Push(startingPlace);
            foreach (var nearbyPlacePair in startingPlace.NearbyPlaces)
            {
                var distance = nearbyPlacePair.Value;
                var place = nearbyPlacePair.Key;
                if (!visited.Contains(place))
                {
                    sum += distance;
                    HitTheRoad(place);
                    sum -= distance;
                }

            }
            if (visited.Count == Places.Count)
            {
                var journey = string.Join("-->", visited.Select(p => p.Name).ToArray());
                distances.Add(journey, sum);
            }
            visited.Pop();
        }


        public string SolvePartOne()
        {
            return FindShortestConnection().ToString();
        }

        public string SolvePartTwo()
        {
            return FindLongestConnection().ToString();
        }

        public string PuzzleName { get { return "All in a Single Night"; } }
    }
}
