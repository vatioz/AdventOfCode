using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day12
{
    public class Day12 : IAdventDay
    {
        public string PuzzleName => "JSAbacusFramework.io";

        public string SolvePartOne()
        {
            var input = FileParser.GetAllText("Day12/Day12Input.txt");
            var parser = new JSONNumberParser();
            var sum = parser.GetAllNumbers(input).Aggregate((a, b) => a + b);
            return sum.ToString();
        }

        public string SolvePartTwo()
        {
            return "Not yet";
        }
    }
}
