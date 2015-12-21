namespace AdventOfCode.Day07
{
    public class OrGate : SignalProvider
    {
        private SignalProvider _one;
        private SignalProvider _two;

        public OrGate(SignalProvider one, SignalProvider two)
        {
            _one = one;
            _two = two;
        }

        public override ushort GetValue()
        {
            return Circut.OR(_one, _two);
        }
    }
}