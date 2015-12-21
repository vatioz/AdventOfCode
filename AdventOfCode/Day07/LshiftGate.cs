namespace AdventOfCode.Day07
{
    public class LshiftGate : SignalProvider
    {
        private SignalProvider _one;
        private byte _count;

        public LshiftGate(SignalProvider one, byte count)
        {
            _one = one;
            _count = count;
        }

        public override ushort GetValue()
        {
            return Circut.LSHIFT(_one, _count);
        }
    }
}