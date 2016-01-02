using AdventOfCode.Shared;

namespace AdventOfCode.Day13
{
    public class Day13 : IAdventDay
    {
        public string SolvePartOne()
        {
            var host = new Host();
            host.NoticePersonalities(Day13Input.HAPPINESS);
            var maxHappiness = host.TryAllSeatingPlans();
            return maxHappiness.ToString();
        }

        public string SolvePartTwo()
        {
            var host = new Host();
            host.NoticePersonalities(Day13Input.HAPPINESS);
            host.SeatHostHimself();
            var maxHappiness = host.TryAllSeatingPlans();
            return maxHappiness.ToString();
        }

        public string PuzzleName => "Knights of the Dinner Table";
    }
}
