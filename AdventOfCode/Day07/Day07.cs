using AdventOfCode.Shared;

namespace AdventOfCode.Day07
{
    public class Day07 : IAdventDay
    {


        public string SolvePartOne()
        {
            Circut.Disassemble();
            var lines = InputLineParser.GetAllLines(Day07Input.BOOKLET);
            foreach (var line in lines)
            {
                var wire = WireParser.ParseWire(line);
                Circut.AllWires.Add(wire.ID, wire);
            }

            var wireA = Circut.AllWires["a"];
            return wireA.GetValue().ToString();
        }

        public string SolvePartTwo()
        {
            Circut.Disassemble();
            var inputPartOne = Day07Input.BOOKLET;
            var inputPartTwo = inputPartOne.Replace("1674 -> b", "46065 -> b");
            var lines = InputLineParser.GetAllLines(inputPartTwo);
            foreach (var line in lines)
            {
                var wire = WireParser.ParseWire(line);
                Circut.AllWires.Add(wire.ID, wire);
            }

            var wireA = Circut.AllWires["a"];
            return wireA.GetValue().ToString();
        }

        public string PuzzleName { get { return "Some Assembly Required"; } }
    }
}
