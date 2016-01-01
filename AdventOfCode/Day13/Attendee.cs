using System.Collections.Generic;

namespace AdventOfCode.Day13
{
    public class Attendee
    {
        #region | Properties & fields

        public string Name { get; }

        public Dictionary<string, int> PotencialHapinnes { get; }

        #endregion

        #region | ctors

        public Attendee(string name)
        {
            Name = name;
            PotencialHapinnes = new Dictionary<string, int>();
        }

        #endregion

        #region | Overrides

        public override bool Equals(object obj)
        {
            var att = (Attendee)obj;
            return att.Name.Equals(Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        #endregion
    }
}