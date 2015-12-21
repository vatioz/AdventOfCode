using AdventOfCode.Shared;

namespace AdventOfCode.Day06
{
    public class Day06 : IAdventDay
    {
        public string SolvePartOne()
        {
            var grid = new BinaryLightingGrid();
            var lines = InputLineParser.GetAllLines(Day06Input.INSTRUCTIONS);
            foreach (var line in lines)
            {
                var instruction = new LightInstruction(line);
                grid.ProcessInstruction(instruction);
            }

            return grid.HowManyLightsAreLit().ToString();
        }

        public string SolvePartTwo()
        {
            var grid = new ShadingLightingGrid();
            var lines = InputLineParser.GetAllLines(Day06Input.INSTRUCTIONS);
            foreach (var line in lines)
            {
                var instruction = new LightInstruction(line);
                grid.ProcessInstruction(instruction);
            }

            return grid.HowManyLightsAreLit().ToString();
        }

        public string PuzzleName { get { return "Probably a Fire Hazard"; } }
    }
}
