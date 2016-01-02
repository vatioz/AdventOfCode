using AdventOfCode.Shared;

namespace AdventOfCode.Day13
{
    public class Day13 : IAdventDay
    {
        public object SolvePartOne()
        {
            var host = new Host();
            host.NoticePersonalities(Day13Input.HAPPINESS);
            var maxHappiness = host.TryAllSeatingPlans();
            return maxHappiness;
        }

        public object SolvePartTwo()
        {
            var host = new Host();
            host.NoticePersonalities(Day13Input.HAPPINESS);
            host.SeatHostHimself();
            var maxHappiness = host.TryAllSeatingPlans();
            return maxHappiness;
        }

        public string PuzzleName => "Knights of the Dinner Table";
    }
}
