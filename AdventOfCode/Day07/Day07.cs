using AdventOfCode.Shared;

namespace AdventOfCode.Day07
{
    public class Day07 : IAdventDay
    {
        #region  | Interface members

        public object SolvePartOne()
        {
            var circut = new Circut();
            var lines = InputLineParser.GetAllLines(Day07Input.BOOKLET);
            foreach (var line in lines)
            {
                var wire = WireParser.ParseWire(circut, line);
                circut.AllWires.Add(wire.ID, wire);
            }

            var wireA = circut.AllWires["a"];
            return wireA.GetValue();
        }

        public object SolvePartTwo()
        {
            var circut = new Circut();
            var inputPartOne = Day07Input.BOOKLET;
            var inputPartTwo = inputPartOne.Replace("1674 -> b", "46065 -> b");
            var lines = InputLineParser.GetAllLines(inputPartTwo);
            foreach (var line in lines)
            {
                var wire = WireParser.ParseWire(circut, line);
                circut.AllWires.Add(wire.ID, wire);
            }

            var wireA = circut.AllWires["a"];
            return wireA.GetValue();
        }

        public string PuzzleName => "Some Assembly Required";

        #endregion
    }
}