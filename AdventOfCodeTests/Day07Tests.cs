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
            Circut.Disassemble();
            var line = "123 -> x";
            var wire = WireParser.ParseWire(line);
            Assert.That(wire.GetValue(), Is.EqualTo(123));
        }

        [Test]
        public void OneHop()
        {
            Circut.Disassemble();
            var line1 = "123 -> x";
            var line2 = "x -> y";
            var wire1 = WireParser.ParseWire(line1);
            var wire2 = WireParser.ParseWire(line2);
            Circut.AllWires.Add(wire1.ID, wire1);
            Circut.AllWires.Add(wire2.ID, wire2);
            Assert.That(Circut.AllWires["y"].GetValue(), Is.EqualTo(123));
        }

        [Test]
        public void AndGate()
        {
            Circut.Disassemble();
            var line1 = "7 -> x";
            var line2 = "1 -> y";
            var line3 = "x AND y -> z";
            var wire1 = WireParser.ParseWire(line1);
            var wire2 = WireParser.ParseWire(line2);
            var wire3 = WireParser.ParseWire(line3);
            Circut.AllWires.Add(wire1.ID, wire1);
            Circut.AllWires.Add(wire2.ID, wire2);
            Circut.AllWires.Add(wire3.ID, wire2);
            Assert.That(Circut.AllWires["z"].GetValue(), Is.EqualTo(1));
        }

        [Test]
        public void OrGate()
        {
            Circut.Disassemble();
            var line1 = "7 -> x";
            var line2 = "1 -> y";
            var line3 = "x OR y -> z";
            var wire1 = WireParser.ParseWire(line1);
            var wire2 = WireParser.ParseWire(line2);
            var wire3 = WireParser.ParseWire(line3);
            Circut.AllWires.Add(wire1.ID, wire1);
            Circut.AllWires.Add(wire2.ID, wire2);
            Circut.AllWires.Add(wire3.ID, wire3);
            Assert.That(Circut.AllWires["z"].GetValue(), Is.EqualTo(7));
        }

        [Test]
        public void Sample()
        {
            Circut.Disassemble();
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
                var wire = WireParser.ParseWire(line);
                Circut.AllWires.Add(wire.ID, wire);
            }

            Assert.That(Circut.AllWires["d"].GetValue(), Is.EqualTo(72));
            Assert.That(Circut.AllWires["e"].GetValue(), Is.EqualTo(507));
            Assert.That(Circut.AllWires["f"].GetValue(), Is.EqualTo(492));
            Assert.That(Circut.AllWires["g"].GetValue(), Is.EqualTo(114));
            Assert.That(Circut.AllWires["h"].GetValue(), Is.EqualTo(65412));
            Assert.That(Circut.AllWires["i"].GetValue(), Is.EqualTo(65079));
            Assert.That(Circut.AllWires["x"].GetValue(), Is.EqualTo(123));
            Assert.That(Circut.AllWires["y"].GetValue(), Is.EqualTo(456));
        }
    }
}
