using AdventOfCode.Shared;

namespace AdventOfCode.Day06
{
    public class Day06 : IAdventDay
    {
        #region  | Interface members

        public object SolvePartOne()
        {
            var grid = new BinaryLightingGrid();
            var lines = InputLineParser.GetAllLines(Day06Input.INSTRUCTIONS);
            foreach (var line in lines)
            {
                var instruction = new LightInstruction(line);
                grid.ProcessInstruction(instruction);
            }

            return grid.HowManyLightsAreLit();
        }

        public object SolvePartTwo()
        {
            var grid = new ShadingLightingGrid();
            var lines = InputLineParser.GetAllLines(Day06Input.INSTRUCTIONS);
            foreach (var line in lines)
            {
                var instruction = new LightInstruction(line);
                grid.ProcessInstruction(instruction);
            }

            return grid.HowManyLightsAreLit();
        }

        public string PuzzleName => "Probably a Fire Hazard";

        #endregion
    }
}