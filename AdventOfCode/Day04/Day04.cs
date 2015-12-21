using AdventOfCode.Shared;
using System;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Day04
{
    public class Day04 : IAdventDay
    {




        public string SolvePartOne() => FindNumberProducingHashWithLeadingZeroes("bgvyzdsv");

        public string SolvePartTwo() => FindNumberProducingHashWithLeadingZeroes("bgvyzdsv", 6);
        public string PuzzleName { get { return "The Ideal Stocking Stuffer"; } }

        public string FindNumberProducingHashWithLeadingZeroes(string secretKey, int numberOfLeadingZeros = 5)
        {
            uint lowestPositiveNumber = 1;
            while (lowestPositiveNumber < uint.MaxValue)
            {
                var hashInput = string.Format("{0}{1}", secretKey, lowestPositiveNumber);
                var md5 = MD5.Create();
                var bytes = Encoding.UTF8.GetBytes(hashInput);
                var hashBytes = md5.ComputeHash(bytes);
                //var hash = Encoding.UTF8.GetString(hashBytes);
                var hash = BitConverter.ToString(hashBytes).Replace("-", "");
                if (hash.StartsWith(new String('0', numberOfLeadingZeros)))
                    return lowestPositiveNumber.ToString();

                lowestPositiveNumber++;
            }

            return "fuck this";
        }
    }
}
