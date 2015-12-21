using System.Collections.Generic;

namespace AdventOfCode.Day07
{
    public class Circut
    {
        public static Dictionary<string, Wire> AllWires = new Dictionary<string, Wire>();

        public static void Disassemble()
        {
            AllWires.Clear();
        }
        public static ushort AND(SignalProvider one, SignalProvider two)
        {
            return (ushort)(one.GetValue() & two.GetValue());
        }

        public static ushort OR(SignalProvider one, SignalProvider two)
        {
            return (ushort)(one.GetValue() | two.GetValue());
        }

        public static ushort NOT(SignalProvider one)
        {
            return (ushort)(~one.GetValue());
        }

        public static ushort LSHIFT(SignalProvider one, byte count)
        {
            return (ushort)(one.GetValue() << count);
        }

        public static ushort RSHIFT(SignalProvider one, byte count)
        {
            return (ushort)(one.GetValue() >> count);
        }
    }
}