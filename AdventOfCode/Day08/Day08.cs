using AdventOfCode.Shared;
using System.Collections.Generic;

namespace AdventOfCode.Day08
{
    public class Day08 : IAdventDay
    {
        #region | Non-public members

        private IEnumerable<string> ReadFile()
        {
            return FileLineParser.GetAllLines(@"Day08\Day08Input.txt");
        }

        #endregion

        #region  | Interface members

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

        #endregion
    }
}