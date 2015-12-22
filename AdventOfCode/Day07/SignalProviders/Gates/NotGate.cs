namespace AdventOfCode.Day07.SignalProviders.Gates
{
    public class NotGate : SignalProvider
    {
        #region | Properties & fields

        private readonly SignalProvider _one;

        #endregion

        #region | ctors

        public NotGate(SignalProvider one)
        {
            _one = one;
        }

        #endregion

        #region | Overrides

        public override ushort GetValue()
        {
            return (ushort) (~_one.GetValue());
        }

        #endregion
    }
}