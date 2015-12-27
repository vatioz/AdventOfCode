using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode.Day11
{
    public class PasswordGenerator
    {
        public PasswordGenerator(string currentPassword)
        {
            CurrentPassword = currentPassword;
            _workingPassword = CurrentPassword.ToCharArray();
        }

        public string CurrentPassword { get; set; }

        private char[] _workingPassword;

        StringBuilder debug = new StringBuilder();

        public void GenerateNext()
        {
            do
            {
                IncrementPassword();                
            }
            while (!IsPasswordValid());

            CurrentPassword = new string(_workingPassword);
        }

        public bool IncludesIncreasingStraight()
        {
            for (int i = 0; i < _workingPassword.Length - 2; i++)
            {
                var first = _workingPassword[i];
                var second = _workingPassword[i + 1];
                var third = _workingPassword[i + 2];

                if (first == second - 1 && second == third - 1)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ContainsConfusingLetters()
        {
            if (_workingPassword.Contains('i') || _workingPassword.Contains('o') || _workingPassword.Contains('l'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> GetAllDoubles(char[] word)
        {
            var doubles = new List<string>();
            for (int i = 0; i < word.Length - 1; i++)
            {
                var letter = word[i];
                var nextLetter = word[i + 1];
                if(letter == nextLetter)
                    doubles.Add($"{letter}{nextLetter}");

            }

            return doubles;
        }

        private bool ContainsTwoDifferentDoubles()
        {
            var doubles = GetAllDoubles(_workingPassword);
            var uniqueDoubles = doubles.Distinct();
            if (uniqueDoubles.Count() > 1)
                return true;

            return false;
        }

        public bool IsPasswordValid()
        {
            if (!IncludesIncreasingStraight())
            {
                return false;
            }

            if (ContainsConfusingLetters())
            {
                return false;
            }

            if (!ContainsTwoDifferentDoubles())
            {
                return false;
            }

            return true;
        }

        public void IncrementPassword()
        {
            var incrementNext = true;
            var currentIndex = _workingPassword.Length - 1;
            while (incrementNext && currentIndex >= 0)
            {
                var currentLetter = _workingPassword[currentIndex];
                if (currentLetter == 'z')
                {
                    _workingPassword[currentIndex] = 'a';
                    currentIndex--;
                }
                else
                {
                    _workingPassword[currentIndex] = ++currentLetter;
                    incrementNext = false;
                }
            }
        }

    }
}
