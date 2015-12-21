using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Shared
{
    public class InputLineParser
    {
        public static IEnumerable<string> GetAllLines(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                yield break;

            var sr = new StringReader(input);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(line))
                    yield return line;
            }
        }


    }
}
