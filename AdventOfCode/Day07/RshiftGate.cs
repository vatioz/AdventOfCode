namespace AdventOfCode.Day07
{
    public class RshiftGate : SignalProvider
    {
        private SignalProvider _one;
        private byte _count;

        public RshiftGate(SignalProvider one, byte count)
        {
            _one = one;
            _count = count;
        }

        public override ushort GetValue()
        {
            return Circut.RSHIFT(_one, _count);
        }
    }
}