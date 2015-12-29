using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Shared;

namespace AdventOfCode.Day11
{
    public class Day11 : IAdventDay
    {
        public string PuzzleName => "CorporatePolicy";

        public string SolvePartOne()
        {
            var gen = new PasswordGenerator("cqjxjnds");
            gen.GenerateNext();
            return gen.CurrentPassword;
        }

        public string SolvePartTwo()
        {
            var gen = new PasswordGenerator("cqjxjnds");
            gen.GenerateNext();
            gen.GenerateNext();
            return gen.CurrentPassword;
        }
    }
}
