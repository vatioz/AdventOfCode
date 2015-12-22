using System.Diagnostics;

namespace AdventOfCode.Day07.SignalProviders
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class Wire : SignalProvider
    {
        #region | Properties & fields

        private readonly Circut _parentCircut;

        private readonly string _rawProvider;

        public string ID { get; }

        private SignalProvider Connection { get; set; }

        public string DebuggerDisplay => $"{ID}{_rawProvider}";

        #endregion

        #region | ctors

        public Wire(Circut circut, string wireId, string rawSignalProvider)
        {
            _parentCircut = circut;
            ID = wireId;
            _rawProvider = rawSignalProvider;
        }

        #endregion

        #region | Non-public members

        private void ResolveProvider()
        {
            Connection = ProviderParser.ParseProviderType(_rawProvider, _parentCircut);
        }

        #endregion

        #region | Overrides

        public override ushort GetValue()
        {
            if (!IsResolved) // cache the value
            {
                ResolveProvider();
                Value = Connection.GetValue();
                IsResolved = true;
            }
            return Value;
        }

        #endregion
    }
}