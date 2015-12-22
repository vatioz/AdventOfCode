using AdventOfCode.Shared;

namespace AdventOfCode.Day02
{
    public class Day02 : IAdventDay
    {
        #region | Public interface

        public int CountAllAreas(string input)
        {
            var sum = 0;
            var lines = InputLineParser.GetAllLines(input);
            foreach (var line in lines)
            {
                var present = new Present(line);
                sum += present.Area + present.GetSmallestArea();
            }

            return sum;
        }

        public int CountAllRibbons(string input)
        {
            var sum = 0;
            var lines = InputLineParser.GetAllLines(input);
            foreach (var line in lines)
            {
                var present = new Present(line);
                sum += present.GetSmallestPerimeter() + present.Volume;
            }

            return sum;
        }

        #endregion

        #region  | Interface members

        public string PuzzleName => "I Was Told There Would Be No Math";

        public string SolvePartOne() => CountAllAreas(Day02Input.RAW_AREAS).ToString();

        public string SolvePartTwo() => CountAllRibbons(Day02Input.RAW_AREAS).ToString();

        #endregion
    }
}