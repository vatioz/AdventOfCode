using AdventOfCode.Day07.SignalProviders;
using AdventOfCode.Day07.SignalProviders.Gates;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day07
{
    public static class ProviderParser
    {
        #region |  Constants

        private static readonly Regex AndRe = new Regex(@"(?<one>\w+) AND (?<two>\w+)", RegexOptions.Compiled);
        private static readonly Regex OrRe = new Regex(@"(?<one>\w+) OR (?<two>\w+)", RegexOptions.Compiled);
        private static readonly Regex NotRe = new Regex(@"NOT (?<one>\w+)", RegexOptions.Compiled);
        private static readonly Regex LshiftRe = new Regex(@"(?<one>\w+) LSHIFT (?<count>\d+)", RegexOptions.Compiled);
        private static readonly Regex RshiftRe = new Regex(@"(?<one>\w+) RSHIFT (?<count>\d+)", RegexOptions.Compiled);

        #endregion

        #region | Public interface

        public static SignalProvider ParseProviderType(string rawProvider, Circut circut)
        {
            Debug.WriteLine(rawProvider);
            var andMatch = AndRe.Match(rawProvider);
            if (andMatch.Success)
            {
                var one = andMatch.Groups["one"].Value;
                var two = andMatch.Groups["two"].Value;

                var wireOne = ParseSingleProvider(one, circut);
                var wireTwo = ParseSingleProvider(two, circut);

                return new AndGate(wireOne, wireTwo);
            }

            var orMatch = OrRe.Match(rawProvider);
            if (orMatch.Success)
            {
                var one = orMatch.Groups["one"].Value;
                var two = orMatch.Groups["two"].Value;

                var wireOne = ParseSingleProvider(one, circut);
                var wireTwo = ParseSingleProvider(two, circut);

                return new OrGate(wireOne, wireTwo);
            }

            var notMatch = NotRe.Match(rawProvider);
            if (notMatch.Success)
            {
                var one = notMatch.Groups["one"].Value;

                var wireOne = ParseSingleProvider(one, circut);

                return new NotGate(wireOne);
            }

            var lshiftMatch = LshiftRe.Match(rawProvider);
            if (lshiftMatch.Success)
            {
                var one = lshiftMatch.Groups["one"].Value;
                var count = lshiftMatch.Groups["count"].Value;

                var wireOne = ParseSingleProvider(one, circut);
                var byteCount = byte.Parse(count);

                return new LshiftGate(wireOne, byteCount);
            }

            var rshiftMatch = RshiftRe.Match(rawProvider);
            if (rshiftMatch.Success)
            {
                var one = rshiftMatch.Groups["one"].Value;
                var count = rshiftMatch.Groups["count"].Value;

                var wireOne = ParseSingleProvider(one, circut);
                var byteCount = byte.Parse(count);

                return new RshiftGate(wireOne, byteCount);
            }

            return ParseSingleProvider(rawProvider, circut);
        }

        #endregion

        #region | Non-public members

        private static SignalProvider ParseSingleProvider(string rawProvider, Circut circut)
        {
            ushort value = 0;
            if (ushort.TryParse(rawProvider, out value))
                return new SignalProvider(value);

            return circut.AllWires[rawProvider];
        }

        #endregion
    }
}