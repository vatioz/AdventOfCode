using AdventOfCode.Shared;
using System.IO;

namespace AdventOfCode.Day02
{
    public class Day02 : IAdventDay
    {
        public int CountAllAreas(string lines)
        {
            var sr = new StringReader(lines);
            string line;
            int sum = 0;
            while ((line = sr.ReadLine()) != null)
            {
                var wrapper = new Wrapper(line);
                sum += wrapper.Area + wrapper.SmallestArea;
            }

            return sum;
        }




        public int CountAllRibbons(string lines)
        {
            var sr = new StringReader(lines);
            string line;
            int sum = 0;
            while ((line = sr.ReadLine()) != null)
            {
                var wrapper = new Wrapper(line);
                sum += wrapper.SmallestPerimeter + wrapper.Volume;
            }

            return sum;
        }

        public string SolvePartOne() => CountAllAreas(Day02Input.RAW_AREAS).ToString();

        public string SolvePartTwo() => CountAllRibbons(Day02Input.RAW_AREAS).ToString();
        public string PuzzleName
        {
            get { return "I Was Told There Would Be No Math"; }
        }
    }
}
