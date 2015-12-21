using AdventOfCode.Day06;
using NUnit.Framework;
using System.Drawing;

namespace AdventOfCodeTests
{
    [TestFixture]
    public class Day06Tests
    {
        [Test]
        public void ItsDarkOnStart()
        {
            var grid = new BinaryLightingGrid();
            var lightsCount = grid.HowManyLightsAreLit();
            Assert.That(lightsCount, Is.EqualTo(0));
        }

        [TestCase(0, 0, 0, 0, ExpectedResult = 1)]
        [TestCase(0, 0, 999, 999, ExpectedResult = 1000000)]
        [TestCase(0, 0, 999, 0, ExpectedResult = 1000)]
        [TestCase(499, 499, 500, 500, ExpectedResult = 4)]
        [TestCase(0, 0, 2, 2, ExpectedResult = 9)]
        public int TurningOnLights(int fromX, int fromY, int toX, int toY)
        {
            var grid = new BinaryLightingGrid();
            grid.ProcessInstruction("turn on", new Point(fromX, fromY), new Point(toX, toY));
            return grid.HowManyLightsAreLit();
        }

        [Test]
        public void CanReset()
        {
            var grid = new BinaryLightingGrid();
            grid.ProcessInstruction("turn on", new Point(1, 1), new Point(5, 5));
            var lightsCount = grid.HowManyLightsAreLit();
            Assert.That(lightsCount, Is.EqualTo(25));

            grid.Reset();
            lightsCount = grid.HowManyLightsAreLit();
            Assert.That(lightsCount, Is.EqualTo(0));
        }


        [Test]
        public void CanToggle()
        {
            var grid = new BinaryLightingGrid();
            grid.ProcessInstruction("turn on", new Point(1, 1), new Point(5, 5));
            var lightsCount = grid.HowManyLightsAreLit();
            Assert.That(lightsCount, Is.EqualTo(25));

            grid.ProcessInstruction("toggle", new Point(1, 1), new Point(1, 1));
            lightsCount = grid.HowManyLightsAreLit();
            Assert.That(lightsCount, Is.EqualTo(24));

            grid.ProcessInstruction("toggle", new Point(0, 0), new Point(1, 1));
            lightsCount = grid.HowManyLightsAreLit();
            Assert.That(lightsCount, Is.EqualTo(28));
        }

        [Test]
        public void CanIncrease()
        {
            var grid = new ShadingLightingGrid();
            grid.ProcessInstruction("turn on", new Point(0, 0), new Point(0, 0));
            var lightsCount = grid.HowManyLightsAreLit();
            Assert.That(lightsCount, Is.EqualTo(1));

            grid.ProcessInstruction("turn on", new Point(0, 0), new Point(0, 0));
            lightsCount = grid.HowManyLightsAreLit();
            Assert.That(lightsCount, Is.EqualTo(2));
        }

        [Test]
        public void CanToggleByTwo()
        {
            var grid = new ShadingLightingGrid();
            grid.ProcessInstruction("toggle", new Point(0, 0), new Point(999, 999));
            var lightsCount = grid.HowManyLightsAreLit();
            Assert.That(lightsCount, Is.EqualTo(2000000));
        }


        [Test]
        public void DimmingCannotDropBelowZero()
        {
            var grid = new ShadingLightingGrid();
            grid.ProcessInstruction("toggle", new Point(0, 0), new Point(999, 999));
            var lightsCount = grid.HowManyLightsAreLit();
            Assert.That(lightsCount, Is.EqualTo(2000000));

            grid.ProcessInstruction("turn off", new Point(0, 0), new Point(0, 0));
            grid.ProcessInstruction("turn off", new Point(0, 0), new Point(0, 0));
            lightsCount = grid.HowManyLightsAreLit();
            Assert.That(lightsCount, Is.EqualTo(2000000 - 2));

            grid.ProcessInstruction("turn off", new Point(0, 0), new Point(0, 0));
            grid.ProcessInstruction("turn off", new Point(0, 0), new Point(0, 0));
            lightsCount = grid.HowManyLightsAreLit();
            Assert.That(lightsCount, Is.EqualTo(2000000 - 2));

        }


    }
}
