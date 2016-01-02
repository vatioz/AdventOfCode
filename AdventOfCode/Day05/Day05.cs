using AdventOfCode.Shared;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day05
{
    public class Day05 : IAdventDay
    {
        #region | Properties & fields

        private readonly string[] _bannedDoubles = { "ab", "cd", "pq", "xy" };

        private readonly char[] _vovels = { 'a', 'e', 'i', 'o', 'u' };

        #endregion

        #region | Public interface

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

        #endregion

        #region | Non-public members

        private bool ContainsDoubleWithOneCharInTheMiddle(string word)
        {
            for (var i = 0; i < word.Length - 2; i++)
            {
                var first = word[i];
                var third = word[i + 2];

                if (first == third)
                    return true;
            }

            return false;
        }

        private List<string> GetAllDoubles(string word)
        {
            var doubles = new List<string>();
            for (var i = 0; i < word.Length - 1; i++)
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

            if (!duplicates.Any())
                return false;

            foreach (var pair in duplicates)
            {
                var modifiedWord = word.Replace(pair, ""); // remove this duplicate
                if (modifiedWord.Length <= word.Length - 4) // only if we removed more than 4 chars, we got at least two doubles
                    return true;
            }
            return false;
        }

        private bool ContainsBannedStrings(string word)
        {
            return _bannedDoubles.Any(word.Contains);
        }

        private bool ContainsDoubledLetter(string word)
        {
            for (var i = 0; i < word.Length - 1; i++)
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
            var vovelCount = word.Count(letter => _vovels.Contains(letter));
            return vovelCount >= 3;
        }

        #endregion

        #region  | Interface members

        public object SolvePartOne()
        {
            var lines = InputLineParser.GetAllLines(Day05Input.WORDS);
            var niceWordsCount = lines.Where(IsWordNice).Count();
            return niceWordsCount;
        }

        public object SolvePartTwo()
        {
            var lines = InputLineParser.GetAllLines(Day05Input.WORDS);
            var niceWordsCount = lines.Where(IsWordReallyNice).Count();
            return niceWordsCount;
        }

        public string PuzzleName => "Doesn't He Have Intern-Elves For This?";

        #endregion
    }
}