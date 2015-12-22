using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode.Day09
{
    /// <summary>
    ///     This class represent a vector in a virtual graph.
    /// </summary>
    [DebuggerDisplay("{Name}")]
    public class Place
    {
        #region | Properties & fields

        public string Name { get; }

        public List<PathToPlace> NearbyPlaces { get; }

        #endregion

        #region | ctors

        public Place(string name)
        {
            Name = name;
            NearbyPlaces = new List<PathToPlace>();
        }

        #endregion

        #region | Public interface

        public void AddNearbyPlace(Place place, int distance)
        {
            if (NearbyPlaces.Any(pathToPlace => Equals(pathToPlace.OtherPlace, place)))
                return;

            NearbyPlaces.Add(new PathToPlace(place, distance));
        }

        #endregion

        #region | Overrides

        public override bool Equals(object obj)
        {
            var plc = (Place) obj;
            return plc.Name == Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        #endregion
    }
}