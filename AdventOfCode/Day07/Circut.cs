using System.Collections.Generic;
using AdventOfCode.Day07.SignalProviders;

namespace AdventOfCode.Day07
{
    public class Circut
    {
        #region | Properties & fields

        public Dictionary<string, Wire> AllWires { get; }

        #endregion

        #region | ctors

        public Circut()
        {
            AllWires = new Dictionary<string, Wire>();
        }

        #endregion

        #region | Public interface

        public void Disassemble()
        {
            AllWires.Clear();
        }

        #endregion
    }
}