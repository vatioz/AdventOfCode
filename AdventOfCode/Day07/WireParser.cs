using AdventOfCode.Day07.SignalProviders;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day07
{
    public static class WireParser
    {
        #region |  Constants

        private static readonly Regex _wireConnectionRE = new Regex(@"(?<provider>.*) -> (?<wire>\w+)");

        #endregion

        #region | Public interface

        public static Wire ParseWire(Circut circut, string line)
        {
            var match = _wireConnectionRE.Match(line);
            var wireName = match.Groups["wire"].Value;
            var rawProvider = match.Groups["provider"].Value;

            return new Wire(circut, wireName, rawProvider);
        }

        #endregion
    }
}