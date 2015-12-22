namespace AdventOfCode.Day07.SignalProviders
{
    public class SignalProvider
    {
        #region | Properties & fields

        protected ushort Value { get; set; }
        protected bool IsResolved { get; set; }

        #endregion

        #region | ctors

        protected SignalProvider()
        {
        }

        public SignalProvider(ushort value)
        {
            Value = value;
            IsResolved = true;
        }

        #endregion

        #region | Public interface

        public virtual ushort GetValue()
        {
            return Value;
        }

        #endregion
    }
}