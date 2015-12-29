using AdventOfCode.Shared;
using System.Collections.Generic;

namespace AdventOfCode.Day09
{
    public class Directions
    {
        #region | Properties & fields

        public List<Direction> ParsedDirections { get; }

        #endregion

        #region | ctors

        public Directions()
        {
            ParsedDirections = new List<Direction>();
        }

        #endregion

        #region | Public interface

        public void LoadDirections(string path)
        {
            var lines = GetLines(path);
            foreach (var line in lines)
            {
                var direction = Direction.Parse(line);
                ParsedDirections.Add(direction);
            }
        }

        #endregion

        #region | Non-public members

        private IEnumerable<string> GetLines(string path)
        {
            return FileLineParser.GetAllLines(path);
        }

        #endregion
    }
}