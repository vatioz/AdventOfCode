using AdventOfCode.Shared;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day09
{
    public class Day09 : IAdventDay
    {
        #region | ctors

        public Day09() : this(@"Day09\Day09Input.txt")
        {
        }

        public Day09(string pathToInputFile)
        {
            LoadTheMap(pathToInputFile);
        }

        #endregion

        #region | Fields and properties

        private readonly List<Direction> _directions = new List<Direction>();
        private readonly Dictionary<string, Place> _places = new Dictionary<string, Place>();
        private readonly Stack<Place> _visited = new Stack<Place>();
        private readonly Dictionary<string, int> _distances = new Dictionary<string, int>();
        private int _sum;

        #endregion

        #region | Parsing the file

        private IEnumerable<string> GetLines(string path)
        {
            return FileLineParser.GetAllLines(path);
        }

        private void LoadTheMap(string path)
        {
            var lines = GetLines(path);
            foreach (var line in lines)
            {
                var direction = Direction.Parse(line);
                _directions.Add(direction);
            }

            foreach (var direction in _directions)
            {
                Place placeA;
                Place placeB;
                if (_places.ContainsKey(direction.PlaceA))
                    placeA = _places[direction.PlaceA];
                else
                {
                    placeA = new Place(direction.PlaceA);
                    _places.Add(placeA.Name, placeA);
                }

                if (_places.ContainsKey(direction.PlaceB))
                    placeB = _places[direction.PlaceB];
                else
                {
                    placeB = new Place(direction.PlaceB);
                    _places.Add(placeB.Name, placeB);
                }

                if (!placeA.NearbyPlaces.ContainsKey(placeB))
                    placeA.NearbyPlaces.Add(placeB, direction.Distance);

                if (!placeB.NearbyPlaces.ContainsKey(placeA))
                    placeB.NearbyPlaces.Add(placeA, direction.Distance);

            }
        }

        #endregion

        #region | Main interface and logic

        public int FindShortestConnection()
        {
            FindAllFullConnections();

            var min = _distances.Min(kvp => kvp.Value);
            return min;
        }

        public int FindLongestConnection()
        {
            FindAllFullConnections();

            var min = _distances.Max(kvp => kvp.Value);
            return min;
        }

        private void FindAllFullConnections()
        {
            _distances.Clear();
            foreach (var place in _places.Values)
            {
                _visited.Clear();
                _sum = 0;

                HitTheRoad(place);
            }
        }

        private void HitTheRoad(Place startingPlace)
        {
            _visited.Push(startingPlace);
            foreach (var nearbyPlacePair in startingPlace.NearbyPlaces)
            {
                var distance = nearbyPlacePair.Value;
                var place = nearbyPlacePair.Key;
                if (!_visited.Contains(place))
                {
                    _sum += distance;
                    HitTheRoad(place);
                    _sum -= distance;
                }

            }
            if (_visited.Count == _places.Count)
            {
                var journey = string.Join("-->", _visited.Select(p => p.Name).ToArray());
                _distances.Add(journey, _sum);
            }
            _visited.Pop();
        }

        #endregion

        #region | IAdventDay interface

        public string SolvePartOne()
        {
            return FindShortestConnection().ToString();
        }

        public string SolvePartTwo()
        {
            return FindLongestConnection().ToString();
        }

        public string PuzzleName { get { return "All in a Single Night"; } }

        #endregion
    }
}
