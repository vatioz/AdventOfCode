using System.Collections.Generic;
using System.Diagnostics;

namespace AdventOfCode.Day09
{
    [DebuggerDisplay("{Name}")]
    public class Place
    {
        public Place(string name)
        {
            Name = name;
            NearbyPlaces = new Dictionary<Place, int>();
        }

        public override bool Equals(object obj)
        {
            var plc = (Place)obj;
            return plc.Name == this.Name;
        }

        public string Name { get; set; }

        public Dictionary<Place, int> NearbyPlaces { get; set; }
    }
}