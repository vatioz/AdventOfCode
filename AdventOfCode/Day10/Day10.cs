using AdventOfCode.Shared;
using System;
using System.Diagnostics;
using System.Text;

namespace AdventOfCode.Day10
{
    public class Day10 : IAdventDay
    {
        private const int NUMBER_OF_ITERATIONS_PART1 = 40;
        private const int NUMBER_OF_ITERATIONS_PART2 = 50;

        private StringBuilder nextSequence;

        public string LookAndSay(string sequence)
        {
            nextSequence = new StringBuilder();
            for (int i = 0; i < sequence.Length; i++)
            {
                char actualDigit = sequence[i];
                int numberOfRepeats = 1;
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
            for (int i = 0; i < iterations; i++)
            {
                startingSequence = LookAndSay(startingSequence);
                Debug.WriteLine($"Iteration {i} done...");
            }

            return startingSequence;
        }

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
    }
}
