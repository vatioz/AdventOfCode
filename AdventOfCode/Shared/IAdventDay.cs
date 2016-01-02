namespace AdventOfCode.Shared
{
    public interface IAdventDay
    {
        object SolvePartOne();
        object SolvePartTwo();

        string PuzzleName { get; }

    }
}
