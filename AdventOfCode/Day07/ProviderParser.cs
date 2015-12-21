using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day07
{
    public class ProviderParser
    {
        private static Regex andRE = new Regex(@"(?<one>\w+) AND (?<two>\w+)", RegexOptions.Compiled);
        private static Regex orRE = new Regex(@"(?<one>\w+) OR (?<two>\w+)", RegexOptions.Compiled);
        private static Regex notRE = new Regex(@"NOT (?<one>\w+)", RegexOptions.Compiled);
        private static Regex lshiftRE = new Regex(@"(?<one>\w+) LSHIFT (?<count>\d+)", RegexOptions.Compiled);
        private static Regex rshiftRE = new Regex(@"(?<one>\w+) RSHIFT (?<count>\d+)", RegexOptions.Compiled);


        public static SignalProvider ParseProviderType(string rawProvider)
        {
            Debug.WriteLine(rawProvider);
            var andMatch = andRE.Match(rawProvider);
            if (andMatch.Success)
            {
                var one = andMatch.Groups["one"].Value;
                var two = andMatch.Groups["two"].Value;

                var wireOne = ParseSingleProvider(one);
                var wireTwo = ParseSingleProvider(two);

                return new AndGate(wireOne, wireTwo);
            }

            var orMatch = orRE.Match(rawProvider);
            if (orMatch.Success)
            {
                var one = orMatch.Groups["one"].Value;
                var two = orMatch.Groups["two"].Value;

                var wireOne = ParseSingleProvider(one);
                var wireTwo = ParseSingleProvider(two);

                return new OrGate(wireOne, wireTwo);
            }

            var notMatch = notRE.Match(rawProvider);
            if (notMatch.Success)
            {
                var one = notMatch.Groups["one"].Value;

                var wireOne = ParseSingleProvider(one);

                return new NotGate(wireOne);
            }

            var lshiftMatch = lshiftRE.Match(rawProvider);
            if (lshiftMatch.Success)
            {
                var one = lshiftMatch.Groups["one"].Value;
                var count = lshiftMatch.Groups["count"].Value;

                var wireOne = ParseSingleProvider(one);
                var byteCount = byte.Parse(count);

                return new LshiftGate(wireOne, byteCount);
            }

            var rshiftMatch = rshiftRE.Match(rawProvider);
            if (rshiftMatch.Success)
            {
                var one = rshiftMatch.Groups["one"].Value;
                var count = rshiftMatch.Groups["count"].Value;

                var wireOne = ParseSingleProvider(one);
                var byteCount = byte.Parse(count);

                return new RshiftGate(wireOne, byteCount);
            }

            return ParseSingleProvider(rawProvider);


        }

        private static SignalProvider ParseSingleProvider(string rawProvider)
        {
            ushort value = 0;
            if (ushort.TryParse(rawProvider, out value))
                return new SignalProvider(value);
            else
                return Circut.AllWires[rawProvider];
        }
    }
}