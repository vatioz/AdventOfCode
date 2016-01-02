using AdventOfCode.Shared;
using System;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Day04
{
    public class Day04 : IAdventDay
    {
        #region | Public interface

        public string FindNumberProducingHashWithLeadingZeroes(string secretKey, int numberOfLeadingZeros = 5)
        {
            var nLeadingZeros = new string('0', numberOfLeadingZeros);
            uint lowestPositiveNumber = 1;
            while (lowestPositiveNumber < uint.MaxValue)
            {
                var hashInput = $"{secretKey}{lowestPositiveNumber}";
                var md5 = MD5.Create();
                var bytes = Encoding.UTF8.GetBytes(hashInput);
                var hashBytes = md5.ComputeHash(bytes);
                var hash = BitConverter.ToString(hashBytes).Replace("-", "");
                if (hash.StartsWith(nLeadingZeros))
                    return lowestPositiveNumber.ToString();

                lowestPositiveNumber++;
            }

            return "fuck this";
        }

        #endregion

        #region  | Interface members

        public object SolvePartOne() => FindNumberProducingHashWithLeadingZeroes("bgvyzdsv");

        public object SolvePartTwo() => FindNumberProducingHashWithLeadingZeroes("bgvyzdsv", 6);

        public string PuzzleName => "The Ideal Stocking Stuffer";

        #endregion
    }
}