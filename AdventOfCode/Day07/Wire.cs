using System.Diagnostics;

namespace AdventOfCode.Day07
{
    [DebuggerDisplay("{ID}, {RawProvider}")]
    public class Wire : SignalProvider
    {
        public Wire(string wireId, string rawSignalProvider)
        {
            ID = wireId;
            RawProvider = rawSignalProvider;
        }
        public string ID { get; set; }

        public SignalProvider Connection { get; set; }

        public string RawProvider { get; set; }

        public override ushort GetValue()
        {
            if (!IsHot)
            {
                ResolveProvider();
                _value = Connection.GetValue();
                IsHot = true;
            }
            return _value;
        }

        private void ResolveProvider()
        {
            Connection = ProviderParser.ParseProviderType(RawProvider);
        }
    }
}