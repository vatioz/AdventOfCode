using AdventOfCode.Shared;

namespace AdventOfCode.Day03
{
    public class Day03 : IAdventDay
    {
        #region | Public interface

        public int CountHousesWithPresent(string directions, int numberOfSantas)
        {
            var tour = new HouseTour();
            tour.AddMultipleDeliveryBoys(numberOfSantas);
            foreach (var arrow in directions)
            {
                tour.DeliverNextPresent(arrow);
            }

            return tour.HousesWithPresentCount;
        }

        #endregion

        #region  | Interface members

        public object SolvePartOne() => CountHousesWithPresent(Day03Input.ARROWS, 1);

        public object SolvePartTwo() => CountHousesWithPresent(Day03Input.ARROWS, 2);

        public string PuzzleName => "Perfectly Spherical Houses in a Vacuum";

        #endregion
    }
}