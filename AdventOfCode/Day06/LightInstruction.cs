using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day06
{
    public class LightInstruction
    {
        #region |  Constants

        private static readonly Regex regex =
            new Regex(@"(?<mode>[turnofgle ]+) (?<fromX>\d+),(?<fromY>\d+) through (?<toX>\d+),(?<toY>\d+)");

        #endregion

        #region | Properties & fields

        public string Mode { get; set; }
        public Point From { get; set; }
        public Point To { get; set; }

        #endregion

        #region | ctors

        public LightInstruction(string line)
        {
            Parse(line);
        }

        #endregion

        #region | Non-public members

        private void Parse(string line)
        {
            var match = regex.Match(line);
            if (!match.Success)
                throw new ArgumentException("bad input line " + line);

            Mode = match.Groups["mode"].Value;
            var fromX = int.Parse(match.Groups["fromX"].Value);
            var fromY = int.Parse(match.Groups["fromY"].Value);
            var toX = int.Parse(match.Groups["toX"].Value);
            var toY = int.Parse(match.Groups["toY"].Value);
            From = new Point(fromX, fromY);
            To = new Point(toX, toY);
        }

        #endregion
    }
}