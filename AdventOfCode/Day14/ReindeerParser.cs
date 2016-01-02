using System.Text.RegularExpressions;

namespace AdventOfCode.Day14
{
    public class ReindeerParser
    {
        static Regex reindeerRE = new Regex(@"(?<name>\w+) can fly (?<speed>\d+) km\/s for (?<active>\d+) seconds, but then must rest for (?<rest>\d+) seconds.", RegexOptions.Compiled);

        public static Reindeer ParseReindeer(string line)
        {
            var match = reindeerRE.Match(line);
            var name = match.Groups["name"].Value;
            var speed = int.Parse(match.Groups["speed"].Value);
            var active = int.Parse(match.Groups["active"].Value);
            var rest = int.Parse(match.Groups["rest"].Value);

            return new Reindeer(name, speed, active, rest);
        }
    }
}
