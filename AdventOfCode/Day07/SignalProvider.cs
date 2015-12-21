namespace AdventOfCode.Day07
{
    public class SignalProvider
    {
        protected ushort _value;
        protected bool IsHot { get; set; }

        public SignalProvider()
        {
        }

        public SignalProvider(ushort value)
        {
            _value = value;
            IsHot = true;
        }
        public virtual ushort GetValue()
        {
            return _value;
        }
    }
}