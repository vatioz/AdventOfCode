namespace AdventOfCode.Day07.SignalProviders.Gates
{
    public class LshiftGate : SignalProvider
    {
        #region | Properties & fields

        private readonly byte _count;

        private readonly SignalProvider _one;

        #endregion

        #region | ctors

        public LshiftGate(SignalProvider one, byte count)
        {
            _one = one;
            _count = count;
        }

        #endregion

        #region | Overrides

        public override ushort GetValue()
        {
            return (ushort) (_one.GetValue() << _count);
        }

        #endregion
    }
}