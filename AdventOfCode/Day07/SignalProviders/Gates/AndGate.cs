namespace AdventOfCode.Day07.SignalProviders.Gates
{
    public class AndGate : SignalProvider
    {
        #region | Properties & fields

        private readonly SignalProvider _one;
        private readonly SignalProvider _two;

        #endregion

        #region | ctors

        public AndGate(SignalProvider one, SignalProvider two)
        {
            _one = one;
            _two = two;
        }

        #endregion

        #region | Overrides

        public override ushort GetValue()
        {
            return (ushort) (_one.GetValue() & _two.GetValue());
        }

        #endregion
    }
}