using AdventOfCode.Day07;
using AdventOfCode.Shared;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    [TestFixture]
    public class Day07Tests
    {

        [Test]
        public void SimpleSignal()
        {
            var circut = new Circut();
            var line = "123 -> x";
            var wire = WireParser.ParseWire(circut, line);
            Assert.That(wire.GetValue(), Is.EqualTo(123));
        }

        [Test]
        public void OneHop()
        {
            var circut = new Circut();
            var line1 = "123 -> x";
            var line2 = "x -> y";
            var wire1 = WireParser.ParseWire(circut, line1);
            var wire2 = WireParser.ParseWire(circut, line2);
            circut.AllWires.Add(wire1.ID, wire1);
            circut.AllWires.Add(wire2.ID, wire2);
            Assert.That(circut.AllWires["y"].GetValue(), Is.EqualTo(123));
        }

        [Test]
        public void AndGate()
        {
            var circut = new Circut();
            var line1 = "7 -> x";
            var line2 = "1 -> y";
            var line3 = "x AND y -> z";
            var wire1 = WireParser.ParseWire(circut, line1);
            var wire2 = WireParser.ParseWire(circut, line2);
            var wire3 = WireParser.ParseWire(circut, line3);
            circut.AllWires.Add(wire1.ID, wire1);
            circut.AllWires.Add(wire2.ID, wire2);
            circut.AllWires.Add(wire3.ID, wire2);
            Assert.That(circut.AllWires["z"].GetValue(), Is.EqualTo(1));
        }

        [Test]
        public void OrGate()
        {
            var circut = new Circut();
            var line1 = "7 -> x";
            var line2 = "1 -> y";
            var line3 = "x OR y -> z";
            var wire1 = WireParser.ParseWire(circut, line1);
            var wire2 = WireParser.ParseWire(circut, line2);
            var wire3 = WireParser.ParseWire(circut, line3);
            circut.AllWires.Add(wire1.ID, wire1);
            circut.AllWires.Add(wire2.ID, wire2);
            circut.AllWires.Add(wire3.ID, wire3);
            Assert.That(circut.AllWires["z"].GetValue(), Is.EqualTo(7));
        }

        [Test]
        public void Sample()
        {
            var circut = new Circut();
            var input = @"
123 -> x
456 -> y
x AND y -> d
x OR y -> e
x LSHIFT 2 -> f
y RSHIFT 2 -> g
NOT x -> h
NOT y -> i";


            var lines = InputLineParser.GetAllLines(input);
            foreach (var line in lines)
            {
                var wire = WireParser.ParseWire(circut, line);
                circut.AllWires.Add(wire.ID, wire);
            }

            Assert.That(circut.AllWires["d"].GetValue(), Is.EqualTo(72));
            Assert.That(circut.AllWires["e"].GetValue(), Is.EqualTo(507));
            Assert.That(circut.AllWires["f"].GetValue(), Is.EqualTo(492));
            Assert.That(circut.AllWires["g"].GetValue(), Is.EqualTo(114));
            Assert.That(circut.AllWires["h"].GetValue(), Is.EqualTo(65412));
            Assert.That(circut.AllWires["i"].GetValue(), Is.EqualTo(65079));
            Assert.That(circut.AllWires["x"].GetValue(), Is.EqualTo(123));
            Assert.That(circut.AllWires["y"].GetValue(), Is.EqualTo(456));
        }
    }
}
