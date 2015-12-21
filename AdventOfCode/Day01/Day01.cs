using AdventOfCode.Shared;

namespace AdventOfCode.Day01
{
    public class Day01 : IAdventDay
    {
        public int WhatFloorShouldSantaGoIn(string brackets)
        {
            int actualFloor = 0;
            foreach (var bracket in brackets)
            {
                if (bracket == '(')
                    actualFloor++;
                else
                    actualFloor--;
            }

            return actualFloor;
        }

        public int WhatIndexIsLeadingIntoTheBasement(string brackets)
        {
            int actualFloor = 0;
            int actualIndex = 0;
            foreach (var bracket in brackets)
            {
                actualIndex++;

                if (bracket == '(')
                    actualFloor++;
                else
                    actualFloor--;

                if (actualFloor == -1)
                    break;
            }

            return actualIndex;
        }

        public string SolvePartOne() => WhatFloorShouldSantaGoIn(Day01Input.BRACKETS).ToString();

        public string SolvePartTwo() => WhatIndexIsLeadingIntoTheBasement(Day01Input.BRACKETS).ToString();
        public string PuzzleName { get { return "Not Quite Lisp"; } }
    }
}
