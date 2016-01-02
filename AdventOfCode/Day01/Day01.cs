using AdventOfCode.Shared;

namespace AdventOfCode.Day01
{
    public class Day01 : IAdventDay
    {
        #region | Public interface

        public int WhatFloorShouldSantaGoIn(string brackets)
        {
            var actualFloor = 0;
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
            var actualFloor = 0;
            var actualIndex = 0;
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

        #endregion

        #region  | Interface members

        public object SolvePartOne() => WhatFloorShouldSantaGoIn(Day01Input.BRACKETS);

        public object SolvePartTwo() => WhatIndexIsLeadingIntoTheBasement(Day01Input.BRACKETS);

        public string PuzzleName => "Not Quite Lisp";

        #endregion
    }
}