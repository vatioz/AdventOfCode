using AdventOfCode.Shared;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day08
{
    public class Day08 : IAdventDay
    {
        public IEnumerable<string> ReadFile()
        {
            return FileLineParser.GetAllLines(@"Day08\Day08Input.txt");
        }



        public string SolvePartOne()
        {
            var memoryAllocation = 0;
            var stringAllocation = 0;

            var lines = ReadFile();
            foreach (var line in lines)
            {
                memoryAllocation += line.Length;
                var unescaped = new Unescapeator(line).Unescape();
                stringAllocation += unescaped.Length;
            }

            return (memoryAllocation - stringAllocation).ToString();

        }

        public string SolvePartTwo()
        {
            var memoryAllocation = 0;
            var stringAllocation = 0;

            var lines = ReadFile();
            foreach (var line in lines)
            {
                stringAllocation += line.Length;
                var reescaped = new Unescapeator(line).Reescape();
                memoryAllocation += reescaped.Length;
            }

            return (memoryAllocation - stringAllocation).ToString();
        }

        public string PuzzleName => "Matchsticks";
    }

    public class Unescapeator
    {
        private static Regex xEscape = new Regex(@"\\x[0-9a-f]{2,2}", RegexOptions.Compiled);

        //private EscapedString escapedString;
        private string escapedString;
        public Unescapeator(string str)
        {
            escapedString = str;
        }

        public string Unescape()
        {
            var unesc = escapedString.Substring(1, escapedString.Length - 2);


            unesc = unesc.Replace("\\\"", "\"");
            unesc = unesc.Replace("\\\\", "\\");
            unesc = xEscape.Replace(unesc, ".");

            return unesc;
        }

        public string Reescape()
        {
            var unesc = escapedString;
            unesc = unesc.Replace("\\", "..");
            unesc = unesc.Replace("\"", "..");
            unesc = xEscape.Replace(unesc, "12345");
            unesc = unesc + "..";

            return unesc;
        }
    }


}
