using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day05
{
    public class Day05 : IAdventDay
    {

        private char[] vovels = new[] { 'a', 'e', 'i', 'o', 'u' };
        private string[] banned = new[] { "ab", "cd", "pq", "xy" };

        public bool IsWordNice(string word)
        {
            if (!ContainsThreeVovels(word))
                return false;
            if (!ContainsDoubledLetter(word))
                return false;
            if (ContainsBannedStrings(word))
                return false;

            return true;
        }

        public bool IsWordReallyNice(string word)
        {
            if (!ContainsTwoDoubles(word))
                return false;
            if (!ContainsDoubleWithOneCharInTheMiddle(word))
                return false;

            return true;
        }

        private bool ContainsDoubleWithOneCharInTheMiddle(string word)
        {
            for (int i = 0; i < word.Length - 2; i++)
            {
                var first = word[i];
                var middle = word[i + 1];
                var last = word[i + 2];

                if (first == last)
                    return true;
            }

            return false;
        }

        private List<string> GetAllDoubles(string word)
        {
            var doubles = new List<string>();
            for (int i = 0; i < word.Length - 1; i++)
            {
                var letter = word[i];
                var nextLetter = word[i + 1];

                doubles.Add($"{letter}{nextLetter}");

            }

            return doubles;
        }

        private bool ContainsTwoDoubles(string word)
        {
            var doubles = GetAllDoubles(word);
            var duplicates = doubles.GroupBy(x => x)
                             .Where(g => g.Count() > 1)
                             .Select(g => g.Key)
                             .ToList();
            if (duplicates.Any())
            {
                foreach (var pair in duplicates)
                {
                    var modifiedWord = word.Replace(pair, "");
                    if (modifiedWord.Length <= word.Length - 4)
                        return true;

                }
            }
            return false;
        }

        private bool ContainsBannedStrings(string word)
        {
            foreach (var ban in banned)
            {
                if (word.Contains(ban))
                    return true;
            }

            return false;
        }

        private bool ContainsDoubledLetter(string word)
        {
            for (int i = 0; i < word.Length - 1; i++)
            {
                var letter = word[i];
                var nextLetter = word[i + 1];

                if (letter == nextLetter)
                    return true;
            }

            return false;
        }

        private bool ContainsThreeVovels(string word)
        {
            int vovelCount = 0;
            foreach (var letter in word)
            {
                if (vovels.Contains(letter))
                    vovelCount++;
            }
            return vovelCount >= 3;
        }

        public string ParseInput(Func<string, bool> part, string lines)
        {
            var sr = new StringReader(lines);
            string line;
            int sum = 0;
            while ((line = sr.ReadLine()) != null)
            {
                if (part(line))
                    sum++;
            }

            return sum.ToString();
        }

        public string SolvePartOne() => ParseInput(IsWordNice, Day05Input.WORDS);

        public string SolvePartTwo() => ParseInput(IsWordReallyNice, Day05Input.WORDS);
        public string PuzzleName { get { return "Doesn't He Have Intern-Elves For This?"; } }
    }
}
