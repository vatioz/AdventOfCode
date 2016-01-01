using System.Text.RegularExpressions;

namespace AdventOfCode.Day13
{
    public class PersonalityParser
    {
        private static readonly Regex _personalityRe = new Regex(@"(?<gainer>\w+) would (?<sign>gain|lose) (?<happiness>\d+) happiness units by sitting next to (?<neighbor>\w+).", RegexOptions.Compiled);

        public static Personality ParsePersonality(string line)
        {
            var match = _personalityRe.Match(line);
            var personality = new Personality
            {
                Name = match.Groups["gainer"].Value,
                Neighbor = match.Groups["neighbor"].Value
            };

            var happiness = int.Parse(match.Groups["happiness"].Value);
            var gainOrLose = match.Groups["sign"].Value;
            if (gainOrLose == "lose")
                happiness = -happiness;

            personality.Happiness = happiness;
            return personality;
        }
    }

    public class Personality
    {
        public string Name { get; set; }
        public int Happiness { get; set; }
        public string Neighbor { get; set; }


    }
}
