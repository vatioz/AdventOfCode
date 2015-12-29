using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Day12
{
    public class JSONNumberParser
    {
        private static Regex numberRE = new Regex(@"[-]{0,1}\d+", RegexOptions.Compiled); 

        public IEnumerable<int> GetAllNumbers(string rawJson)
        {
            var matches = numberRE.Matches(rawJson);
            foreach(Match match in matches)
            {
                yield return int.Parse(match.Value);
            }
        }

        public void Parse(string input)
        {
            
        }
    }
}
