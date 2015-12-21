using AdventOfCode.Shared;
using System.Collections.Generic;

namespace AdventOfCode.Day03
{
    public class Day03 : IAdventDay
    {
        private List<Position> whereHaveIBeen = new List<Position>();
        private Position actual;
        public int CountHousesWithPresent(string directions)
        {

            actual = new Position(0, 0);
            whereHaveIBeen.Clear();
            whereHaveIBeen.Add(actual);
            foreach (var arrow in directions)
            {
                actual.Move(arrow);
                if (!whereHaveIBeen.Contains(actual))
                    whereHaveIBeen.Add(actual);
            }

            return whereHaveIBeen.Count;
        }


        private Position liveSanta;
        private Position roboSanta;

        public int CountHousesWithPresentRobo(string directions)
        {
            liveSanta = new Position(0, 0);
            roboSanta = new Position(0, 0);


            whereHaveIBeen.Clear();
            whereHaveIBeen.Add(liveSanta);
            for (int i = 0; i < directions.Length; i += 2)
            {
                var liveMove = directions[i];
                var roboMove = ' ';
                // if (i + 1 != directions.Length)
                roboMove = directions[i + 1];

                liveSanta.Move(liveMove);
                if (!whereHaveIBeen.Contains(liveSanta))
                    whereHaveIBeen.Add(liveSanta);

                roboSanta.Move(roboMove);
                if (!whereHaveIBeen.Contains(roboSanta))
                    whereHaveIBeen.Add(roboSanta);
            }

            return whereHaveIBeen.Count;
        }

        public string SolvePartOne() => CountHousesWithPresent(Day03Input.ARROWS).ToString();

        public string SolvePartTwo() => CountHousesWithPresentRobo(Day03Input.ARROWS).ToString();
        public string PuzzleName { get { return "Perfectly Spherical Houses in a Vacuum"; } }
    }
}
