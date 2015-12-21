using AdventOfCode.Shared;
using NUnit.Framework;
using System.Linq;

namespace AdventOfCodeTests
{
    [TestFixture]
    public class InputLineParserTests
    {

        private static object[] rawLinesCases = new[]
        {
            new object[] {@"
abc
def
ghi", 3},
            new object[] {@"
aaa", 1},
            new object[] {@"
1
2
3
4
5
6", 6},
            new object[] {@"", 0},
            new object[] {null, 0},
            new object[] {@"
   
 
 
 


    ", 0},
        };

        [TestCaseSource("rawLinesCases")]
        public void ParserReturnLines(string rawLines, int expectedNumberOfLines)
        {
            var parsedLines = InputLineParser.GetAllLines(rawLines);
            Assert.That(parsedLines.Count(), Is.EqualTo(expectedNumberOfLines));
        }
    }
}
