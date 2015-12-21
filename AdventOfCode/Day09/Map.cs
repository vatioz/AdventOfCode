using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day09
{
    public class Map
    {
        public Map()
        {
            _places = new Dictionary<string, Place>();
        }

        private Dictionary<string, Place> _places;
        public List<Place> Places => _places.Values.ToList();


        public void LoadMap(List<Direction> directions)
        {
            foreach (var direction in directions)
            {
                var placeA = GetOrCreatePlace(direction.PlaceA);
                var placeB = GetOrCreatePlace(direction.PlaceB);

                placeA.AddNearbyPlace(placeB, direction.Distance);
                placeB.AddNearbyPlace(placeA, direction.Distance);

                /*
                if (!placeA.NearbyPlaces.Contains(placeB))
                    placeA.NearbyPlaces.Add(placeB, direction.Distance);

                if (!placeB.NearbyPlaces.ContainsKey(placeA))
                    placeB.NearbyPlaces.Add(placeA, direction.Distance);
                */
            }
        }

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
    }
}
