using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day09
{
    /// <summary>
    ///     This class represents file input and it maps to single line of input.
    /// </summary>
    [DebuggerDisplay("{PlaceA} -- {Distance} --> {PlaceB}")]
    public class Direction
    {
        #region |  Constants

        private static readonly Regex NavigRe = new Regex(@"(?<placeA>\w+) to (?<placeB>\w+) = (?<distance>\d+)",
            RegexOptions.Compiled);

        #endregion

        #region | Properties & fields

        public string PlaceA { get; }
        public string PlaceB { get; }
        public int Distance { get; }

        #endregion

        #region | ctors

        private Direction(string placeA, string placeB, int distance)
        {
            PlaceA = placeA;
            PlaceB = placeB;
            Distance = distance;
        }

        #endregion

        #region | Public interface

        public static Direction Parse(string line)
        {
            var match = NavigRe.Match(line);
            if (!match.Success)
                throw new ArgumentException($"Bad direction {line}");

            var placeA = match.Groups["placeA"].Value;
            var placeB = match.Groups["placeB"].Value;
            var rawDistance = match.Groups["distance"].Value;
            var distance = int.Parse(rawDistance);
            return new Direction(placeA, placeB, distance);
        }

        #endregion
    }
}