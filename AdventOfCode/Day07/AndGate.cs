namespace AdventOfCode.Day07
{
    public class AndGate : SignalProvider
    {
        private SignalProvider _one;
        private SignalProvider _two;

        public AndGate(SignalProvider one, SignalProvider two)
        {
            _one = one;
            _two = two;
        }

        public override ushort GetValue()
        {
            return Circut.AND(_one, _two);
        }
    }
}