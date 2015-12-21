namespace AdventOfCode.Day07
{
    public class NotGate : SignalProvider
    {
        private SignalProvider _one;

        public NotGate(SignalProvider one)
        {
            _one = one;
        }

        public override ushort GetValue()
        {
            return Circut.NOT(_one);
        }
    }
}