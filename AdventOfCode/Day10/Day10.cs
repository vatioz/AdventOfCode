using AdventOfCode.Shared;
using System.Diagnostics;
using System.Text;

namespace AdventOfCode.Day10
{
    public class Day10 : IAdventDay
    {
        #region |  Constants

        private const int NUMBER_OF_ITERATIONS_PART1 = 40;
        private const int NUMBER_OF_ITERATIONS_PART2 = 50;

        #endregion

        #region | Properties & fields

        private StringBuilder nextSequence;

        #endregion

        #region | Public interface

        public string LookAndSay(string sequence)
        {
            nextSequence = new StringBuilder();
            for (var i = 0; i < sequence.Length; i++)
            {
                var actualDigit = sequence[i];
                var numberOfRepeats = 1;
                while ((i + 1 < sequence.Length) && actualDigit == sequence[i + 1])
                {
                    i++;
                    numberOfRepeats++;
                }

                nextSequence.Append(numberOfRepeats).Append(actualDigit);
            }

            return nextSequence.ToString();
        }

        public string RepeatedLookAndSay(string startingSequence, int iterations)
        {
            for (var i = 0; i < iterations; i++)
            {
                startingSequence = LookAndSay(startingSequence);
                Debug.WriteLine($"Iteration {i} done.");
            }

            return startingSequence;
        }

        #endregion

        #region  | Interface members

        public string SolvePartOne()
        {
            var resultSeq = RepeatedLookAndSay("3113322113", NUMBER_OF_ITERATIONS_PART1);
            return resultSeq.Length.ToString();
        }

        public string SolvePartTwo()
        {
            var resultSeq = RepeatedLookAndSay("3113322113", NUMBER_OF_ITERATIONS_PART2);
            return resultSeq.Length.ToString();
        }

        public string PuzzleName => "Elves Look, Elves Say";

        #endregion
    }
}