using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day09
{
    public class Map
    {
        #region | Properties & fields

        private readonly Dictionary<string, Place> _places;
        public List<Place> Places => _places.Values.ToList();

        #endregion

        #region | ctors

        public Map()
        {
            _places = new Dictionary<string, Place>();
        }

        #endregion

        #region | Public interface

        public void LoadMap(List<Direction> directions)
        {
            foreach (var direction in directions)
            {
                var placeA = GetOrCreatePlace(direction.PlaceA);
                var placeB = GetOrCreatePlace(direction.PlaceB);

                placeA.AddNearbyPlace(placeB, direction.Distance);
                placeB.AddNearbyPlace(placeA, direction.Distance);
            }
        }

        #endregion

        #region | Non-public members

        private Place GetOrCreatePlace(string placeName)
        {
            Place place;
            if (_places.ContainsKey(placeName))
                place = _places[placeName];
            else
            {
                place = new Place(placeName);
                _places.Add(place.Name, place);
            }
            return place;
        }

        #endregion
    }
}