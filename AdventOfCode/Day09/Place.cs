using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode.Day09
{
    /// <summary>
    /// This class represent a vector in a virtual graph.
    /// </summary>
    [DebuggerDisplay("{Name}")]
    public class Place
    {
        public Place(string name)
        {
            Name = name;
            NearbyPlaces = new List<PathToPlace>();
        }

        public string Name { get; }

        public List<PathToPlace> NearbyPlaces { get; }

        public void AddNearbyPlace(Place place, int distance)
        {
            if (NearbyPlaces.Any(pathToPlace => Equals(pathToPlace.OtherPlace, place)))
                return;

            NearbyPlaces.Add(new PathToPlace(place, distance));
        }

        public override bool Equals(object obj)
        {
            var plc = (Place)obj;
            return plc.Name == this.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}