using AdventOfCode.Shared;
using System.Collections.Generic;

namespace AdventOfCode.Day09
{
    public class Directions
    {
        public Directions()
        {
            ParsedDirections = new List<Direction>();
        }

        #region | Parsing the file

        public List<Direction> ParsedDirections { get; }

        private IEnumerable<string> GetLines(string path)
        {
            return FileLineParser.GetAllLines(path);
        }

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
    }
}
