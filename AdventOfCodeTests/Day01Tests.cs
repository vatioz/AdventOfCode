using AdventOfCode.Day01;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    [TestFixture]
    public class Day01Tests
    {

        private static object[] floors = new[]
        {
            new object[] {"", 0},
            new object[] {"(", 1},
            new object[] {")", -1},
            new object[] {"()", 0},
            new object[] {"(())", 0},
            new object[] {"()()", 0},
            new object[] {"((((()", 4},
            new object[] {"((()((", 4},
        };


        [TestCaseSource("floors")]
        public void FloorTesting(string brackets, int expectedFloor)
        {
            Day01 d01 = new Day01();
            int floor = d01.WhatFloorShouldSantaGoIn(brackets);
            Assert.That(floor, Is.EqualTo(expectedFloor));
        }
    }
}
