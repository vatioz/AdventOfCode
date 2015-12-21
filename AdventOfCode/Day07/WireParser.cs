using System.Text.RegularExpressions;

namespace AdventOfCode.Day07
{
    public class WireParser
    {
        private static Regex wireConnectionRE = new Regex(@"(?<provider>.*) -> (?<wire>\w+)");


        public static Wire ParseWire(string line)
        {
            var match = wireConnectionRE.Match(line);
            var wireName = match.Groups["wire"].Value;
            var rawProvider = match.Groups["provider"].Value;

            //Debug.WriteLine($"Parsed wire {wireName}");
            return new Wire(wireName, rawProvider);
        }
    }
}