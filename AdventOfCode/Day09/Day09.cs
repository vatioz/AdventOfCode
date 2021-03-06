﻿using AdventOfCode.Shared;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day09
{
    public class Day09 : IAdventDay
    {
        #region | Properties & fields

        private readonly Dictionary<string, int> _distances;

        private readonly Map _graphMap;

        private readonly Stack<Place> _visited;
        private int _sum;

        #endregion

        #region | ctors

        public Day09() : this(@"Day09\Day09Input.txt")
        {
        }

        public Day09(string pathToInputFile)
        {
            _visited = new Stack<Place>();
            _distances = new Dictionary<string, int>();

            var rawDirections = new Directions();
            rawDirections.LoadDirections(pathToInputFile);

            _graphMap = new Map();
            _graphMap.LoadMap(rawDirections.ParsedDirections);
        }

        #endregion

        #region | Public interface

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

        #endregion

        #region | Non-public members

        private void FindAllFullConnections()
        {
            _distances.Clear();
            foreach (var place in _graphMap.Places)
            {
                _visited.Clear();
                _sum = 0;

                HitTheRoad(place);
            }
        }

        private void HitTheRoad(Place startingPlace)
        {
            _visited.Push(startingPlace);
            foreach (var nearbyPlace in startingPlace.NearbyPlaces)
            {
                if (!_visited.Contains(nearbyPlace.OtherPlace))
                {
                    _sum += nearbyPlace.Distance;
                    HitTheRoad(nearbyPlace.OtherPlace);
                    _sum -= nearbyPlace.Distance;
                }
            }
            if (_visited.Count == _graphMap.Places.Count)
            {
                RecordCurrentFullJourney();
            }
            _visited.Pop();
        }

        private void RecordCurrentFullJourney()
        {
            var journey = string.Join("-->", _visited.Select(p => p.Name).ToArray());
            _distances.Add(journey, _sum);
        }

        #endregion

        #region  | Interface members

        public object SolvePartOne()
        {
            return FindShortestConnection();
        }

        public object SolvePartTwo()
        {
            return FindLongestConnection();
        }

        public string PuzzleName => "All in a Single Night";

        #endregion
    }
}